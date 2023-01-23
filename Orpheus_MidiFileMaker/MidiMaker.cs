using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orpheus_Analyser;
using System.Text.Json;

namespace Orpheus_MidiFileMaker
{
    public class MidiMaker
    {
        static void Main(string[] args)
        {
        }

        public static void Generate(InputData UserData) 
        {
            string path = "/Users/seun_/source/repos/Orpheus/Orpheus_Analyser/bin/Debug/midi file list/MidiData.json";
            int bpm = UserData.GetBPM();
            string timesig = UserData.GetTimeSig();

            List<TheMidiFile> CollectedFiles = GetMidiFiles(path, bpm, timesig);
            //Search JSON file for relevant information
            //BPM, TimeSig
            //Take that data as TheMidiFile Objects
            //Put it in a new list

        }

        public static List<TheMidiFile> GetMidiFiles(string path, int bpm, string timesig) 
        {
            List<TheMidiFile> ALlFiles = JsonSerializer.Deserialize<List<TheMidiFile>>(path);
        }
       

    }

    public class InputData
    {
        private string PatternSeed;
        private string[] ExcludedNotes;
        private int bpm;
        private string TimeSig;
        private int Randomness;

        public InputData(string patternSeed, string[] excludedNotes, int bpm, string timeSig, int randomness)
        {
            PatternSeed = patternSeed;
            ExcludedNotes = excludedNotes;
            this.bpm = bpm;
            TimeSig = timeSig;
            Randomness = randomness;
        }

        public int GetBPM() 
        {
            return bpm;       
        }

        public string GetTimeSig() 
        {
            return TimeSig;
        }
    }
}
