using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Data
    {
        DataContext Context = new DataContext();
        public void addGuest(Guest guest)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=.;Database=ReservationSystem; integrated security= SSPI");
            // con.Open();
            //SqlCommand sc = new SqlCommand($"insert into Guest values('{guest.GuestName}','{guest.TableforPeople}','{guest.BillAmount}','{guest.ReservationId}')", con);
            // sc.ExecuteNonQuery();
            //con.Close();
            List<Reservation> reservations = new List<Reservation>();
            Reservation reservation = new Reservation();
           // reservation= Context.reservations.Where(k => k.ReservationId == guest.ReservationId);
            var item = Context.reservations.Where(k => k.ReservationId == guest.ReservationId);
            foreach (var i in item)
            {
                i.Status = 1;
            }
            Context.guests.Add(guest);
            Context.SaveChanges();



        }

        public List<Reservation> displayReservation()
        {

            List<Reservation> reservations = new List<Reservation>();
            reservations = Context.reservations.ToList();
            return reservations;
        }
    }
}
