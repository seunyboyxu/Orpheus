using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    string[] chordBuild = midiMaker.CommonChords[Array.IndexOf(midiMaker.CommonChordNames, chordType)]; 
                    //iterate through the array and changed the chordbuild notes to acutal notes
                    //options: 1, 3, 5, 6, 7, b3, b5, #5, b7
                    //use notesMaj as general note chooser from 0 to 10


                    break;
                case "min":
                    scalePosition = ChordSymbolToNumber(chordSymbol);
                    break;
                default: 
                    break;

            }

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
            int chosenNote;
            string chosenNoteSTR = "";
            switch(buildnoteNum) 
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
                case "b3":
                    chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][2];
                    break;
                case "b5":
                    chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][4];
                    break;
                case "#5":
                    chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][4];
                    break;
                case "b7":
                    chosenNoteSTR = midiMaker.notesMajScales[keySigScaleIndex][6];
                    break;
                default:
                    break;
            }
            
        }
    }
}
