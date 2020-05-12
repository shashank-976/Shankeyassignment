using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLayer;
using EntityLayer;

namespace ReservationSystem.Models
{
    public class GuestSort : IComparable<GuestSort>
    {
        public int GuestId { get; set; }
        public string GuestName { get; set; }
        public Nullable<int> TableforPeople { get; set; }
        public Nullable<int> BillAmount { get; set; }
        public Nullable<int> ReservationId { get; set; }

        public virtual ReservationModel Reservation { get; set; }

        public int CompareTo(GuestSort other)
        {
            if (this.ReservationId > other.ReservationId)
                return -1;
            else if (this.ReservationId < other.ReservationId)
                return 1;
            else
                return 0;
        }

        public class GetAllId
        {
            public List<GuestSort> guestT()
            {
                Business business = new Business();
                List<Guest> guests = new List<Guest>();

                List<GuestSort> guestSorts = new List<GuestSort>();
                guests = business.dispalyGuestId();


                foreach(var item in guests)
                {
                    GuestSort guestSort = new GuestSort();
                    guestSort.GuestId = item.GuestId;
                    guestSort.GuestName = item.GuestName;
                    guestSort.TableforPeople = item.TableforPeople;
                    guestSort.ReservationId = item.ReservationId;
                    guestSorts.Add(guestSort);
                }
                guestSorts.Sort();
                return guestSorts;
            }
        }
    }
}