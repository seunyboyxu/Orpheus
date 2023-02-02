using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melanchall.DryWetMidi.Interaction;
using Orpheus_Analyser;
using Orpheus_MidiFileMaker;

namespace Orpheus_MidiFileMaker
{
    internal class MyChordProcessses
    {
        public MyChordProcessses() { }
        public static List<string> ChordBuilder(string keysig, string majmin, string chordSymbol, string chordType) 
        {
            MidiMaker midiMaker = new MidiMaker();
            var chord = new List<string>();
            int scalePosition = 0;
            int KeySigScaleIndex = 0;
            //switch statement to choose between major or minor scales
            switch (majmin) 
            {
                case "maj":
                    //gets the root note position of the chord symbol
                    scalePosition = ChordSymbolToNumber(chordSymbol);
                    //gets the index of the key signiture to use on the scales
                    KeySigScaleIndex = Array.IndexOf(midiMaker.notesMaj, keysig.ToUpper());
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
                    KeySigScaleIndex = Array.IndexOf(midiMaker.notesMin, keysig.ToUpper());
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

            return numberEquivalent;
        }

        public static string NoteNumberToNoteLetter(string buildnoteNum, int keySigScaleIndex, string majmin) 
        {
            MidiMaker midiMaker = new MidiMaker();
            //this is going to hold the chosen note index number
            int chosenNote;
            //this is oging to hold the chosen note letter
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

                        chosenNoteSTR = midiMaker.notesMinScales[keySigScaleIndex][0];
                        break;
                    case "3":
                        chosenNoteSTR = midiMaker.notesMinScales[keySigScaleIndex][2];
                        break;
                    case "5":
                        chosenNoteSTR = midiMaker.notesMinScales[keySigScaleIndex][4];
                        break;
                    case "6":
                        chosenNoteSTR = midiMaker.notesMinScales[keySigScaleIndex][5];
                        break;
                    case "7":
                        chosenNoteSTR = midiMaker.notesMinScales[keySigScaleIndex][6];
                        break;
                    //the flats and sharps require different functions to get the note below the chosen note because they are flats
                    case "b3":
                        chosenNoteSTR = midiMaker.notesMinScales[keySigScaleIndex][2];
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
                        chosenNoteSTR = midiMaker.notesMinScales[keySigScaleIndex][4];
                        //finds the index of the note in my note array 
                        int tempNoteIndex2 = Array.IndexOf(midiMaker.notesMaj, chosenNoteSTR);
                        //since it is a flat, i want to choose the note just below it, but i need to account for the fact that the note could be at index 0
                        if (tempNoteIndex2 == 10) { tempNoteIndex2 = 0; } else { tempNoteIndex2--; }
                        //now takes the chosen note and puts it in the chosen note variable
                        chosenNoteSTR = midiMaker.notesMaj[tempNoteIndex2];
                        break;
                    case "b7":
                        chosenNoteSTR = midiMaker.notesMinScales[keySigScaleIndex][6];
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
    }
}
