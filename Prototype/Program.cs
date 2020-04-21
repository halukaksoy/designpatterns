using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderManager orderManager = new OrderManager();
            var order1 = orderManager.CreateOrder(1, DateTime.Now, OrderType.Sales);
            var order2 = (Order)order1.Clone();
            order2.Id = 2;
            if (order1.Id == order2.Id)
            {
                Console.WriteLine("Equal");
            }
            else
            {
                Console.WriteLine("NotEqual");
            }
            Console.ReadLine();
        }
    }
    //Abstract Prototype
    abstract class OrderPrototype
    {
        public abstract OrderPrototype Clone();
    }
    enum OrderType
    {
        Sales,
        Purchase
    }
    class Order : OrderPrototype
    {
        private int _id;
        private DateTime _orderDate;
        private OrderType _orderType;
        public Order(int id, DateTime orderDate, OrderType orderType)
        {
            _id = id;
            _orderDate = orderDate;
            _orderType = orderType;
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public override OrderPrototype Clone()
        {
            return this.MemberwiseClone() as OrderPrototype;
        }
    }

    class OrderManager
    {
        public Order CreateOrder(int id, DateTime orderDate, OrderType orderType)
        {
            return new Order(id, orderDate, orderType);
        }
    }
}
