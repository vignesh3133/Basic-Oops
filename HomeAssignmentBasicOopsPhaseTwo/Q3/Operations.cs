using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q3
{
    public class Operations
    {
        public static List<CustomerDetails> customerList = new List<CustomerDetails>();

        public static void MainMenu()
        {
            string result = "YES";
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
                            result = "NO";
                            break;
                        }
                }
            } while (result == "YES");
        }
        public static void Registration()
        {
            Console.WriteLine("enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("enter phone: ");
            long phone = long.Parse(Console.ReadLine());
            Console.WriteLine("enter mailid: ");
            string mailID = Console.ReadLine();
            Console.WriteLine("enter unitsused: ");
            int unitsUsed = int.Parse(Console.ReadLine());

            CustomerDetails customer = new CustomerDetails(name, phone, mailID, unitsUsed);
            customerList.Add(customer);
            Console.WriteLine("the meter id is created successfully" + customer.MeterID);

        }

        public static void Login()
        {
            Console.WriteLine("enter employee id");
            string employeeID = Console.ReadLine();
            foreach (CustomerDetails customer in customerList)
            {
                bool flag=true;
                if (customer.MeterID == employeeID)
                {
                    flag=false;
                    SubMenu();
                }
                if(flag)
                {
                    Console.WriteLine("Invalid meter id");
                }
            }
        }

        public static void SubMenu()
        {
            string answer = "YES";
            do
            {

                Console.WriteLine("select 1.Calculate amount 2.Display user details 3.exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            CalculationAmount();
                            break;
                        }
                    case 2:
                        {
                            UserDetails();
                            break;
                        }
                    case 3:
                        {
                            answer = "NO";
                            break;
                        }
                }
            } while (answer == "YES");
        }

        public static void CalculationAmount()
        {
            foreach (CustomerDetails customer in customerList)
            {
                int amount = customer.CalculateAmount(customer.UnitsUsed);
                Console.WriteLine(customer.Name);
                Console.WriteLine(customer.UnitsUsed);
                Console.WriteLine(amount);
            }
        }
        public static void UserDetails()
        {
            foreach (CustomerDetails customer in customerList)
            {
                Console.WriteLine(customer.MeterID);
                Console.WriteLine(customer.Name);
                Console.WriteLine(customer.Phone);
                Console.WriteLine(customer.MailID);
            }
        }


    }
}