using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using Domain;

namespace BLL
{
    public class RentalCalculator
    {
        private IRentalStrategy _rentalStrategy;

        public RentalCalculator()
        {
        }

        public RentalCalculator(IRentalStrategy rentalStrategy)
        {
            _rentalStrategy = rentalStrategy;
        }

        public void SetCalculator(IRentalStrategy calculator) => _rentalStrategy = calculator;
        public double Calculate(IEnumerable<RentalReport> reports) => _rentalStrategy.CalculateRentalPrice(reports);
    }
}
