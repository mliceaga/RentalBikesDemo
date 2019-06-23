using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IPromotion
    {
        double ApplyDiscount(IEnumerable<RentalReport> rentalReports);
    }
}
