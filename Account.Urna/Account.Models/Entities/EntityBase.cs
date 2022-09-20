using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Models.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        public virtual int? Id { get; set; }
    }
}
