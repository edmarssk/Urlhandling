using System;
using System.Collections.Generic;
using System.Text;

namespace UrlHandling.Business.Models
{
    public abstract class Entity
    {
        public Guid Id { set; get; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}