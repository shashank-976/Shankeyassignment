using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservationSystem.Models
{
    public class GuestModel:IComparable
    {
        public int GuestId { get; set; }
        public string GuestName { get; set; }
        public Nullable<int> TableforPeople { get; set; }
        public Nullable<int> BillAmount { get; set; }
        public Nullable<int> ReservationId { get; set; }

        public int CompareTo(Object obj)
        {
            GuestModel guest = obj as GuestModel;
            if (BillAmount > guest.BillAmount)
            {
                return 1;
            }

            else if (BillAmount > guest.BillAmount)
            {
                return -1;
            }
            else
            {
                return 0;
            }
            
        }
        public class GuestModelCompare : IComparer<GuestModel>
        {
            public int Compare(GuestModel x, GuestModel y)
            {
                if(x.ReservationId>y.ReservationId)
                {
                    return 1;
                }
                else if(x.ReservationId < y.ReservationId)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}