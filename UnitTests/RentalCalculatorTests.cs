using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using Domain;
using SimpleInjector;
using BLL.Interfaces;
using System.IO;
using System.Linq;
using System.Reflection;

namespace UnitTests
{
    [TestClass]
    public class RentalCalculatorTests
    {
        [AssemblyInitialize]
        public static void Configure(TestContext tc)
        {
            var repository = log4net.LogManager.GetRepository(Assembly.GetEntryAssembly());
            log4net.Config.XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
        }

        [TestInitialize]
        public void InitializeRentalCalculatorTests()
        {
            Container container;

            container = new Container();

            container.Collection.Register<IRentalStrategy>(
                typeof(HourRental),
                typeof(DayRental),
                typeof(WeekRental)
                );

            container.Register<IPromotion, FamilyRental>();

            container.Verify();
        }

        [TestMethod]
        public void HourRentalTest()
        {
            //Arrange
            var hourRental = new HourRental();
            var report = new RentalReport(1, "1 hour", RentalType.Hour, 1);
            List<RentalReport> rentalReports = new List<RentalReport>
            {
                report
            };

            //Act
            var result = hourRental.CalculateRentalPrice(rentalReports.AsEnumerable());

            //Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void DayRentalTest()
        {
            //Arrange
            var dayRental = new DayRental();
            var report = new RentalReport(1, "1 day", RentalType.Day, 1);
            List<RentalReport> rentalReports = new List<RentalReport>
            {
                report
            };

            //Act
            var result = dayRental.CalculateRentalPrice(rentalReports.AsEnumerable());

            //Assert
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void WeekRentalTest()
        {
            //Arrange
            var weekRental = new WeekRental();
            var report = new RentalReport(1, "1 week", RentalType.Week, 1);
            List<RentalReport> rentalReports = new List<RentalReport>
            {
                report
            };

            //Act
            var result = weekRental.CalculateRentalPrice(rentalReports.AsEnumerable());

            //Assert
            Assert.AreEqual(60, result);
        }

        [TestMethod]
        public void FamilyRentalTest()
        {
            //Arrange
            var hourRental = new HourRental();
            var dayRental = new DayRental();
            var weekRental = new WeekRental();
            var report = new RentalReport(1, "1 hour", RentalType.Hour, 1);
            var report2 = new RentalReport(1, "1 day", RentalType.Day, 1);
            var report3 = new RentalReport(1, "1 week", RentalType.Week, 1);
            List<RentalReport> rentalReports = new List<RentalReport>
            {
                report,
                report2,
                report3
            };

            List<IRentalStrategy> rentalStrategies = new List<IRentalStrategy>
            {
                hourRental,
                dayRental,
                weekRental
            };
            var familyRental = new FamilyRental(rentalStrategies);

            //Act
            var result = familyRental.ApplyDiscount(rentalReports);

            //Assert
            Assert.AreEqual(59.5, result);
        }

        [TestMethod]
        public void FamilyRentalFailsTest()
        {
            //Arrange
            var hourRental = new HourRental();
            var dayRental = new DayRental();
            var report = new RentalReport(1, "1 hour", RentalType.Hour, 1);
            var report2 = new RentalReport(1, "1 day", RentalType.Day, 1);
            List<RentalReport> rentalReports = new List<RentalReport>
            {
                report,
                report2,
            };

            List<IRentalStrategy> rentalStrategies = new List<IRentalStrategy>
            {
                hourRental,
                dayRental,
            };
            var familyRental = new FamilyRental(rentalStrategies);

            //Act
            //Assert
            Assert.ThrowsException<NullReferenceException>(() => familyRental.ApplyDiscount(rentalReports));
        }
    }
}
