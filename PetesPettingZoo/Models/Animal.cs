using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetesPettingZoo.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string AnimalName { get; set; }
        [Display(Name = "Animal")]
        public string AnimalType { get; set; }
        [Display(Name = "Show at the Petting Zoo?")]
        public bool AtTheZoo { get; set; }
    }
}