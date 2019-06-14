using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rezerwacja_pokoi.Models
{
    public class Message
    {
        public int MessageID { get; set; }

        [EmailAddress(ErrorMessage = "Niepoprawny adres e-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Podaj temat wiadomości")]
        [StringLength(100, ErrorMessage = "Temat wiadomości nie może być dłuższy niż 100 znaków.")]
        public string Topic { get; set; }

        [StringLength(2000, ErrorMessage = "Wiadomość nie może być dłuższa niż 2000 znaków.")]
        public string Text { get; set; }

        public DateTime Date { get; set; }
    
        public User User { get; set; }
        
    }
}
