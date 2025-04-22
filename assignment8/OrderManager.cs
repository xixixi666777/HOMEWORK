using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace _3_20_C_
{
    public class OrderManager
    {
        public class Goods
        {
            public int GoodsId { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
        }

        public class Customer
        {
            public int CustomerId { get; set; }
            public string Name { get; set; }
            public string Contact { get; set; }
        }

        public class OrderDetails
        {
            public string OrderId { get; set; }
            public int GoodsId { get; set; }
            public int Quantity { get; set; }
            public Goods Item { get; set; }
            public Order Order { get; set; }
            public double Amount => Item?.Price * Quantity ?? 0;
        }

        public class Order
        {
            public string OrderId { get; set; }
            public int CustomerId { get; set; }
            public Customer Client { get; set; }
            public List<OrderDetails> Details { get; set; } = new List<OrderDetails>();
            public int CompareTo(Order other) => string.Compare(OrderId, other.OrderId, StringComparison.Ordinal);
            public double TotalAmount => Details.Sum(d => d.Amount);
        }

        public class OrderService
        {
            public void AddOrder(Order order)
            {
                using var context = new OrderManagerEF.OrderContext();
                if (context.Orders.Any(o => o.OrderId == order.OrderId))
                    throw new Exception("订单已存在");
                context.Orders.Add(order);
                context.SaveChanges();
            }

            public void RemoveOrder(string orderId)
            {
                using var context = new OrderManagerEF.OrderContext();
                var order = context.Orders.Include(o => o.Details).FirstOrDefault(o => o.OrderId == orderId);
                if (order == null)
                    throw new Exception("订单不存在");
                context.Orders.Remove(order);
                context.SaveChanges();
            }

            public void UpdateOrder(Order newOrder)
            {
                using var context = new OrderManagerEF.OrderContext();
                var oldOrder = context.Orders.Include(o => o.Details).FirstOrDefault(o => o.OrderId == newOrder.OrderId);
                if (oldOrder == null)
                    throw new Exception("订单不存在");
                context.Entry(oldOrder).CurrentValues.SetValues(newOrder);
                oldOrder.Client = newOrder.Client;
                oldOrder.Details.Clear();
                foreach (var detail in newOrder.Details)
                    oldOrder.Details.Add(detail);
                context.SaveChanges();
            }

            public List<Order> QueryOrders(Func<Order, bool> condition)
            {
                using var context = new OrderManagerEF.OrderContext();
                return context.Orders
                    .Include(o => o.Client)
                    .Include(o => o.Details).ThenInclude(d => d.Item)
                    .Where(condition).ToList();
            }

            public void SortOrders(Comparison<Order> comparison = null) { }
        }
    }
}