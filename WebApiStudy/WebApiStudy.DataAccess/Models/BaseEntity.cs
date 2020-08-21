using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiStudy.DataAccess.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public void SetModifier(int userId)
        {
            this.IsDeleted = false;
            this.ModifiedDate = DateTime.Now;
            this.CreatedDate = DateTime.Now;
        }

        public void SetUpdateModifier(int userId)
        {
            this.ModifiedDate = DateTime.Now;
        }

        public void SetDeleteModifier(int userId)
        {
            this.ModifiedDate = DateTime.Now;
            this.IsDeleted = true;
        }
    }
}
