﻿using Orpheus_Analyser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Orpheus_MidiFileMaker
{
    internal class NoteProcesses
    {
        List<double> SetDoubles = new List<double>()
        {
            1.0, 0.75, 0.5, 0.25, 0.4375, 0.65625, 0.625, 0.375, 0.3125, 0.21875, 0.15625, 0.109375, 0.1875, 0.125, 0.0625, 0.03125, 0.015625, 0.046875
        };
        public NoteProcesses() { }

        //this first function is made to generate a list of patterns per bar, these patterns will always have to add up to a certain value
        public List<List<double>> PatternGen(string timesig, List<double> patterns, int PatternChooser) 
        {
            Random random = new Random();   
            List<double> BarPattern= new List<double>();
            List<List<double>> PatternSequence = new List<List<double>>();

            //go through the list of patterns and shifts it to its set nearest value
            //this ensures, the music will be written in a correct musical and mathematical format

            for(int i = 0; i < patterns.Count; i++)
            {
                var x = GetNearestValue(patterns[i], SetDoubles);
                patterns[i] = x;
            }
            //removing all values of one
            patterns = patterns.Where(x => x != 1.0).ToList();


            //calculate the max beats in a bar
            double BarQuota = 0;
            switch (timesig) 
            {
                case "4/4":
                    BarQuota = 1;
                    break;
                case "3/4":
                    BarQuota = 0.75;
                    break;
                case "2/4":
                    BarQuota = 0.5;
                    break;                
            }

            //go through each bar and feed in the notes from the patterns
            int PatternIndicator = 0;
            for(int i = 0; i < 4; i ++)
            {
                //clear BarPattern Variable
                BarPattern.Clear();

                //indefinetly go through pattern list to fill up each bar
                while (true)

                {
                    //checks to see if the total patterns in the BarQuota have been filled
                    if(BarPattern.Sum() >= BarQuota)
                    {
                        break;
                    }

                    //adds the pattern from the pattern indicator to the bar
                    BarPattern.Add(patterns[PatternIndicator]);
                    //increment the Pattern indicator to the next one, since the previous pattern number has been used
                    //added to pattern chooser which is generated from pattern seed
                    PatternIndicator += (PatternChooser * PatternChooser);
                    if(PatternIndicator > patterns.Count() || PatternIndicator < 0)
                    {
                        PatternIndicator = patterns.Count() / random.Next(2, 8);
                    }
                }

                //last check to make sure the BarPattern fits the quota incase the last note added made it go over the quota
                if(BarPattern.Sum() > BarQuota) 
                {
                    //removes the last item
                    BarPattern.RemoveAt(BarPattern.Count - 1);

                    //puts a filler last note to make sure there arent any spaces
                    if(BarPattern.Sum() != BarQuota)
                    {
                        //calculates the filler note i.e total minus current total to work out how to get to the total
                        double filler = BarQuota - BarPattern.Sum();

                        //adds the filler note to the end of the List
                        BarPattern.Add(filler);
                    }
                }

                PatternSequence.Add(BarPattern);

            }

            return PatternSequence;
           

        }

        //this function gets the double nearest to the refrenceValues
        public static double GetNearestValue(double input, List<double> array)
        {
            //binary search method
            array.Sort();

            int low = 0;
            int high = array.Count - 1;
            int mid = 0;
            while (low <= high)
            {
                mid = (low + high) / 2;
                if (input == array[mid])
                {
                    return array[mid];

                }
                else if (input < array[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            // At this point, low is greater than high, so we compare the input value with // the elements at low and high indices to find the nearest value
            if (low >= array.Count)
            // low is out of range, so we return array[high]
            {
                return array[high];
            }
            else if (high < 0) // high is out of range, so we return array[low]
            {
                return array[low];
            }
            else // we return the element that has a smaller difference with the input value
            {
                double diffLow = Math.Abs(input - array[low]);
                double diffHigh = Math.Abs(input - array[high]);
                return diffLow < diffHigh ? array[low] : array[high];
            }

        }

        //generates the final note and pattern combinations
        public List<List<FinalNote>> NoteGen(List<List<double>> patternSeq, List<string> AllNotes, int Randomness) 
        {
            //final List
            List<List<FinalNote>> Sequence = new List<List<FinalNote>>();

            //find midpoint of List of notes
            int midPoint = AllNotes.Count / 2;

            //gets the total number of pattern notes in the list to iterate through and add a note
            int total = patternSeq.Select(x => x.Count()).Sum();

            //generate the list of notes
            List<string> notes = new List<string>();

            int index = midPoint;
            Random random = new Random();
            int direction = 1;
            for(int i = 0; i < total; i++)
            {
                //choses jump range based on randomness
                int jump = random.Next(0, Randomness + 2);
                //makes sure the jump goes in the right direction
                jump = jump * direction;
                //adds the jump on to the index
                index = jump + index;
                //checks when index is higher than the AllNotes
                if(index >= AllNotes.Count() || index < 0) 
                {
                    //resets to midpoint times a direction + a random place
                    index = (midPoint + (random.Next(0, 2) * direction));
                }
                //adds the note at index to the AllNotes
                notes.Add(AllNotes[index]);
                //changes the direction at the end
                if (direction == 1) { direction = -1; } else if (direction == -1) { direction = 1; }
            }

            //adds the pattern note and note name together in a final sequence, uses the pattern as an indicator
            int noteIndicator = 0;
            foreach(var bar in patternSeq) 
            {
                List<FinalNote> temp = new List<FinalNote>();
                //goes through every bar
                for(int i = 0; i < bar.Count;i++) 
                {
                    FinalNote finalNote = new FinalNote(notes[noteIndicator], bar[i]);
                    temp.Add(finalNote);
                    noteIndicator++;
                }

                Sequence.Add(temp);
            }

            return Sequence;
            
        }

        public List<double> PatternFlattener(List<TheMidiFile> files)
        {
            List<double> patternsCOMBO = new List<double>();
            List<List<double>> collectedFile = new List<List<double>>();


            foreach (var file in files)
            {
                //gets all the patterns from the collected files
                collectedFile = file.GetPatterns();
                //flattens the list into one large long double list
                var temp = collectedFile.SelectMany(x => x).ToList();
                //adds to the patternsCombo
                foreach(var x in temp) 
                {
                    patternsCOMBO.Add(x);
                }

            }

            return patternsCOMBO;
        }

    }
}
