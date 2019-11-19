using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rezerwacja_pokoi.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int RoomID { get; set; }
        public int PaymentID { get; set; }
        public int ChosenConvID { get; set; }

        [Required(ErrorMessage = "Data ropoczecia rezerwacji jest wymagana.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateFrom { get; set; }
        [Required(ErrorMessage = "Data zakończenia rezerwacji jest wymagana.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateTo { get; set; }
        public bool Confirmed { get; set; }
        [StringLength(100, ErrorMessage = "Ocena nie może być dłuższa niż 100 znaków.")]
        public string Feedback { get; set; }

        public User User { get; set; }
        public Room Room { get; set; }
        public Payment Payment { get; set; }
        public ICollection<ChosenConv> ChosenConvs { get; set; }
    }
}
