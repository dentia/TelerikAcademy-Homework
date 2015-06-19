namespace Exceptions_Homework
{
    using System;

    public class SimpleMathExam : Exam
    {
        private const int MinProblemsSolved = 0;
        private const int MaxProblemsSolved = 10;
        private const string ExcelentResultsComment = "Excellent result: everything's done correctly.";
        private const string GoodResultsComment = "Good result: almost everything's done correctly.";
        private const string AverageResultsComment = "Average result: almost nothing done.";
        private const string BadResultsComment = "Bad result: nothing done.";
        private const int BadGradeMaxProblems = 2;
        private const int AverageGradeMaxProblems = 5;
        private const int GoodGradeMaxProblems = 8;
        private int problemsSolved;

        public SimpleMathExam(int problemsSolved)
        {
            this.ProblemsSolved = problemsSolved;
        }
        
        public int ProblemsSolved
        {
            get 
            {
                if (this.problemsSolved < SimpleMathExam.MinProblemsSolved)
                {
                    return SimpleMathExam.MinProblemsSolved;
                }
                else if (this.problemsSolved > SimpleMathExam.MaxProblemsSolved)
                {
                    return SimpleMathExam.MaxProblemsSolved;
                }
                else
                {
                    return this.problemsSolved;
                }
            }

            set 
            { 
                this.problemsSolved = value; 
            }
        }

        public override ExamResult Check()
        {
            string comment;

            if (this.ProblemsSolved <= SimpleMathExam.BadGradeMaxProblems)
            {
                comment = SimpleMathExam.BadResultsComment;
            }
            else if (this.ProblemsSolved <= SimpleMathExam.AverageGradeMaxProblems)
            {
                comment = SimpleMathExam.AverageResultsComment;
            }
            else if (this.ProblemsSolved <= SimpleMathExam.GoodGradeMaxProblems)
            {
                comment = SimpleMathExam.GoodResultsComment;
            }
            else
            {
                comment = SimpleMathExam.ExcelentResultsComment;
            }

            return new ExamResult(this.ProblemsSolved, SimpleMathExam.MinProblemsSolved, SimpleMathExam.MaxProblemsSolved, comment);
        }
    }
}