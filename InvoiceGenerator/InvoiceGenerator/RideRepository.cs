using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    class RideRepository//it contains the information of the userid 
    {
        Dictionary<string, List<Ride>> userRides = null;//here we are creating the dictonary and inside that we are ahving the list contains the ride class

        public RideRepository()//constructor
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }
        public void AddRide(string userId, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                if (!rideList)
                {
                    List<Ride> list = new List<Ride>();//herer we are creating the list to sotore the ride values like distance and yile
                    list.AddRange(rides);//this will add the specified collection to the end of the list
                    //here adding inside the dictonary
                    this.userRides.Add(userId, list);//why it contains value=2 means
                                                     //buz we are adding two time and distance for same userid
                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides are null");
            }
        }

        public Ride[] getRides(string userId)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                return this.userRides[userId].ToArray();//copy this to toarray
                // it will return the array which contains the dictonary

                //why we are adding toarray() buz here we are having a return tye as a ride array
            }
            catch (Exception)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid user ID");
            }
        }

    }

}