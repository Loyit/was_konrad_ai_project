using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rezerwacja_pokoi.Models
{
    public class ChosenConv
    {
        public int ChosenConvID { get; set; }
    
        public Convenience Conv { get; set; }
        public Reservation Reservations { get; set; }
       
    }
}
