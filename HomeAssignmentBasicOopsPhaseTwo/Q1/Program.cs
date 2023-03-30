using System;
using System.Collections.Generic;
namespace Q1;

    class Program
    {
        public static void Main(string[] args)
        {
            List<CustomerDetails> customerList = new List<CustomerDetails>();
            string choice = "YES";
            do
            {
                Console.WriteLine("user to select 1. Registration or 2. Login 3. Exit");

                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    //repeating the process for n number of customers
                    case 1:
                        {



                            Console.WriteLine("enter customer name");
                            string name = Console.ReadLine();
                            Console.WriteLine("enter a balance");
                            int balance=int.Parse(Console.ReadLine());

                            Console.WriteLine("enter a gender");
                            Gender gender =Enum.Parse<Gender>(Console.ReadLine());
                            Console.WriteLine("enter your phone number");
                            long phone = long.Parse(Console.ReadLine());
                            Console.WriteLine("enter your Mail id");
                            String mailId = Console.ReadLine();
                            Console.WriteLine("enter a date(dd/MM/yyyy): ");
                            DateTime dob;
                            // DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                            bool temp1 = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob);
                            while (!temp1)
                            {
                                Console.WriteLine("entered wrong date.enter again");
                                temp1 = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob);
                            }

                            CustomerDetails customer = new CustomerDetails(name,balance, gender, phone, mailId, dob);
                            //Adding the object to list
                            customerList.Add(customer);
                            Console.WriteLine($" customer added successfully. customer ID:{customer.CustomerID}");
                            break;

                        }





                    case 2:
                        {
                            
                            Console.WriteLine("enter the customerid to login");
                            string loginID = Console.ReadLine().ToUpper();
                            bool flag = true; // if flag true id is not found
                            foreach (CustomerDetails customer1 in customerList)
                            {
                                // checking the login id
                                if (customer1.CustomerID == loginID)
                                {
                                    flag = false;// reinitalizing to false
                                    string answer="YES";
                                    do{
                                    Console.WriteLine("user to select press 1. Deposit, 2. withdraw, 3.balance check 4. exit");

                                    int option1 = int.Parse(Console.ReadLine());
                                    

                                    switch (option1)
                                    {
                                        case 1:
                                            {
                                                Console.WriteLine("enter deposit amount");
                                                int deposit = int.Parse(Console.ReadLine());
                                                int currentBalance = customer1.add(deposit,customer1.Balance);
                                                Console.WriteLine($"your current balance is {currentBalance}");
                                                break;
                                            }
                                        case 2:
                                            {
                                                Console.WriteLine("enter withdraw amount");
                                                int withdraw = int.Parse(Console.ReadLine());
                                                if (withdraw <= customer1.Balance)
                                                {
                                                    int currentBalance = customer1.sub(withdraw,customer1.Balance);
                                                    Console.WriteLine($"your current balance is {currentBalance}");

                                                }
                                                break;
                                            }
                                        case 3:
                                            {

                                                Console.WriteLine($"your current balance is {customer1.Balance}");
                                                break;
                                            }
                                        case 4:
                                            {
                                                answer = "NO";
                                                break;
                                            }
                                    }
                                    
                                    }while(answer=="YES");

                                }
                                if (flag)
                                {
                                    Console.WriteLine("invalid student id");
                                }

                            }
                            break;
                        }
                    case 3:
                        {
                            choice="NO";
                            break;
                        }

                }
             

            } while (choice == "YES") ;
        }
    }
