using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourcing.Events
{
    public class AverageTimeDTO
    {
        public double FirstStep { get; set; }
        public double SecondStep { get; set; }
        public double ThirdStep { get; set; }
        public double FourthStep { get; set; }
        public double FifthStep { get; set; }
        public double Unsuccessful { get; set; }
        public double Next { get; set; }
        public double Prev { get; set; }

        public AverageTimeDTO() {}
    }
}
