using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Tools;
using Orpheus_Analyser;
using Orpheus_MidiFileMaker;

namespace Orpheus_MidiFileMaker
{
    //this class is to hold the start and endvalue of two chords into one object to allow to check through my list of sequences and compare with my rules
    class ChordStep
    {
        private string startChord;
        private string endChord;

        public ChordStep(string start, string end) 
        {
            startChord = start;
            endChord= end;

        }

        public bool Equals(ChordStep step) 
        {
            if(step.GetStartingChord() == startChord) 
            {
                if(step.GetEndChord() == endChord) 
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public string GetStartingChord() 
        {
            return startChord;
        }

        public string GetEndChord() 
        { 
            return endChord; 
        }

    }
    internal class MyChordProcessses
    {
        //my rules dictionary is going to be made up of a chord step object which has a attributres start and end chords
        public static  Dictionary<ChordStep, string> Rules = new Dictionary<ChordStep, string>();
        public static Dictionary<string, string> MajorChords;
        public static Dictionary<string, string> MinorChords;
        //list to store previous instructions temporarily
        public static List<string> PrevInstructions= new List<string>();

        //dimished chord identifier
        public static bool diminishedCHRD = false;

        //sets up the rules to be used to link chords together
        public static void SetUpRules() 
        {
            ChordStep chordstep;


            //augmented chord rules
            chordstep = new ChordStep("I", "IV");
            Rules.Add(chordstep, "aug_add_first");
            chordstep = new ChordStep("I", "VI");
            Rules.Add(chordstep, "aug_add_first");
            chordstep = new ChordStep("V", "I");
            Rules.Add(chordstep, "aug_add_first");

            //diminshed chord rules
            chordstep = new ChordStep("V", "VI");
            Rules.Add(chordstep, "dim_replace_first");
            chordstep = new ChordStep("V", "IV");
            Rules.Add(chordstep, "dim_replace_first");

            //major 7 rules
            chordstep = new ChordStep("II", "V");
            Rules.Add(chordstep, "major7_replace_both");
            chordstep = new ChordStep("III", "IV");
            Rules.Add(chordstep, "major7_replace_both");
            chordstep = new ChordStep("IV", "II");
            Rules.Add(chordstep, "major7_replace_both");
            chordstep = new ChordStep("II", "I");
            Rules.Add(chordstep, "major7_replace_both");

            //MajorChord Rules
            MajorChords = new Dictionary<string, string>()
            {
                {"I", "maj"},
                {"II", "min"},
                {"III", "min"},
                {"IV", "maj"},
                {"V", "maj"},
                {"VI", "min"},
                {"VII", "min"}
            };

            //MinorChord Rules
            MinorChords = new Dictionary<string, string>()
            {
                {"I", "min"},
                {"II", "min"},
                {"III", "maj"},
                {"IV", "min"},
                {"V", "min"},
                {"VI", "maj"},
                {"VII", "maj"}

            };
        }
        
        public MyChordProcessses() { }

        //public static List<List<List<string>>> SequenceBuilder() 
        //{
            
        //}
        
        //Ths function is going to be used to build a bar of chords, the number of chords allowed in a bar depends on the time signiture and other parameters determine which chords are going to be played
        public static List<List<string>> BarBuilder(string timesig, string majmin, List<string> ChoppedSequence, string keysig) 
        {
            //the final bar
            List<List<string>> bar = new List<List<string>>();
            //this creates a new chord step function. The ChoppedSequence parameter should only have 2 chords in it
             ChordStep CurrentChordStep = new ChordStep(ChoppedSequence[0], ChoppedSequence[1]);

            //create the new array to determine what chords are going to be used
            List<string> chordsToUse = new List<string>();
            //add the first chord and their chord type as a defualt
            chordsToUse.Add(ChoppedSequence.First());

            //use a switch to determine which set of chord rules to use to add my chords for the defualt
            switch (majmin) 
            {
                //add defualt chord type from dictionary. takes the minor set or the major set depending on the specified parameter
                case "min":   
                    chordsToUse.Add(MinorChords[chordsToUse[0]]);
                    break; 
                case "maj":
                    chordsToUse.Add(MajorChords[chordsToUse[0]]);
                    break; 
            }

            //Determine max number of chords
            var maxNumberOfChordsSTR = timesig.Split('/');
            int maxNumberOfChords = Convert.ToInt32(maxNumberOfChordsSTR[0]);

            //get all the instructions from the dictionary that match a certain chordstep
            //first make a new string list called instructions
            List<string> instructions = new List<string>();
            //select the chord step keys that match the current chordstep
            //to explain it, where a key is equal to a certain key, it selects the value from that key
            instructions = Rules.Where(x => x.Key.Equals(CurrentChordStep)).Select(x => x.Value).ToList();
            //goes through the instructions and applys it through a function
            foreach(var instruction in instructions) 
            {
                chordsToUse = InstructionReader(instruction, chordsToUse);
            }

            var FinalChord = ChordBuilder(keysig, majmin, chordsToUse[0], chordsToUse[1]);
            bar.Add(FinalChord);
            return bar;




        }

        public static List<string> InstructionReader(string instruction, List<string> ChordsToUse)
        {
            //splits the instruction string into a list of each instruction part
            List<string> instructionSplit = instruction.Split('_').ToList();

            //checks the previous instruction list for past instructions that require both items to be changed
            if(PrevInstructions.Count > 0) 
            {
                //goes through each prev instruction in the list
                foreach(var x in PrevInstructions) 
                {
                    //splits up the previous instruction
                    List<string> tempSplit = instruction.Split('_').ToList();
                    if ((tempSplit[2] == "both") && (tempSplit[1] == "replace") && !(tempSplit[0] == "dim")) 
                    {
                        //this will only get to this point if the previous instruction had an instruction of replace and an identifier of both
                        //now adds the specified chord type to that chord
                        ChordsToUse[1] = tempSplit[0];
                    }
                    else 
                    {
                        diminishedCHRD = true;
                    }

                    

                    PrevInstructions.Remove(x);
                }

            }

            //switch statement for the middle part of the instruction which is either replace or add
            switch (instructionSplit[1])
            {
                case "add":
                    //adds a new chord to the end of the list with the same symbol but a specified type

                    //adds the first note to the list
                    ChordsToUse.Add(ChordsToUse.First());
                    //now adds the chord type
                    ChordsToUse.Add(instructionSplit[0]);

                    //now checks to see whether to change the first, second or both chords

                    if (instructionSplit[2] == "both")
                    {
                        //adds the previous instruction to the list of previous instructions
                        PrevInstructions.Add(instruction);

                    }

                    break;
                case "replace":
                    //replaces just the first chord type
                    ChordsToUse[1] = instructionSplit[0];

                    //now checks again to change the first, second or both chords
                    if (instructionSplit[2] == "both") 
                    {
                        //adds the instruction to the previous instruction list
                        PrevInstructions.Add(instruction);

                    }
                    break;




            }
            return ChordsToUse;
        }
        
        public static List<string> ChordBuilderTRY1(string keysig, string majmin, string chordSymbol, string chordType) 
        {
            MidiMaker midiMaker = new MidiMaker();
            var chord = new List<string>();
            int scalePosition = 0;
            int KeySigScaleIndex = 0;
            //switch statement to choose between major or minor scales
            switch (majmin) 
            {
                case "maj":
                    //gets the root note position of the chord symbol and the scale position
                    scalePosition = ChordSymbolToNumber(chordSymbol);
                    //gets the index of the key signiture to use on the scales
                    //find the original C signiture scale to find the new one
                    int KeySigScaleOriginalIndex = Array.IndexOf(midiMaker.notesMaj, keysig.ToUpper());
                    //put the orignal index, with the scale position to find the key sig scale index of the new scale
                    KeySigScaleIndex = Array.IndexOf(midiMaker.notesMaj, midiMaker.notesMajScales[KeySigScaleOriginalIndex][scalePosition]);
                    //KeySigScaleIndex = midiMaker.notesMaj[scalePosition];

                    //use chordtype to determine which chord is going to be played. 
                    //add the chordtype list, adds the common chords array based on the chord type
                    string[] chordBuildMaj = midiMaker.CommonChords[Array.IndexOf(midiMaker.CommonChordNames, chordType)]; 
                    //iterate through the array and changed the chordbuild notes to acutal notes
                    //options: 1, 3, 5, 6, 7, b3, b5, #5, b7
                    //use notesMaj as general note chooser from 0 to 10
                    foreach(string notenum in chordBuildMaj) 
                    {
                        chord.Add(NoteNumberToNoteLetter(notenum, KeySigScaleIndex, majmin));
                    }


                    break;
                case "min":
                    scalePosition = ChordSymbolToNumber(chordSymbol);
                    int KeySigScaleOriginalIndexMin = Array.IndexOf(midiMaker.notesMin, keysig.ToUpper());
                    KeySigScaleIndex = Array.IndexOf(midiMaker.notesMin, midiMaker.notesMinScales[KeySigScaleOriginalIndexMin][scalePosition]);
                    string[] chordBuildMin = midiMaker.CommonChords[Array.IndexOf(midiMaker.CommonChordNames, chordType)];
                    foreach (string notenum in chordBuildMin)
                    {
                        chord.Add(NoteNumberToNoteLetter(notenum, KeySigScaleIndex, majmin));
                    }


                    break;
                default: 
                    break;

            }
            return chord;

        }

        //function to determine the root note from chord symbols

        public static int ChordSymbolToNumber(string s) 
        {
            int numberEquivalent = 0;

            //converts to upper, so everything is in the same format
            s = s.ToUpper();
            switch (s)
            {
                case "I":
                    numberEquivalent = 1;
                    break;
                case "II":
                    numberEquivalent = 2;
                    break;
                case "III":
                    numberEquivalent = 3;
                    break;
                case "IV":
                    numberEquivalent = 4;
                    break;
                case "V":
                    numberEquivalent = 5;
                    break;
                case "VI":
                    numberEquivalent = 6;
                    break;
                case "VII":
                    numberEquivalent = 7;
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }

            return numberEquivalent - 1;
        }

        //i am using the parameters keysig for the key signiture. Whether the key signiture is major or minor doesn't matter since I am building cores from the base scale. 
        //The chord symbol is the roman numeral version of the chord and the chord type is the type of chord created. This will determine whether it is major or minor or others
        public static List<string> ChordBuilder(string keysig, string majmin, string chordSymbol, string chordType) 
        {
            //Making a new object of midi maker to take a look at the data i made in there
            MidiMaker midimaker = new MidiMaker();
            List<string> chord = new List<string>();

            //get the scale position of the chord from the chord symbol
            int scalePos = ChordSymbolToNumber(chordSymbol);

            //gets the original scale list, this depends on major or minor
            int KeySigScaleIndex = 0;
            int KeySigScaleOriginalIndex = 0;
            switch (majmin) 
            { 
                case "maj":
                    //takes scale of the key signiture
                    KeySigScaleOriginalIndex = Array.IndexOf(midimaker.notesMaj, keysig.ToUpper());
                    //puts the new scale position in a new variable in the index notesMaj. 
                    KeySigScaleIndex = Array.IndexOf(midimaker.notesMaj, midimaker.notesMajScales[KeySigScaleOriginalIndex][scalePos]); 
                    break;
                case "min":
                    //takes the scake of the keysigniture in minor
                    KeySigScaleOriginalIndex = Array.IndexOf(midimaker.notesMin, keysig.ToUpper());
                    //puts the new scale position in a new variable in the index notesMaj to keep all the scales the same.
                    //looks through the minor scale and finds the same value in the major one
                    KeySigScaleIndex = Array.IndexOf(midimaker.notesMaj, midimaker.notesMinScales[KeySigScaleOriginalIndex][scalePos]);
                    break;
            }

            //use chordtype to determine which chord is going to be played. 
            //add the chordtype list, adds the common chords array based on the chord type
            string[] chordBuildMaj = midimaker.CommonChords[Array.IndexOf(midimaker.CommonChordNames, chordType)];

            //iterate through the array and changed the chordbuild notes to acutal notes
            //options: 1, 3, 5, 6, 7, b3, b5, #5, b7
            //use notesMaj as general note chooser from 0 to 10
            foreach (string notenum in chordBuildMaj)
            {
                chord.Add(NumberToLetter(notenum, KeySigScaleIndex));
            }

            return chord;


        }

        public static string NumberToLetter(string notenum, int keySigScaleIndex) 
        {
            MidiMaker midiMaker= new MidiMaker();
            string chosenNoteSTR = "";

            switch (notenum)
            {
                case "1":

                    chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][0];
                    break;
                case "3":
                    chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][2];
                    break;
                case "5":
                    chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][4];
                    break;
                case "6":
                    chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][5];
                    break;
                case "7":
                    chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][6];
                    break;
                //the flats and sharps require different functions to get the note below the chosen note because they are flats
                case "b3":
                    chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][2];
                    //finds the index of the note in my note array 
                    int tempNoteIndex = Array.IndexOf(midiMaker.notesMaj, chosenNoteSTR);
                    //since it is a flat, i want to choose the note just below it, but i need to account for the fact that the note could be at index 0
                    if (tempNoteIndex == 0) { tempNoteIndex = 10; } else { tempNoteIndex--; }
                    //now takes the chosen note and puts it in the chosen note variable
                    chosenNoteSTR = midiMaker.notesMaj[tempNoteIndex];
                    break;
                case "b5":
                    chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][4];
                    //finds the index of the note in my note array 
                    int tempNoteIndex1 = Array.IndexOf(midiMaker.notesMaj, chosenNoteSTR);
                    //since it is a flat, i want to choose the note just below it, but i need to account for the fact that the note could be at index 0
                    if (tempNoteIndex1 == 0) { tempNoteIndex1 = 10; } else { tempNoteIndex1--; }
                    //now takes the chosen note and puts it in the chosen note variable
                    chosenNoteSTR = midiMaker.notesMaj[tempNoteIndex1];
                    break;
                case "#5":
                    chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][4];
                    //finds the index of the note in my note array 
                    int tempNoteIndex2 = Array.IndexOf(midiMaker.notesMaj, chosenNoteSTR);
                    //since it is a flat, i want to choose the note just below it, but i need to account for the fact that the note could be at index 0
                    if (tempNoteIndex2 == 10) { tempNoteIndex2 = 0; } else { tempNoteIndex2++; }
                    //now takes the chosen note and puts it in the chosen note variable
                    chosenNoteSTR = midiMaker.notesMaj[tempNoteIndex2];
                    break;
                case "b7":
                    chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][6];
                    //finds the index of the note in my note array 
                    int tempNoteIndex3 = Array.IndexOf(midiMaker.notesMaj, chosenNoteSTR);
                    //since it is a flat, i want to choose the note just below it, but i need to account for the fact that the note could be at index 0
                    if (tempNoteIndex3 == 0) { tempNoteIndex3 = 10; } else { tempNoteIndex3--; }
                    //now takes the chosen note and puts it in the chosen note variable
                    chosenNoteSTR = midiMaker.notesMaj[tempNoteIndex3];
                    break;
                default:
                    break;
            }

            return chosenNoteSTR;
        }

        //try 1 ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public static string NoteNumberToNoteLetter(string buildnoteNum, int keySigScaleIndex, string majmin) 
        {
            MidiMaker midiMaker = new MidiMaker();
            //this is going to hold the chosen note index number
            int chosenNoteIndex;
            //this is going to hold the chosen note letter
            string chosenNoteSTR = "";


            //uses the buildnote number of 1, 3, 5, 6, 7 or the b3, b5, b7, #5 to first get the corresponding note in that scale
            //uses the keySigScaleIndex to choose the right scale, then chooses the note based on the buildnoteNum - 1 because it is an array
            //but first checks if it is major or minor, it will do the same thing for both, its just going to look througha  completely different array
            if (majmin == "maj")
            {
                switch (buildnoteNum)
                {
                    case "1":

                        chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][0];

                        break;
                    case "3":
                        chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][2];
                        break;
                    case "5":
                        chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][4];
                        break;
                    case "6":
                        chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][5];
                        break;
                    case "7":
                        chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][6];
                        break;
                    //the flats and sharps require different functions to get the note below the chosen note because they are flats
                    case "b3":
                        chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][2];
                        //finds the index of the note in my note array 
                        int tempNoteIndex = Array.IndexOf(midiMaker.notesMaj, chosenNoteSTR);
                        //since it is a flat, i want to choose the note just below it, but i need to account for the fact that the note could be at index 0
                        if (tempNoteIndex == 0) { tempNoteIndex = 10; } else { tempNoteIndex--; }
                        //now takes the chosen note and puts it in the chosen note variable
                        chosenNoteSTR = midiMaker.notesMaj[tempNoteIndex];
                        break;
                    case "b5":
                        chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][4];
                        //finds the index of the note in my note array 
                        int tempNoteIndex1 = Array.IndexOf(midiMaker.notesMaj, chosenNoteSTR);
                        //since it is a flat, i want to choose the note just below it, but i need to account for the fact that the note could be at index 0
                        if (tempNoteIndex1 == 0) { tempNoteIndex1 = 10; } else { tempNoteIndex1--; }
                        //now takes the chosen note and puts it in the chosen note variable
                        chosenNoteSTR = midiMaker.notesMaj[tempNoteIndex1];
                        break;
                    case "#5":
                        chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][4];
                        //finds the index of the note in my note array 
                        int tempNoteIndex2 = Array.IndexOf(midiMaker.notesMaj, chosenNoteSTR);
                        //since it is a flat, i want to choose the note just below it, but i need to account for the fact that the note could be at index 0
                        if (tempNoteIndex2 == 10) { tempNoteIndex2 = 0; } else { tempNoteIndex2--; }
                        //now takes the chosen note and puts it in the chosen note variable
                        chosenNoteSTR = midiMaker.notesMaj[tempNoteIndex2];
                        break;
                    case "b7":
                        chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][6];
                        //finds the index of the note in my note array 
                        int tempNoteIndex3 = Array.IndexOf(midiMaker.notesMaj, chosenNoteSTR);
                        //since it is a flat, i want to choose the note just below it, but i need to account for the fact that the note could be at index 0
                        if (tempNoteIndex3 == 0) { tempNoteIndex3 = 10; } else { tempNoteIndex3--; }
                        //now takes the chosen note and puts it in the chosen note variable
                        chosenNoteSTR = midiMaker.notesMaj[tempNoteIndex3];
                        break;
                    default:
                        break;
                }
            }else if(majmin == "min") 
            {
                switch (buildnoteNum)
                {
                    case "1":

                        chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][0];
                        break;
                    case "3":
                        chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][2];
                        break;
                    case "5":
                        chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][4];
                        break;
                    case "6":
                        chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][5];
                        break;
                    case "7":
                        chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][6];
                        break;
                    //the flats and sharps require different functions to get the note below the chosen note because they are flats
                    case "b3":
                        chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][2];
                        //finds the index of the note in my note array 
                        int tempNoteIndex = Array.IndexOf(midiMaker.notesMaj, chosenNoteSTR);
                        //since it is a flat, i want to choose the note just below it, but i need to account for the fact that the note could be at index 0
                        if (tempNoteIndex == 0) { tempNoteIndex = 10; } else { tempNoteIndex--; }
                        //now takes the chosen note and puts it in the chosen note variable
                        chosenNoteSTR = midiMaker.notesMaj[tempNoteIndex];
                        break;
                    case "b5":
                        chosenNoteSTR = midiMaker.notesMinScales[keySigScaleIndex][4];
                        //finds the index of the note in my note array 
                        int tempNoteIndex1 = Array.IndexOf(midiMaker.notesMaj, chosenNoteSTR);
                        //since it is a flat, i want to choose the note just below it, but i need to account for the fact that the note could be at index 0
                        if (tempNoteIndex1 == 0) { tempNoteIndex1 = 10; } else { tempNoteIndex1--; }
                        //now takes the chosen note and puts it in the chosen note variable
                        chosenNoteSTR = midiMaker.notesMaj[tempNoteIndex1];
                        break;
                    case "#5":
                        chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][4];
                        //finds the index of the note in my note array 
                        int tempNoteIndex2 = Array.IndexOf(midiMaker.notesMaj, chosenNoteSTR);
                        //since it is a flat, i want to choose the note just below it, but i need to account for the fact that the note could be at index 0
                        if (tempNoteIndex2 == 10) { tempNoteIndex2 = 0; } else { tempNoteIndex2++; }
                        //now takes the chosen note and puts it in the chosen note variable
                        chosenNoteSTR = midiMaker.notesMaj[tempNoteIndex2];
                        break;
                    case "b7":
                        chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][6];
                        //finds the index of the note in my note array 
                        int tempNoteIndex3 = Array.IndexOf(midiMaker.notesMaj, chosenNoteSTR);
                        //since it is a flat, i want to choose the note just below it, but i need to account for the fact that the note could be at index 0
                        if (tempNoteIndex3 == 0) { tempNoteIndex3 = 10; } else { tempNoteIndex3--; }
                        //now takes the chosen note and puts it in the chosen note variable
                        chosenNoteSTR = midiMaker.notesMaj[tempNoteIndex3];
                        break;
                    default:
                        break;
                }
            }

            return chosenNoteSTR;
            
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
}

