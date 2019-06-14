using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rezerwacja_pokoi.Models
{
    public class Convenience
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public ICollection<ChosenConv> ChosenConvs { get; set; }

    }
}
