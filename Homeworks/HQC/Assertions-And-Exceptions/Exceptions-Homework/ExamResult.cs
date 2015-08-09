namespace Exceptions_Homework
{
    using System;

    public class ExamResult
    {
        private int grade;
        private int minGrade;
        private int maxGrade;
        private string comments;
        
        public ExamResult(int grade, int minGrade, int maxGrade, string comments)
        {
            this.Grade = grade;
            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
            this.Comments = comments;
        }

        public int Grade 
        {
            get
            {
                return this.grade;
            }

            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Grade cannot be negative.");
                }

                this.grade = value;
            }
        }

        public int MinGrade
        {
            get
            {
                return this.minGrade;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Min grade cannot be negative.");
                }

                this.minGrade = value;
            }
        }

        public int MaxGrade
        {
            get
            {
                return this.maxGrade;
            }

            private set
            {
                if (value < this.minGrade)
                {
                    throw new ArgumentException("Max grade must be positive and greater than or equal to min grade.");
                }

                this.maxGrade = value;
            }
        }

        public string Comments
        {
            get
            {
                return this.comments;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Comment cannot be null or empty.");
                }

                this.comments = value;
            }
        }
    }
}