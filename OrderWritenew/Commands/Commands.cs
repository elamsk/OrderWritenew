using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderWritenew.Models;

namespace OrderWritenew.Commands
{
    public interface ICommands
    {

    }
    
    public class CreateOrder : ICommands
    {
        public int Orderid { get;  set; }
        public string firstName { get;  set; }
        public string lastName { get; set; }
        public DateTime Orderdate { get;  set; }
        public List<OrderLineItems> OrderItems { get;  set; }
    }
}
