using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
//These extra libraries are needed to access the drywetmidi functions
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Tools;
//using Melanchall.DryWetMidi.Devices;
//using Melanchall.DryWetMidi.MusicTheory;
using Melanchall.DryWetMidi.Standards;
using Melanchall.DryWetMidi.Composing;
using System.Net.Http.Headers;
using Melanchall.DryWetMidi.Multimedia;
using System.Collections;
using System.Numerics;


//machine learning LSTM
using MathNet.Numerics.LinearAlgebra;
using System.Runtime.CompilerServices;
using System.ComponentModel;

//JSON stuff
using System.Text.Json;
using System.Threading;

namespace Orpheus_Analyser
{
    
    public class MidiAnalyser
    {
        public static int NumberOfFiles = GetNumberOfFiles();
        public static int ProgressTracker = 0;
        public static void Main(string[] args)
        {
            Console.WriteLine("Number of Files: " + GetNumberOfFiles());
            MidiAnalyser_LoadingPage LoadingPage = new MidiAnalyser_LoadingPage();

        }

        public void Loader() 
        {
             
             RunAsync();
        }

        public void RunAsync()
        {
            Task.Run(() => ProgressBarChanger());
        }

        public void ProgressBarChanger()
        {
            while (ProgressTracker != NumberOfFiles)
            {

                //LoadingPage.SetProgressBar(ProgressTracker, NumberOfFiles);

            }
        }

        public static int GetNumberOfFiles() 
        {
            int count = 0;
            string path = "/Users/seun_/source/repos/Orpheus/Orpheus_Analyser/bin/Debug/midi file list";
            foreach(string file in Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories)){ count++; }
            return count;
        }

