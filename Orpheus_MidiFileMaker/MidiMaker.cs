using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orpheus_Analyser;
using System.Text.Json;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace Orpheus_MidiFileMaker
{
    public class MidiMaker
    {
        static void Main(string[] args)
        {
            string[] excludedNotes = new string[0];
            InputData data = new InputData("12412", excludedNotes, 120, "4/4", 297369);
            Generate(data);
        }

        public static void Generate(InputData UserData) 
        {
            string path = "C:/Users/seun_/source/repos/Orpheus/Orpheus_Analyser/bin/Debug/MidiDataTest.json";
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
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true
                
                
            };

            string jsonContents = File.ReadAllText(path);
            List<TheMidiFile> AllFiles = JsonSerializer.Deserialize<List<TheMidiFile>>(jsonContents, options);
            var FinalList = AllFiles.Where(x => (int)x.GetBPM() == bpm && x.GetTimeSig() == timesig).ToList();
            return FinalList;
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
