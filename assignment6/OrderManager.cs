

namespace _3_20_C_
{
    

    internal class OrderManager
    {
        // 商品类
        public class Goods
        {
            public string Name { get; set; }
            public double Price { get; set; }

            public override string ToString() => $"商品:{Name} 单价:{Price}";
        }

        // 客户类
        public class Customer
        {
            public string Name { get; set; }
            public string Contact { get; set; }

            public override string ToString() => $"客户:{Name} 联系方式:{Contact}";
        }

        // 订单明细类
        public class OrderDetails
        {
            public Goods Item { get; set; }
            public int Quantity { get; set; }
            public double Amount => Item.Price * Quantity;

            public override bool Equals(object obj) =>
                obj is OrderDetails detail &&
                detail.Item.Name == Item.Name;

            public override string ToString() => $"{Item} 数量:{Quantity} 小计:{Amount}";
        }

        // 订单类
        public class Order : IComparable<Order>
        {
            public string OrderId { get; set; }
            public Customer Client { get; set; }
            public List<OrderDetails> Details { get; } = new List<OrderDetails>();
            public double TotalAmount => Details.Sum(d => d.Amount);

            public override bool Equals(object obj) =>
                obj is Order order && order.OrderId == OrderId;

            public int CompareTo(Order other) => OrderId.CompareTo(other.OrderId);

            public override string ToString() =>
                $"订单号:{OrderId}\n{Client}\n明细:\n{string.Join("\n", Details)}\n总计:{TotalAmount}\n";
        }
        public class OrderService
        {
            private List<Order> orders = new List<Order>();

            // 添加订单
            public void AddOrder(Order order)
            {
                if (orders.Contains(order))
                    throw new Exception("订单已存在");
                orders.Add(order);
            }

            // 删除订单
            public void RemoveOrder(string orderId)
            {
                var order = orders.FirstOrDefault(o => o.OrderId == orderId);
                if (order == null)
                    throw new Exception("订单不存在");
                orders.Remove(order);
            }

            // 修改订单
            public void UpdateOrder(Order newOrder)
            {
                var index = orders.FindIndex(o => o.OrderId == newOrder.OrderId);
                if (index < 0)
                    throw new Exception("订单不存在");
                orders[index] = newOrder;
            }

            // 查询订单（LINQ实现）
            public List<Order> QueryOrders(Func<Order, bool> condition) =>
                orders.Where(condition).OrderBy(o => o.TotalAmount).ToList();

            // 排序方法
            public void SortOrders(Comparison<Order> comparison = null) =>
                orders.Sort(comparison ?? ((x, y) => x.CompareTo(y)));
        }
        class Program
        {
            static void Main()
            {
                var service = new OrderService();

                // 示例数据
                var goods1 = new Goods { Name = "手机", Price = 3999 };
                var goods2 = new Goods { Name = "耳机", Price = 299 };
                var customer = new Customer { Name = "张三", Contact = "13800138000" };

                var order1 = new Order { OrderId = "001", Client = customer };
                order1.Details.Add(new OrderDetails { Item = goods1, Quantity = 1 });
                order1.Details.Add(new OrderDetails { Item = goods2, Quantity = 2 });

                // 添加订单
                service.AddOrder(order1);

                // 查询示例
                var results = service.QueryOrders(o =>
                    o.OrderId == "001" ||
                    o.Details.Any(d => d.Item.Name.Contains("手机")));

                results.ForEach(Console.WriteLine);
            }
        }
    }

}
