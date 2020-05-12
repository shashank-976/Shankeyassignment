using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;

namespace BusinessLayer
{
    public class Business
    {
        public void addGuest(Guest guest)
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.addGuest(guest);
        }
        public List<Reservation> displayReservation()
        {
            DataAccess dataAccess = new DataAccess();
            List<Reservation> reservations = dataAccess.displayReservation();
            return reservations;
        }

        public List<Guest> displayGuest()
        {
            DataAccess dataAccess = new DataAccess();
            List<Guest> guests = dataAccess.displayGuest();
            return guests;
        }

        public List<Guest> displayLGuest()
        {
            DataAccess dataAccess = new DataAccess();
            List<Guest> guests = dataAccess.displayLGuest();
            return guests;
        }

        public List<Guest> displayNames()
        {
            DataAccess dataAccess = new DataAccess();
            List<Guest> guests = dataAccess.displayNames();
            return guests;
        }

       public List<Guest> dispalyGuestId()
        {
            DataAccess dataAccess = new DataAccess();
            List<Guest> guests = new List<Guest>();
            guests = dataAccess.displayGuestId();
            return guests;
        }

        public void UpdateBillDetails(Guest guest,int id)
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.UpdateBillDetails(guest,id);
        }

    }
}
