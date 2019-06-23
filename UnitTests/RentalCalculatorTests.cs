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

namespace UnitTests
{
    [TestClass]
    public class RentalCalculatorTests
    {
        [AssemblyInitialize]
        public static void Configure(TestContext tc)
        {
            var repository = log4net.LogManager.GetRepository("UnitTestsRepository");
            log4net.Config.XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
        }

        [TestInitialize]
        public void InitializeRentalCalculatorTests()
        {
            Container container;

            container = new Container();

            container.Register<IRentalStrategy, HourRental>();
            container.Register<IRentalStrategy, DayRental>();
            container.Register<IRentalStrategy, WeekRental>();

            container.Verify();
        }

        [TestMethod]
        public void HourRentalTest()
        {

        }

        [TestMethod]
        public void DayRentalTest()
        {

        }

        [TestMethod]
        public void WeekRentalTest()
        {

        }

        [TestMethod]
        public void FamilyRentalTest()
        {
            
        }
    }
}
