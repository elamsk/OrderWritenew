using OrderWritenew.Commands;
using OrderWritenew.Events;
using OrderWritenew.Infra;
using OrderWritenew.Models;
using OrderWritenew.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OrderWritenew.Services
{
    public interface ICommandHandlers
    {
        void HandleCommand(ICommands cmd);
    }
    public class CommandHandlers : ICommandHandlers
    {
        private IOrderRepository _repo;
        private IServiceBusSender _sender;

        public CommandHandlers(IOrderRepository repo, IServiceBusSender sender)
        {
            _repo = repo;
            _sender = sender;
        }
        public void HandleCommand(ICommands cmd)
        {
            switch (cmd)
            {
                case CreateOrder co:
                    CreateOrder command = (CreateOrder)cmd;
                    CustomerName cust = CustomerName.CustomerNameFactory(command.firstName, command.lastName, "hyderabad");
                    Order o = new Order(command.Orderid, cust, command.Orderdate, command.OrderItems);
                    _repo.NewOrder(o);
                    List <IEvents> events = o.GetChanges().ToList();
                    foreach (var e in events)
                    {
                        _sender.SendMessage(e);
                    }

                    break;
                default:
                    break;
            }
        }
    }
}
