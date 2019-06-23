using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;
using Domain;

namespace BLL
{
    public class DayRental: IRentalStrategy
    {
        public double CalculateRentalPrice(IEnumerable<RentalReport> reports)
        {
            return reports.Where(r => r.RentalType == RentalType.Day).Select(r => r.CalculateRental()).Sum();
        }
    }
}
