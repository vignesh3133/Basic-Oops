using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncCart
{

    public class Operations
    {
        public CustomerDetails currentCustomer = null;
        public List<CustomerDetails> customerList = new List<CustomerDetails>();
        public List<ProductDetails> productList = new List<ProductDetails>();
        public List<OrderDetails> orderList = new List<OrderDetails>();
        public void MainMenu()
        {
            string answer = "YES";
            do
            {


                Console.WriteLine("select 1.Registration 2.login 3.exit");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            Login();
                            break;
                        }
                    case 3:
                        {
                            answer = "No";
                            break;
                        }

                }
            } while (answer == "YES");
        }

        public void Registration()
        {
            Console.WriteLine("enter customer name");
            string name = Console.ReadLine();
            Console.WriteLine("enter city");
            string city = Console.ReadLine();
            Console.WriteLine("enter mobile");
            string phone = Console.ReadLine();
            Console.WriteLine("enter mailid");
            string mailID = Console.ReadLine();
            Console.WriteLine("enter walletbalance");
            double walletBalance = double.Parse(Console.ReadLine());

            CustomerDetails customer = new CustomerDetails(name, city, phone, mailID, walletBalance);
            customerList.Add(customer);
            Console.WriteLine("the customer id created successfully: " + customer.CustomerID);
        }

        public void Login()
        {
            Console.WriteLine("enter customer id:");
            string customerID = Console.ReadLine();
            bool flag = true;
            foreach (CustomerDetails customer in customerList)
            {
                if (customerID == customer.CustomerID)
                {
                    Console.WriteLine("login created successfully");
                    currentCustomer = customer;
                    flag = false;
                    SubMenu();

                }

            }
            if (flag)
            {
                Console.WriteLine("Invalid customer id");
            }
        }

        public void SubMenu()
        {
            string result = "YES";
            do
            {
                Console.WriteLine("select a.Purchase\n b.Order History \n c.Cancel Order\n d.Wallet Balance \n e.WalletRecharge \n f.Exit");
                char option = char.Parse(Console.ReadLine());
                switch (option)
                {
                    case 'a':
                        {
                            Purchase();
                            break;
                        }
                    case 'b':
                        {
                            OrderHistory();
                            break;
                        }
                    case 'c':
                        {
                            CancelOrder();
                            break;
                        }
                    case 'd':
                        {
                            WalletBalance();
                            break;
                        }
                    case 'e':
                        {
                            WalletRecharges();
                            break;
                        }
                    case 'f':
                        {
                            result = "NO";
                            break;
                        }
                }
            } while (result == "YES");
        }

        public void Purchase()
        {
            Console.WriteLine("the list of product details are");
            foreach (ProductDetails product in productList)
            {
                Console.WriteLine($"{product.ProductID} | {product.Name} | {product.Price} | {product.Stock} | {product.ShippingDuration}");
            }
            Console.WriteLine("enter the product using product id");
            string productID = Console.ReadLine().ToUpper();
            bool flag = true;
            foreach (ProductDetails product in productList)
            {
                if (productID == product.ProductID)
                {
                    flag = false;
                    Console.WriteLine("enter the count");
                    int count = int.Parse(Console.ReadLine());
                    if (count <= product.Stock)
                    {
                        double totalAmount;
                        totalAmount = (product.Price * count) + 50;
                        if (currentCustomer.WalletBalance >= totalAmount)
                        {
                            currentCustomer.DeductBalance(totalAmount);
                            product.Stock = product.Stock - count;
                            OrderDetails order = new OrderDetails(currentCustomer.CustomerID, product.ProductID, totalAmount, DateTime.Now, count, OrderStatus.Ordered);
                            orderList.Add(order);
                            Console.WriteLine("Order Placed Successfully. Order ID:" + currentCustomer.CustomerID);
                        }
                        else
                        {
                            Console.WriteLine("Insufficient Wallet Balance. Please recharge your wallet and do purchase again");
                        }

                    }
                    else
                    {
                        Console.WriteLine($"Required count not available. Current availability is {product.Stock}");
                    }

                }

            }
            if (flag)
            {
                Console.WriteLine("invalid product id");
            }

        }

        public void OrderHistory()
        {
            bool flag = true;
            foreach (OrderDetails order in orderList)
            {
                if (order.CustomerID == currentCustomer.CustomerID)
                {
                    flag = false;
                    Console.WriteLine($"the order history is {order.OrderID} | {order.CustomerID} | {order.ProductID} | {order.TotalPrice} | {order.PurchaseDate} | {order.Quantity} | {order.Status}");

                }

            }
            if (flag)
            {
                Console.WriteLine("There is no order history");
            }
        }

        public void CancelOrder()
        {
            bool flag = true;
            foreach (OrderDetails order in orderList)
            {
                if (currentCustomer.CustomerID == order.CustomerID && order.Status == OrderStatus.Ordered)
                {
                    flag = false;
                    Console.WriteLine($"the orders are {order.CustomerID} | {order.OrderID} | {order.ProductID} | {order.PurchaseDate} | {order.Quantity} | {order.TotalPrice} | {order.Status}");
                }
            }
            if (flag)
            {
                Console.WriteLine("No order history");
            }

            Console.WriteLine("enter orderid");
            string orderID = Console.ReadLine();

            foreach (OrderDetails order in orderList)
            {

                if(orderID==order.OrderID)
                {

                    foreach (ProductDetails product in productList)
                    {
                        if (product.ProductID == order.ProductID)
                        {
                            product.Stock = product.Stock + order.Quantity;
                        }
                    }
                    currentCustomer.WalletRecharge(order.TotalPrice-50);
                    order.Status = OrderStatus.Cancelled;
                    Console.WriteLine($"Order: {order.OrderID} cancelled successfully");
                
                }

            }

        }

        public void WalletBalance()
        {
            Console.WriteLine("current available balance is:");
            Console.WriteLine(currentCustomer.WalletBalance);
        }

        public void WalletRecharges()
        {
            Console.WriteLine("do you want to recharge press YES or NO");
            string option = Console.ReadLine().ToUpper();
            if (option == "YES")
            {
                Console.WriteLine("enter the amount to recharge: ");
                double amount = double.Parse(Console.ReadLine());
                currentCustomer.WalletRecharge(amount);
                Console.WriteLine("the current balance is" + currentCustomer.WalletBalance);
            }

        }
        public void DefaultData()
        {

            CustomerDetails customer = new CustomerDetails("Ravi", "Chennai", "9885858588", "ravi@mail.com", 50000);
            CustomerDetails customer1 = new CustomerDetails("Baskaran", "chennai", "9888475757", "baskaran@mail.com", 60000);
            ProductDetails product = new ProductDetails("Mobile (Samsung)", 10000, 10, 3);
            ProductDetails product1 = new ProductDetails("Tablet (Lenovo)", 15000, 5, 2);
            ProductDetails product2 = new ProductDetails("Camara (Sony)", 20000, 3, 4);
            ProductDetails product3 = new ProductDetails("iPhone", 50000, 5, 6);
            ProductDetails product4 = new ProductDetails("Laptop (Lenovo I3)", 40000, 3, 3);
            ProductDetails product5 = new ProductDetails("HeadPhone (Boat)", 1000, 5, 2);
            ProductDetails product6 = new ProductDetails("Speakers(Boat)", 500, 4, 2);
            OrderDetails order = new OrderDetails("CID1001", "PID101", 20000,new DateTime(2000, 11, 3), 2, OrderStatus.Ordered);
            OrderDetails order1 = new OrderDetails("CID1002", "PID103", 40000, new DateTime(2001, 02, 27), 2, OrderStatus.Ordered);
            customerList.Add(customer);
            customerList.Add(customer1);
            productList.Add(product);
            productList.Add(product1);
            productList.Add(product2);
            productList.Add(product3);
            productList.Add(product4);
            productList.Add(product5);
            productList.Add(product6);
            orderList.Add(order);
            orderList.Add(order1);

            /*   foreach(CustomerDetails customer8 in customerList)
               {
                   Console.WriteLine($"{customer8.Name} | {customer8.City} | {customer8.MobileNumber} | {customer8.EmailID} | {customer8.WalletBalance}");


                }
                foreach(ProductDetails product8 in productList)
                {
                   Console.WriteLine($"{product8.Name} | {product8.Price} | {product8.Stock} | {product8.ShippingDuration}");
                }


               foreach(OrderDetails order8 in orderList)
               {      
                   Console.WriteLine($"{order8.CustomerID} | {order8.ProductID} | {order8.TotalPrice} | {order8.PurchaseDate} | {order8.Quantity} | {order8.Status}");

               }

   */
        }
    }
}