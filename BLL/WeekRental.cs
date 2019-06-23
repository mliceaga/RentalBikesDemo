using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;
using Domain;

namespace BLL
{
    public class WeekRental : IRentalStrategy
    {
        public double CalculateRentalPrice(IEnumerable<RentalReport> reports)
        {
            return reports.Where(r => r.RentalType == RentalType.Week).Select(r => r.CalculateRental()).Sum();
        }
    }
}
