using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
    [TestFixture()]
    public class FlightTest
    {

        private readonly DateTime dateThatFlightLeaves;
        private readonly DateTime dateThatFlightReturns;
        private readonly int someMiles;
        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(dateThatFlightLeaves, dateThatFlightReturns, someMiles);
            Assert.IsNotNull(target);
        }

        [Test()]
        public void TesThatFlightHasCorrectBasePriceForOneDayFlight()
        {
            DateTime dateTestFlightLeaves = new DateTime(2010, 1, 18);
            DateTime dateTestFlightReturns = new DateTime(2010, 1, 19);
            var target = new Flight(dateTestFlightLeaves, dateTestFlightReturns, someMiles);
            Assert.AreEqual(220, target.getBasePrice());
        }

        [Test()]
        public void TesThatFlightHasCorrectBasePriceForTwoDayFlight()
        {
            DateTime dateTestFlightLeaves = new DateTime(2011, 3, 18);
            DateTime dateTestFlightReturns = new DateTime(2011, 3, 20);
            var target = new Flight(dateTestFlightLeaves, dateTestFlightReturns, someMiles);
            Assert.AreEqual(240, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceFor20DayFlight()
        {
            DateTime dateTestFlightLeaves = new DateTime(2011, 3, 18);
            DateTime dateTestFlightReturns = new DateTime(2011, 4, 7);
            var target = new Flight(dateTestFlightLeaves, dateTestFlightReturns, someMiles);
            Assert.AreEqual(600, target.getBasePrice());

        }
        
        
        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightEndDateIsAfterStartDate()
        {
            DateTime dateTestFlightLeaves = new DateTime(2011, 3, 18);
            DateTime dateTestFlightReturns = new DateTime(2010, 3, 18);
            var target = new Flight(dateTestFlightLeaves, dateTestFlightReturns, someMiles);
        }
        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatMilesCannotBeNegative()
        {
            new Flight(dateThatFlightLeaves, dateThatFlightReturns, -2);
        }

        [Test()]
        public void TestThatFlightHasIncorrectBasePriceFor1DayFlight()
        {
            DateTime dateTestFlightLeaves = new DateTime(2011, 3, 18);
            DateTime dateTestFlightReturns = new DateTime(2011, 3, 19);
            var target = new Flight(dateTestFlightLeaves, dateTestFlightReturns, someMiles);
            Assert.AreNotEqual(230, target.getBasePrice());
        }


    }
}
