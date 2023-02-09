using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orpheus_MidiFileMaker
{
    public class FinalNote
    {
        private string NoteName;
        private double NoteDuration;

        public FinalNote(string NoteName, double NoteDuration)
        {
            this.NoteName = NoteName;
            this.NoteDuration = NoteDuration;
        }

        public string GetNoteName() { return NoteName; }
        public double GetNoteDuration() { return NoteDuration; }



    }
}
