using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;

namespace BLL
{
    public class FamilyRental : IPromotion
    {
        List<IRentalStrategy> rentalStrategies = new List<IRentalStrategy>();
        //TODO add constraint for 3 to 5 total strategies

        public double ApplyDiscount()
        {
            throw new NotImplementedException();
        }
    }
}
