using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using BLL.Interfaces;
using Domain;

namespace BLL
{
    public class FamilyRental : IPromotion
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(FamilyRental));
        List<IRentalStrategy> _rentalStrategies;

        public FamilyRental(List<IRentalStrategy> rentalStrategies)
        {
            try
            {
                if (rentalStrategies.Count < 3 || rentalStrategies.Count > 5)
                {
                    log.Error("You must enter from 3 to 5 rental strategies to initialize this promotion.");
                    return;
                }
                _rentalStrategies = rentalStrategies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
            public void AddRentalStrategy(IRentalStrategy rentalStrategy)
            {
            try
            {
                if (_rentalStrategies.Count > 4)
                {
                    log.Error("You can have from 3 to 5 rental strategies for this promotion.");
                    return;
                }
                _rentalStrategies.Add(rentalStrategy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveRentalStrategy(IRentalStrategy rentalStrategy)
        {
            try
            {
                if (_rentalStrategies.Count < 1)
                {
                    log.Error("You can have from 3 to 5 rental strategies for this promotion.");
                    return;
                }
                foreach (var rs in _rentalStrategies)
                {
                    if (rs.GetHashCode() != rentalStrategy.GetHashCode())
                    {
                        _rentalStrategies.Add(rentalStrategy);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double ApplyDiscount(IEnumerable<RentalReport> rentalReports)
        {
            double totalRental = 0;
            try
            {
                foreach (var rs in _rentalStrategies)
                {
                    totalRental += rs.CalculateRentalPrice(rentalReports);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return (totalRental * 70) / 100;
        }
    }
}