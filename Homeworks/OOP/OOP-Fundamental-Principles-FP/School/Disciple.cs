using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    public class Disciple : Person, ICommentable
    {
        private int exercises;
        private int lectures;
        private uint uniqueNumber;

        public int NumberOfExercises
        {
            get { return exercises; }
            set { exercises = value; }
        }

        public int NumberOfLectures
        {
            get { return this.lectures; }
            set { this.lectures = value; }
        }

        public uint UniqueNumber
        {
            get { return uniqueNumber; }
            set { uniqueNumber = value; }
        }

        public Disciple(string name, uint uniqueNumber, int lecures, int exercises)
            : base(name)
        {
            this.UniqueNumber = uniqueNumber;
            this.NumberOfLectures = lecures;
            this.NumberOfExercises = exercises;
        }

        public override string ToString()
        {
            return String.Format("{0} ({1}). Lectures: {2}, Exercises: {3}", 
                this.Name, this.UniqueNumber, this.NumberOfLectures, this.NumberOfExercises);
        }
    }
}
