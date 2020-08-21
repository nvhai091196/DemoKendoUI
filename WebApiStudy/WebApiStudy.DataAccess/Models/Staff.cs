using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiStudy.DataAccess.Models
{
    public class Staff : BaseEntity
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
