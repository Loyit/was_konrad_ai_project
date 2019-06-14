using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rezerwacja_pokoi.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public string Method { get; set; }
        public double TotalCost { get; set; }
        public DateTime Date { get; set; }


        public ICollection<Reservation> Reservations { get; set; }

    }
}
