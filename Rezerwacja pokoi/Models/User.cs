using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Rezerwacja_pokoi.Models
{
    public class User
    {
        public int UserID { get; set; } 
        public string Name { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Hasło nie może być dłuższe niż 20 znaków oraz krótsze od 5.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "E-mail jest wymagane")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Imię jest wymagane")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Imię nie może być dłuższe niż 20 znaków oraz krótsze od 2.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Nazwisko nie może być dłuższe niż 25 znaków oraz krótsze od 2.")]
        public string LastName { get; set; }      
        public string Address { get; set; }

        public ICollection<PermRoles> PermRoless { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
