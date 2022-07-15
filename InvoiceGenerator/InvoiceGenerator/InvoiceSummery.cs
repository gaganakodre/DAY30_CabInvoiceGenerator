using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceSummary
    {
        private int numberOfRides;
        private double totalFare;
        private double averageFare;
        private string userId;
        public InvoiceSummary(int numberOfRides, double totalFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.numberOfRides;
        }
        public InvoiceSummary(int numberOfRides, double totalFare, double averageFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.numberOfRides;
        }
        public InvoiceSummary(int numberOfRides, double totalFare, string userId)
        {//because to retun the avg we are creating this constructor
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.userId = userId;
            this.averageFare = this.totalFare / this.numberOfRides;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is InvoiceSummary)) return false;
            InvoiceSummary inputObject = (InvoiceSummary)obj;//here we are comparing the objects of summery with invoice
            //and it will return the objects which we are specifiedd here inputobject parameter specifies and  returns the current object
            return this.numberOfRides == inputObject.numberOfRides && this.totalFare == inputObject.totalFare && this.averageFare == inputObject.averageFare;
        }

        public override int GetHashCode()
        {
            return this.numberOfRides.GetHashCode() ^ this.totalFare.GetHashCode() ^ this.averageFare.GetHashCode();
        }
    }

}