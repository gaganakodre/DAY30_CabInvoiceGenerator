using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceGenerator
{
    public class Ride
    {
        public double distance;
        public int time;
        public int userID;
        public Ride(double distance,int time, int userID)
        {
            this.distance = distance;
            this.time = time;
            this.userID = userID;
        }
    }
}
