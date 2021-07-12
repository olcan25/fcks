using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity.Abstract
{
    public abstract class BaseEntity
    {
        public DateTime? Created { get; set; } = DateTime.Now;
        public DateTime? Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
    }
}
