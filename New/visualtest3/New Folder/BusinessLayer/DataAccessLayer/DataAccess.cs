using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using ExceptionLayer;

namespace DataAccessLayer
{
    public class DataAccess
    {
        ReservationSystemEntities reservationSystemEntities = new ReservationSystemEntities();
        public void addGuest(EntityLayer.Guest guest)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=.;Database=ReservationSystem; integrated security= SSPI");
            // con.Open();
            //SqlCommand sc = new SqlCommand($"insert into Guest values('{guest.GuestName}','{guest.TableforPeople}','{guest.BillAmount}','{guest.ReservationId}')", con);
            // sc.ExecuteNonQuery();
            //con.Close();
            var item = reservationSystemEntities.Reservations.Where(k => k.ReservationId == guest.ReservationId);
            foreach (var i in item)
            {
                i.Status = 1;
            }
            reservationSystemEntities.Guests.Add(guest);
            reservationSystemEntities.SaveChanges();
            
            
            
        }
        public List<Reservation> displayReservation()
        {
            
            List<Reservation> reservations = new List<Reservation>();
            reservations = reservationSystemEntities.Reservations.ToList();
            return reservations;
        }

        public List<Guest> displayGuest()
        {
            List<Guest> guests = new List<Guest>();
            guests = (from p in reservationSystemEntities.Guests orderby p.BillAmount descending select p).Take(5).ToList();
            return guests;
        }
        //public void UpdateBillDetails(Guest guest,int id)
        //{

        //    Guest item = reservationSystemEntities.Guests.Where(x => x.GuestId == guest.GuestId).FirstOrDefault();

        //    item.BillAmount = guest.BillAmount;

        //    var bill = reservationSystemEntities.Reservations.Where(k => k.ReservationId == guest.ReservationId);
        //    foreach (var i in bill)
        //    {

        //        i.Status = 0;

        //    }

        //    reservationSystemEntities.SaveChanges();
        //}
        public void UpdateBillDetails(Guest guest, int id)
        {
            List<Reservation> reservations = new List<Reservation>();
            Reservation reservation = new Reservation();
            Guest g = reservationSystemEntities.Guests.Find(id);
            g.BillAmount = guest.BillAmount;
            var bill = reservationSystemEntities.Reservations.Where(k => k.ReservationId == g.ReservationId);
            foreach (var i in bill)
            {

                i.Status = 0;

            }
            reservationSystemEntities.SaveChanges();

        }

        public List<Guest> displayLGuest()
        {
            List<Guest> guests = new List<Guest>();
            guests = (from r in reservationSystemEntities.Guests orderby r.BillAmount ascending select r).Take(5).ToList();
            return guests;
        }

        public List<Guest> displayNames()
        {
            List<Guest> guests = new List<Guest>();
            guests = reservationSystemEntities.Guests.Where(b => b.Reservation.Status == 1).ToList();
            return guests;
        }

        public List<Guest> displayGuestId()
        {
            List<Guest> guests = new List<Guest>();
            guests = reservationSystemEntities.Guests.ToList();
            return guests;
        }
        

        }


    }

    

