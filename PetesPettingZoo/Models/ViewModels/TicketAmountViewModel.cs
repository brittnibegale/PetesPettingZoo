using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetesPettingZoo.Models.ViewModels
{
    public class TicketAmountViewModel
    {
    public string FirstName { get; set; }
    [Display(Name = "Your tickets cost:")]
    public double Cost { get; set; }
    }
}