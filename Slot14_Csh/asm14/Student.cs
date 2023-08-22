using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot14_Csh.asm14
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public double MathScore { get; set; }
        public double PhysicsScore { get; set; }
        public double ChemistryScore { get; set; }
        public double AverageScore => (MathScore + PhysicsScore + ChemistryScore) / 3;
        public string AcademicPerformance
        {
            get
            {
                if (AverageScore >= 8)
                    return "Giỏi";
                else if (AverageScore >= 6.5)
                    return "Khá";
                else if (AverageScore >= 5)
                    return "Trung Bình";
                else
                    return "Yếu";
            }
        }
    }
}
