using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orpheus_Analyser;
using System.Text.Json;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Runtime.InteropServices;

namespace Orpheus_MidiFileMaker
{
    public class MidiMaker
    {
        //major scales parallel array
        string[][] notesMajScales = {
             new string[] { "C", "D", "E", "F", "G", "A", "B" },
             new string[] { "C#", "D#", "F", "F#", "G#", "A#", "C" },
             new string[] { "D", "E", "F#", "G", "A", "B", "C#" },
             new string[] { "D#", "F", "G", "G#", "A#", "C", "D" },
             new string[] { "E", "F#", "G#", "A", "B", "C#", "D#" },
             new string[] { "F", "G", "A", "A#", "C", "D", "E" },
             new string[] { "F#", "G#", "A#", "B", "C#", "D#", "F" },
             new string[] { "G", "A", "B", "C", "D", "E", "F#" },
             new string[] { "G#", "A#", "C", "C#", "D#", "F", "G" },
             new string[] { "A", "B", "C#", "D", "E", "F#", "G#" },
             new string[] { "A#", "C", "D", "D#", "F", "G", "A" },
             new string[] { "B", "C#", "D#", "E", "F#", "G#", "A#" }
        };

        string[] notesMaj = { "C", "C#", "D", "D#", "E", "F", "G", "G#", "A", "A#", "B" };

        //minor scales parallel array
        string[][] notesMinScales = {
            new string[] { "A", "B", "C", "D", "E", "F", "G" },
            new string[] { "A#", "C", "C#", "D#", "F", "F#", "A" },
            new string[] { "B", "C#", "D", "E", "F#", "G", "A#" },
            new string[] { "C", "D", "D#", "F", "G", "G#", "B" },
            new string[] { "C#", "D#", "E", "F#", "G#", "A", "C" },
            new string[] { "D", "E", "F", "G", "A", "A#", "C#" },
            new string[] { "D#", "F", "F#", "G#", "A#", "B", "D" },
            new string[] { "E", "F#", "G", "A", "B", "C", "D#" },
            new string[] { "F", "G", "G#", "A#", "C", "C#", "E" },
            new string[] { "F#", "G#", "A", "B", "C#", "D", "F" },
            new string[] { "G", "A", "A#", "C", "D", "D#", "F#" },
            new string[] { "G#", "A#", "B", "C#", "D#", "E", "G" }
        };

        //chords parallel
        string[] CommonChordNames = {"major", "minor", "diminshed", "augmented",
            "major 7th", "Dominant 7th", "minor 7th", "half-diminshed 7th", "fully-diminshed 7th"};
        string[][] CommonChords =
        {
                new string[] {"1", "3", "5"},
                new string[] {"1", "b3", "5"},
                new string[] {"1", "b3", "b5"},
                new string[] {"1", "3", "#5"},
                new string[] {"1", "3", "5", "7"},
                new string[] {"1", "3", "5", "b7"},
                new string[] {"1", "b3", "5", "b7"},
                new string[] {"1", "b3", "b5", "b7"},
                new string[] {"1", "b3", "b5", "6"} 
        };

        //chord patterns, 4 chords
        string[] commonChordSequences = new string[]
{
    "I - IV - V - IV",
    "I - V - vi - IV",
    "vi - IV - I - V",
    "IV - I - V - vi",
    "I - IV - V - vi",
    "ii - V - I - IV",
    "I - V - vi - iii",
    "IV - I - vi - V",
    "vi - iii - IV - I",
    "ii - V - IV - I",
    "I - vi - IV - iii",
    "IV - ii - V - I",
    "I - V - IV - iii",
    "vi - IV - ii - V",
    "iii - IV - I - V",
    "IV - I - vi - iii",
    "I - vi - iii - IV",
    "ii - V - IV - vi",
    "IV - ii - I - V",
    "I - IV - iii - V",
    "vi - IV - I - iii",
    "iii - ii - V - I",
    "IV - I - iii - vi",
    "I - iii - vi - IV",
    "ii - V - vi - III",
    "I - IV - ii - V",
    "vi - IV - iii - I",
    "iii - ii - IV - I"
};





        string[] notesMin = { "A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#"};

        static void Main(string[] args)
        {
            string[] excludedNotes = new string[0];
            InputData data = new InputData("539472", excludedNotes, 120, "4/4", 5, "C", "maj");
            Generate(data);
            
        }

        public static void Generate(InputData UserData) 
        {
            string path = "C:/Users/seun_/source/repos/Orpheus/Orpheus_Analyser/bin/Debug/MidiDataTest.json";
            int bpm = UserData.GetBPM();
            string timesig = UserData.GetTimeSig();

            //collects all the midifile objects found with specified data
            List<TheMidiFile> CollectedFiles = GetMidiFiles(path, bpm, timesig);

            //Chooses a number for how I will iterate through the pattern data
            int PatternChooser = UserData.GetPatternSeedInt();

            //Gets a list of excluded notes in their letter format
            string[] notesExcludedString = UserData.GetExcludedNotes();

            //randomness + keysig
            //we need top ten notes from all midi files
            List<string> allTop10Notes= new List<string>();
            foreach(var midifile in CollectedFiles) { allTop10Notes.Concat(midifile.GetTop10Notes()).ToList(); }
            //Get rid of excluded notes
            allTop10Notes.Except(notesExcludedString).ToList();
            //filter notes to get the ones in the relevant key signiture, need a function for this
            MidiMaker midimaker = new MidiMaker();
            allTop10Notes = midimaker.FilterKeySig(allTop10Notes, UserData.GetKeySig(), UserData.GetMajMin());
            //Now to sort the list so its in order from A to G
            allTop10Notes.Sort();
            //now to deal with all the chords



            
        }

