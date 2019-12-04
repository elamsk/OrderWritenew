using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using OrderWritenew.Models;

namespace OrderWritenew.Repository
{
    public interface IOrderRepository
    {
        Order GetOrder(int orderid);
        void DeleteOrder(int orderid);
        void NewOrder(Order order);
        IEnumerable<Order> GetAllOrder();
        void UpdateOrder(Order order);
    }

    public class OrderRepository : IOrderRepository
    {

        private OrderDBContext _context;

        public OrderRepository(OrderDBContext context)
        {
            _context = context;
        }

        public void DeleteOrder(int orderid)
        {
            Order o = _context.orders.Where(aa => aa.Orderid == orderid).FirstOrDefault();
            _context.Remove(o);
            _context.SaveChanges();
        }

        public IEnumerable<Order> GetAllOrder()
        {
            IEnumerable<Order> e = _context.orders.ToList();
            return e;
        }

        public Order GetOrder(int orderid)
        {
            Order o = _context.orders.Where(aa => aa.Orderid == orderid).FirstOrDefault();
            return o;
        }

        public void NewOrder(Order order)
        {
            _context.orders.Add(order);
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _context.Entry<Order>(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
