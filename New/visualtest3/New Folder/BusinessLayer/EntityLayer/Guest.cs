//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Guest
    {
        public int GuestId { get; set; }
        public string GuestName { get; set; }
        public Nullable<int> TableforPeople { get; set; }
        public Nullable<int> BillAmount { get; set; }
        public Nullable<int> ReservationId { get; set; }
    
        public virtual Reservation Reservation { get; set; }

        //public int CompareTo(Guest other)
        //{
        //    if (this.ReservationId > other.ReservationId)
        //        return 1;
        //    else if (this.ReservationId < other.ReservationId)
        //        return -1;
        //    else
        //        return 0;
        //}

        //public int Compare(Guest x, Guest y)
        //{
        //    if (x.ReservationId > y.ReservationId)
        //        return 1;
        //    else if (x.ReservationId < y.ReservationId)
        //        return -1;
        //    else
        //        return 0;

        //}
    }
}
