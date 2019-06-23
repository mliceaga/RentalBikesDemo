using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;
using Domain;

namespace BLL
{
    public class HourRental: IRentalStrategy
    {
        public double CalculateRentalPrice(IEnumerable<RentalReport> reports)
        {

            return reports.Where(r => r.RentalType == RentalType.Hour).Select(r => r.CalculateRental()).Sum();
        }
    }
}
