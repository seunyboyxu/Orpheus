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
        static void Main(string[] args)
        {
            string[] excludedNotes = new string[0];
            InputData data = new InputData("539472", excludedNotes, 120, "4/4", 5);
            Generate(data);
        }

        public static void Generate(InputData UserData) 
        {
            string path = "C:/Users/seun_/source/repos/Orpheus/Orpheus_Analyser/bin/Debug/MidiDataTest.json";
            int bpm = UserData.GetBPM();
            string timesig = UserData.GetTimeSig();

            List<TheMidiFile> CollectedFiles = GetMidiFiles(path, bpm, timesig);
            int PatternChooser = UserData.GetPatternSeedInt();

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

        public static int PatternSeedGen(int x)
        {
            int final = 0;

            int[] NumArr = x.ToString().Select(x => x - 48).ToArray();

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

        public int GetPatternSeedInt() 
        { 
            int x = Convert.ToInt32(PatternSeed);
            return x; 
        }
    }
}
