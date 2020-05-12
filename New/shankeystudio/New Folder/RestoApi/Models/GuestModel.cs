using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestoApi.Models
{
    public class GuestModel
    {
        
        public int GuestId { get; set; }
        public string GuestName { get; set; }
        public Nullable<int> TableforPeople { get; set; }
        public Nullable<int> BillAmount { get; set; }
        
        public Nullable<int> ReservationId { get; set; }

        public ReservationModel Reservation { get; set; }
    }
}