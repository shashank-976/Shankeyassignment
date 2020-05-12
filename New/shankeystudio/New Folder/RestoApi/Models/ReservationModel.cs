using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestoApi.Models
{
    public class ReservationModel
    {
        public int ReservationId { get; set; }
        public Nullable<int> TotalSeats { get; set; }
        public Nullable<int> Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GuestModel> Guests { get; set; }
    }
}