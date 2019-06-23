using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IRentalStrategy
    {
        double CalculateRentalPrice(IEnumerable<RentalReport> reports);
    }
}
