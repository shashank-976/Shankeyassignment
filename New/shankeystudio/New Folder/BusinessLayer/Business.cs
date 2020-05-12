using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Business
    {
        public void addGuest(Guest guest)
        {
            Data data = new Data();
            data.addGuest(guest);
        }

        public List<Reservation> displayReservation()
        {
            Data data = new Data();
            List<Reservation> reservations = data.displayReservation();
            return reservations;
        }

    }
}
