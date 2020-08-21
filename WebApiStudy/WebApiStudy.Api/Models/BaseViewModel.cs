using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiStudy.Api.Models
{
    public class BaseViewModel
    {
        public int Id { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
    }
}