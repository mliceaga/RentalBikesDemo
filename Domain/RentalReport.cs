using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class RentalReport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RentalType RentalType { get; set; }
        public int Period { get; set; }
        public double Rate { get; set; }

        public double CalculateRental() => Period * Rate;
    }
}