        public List<string> FilterKeySig(List<string> notes, string keysig, string majmin) 
        {
            int KeySigIndex = 0;
            //filters the list of notes by the specified key signiture
            switch (majmin) 
            {
                case "maj":
                    KeySigIndex = Array.IndexOf(notesMaj, keysig);
                    notes = notes.Where(x => notesMajScales[KeySigIndex].Contains(x)).ToList();
                    break;
                case "min":
                    KeySigIndex = Array.IndexOf(notesMin, keysig);
                    notes = notes.Where(x => notesMinScales[KeySigIndex].Contains(x)).ToList();
                    break;
            }

            return notes;
        }

        public static int[] ExcludedNoteLettersToNumbers(string[] x) 
        {
            return x.Select(z => Analysis.ConvertLetterToMidiNote(z)).ToArray();
        }

        public static List<TheMidiFile> GetMidiFiles(string path, int bpm, string timesig) 
        {

            //Search JSON file for relevant information
            //BPM, TimeSig
            //Take that data as TheMidiFile Objects
            //Put it in a new list
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true
                
                
            };

            string jsonContents = File.ReadAllText(path);
            List<TheMidiFile> AllFiles = JsonSerializer.Deserialize<List<TheMidiFile>>(jsonContents, options);
            var FinalList = AllFiles.Where(x => (int)x.GetBPM() == bpm && x.GetTimeSig() == timesig).ToList();
            return FinalList;
        }

        public static int PatternSeedGen(int z)
        {
            int final = 0;

            int[] NumArr = z.ToString().Select(x => x - 48).ToArray();

            //Multiply every two digits and put into three seperate number variables
            int num1 = NumArr[0] * NumArr[1];
            int num2 = NumArr[2] * NumArr[3];
            int num3 = NumArr[4] * NumArr[5];

            //Add the first and last numbers
            //Doing this by puting them in an array first
            int[] Num1Arr = num1.ToString().Select(x => x - 48).ToArray();
            int[] Num3Arr = num3.ToString().Select(x => x - 48).ToArray();
            //Then adding them together
            num1 = Num1Arr.Sum();
            num3 = Num3Arr.Sum();

            //Make sure i have no 0s or 1s
            if (num1 == 0 || num1 == 1) { num1 = 2; }
            if (num2 == 0 || num2 == 1) { num2 = 2; }
            if (num3 == 0 || num3 == 1) { num3 = 2; }

            //Find largest 2 numbers    
            int max1 = Math.Max(num1, Math.Max(num2, num3));
            int max2 = 0;
            int BiggerNumber = 0;

            if (max1 == num1)
            {
                max2 = Math.Max(num2, num3);
                BiggerNumber = max1 * max2;
                if (max2 == num2) { final = BiggerNumber / num3; }
                else if (max2 == num3) { final = BiggerNumber / num2; }


            }
            else if (max1 == num2)
            {
                max2 = Math.Max(num1, num3);
                BiggerNumber = max1 * max2;
                if (max2 == num1) { final = BiggerNumber / num3; }
                else if (max2 == num3) { final = BiggerNumber / num1; }
            }
            else if (max1 == num3)
            {
                max2 = Math.Max(num2, num1);
                BiggerNumber = max1 * max2;
                if (max2 == num1) { final = BiggerNumber / num2; }
                else if (max2 == num2) { final = BiggerNumber / num1; }
            }

            return final;


        }



    }

    public class InputData
    {
        private string PatternSeed;
        private string[] ExcludedNotes;
        private int bpm;
        private string TimeSig;
        private int Randomness;
        private string KeySig;
        private string MajMin;

        public InputData(string patternSeed, string[] excludedNotes, int bpm, string timeSig, int randomness, string keySig, string majMin)
        {
            PatternSeed = patternSeed;
            ExcludedNotes = excludedNotes;
            this.bpm = bpm;
            TimeSig = timeSig;
            Randomness = randomness;
            KeySig = keySig;
            MajMin = majMin;

        }

        public int GetBPM() 
        {
            return bpm;       
        }

        public string GetTimeSig() 
        {
            return TimeSig;
        }

        public int GetPatternSeedInt() 
        { 
            int x = Convert.ToInt32(PatternSeed);
            return x; 
        }

        public string[] GetExcludedNotes() 
        {
            return ExcludedNotes;
        }

        public string GetKeySig() 
        {
            return KeySig;
        }

        public string GetMajMin() { return MajMin; }
    }
}
