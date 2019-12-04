using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderWritenew.Events;

namespace OrderWritenew.Models
{
    public abstract class Entity
    {
        private List<IEvents> Changes { get; set; }
        public Entity()
        {
            Changes = new List<IEvents>();
        }

        public IEnumerable<IEvents> GetChanges()
        {
            return Changes.AsEnumerable();
        }

        public void ClearChanges()
        {
            Changes.Clear();
        }

        public void apply(IEvents myEvent)
        {
            when(myEvent);
            CheckValidation();
            Changes.Add(myEvent);
        }

        public abstract void CheckValidation();

        public abstract void when(IEvents myEvent);
        
    }
}
