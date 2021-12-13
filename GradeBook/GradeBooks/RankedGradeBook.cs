using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook:BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted):base(name, isWeighted)
        {
            this.type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (this.Students.Count < 20)
                throw new InvalidOperationException();

            List<double> gd = GetSortedGrades();
            int[] quintiles = GetQuintiles(gd.Count);

            if (averageGrade >= quintiles[0])
            {
                return 'A';
            } 
            else if(averageGrade >= quintiles[1] && averageGrade < quintiles[0])
            {
                return 'B';
            }
            else if (averageGrade >= quintiles[2] && averageGrade < quintiles[1])
            {
                return 'C';
            }
            else if (averageGrade >= quintiles[3] && averageGrade < quintiles[2])
            {
                return 'D';
            }

            return 'F';
        }
        public List<double> GetSortedGrades()
        {
            List<double> grades = new List<double>();
            grades.Sort();
            this.Students.ForEach((s) => grades.Add(s.AverageGrade));
            return grades;
        }
        public int [] GetQuintiles(double count)
        {
                       
            double gradeA = count * 0.8;
            double gradeB = count * 0.6;
            double gradeC = count * 0.4;
            double gradeD = count * 0.2;

            int [] quintiles = { (int)gradeA, (int)gradeB, (int)gradeC, (int)gradeD };
            return quintiles;
        }
        public override void CalculateStatistics()
        {
            if (this.Students.Count < 5)
                throw new InvalidOperationException("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (this.Students.Count < 5)
                throw new InvalidOperationException("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            base.CalculateStudentStatistics(name);
        }
    }
}
