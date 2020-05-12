using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    [Table("Guest")]
    public class Guest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GuestId { get; set; }
        public string GuestName { get; set; }
        public Nullable<int> TableforPeople { get; set; }
        public Nullable<int> BillAmount { get; set; }
        [ForeignKey("Reservation")]
        public Nullable<int> ReservationId { get; set; }

        public Reservation Reservation { get; set; }

    }
}
