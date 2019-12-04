using OrderWritenew.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderWritenew.Models
{

    public enum OrderState
    {
        OrderCreated,
        OrderApproved,
        OrderRejcted,
        OrderFullfilled
    }

    //public class OrderID
    //{
    //    private int orderid;
    //    public OrderID(int Oid)
    //    {
    //        if (Oid == default)
    //        {
    //            throw new Exception("Order id cannot be null");
    //        }
    //    }
    //}
    /// <summary>
    /// Aggrecator
    /// </summary>
    public class Order : Entity
    {
        public override void CheckValidation()
        {
            switch (State)
            {
                case OrderState.OrderCreated:
                    if (Orderid == default)
                    {
                        throw new Exception("Order date should be greater than today");
                    }

                    if (Orderdate < DateTime.Now)
                    {
                        throw new Exception("Order date should be greater than today");
                    }
                    break;
                case OrderState.OrderApproved:
                    break;
                case OrderState.OrderRejcted:
                    break;
                case OrderState.OrderFullfilled:
                    break;
                default:
                    break;
            }

            
        }
        public Order(int orderid,CustomerName cu, DateTime od , List<OrderLineItems> oli)
        {

            apply(new OrderCreated()
            {
                OrderItems = oli,
                OrderId = orderid,
                Customer = cu,
                OrderDate = od,
                EventType = "OrderCreated"
            });
           
            State = OrderState.OrderCreated;
        }

        private Order()
        {

        }

       public void UpdateOrderDate(DateTime odt, int oid)
        {
            apply(new OrderUpdated()
            {
                OrderDate = odt,
                OrderId = oid
            });
            CheckValidation();
        }

        public override void when(IEvents myEvent)
        {
            switch (myEvent.EventType)
            {
                case "OrderCreated":
                    this.Customer = ((OrderCreated)myEvent).Customer;
                    this.Orderdate = ((OrderCreated)myEvent).OrderDate;
                    this.OrderItems = ((OrderCreated)myEvent).OrderItems;
                    this.Orderid = ((OrderCreated)myEvent).OrderId;
                    break;
                case "OrderUpdated":
                    this.Orderdate = ((OrderUpdated)myEvent).OrderDate;
                    this.Orderid = ((OrderUpdated)myEvent).OrderId;
                    break;
                case "OrderRejcted":
                    break;
                case "OrderFullfilled":
                    break;
                default:
                    break;
            }
        }

        public OrderState State { get; set; }
        public int Orderid { get; private set; }
        public CustomerName Customer { get; private set; }
        public DateTime Orderdate { get; private set; }
        public List<OrderLineItems> OrderItems { get; private set; }
    }

    /// <summary>
    /// Value type
    /// </summary>
    public class CustomerName : IEquatable<CustomerName>
    {

        public static CustomerName CustomerNameFactory(string first, string last, string location)
        {
            return new CustomerName(first, last, location);
        }

        public CustomerName(string _first, string _last, string _location)
        {
            if (_first == default)
            {
                throw new Exception("first Name cannot be empty");
            }
            if (_last == default)
            {
                throw new Exception("last Name cannot be empty");
            }
            if (_location == default || _location != "hyderabad")
            {
                throw new Exception("Location cannot be empty and should be hyderbad");
            }
            Firstname = _first;
            Lastname = _last;
            Location = _location;
        }

        private CustomerName()
        {

        }

        public string Firstname { get; private set; }
        public string Lastname { get; set; }
        public string Location { get; set; }

        public bool Equals(CustomerName other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(other, this)) return true;

            return Firstname.Equals(other.Firstname) && Lastname.Equals(other.Lastname) && Location.Equals(other.Location);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;

            return base.Equals((CustomerName)obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(CustomerName left, CustomerName right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CustomerName left, CustomerName right)
        {
            return !Equals(left, right);
        }
    }


    /// <summary>
    /// entity list 
    /// </summary>
    public class OrderLineItems
    {
      //  public int OrderLineItemsId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
