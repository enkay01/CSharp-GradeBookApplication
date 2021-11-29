using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace GradeBook.GradeBooks
{
    class RankedGradeBook:StandardGradeBook
    {
        public RankedGradeBook(string name):base(name)
        {
            this.type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (this.Students.Count < 20)
                throw new InvalidOperationException();


            var threshold = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (averageGrade >= grades[threshold - 1])
                return 'A';

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
        
    }
}
