using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orpheus_MidiFileMaker
{
    public class MidiMaker
    {
        static void Main(string[] args)
        {
        }

        public static void Generate(InputData UserData) 
        {
            
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
    }
}