        public static void LoadMidiFiles()
        {
            List<TheMidiFile> AllMidiFiles = new List<TheMidiFile>();
            string path = "/Users/seun_/source/repos/Orpheus/Orpheus_Analyser/bin/Debug/midi file list";
            int count = 0;
            foreach (string file in Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories))
            {
                if (count == 100)
                {
                    string json = JsonSerializer.Serialize(AllMidiFiles);
                    System.IO.File.AppendAllText("midiData.json", json);
                    AllMidiFiles.Clear();
                    count = 0;

                }

                if (Path.GetExtension(file) == ".mid")
                {
                    try
                    {
                        TheMidiFile tempMidiFile = new TheMidiFile(file);

                        tempMidiFile.SetBPM(Analysis.GetBPM(tempMidiFile.GetMidiFile()));
                        tempMidiFile.SetTimeSig(Analysis.GetTimeSig(tempMidiFile.GetMidiFile()));
                        tempMidiFile.SetTop10Notes(Analysis.GetTop10Notes(tempMidiFile.GetMidiFile()));
                        tempMidiFile.SetAllNotesUsed(Analysis.AllUsedNotes(tempMidiFile.GetMidiFile()));
                        tempMidiFile.SetPatterns(Analysis.PredictNoteDurations(tempMidiFile.GetMidiFile()));
                        
                        
                        AllMidiFiles.Add(tempMidiFile);
                    }
                    catch (Exception ex)
                    {
                        Analysis.errors.Add(ex.ToString(
                            ));
                    }
                }

                count++;
                ProgressTracker ++;
                
            }
        }

    }

    public class TheMidiFile
    {
        public string filename {get; set;}
        public MidiFile midiFile {get; set;}
        public string location { get; set; }
        public double bpm { get; set; }
        public string TimeSig { get; set; }
        public List<string> Top10Notes { get; set; }
        public List<string> AllNotesUsed { get; set; }
        public List<List<double>> patterns { get; set; }

        public TheMidiFile(string locationInput)
        {
            location = locationInput;
            midiFile = MidiFile.Read(locationInput);
            GetFileName();
        }

        
        public void SetBPM(double x) { bpm = x;  }
        public double GetBPM() { return bpm; }

        
        public void SetTimeSig(string x) { TimeSig = x; }
        public string GetTimeSig() { return TimeSig; }

        
        public void SetTop10Notes(List<string> x) { Top10Notes = x; }
        public List<string> GetTop10Notes() { return Top10Notes; }

        
        public void SetAllNotesUsed(List<string> x) { AllNotesUsed = x; }
        public List<string> GetAllNotesUsed() { return AllNotesUsed; }

        
        public void SetPatterns(List<List<double>> x) { patterns = x; }
        public List<List<double>> GetPatterns() { return patterns; }

        public void GetFileName()
        {
            filename = Path.GetFileName(location);
        }

        public MidiFile GetMidiFile() { return midiFile; }
    }

    public class Analysis
    {
        public static List<string> errors = new List<string>();
        public Analysis() { }

        public static double GetBPM(MidiFile midifile)
        {
            // Firstly a tempo map of the file is created, this gets all the time data from the midifile. 
            //calls the GetTempoMap method
            TempoMap fileTimedata = midifile.GetTempoMap();
            //Next I needed to create a TimeSpan variable with the MetricTimeSpan field. 
            //assuming the BPM for the whole piece stays the same for the whole piece, the time is set to 0.
            //the three parameters represent hours, minutes and seconds
            MetricTimeSpan timeSpan1 = new MetricTimeSpan(0, 0, 0);
            //next, the tempo is then found using the GetTempoAtTime getter. I use the timeSpan1 parameter to get the tempo at time 0
            //This returns the value in mircoseconds per quarter note which is not what I need at the moment
            Tempo tempo = fileTimedata.GetTempoAtTime(timeSpan1);
            //This converts the tempo into bpm which is used universaly so it is a good starting point for calculations. 
            //it puts it into a double variable
            double BPM = (int)tempo.BeatsPerMinute;
            //I then return the final value
            return BPM;

        }

        //This is the function I am making to retrieve the time signiture from a midi file
        public static string GetTimeSig(MidiFile midifile)
        {
            //Firstly i need to create a tempomap variable of the midi file
            TempoMap fileTImedata = midifile.GetTempoMap();
            //I will then create a new metric timespan variable.
            //this is basically a pointer in a midi file and it is set to 0 because that is the start
            MetricTimeSpan timeSpan2 = new MetricTimeSpan(0, 0, 0);
            //this lie will get the timesignature and the specified timespan which is 0
            TimeSignature TimeSig = fileTImedata.GetTimeSignatureAtTime(timeSpan2);

            //Now i convert my value to a string to return the value
            string TimeSigSTR = TimeSig.ToString();

            return TimeSigSTR;

        }

        public static List<string> ConvertMidiNoteToLetter(List<int> numbers)
        {
            List<string> result = new List<string>();
            foreach (int num in numbers)
            {
                // Calculate the octave by dividing the number by 12 and adding 1
                int octave = (num / 12) - 1;

                // Calculate the note by taking the number mod 12
                int note = num % 12;

                // Convert the note number to a note name (A, B, C, D, E, F, or G)
                string noteName;
                switch (note)
                {
                    case 0:
                        noteName = "C";
                        break;
                    case 1:
                        noteName = "C#";
                        break;
                    case 2:
                        noteName = "D";
                        break;
                    case 3:
                        noteName = "D#";
                        break;
                    case 4:
                        noteName = "E";
                        break;
                    case 5:
                        noteName = "F";
                        break;
                    case 6:
                        noteName = "F#";
                        break;
                    case 7:
                        noteName = "G";
                        break;
                    case 8:
                        noteName = "G#";
                        break;
                    case 9:
                        noteName = "A";
                        break;
                    case 10:
                        noteName = "A#";
                        break;
                    case 11:
                        noteName = "B";
                        break;
                    default:
                        noteName = "";
                        break;
                }

                // Output the MIDI note in the format "A4"
                //Console.WriteLine(noteName + octave);
                result.Add(noteName + octave);

            }
            return result;

        }

        public static List<int> GetAllNotes(MidiFile testFile)
        {
            //------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //This bit here gets all the Note data for the whole midi file
            //I first need to create a few variables
            //The first variable creates a Collection based list called IEnumerable of TrackChunk Objects, the track chunks are the individual channels of midi note data
            IEnumerable<TrackChunk> chunks = testFile.GetTrackChunks();
            //I then need to create a collection of Note objects to store the collection of notes from the collection of track chunks
            ICollection<Note> notes = new List<Note>();
            //I then need to create a final List to easily store my results in a readable way which is why it is a List. 
            //the first one stores the notes as letters
            List<List<Note>> TrackNoteDataLT = new List<List<Note>>();
            //this one will store a list of numbers
            List<int> TrackNoteDataNM = new List<int>(1);
            //This array is to take note of every note that is used. It goes from 0 - 127 because that is the range of notes in midi
            //using 128 so it includes 0 and 127
            // I am using an array instead of a list because i want this set of spaces to stay constant
            int[] NMNotes = new int[128];
            //The foreach loop is to go through each chunk in the chunks of data to collect all the Note data
            foreach (var chunk in chunks)
            {
                //I use the GetNotes method to get the notes and put it into my notes ICollection
                notes = chunk.GetNotes();
                //I then convert the notes I got as a List and place it into a temporary variable
                var temp = notes.ToList();
                //I then add that temp variable to my final list of tracks
                TrackNoteDataLT.Add(temp);
            }//end of loop
             //After this, I get List of Notes in every track, therefore getting every note used in the midi file 

            //this next for loop will get all the numbers for the notes and put it into a int list
            for (int i = 0; i < TrackNoteDataLT.Count; i++)
            {
                for (int j = 0; j < TrackNoteDataLT[i].Count; j++)
                {
                    TrackNoteDataNM.Add(TrackNoteDataLT[i][j].NoteNumber);
                }
            }

            //What I did here was to make a note of the most frequently used notes as music may have other factors which could affect the key detection of a song.
            //Using the most frequently used notes allows my to easily identify key patterns and scales
            //So this foreach loop basically goes through every used note and takes a tally.
            foreach (int x in TrackNoteDataNM)
            {
                NMNotes[x]++;
            }



            return NMNotes.ToList();
        }

        public static List<string> AllUsedNotes(MidiFile midifile)
        {
            var NMNotes = GetAllNotes(midifile);
            //creates a list of all the used notes
            List<int> allUsedNotes = new List<int>();
            for (int i = 0; i < NMNotes.Count; i++)
            {
                if (NMNotes[i] != 0) { allUsedNotes.Add(i); }
            }
            //Now I am going to convert that used notes in list into a list of strings with the note letters instead of the midi numbers

            List<string> allUsedNotesSTR = ConvertMidiNoteToLetter(allUsedNotes);

            return allUsedNotesSTR;

        }

        public static List<string> GetTop10Notes(MidiFile testFile)
        {
            List<int> NMNotes = GetAllNotes(testFile);

            //Using the same function i made, i will then find the top 10 most used notes and put then into int and string arrays

            //finds the highest value to start of in finding the top 10 most used notes. The number is the number of times the note is pressed and the index is what note is pressed
            List<int> Top10Notes = new List<int>();
            List<string> Top10NotesSTR = new List<string>();

            // create a new list to hold the 10 highest values
            List<int> highestValues = new List<int>();

            // loop through the original list and find the 10 highest values
            for (int i = 0; i < NMNotes.Count; i++)
            {
                // check if the current value is one of the 10 highest
                if (highestValues.Count < 10 || NMNotes[i] > highestValues.Min())
                {
                    // add the current value to the list of highest values
                    highestValues.Add(NMNotes[i]);

                    // add the index of the current value to the Top10Notes list
                    Top10Notes.Add(i);

                    // if there are more than 10 values in the list of highest values, remove the lowest one
                    // this is a failsafe just to make sure there are 10 notes when finished
                    if (highestValues.Count > 10)
                    {
                        int minIndex = highestValues.IndexOf(highestValues.Min());
                        highestValues.RemoveAt(minIndex);
                        Top10Notes.RemoveAt(minIndex);
                    }
                }
            }

            //Now we have a int list with teh top ten notes, we need to convert it to its string value to make it more user friendly
            //we can use the function i made to do this

            Top10NotesSTR = ConvertMidiNoteToLetter(Top10Notes);

            //I would like to export the Top10Notes as a string to make it look nicer.

            return Top10NotesSTR;


        }

        public static double[] predictDurations(List<double> durations)
        {

            List<double> predictions = new List<double>();
            // Initialize the smoothing factor and initial prediction
            double alpha = 0.5;
            double y_hat_0 = 0;

            // Predict the next 16 doubles using exponential smoothing
            for (int t = 0; t < 16; t++)
            {
                // Get the observed value for the current time period
                double y_t = (t < durations.Count) ? durations[t] : 0;

                // Calculate the prediction for the next time period
                double y_hat_t = alpha * y_t + (1 - alpha) * y_hat_0;

                // Update the initial prediction for the next iteration
                y_hat_0 = y_hat_t;

                // Add the predicted value to the list
                decimal temp = (decimal)y_hat_t;
                double finalValue = (double)decimal.Round(temp, 2);
                predictions.Add(finalValue);
            }

            return predictions.ToArray();
        }

        public static double DeltaToDecimal(long deltatime, int bpm)
        {
            //I am using decimal variables to get the full values so the fractions can be calculated more easily
            decimal sixty = 60;
            decimal QuarterNoteLength = (decimal)bpm / sixty;

            decimal secondsFromMS = decimal.Round((decimal)deltatime / 1000, 10);


            double deciamlFormat = (double)QuarterNoteLength * (double)secondsFromMS;

            return deciamlFormat;

        }

        public static List<List<double>> CalculateNoteDurations(MidiFile midiFile)
        {
            // Create a 2D array to store the duration of each note in each chunk
            var durations = new List<List<double>>();

            // Iterate over each chunk in the MIDI file
            foreach (var chunk in midiFile.GetTrackChunks())
            {
                // Calculate the durations of the notes in this chunk
                var chunkDurations = CalculateChunkNoteDurations(chunk, midiFile);

                // Add the list of durations for this chunk to the 2D array
                durations.Add(chunkDurations);
            }

            return durations;
        }

        public static List<double> CalculateChunkNoteDurations(TrackChunk chunk, MidiFile midifile)
        {
            // Create a list to store the durations of the notes in this chunk
            var chunkDurations = new List<double>();

            // Use a dictionary to store the NoteOnEvent for each note number
            var noteOnEvents = new Dictionary<int, NoteOnEvent>();

            // Get a list of all the timed events in the chunk
            var timedEvents = chunk.GetTimedEvents().ToList();

            var tempomap = midifile.GetTempoMap();

            var time = new MetricTimeSpan(0, 0, 0);


            var tempo = tempomap.GetTempoAtTime(time);

            int bpm = (int)tempo.BeatsPerMinute;

            NoteOnEvent NoteOn = new NoteOnEvent();
            NoteOffEvent NoteOff = new NoteOffEvent();

            // Iterate through the timed events in the chunk
            foreach (var timedEvent in chunk.Events)
            {
                try
                {

                    // Check if the timed event is a NoteOnEvent
                    if (timedEvent.GetType().Equals(NoteOn.GetType()))
                    {
                        // Store the NoteOnEvent in the dictionary
                        var noteOnEvent = (NoteOnEvent)timedEvent;
                        noteOnEvents[noteOnEvent.NoteNumber] = noteOnEvent;
                    }
                    // Check if the timed event is a NoteOffEvent
                    else if (timedEvent.GetType().Equals(NoteOff.GetType()))
                    {
                        // Retrieve the corresponding NoteOnEvent from the dictionary
                        var noteOffEvent = (NoteOffEvent)timedEvent;
                        var noteOnEvent = noteOnEvents[noteOffEvent.NoteNumber];
                        long duration = 0;

                        // Calculate the duration of the note by subtracting the delta time of the NoteOnEvent from the delta time of the NoteOffEvent
                        if (noteOffEvent.DeltaTime > noteOnEvent.DeltaTime)
                        {
                            duration = noteOffEvent.DeltaTime - noteOnEvent.DeltaTime;
                        }
                        else if (noteOnEvent.DeltaTime > noteOffEvent.DeltaTime)
                        {
                            duration = noteOnEvent.DeltaTime - noteOffEvent.DeltaTime;
                        }
                        else if (noteOnEvent.DeltaTime == noteOffEvent.DeltaTime)
                        {
                            duration = noteOnEvent.DeltaTime;
                        }

                        //duration = RoundDeltaDuration(duration);

                        chunkDurations.Add(DeltaToDecimal(duration, bpm));


                    }
                }
                catch (Exception e)
                {
                    Analysis.errors.Add(e.ToString());
                }
            }
            return chunkDurations;
        }

        public static List<List<double>> PredictNoteDurations(MidiFile midifile)
        {
            var durations = CalculateNoteDurations(midifile);
            List<List<double>> predictedDurations = new List<List<double>>();


            foreach (var duration in durations)
            {
                if (duration.Count > 10)
                {
                    var newDurations = predictDurations(duration);
                    predictedDurations.Add(newDurations.ToList());
                }
            }

            return predictedDurations;

        }



    }



}
