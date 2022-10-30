using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class AuditableBaseEntity
    {
        public virtual int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }

}
