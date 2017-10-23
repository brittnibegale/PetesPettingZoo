using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetesPettingZoo.Models
{
    public class Customers
    {
        [Key]
        public int Id { get; set; }
        public double Cost { get; set; }
        public bool Paid { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email for Confirmation")]
        public string Email { get; set; }

        [ForeignKey("OpenDaysId")]
        public OpenDays OpenDay { get; set; }
        [Required]
        [Display(Name = "Choose date you would like to attend")]
        public int OpenDaysId { get; set; }
        public IEnumerable<OpenDays>OpenDays { get; set; }

        [ForeignKey("TicketId")]
        public Tickets Ticket { get; set; }
        [Required]
        [Display(Name = "Ticket Amount")]

        public int TicketId { get; set; }
        public IEnumerable<Tickets>Tickets { get; set; }




    }
}