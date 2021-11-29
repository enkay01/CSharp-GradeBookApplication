using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook:StandardGradeBook
    {
        public RankedGradeBook(string name):base(name)
        {
            this.type = Enums.GradeBookType.Ranked;
        }
    }
}
