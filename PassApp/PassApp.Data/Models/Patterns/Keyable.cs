using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Data.Models.Patterns
{
    public abstract class Keyable : Auditable
    {
        [Key]
        public Guid Id { get; set; }
    }
}
