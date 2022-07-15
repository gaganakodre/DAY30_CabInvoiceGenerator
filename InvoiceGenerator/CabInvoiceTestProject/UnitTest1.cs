using CabInvoiceGenerator;
using NUnit.Framework;

namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()//given with the distance and the time and we should return the total fare
        {
            //arrange
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);//it will go inside the invoive generator
            double distance = 2.0;
            int time = 5;
            double expected = 25;
            //act
            double fare = invoiceGenerator.CalculateFare(distance, time);
            //assert
            Assert.AreEqual(expected, fare);
        }

        [Test]
        public void GivenMultipleRideShouldReturnInvoiceSummary()
        {
            //arrange
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 5) };
            //act
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 35.0);
            //assert   //(The exact runtime type of the current instance.)gettype method retuns type of current instance so here if it returns same type then they both are equal
            Assert.AreEqual(expectedSummary.GetType(), summary.GetType());//assert class is a collection helper class
            //assert is a abstract class and it retrn void and aslo areequal()=static method dosenot return any type it is void.
        }
        [Test]
        public void GivenInvoiceGenerator_UsingInvoiceSummary_ShouldReturnInvoiceSummary()
        {
            //arrange
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            //act
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0, 3);
            //assert
            Assert.AreEqual(expectedSummary, summary);
        }
        [Test]
        public void GivenUserId_UsingInvoiceSummary_ShouldReturnInvoice()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            invoiceGenerator.AddRides("1", rides);//it will go and add the userid ti that dictoanry as a key
            InvoiceSummary summary = invoiceGenerator.GetInvoiceSummary("1");
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0, "1");
            Assert.AreEqual(expectedSummary, summary);
        }
        [Test]
        public void GivenRides_WhenPremiumOrNormal_ShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = 3.0;
            int time = 20;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 85;
            Assert.AreEqual(expected, fare);
        }
    }
}