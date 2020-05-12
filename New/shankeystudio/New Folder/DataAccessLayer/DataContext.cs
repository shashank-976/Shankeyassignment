using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class DataContext:DbContext
    {
        public DataContext() : base("connection")
        {

        }
        public DbSet<Guest> guests { get; set; }
        public DbSet<Reservation> reservations { get; set; }
        public object Reservations { get; internal set; }
    }


}
