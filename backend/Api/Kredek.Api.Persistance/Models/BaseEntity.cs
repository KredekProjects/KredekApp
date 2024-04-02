using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kredek.Api.Persistance.Models;

public abstract class BaseEntity
{
    public virtual DateTime CreatedAt { get; set; }
    public virtual DateTime ModifiedAt { get; set; }
}
