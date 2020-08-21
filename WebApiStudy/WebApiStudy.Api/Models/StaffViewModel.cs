using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiStudy.Api.Models
{
    public class StaffViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime? DayOfBirth { get; set; }
        public bool? Gender { get; set; }
        public string Interests { get; set; }
    }
}