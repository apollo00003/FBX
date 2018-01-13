using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaliczenie_ld_308.Entities
{
    class SimpleEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreationDateTime { get; set; }
        public virtual DateTime ModificationDateTime { get; set; }
        public virtual bool IsDeleted { get; set; }

        public SimpleEntity()
        {
            this.CreationDateTime = new DateTime();
            this.CreationDateTime = new DateTime();
            this.IsDeleted = false;
            this.Id = 0;
        }
    }
}
