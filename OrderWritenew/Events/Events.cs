using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderWritenew.Models;

namespace OrderWritenew.Events
{

    public interface IEvents
    {
        public string EventType { get; set; }
    }

    public class OrderCreated : IEvents
    {
        public int OrderId { get; set; }
        public CustomerName Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderLineItems> OrderItems { get; set; }
        public string EventType { get; set; }
    }


    public class OrderUpdated : IEvents
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        public string EventType { get; set; }
    }
}
