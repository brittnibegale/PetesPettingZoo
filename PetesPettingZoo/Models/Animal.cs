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
        public string AnimalName { get; set; }
        public string AnimalType { get; set; }
        public bool AtTheZoo { get; set; }
    }
}