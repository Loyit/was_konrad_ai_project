using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rezerwacja_pokoi.Models
{
    public class Room
    {
        public int RoomID { get; set; }

        public int RoomNumber { get; set; }
        public string Description { get; set; }
        public int BedsCount { get; set; }
        public double Price { get; set; }
        public int Rate { get; set; }
        public string Location { get; set; }


        public ICollection<Reservation> Reservations { get; set; }
    }
}
