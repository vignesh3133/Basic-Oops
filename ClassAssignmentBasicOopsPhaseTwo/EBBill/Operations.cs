using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBBill
{
    public class Operations
    {
        List<UserDetails> userList=new List<UserDetails>();
        List<EBMeterDetails> entryList=new List<EBMeterDetails>();
        public UserDetails currentUser;
        public void MainMenu()
        {
            int option=0;
            do
            {
            Console.WriteLine("Select options\n1.Registration\n2.Login\n3.Entry Reading\n4.Exit");
            option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    {
                        Console.WriteLine("User Registration Form");
                        Registration();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Login Form");
                        Login();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Reading Entry Form");
                        ReadingEntry();
                        break;
                    }
            }
            }while(option<4);
        }
        public void Registration()
        {
            Console.WriteLine("Enter Name: ");
            string name=Console.ReadLine();
             Console.WriteLine("Enter Phone: ");
            string phone=Console.ReadLine();
             Console.WriteLine("Enter Address: ");
            string address=Console.ReadLine();
            UserDetails user=new UserDetails(name,phone,address);
            userList.Add(user);
            Console.WriteLine("Successfully Registered!Your user ID: "+user.CustomerID);
        }
        public void Login()

        {
            Console.WriteLine("Enter Customer ID: ");
            string customerID=Console.ReadLine().ToUpper();
            bool flag=true;
            foreach(UserDetails user in userList)
            {
                if(customerID==user.CustomerID)
                {
                    Console.WriteLine("Login Successful!");
                    currentUser=user;
                    flag=false;
                    SubMenu();
                    break;
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid Customer ID!");
            }
        }

        public void ReadingEntry()
        {
            Console.WriteLine("Enter Customer ID ");
            string customerID=Console.ReadLine();
            Console.WriteLine("Enter unit consumed ");
            int units=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Meter type (Commercial/Domestic)");
            MeterType meter=Enum.Parse<MeterType>(Console.ReadLine(),true);
            /*Console.WriteLine("Enter meter type\n1.Domestic\n2.Commercial");
            int area=int.Parse(Console.ReadLine());
            MeterType meter1=(MeterType)area;*/
            Console.WriteLine("Enter Bill Month-Year ");
            string billMonth=Console.ReadLine();
            EBMeterDetails entry=new EBMeterDetails(customerID,units,meter,billMonth);
            entryList.Add(entry);
            Console.WriteLine("Entry Added Successfully!");
        }
        public void SubMenu()
        {
            int option=0;
            do
            {
                Console.WriteLine("Select Submenu \n1.Recharge\n2.Pay Bill\n3.Payment History\n4.Exit");
                option=int.Parse(Console.ReadLine());
            switch(option)
            {
                case 1:
                {
                    Console.WriteLine("Enter the amount to be recharged ");
                    double amount=double.Parse(Console.ReadLine());
                    currentUser.Recharge(amount);
                    Console.WriteLine("Your Balance: "+currentUser.Balance);
                    break;
                }
                case 2:
                {
                    PayBill();
                    break;
                }
                case 3:
                {
                    PaymentHistory();
                    break;
                }
            }
            }while(option<4);
            
        } 
        public void PayBill()
        {
            foreach(EBMeterDetails entry in entryList)
            {
                if(entry.CustomerID==currentUser.CustomerID && entry.Status==PaymentStatus.Unpaid)
                {
                    Console.Write($"{entry.EntryID}|{entry.CustomerID}|{entry.BillAmount}|{entry.BillDate}");
                    Console.WriteLine($"{entry.MeterTarrifType}|{entry.Status}");
                }
            }
            Console.WriteLine("Enter Reading entry Id to pay ");
            string entryID=Console.ReadLine().ToUpper();
             foreach(EBMeterDetails entry in entryList)
            {
                if(entry.CustomerID==currentUser.CustomerID && entry.Status==PaymentStatus.Unpaid)
                {
                  if(entry.EntryID==entryID)
                  {
                    currentUser.DeductBalance(entry.BillAmount);
                    entry.Status=PaymentStatus.Paid;
                    Console.WriteLine("Bill Paid Successfully!");
                  }
                }
            }

        }
        public void PaymentHistory()
        {
            bool flag=true;
            foreach(EBMeterDetails entry in entryList)
            {
                if(entry.CustomerID==currentUser.CustomerID)
                {
                    flag=false;
                    Console.Write($"{entry.EntryID}|{entry.CustomerID}|{entry.BillAmount}|{entry.BillDate}");
                    Console.WriteLine($"|{entry.MeterTarrifType}|{entry.Status}");
                }
            }
            if(flag)
            {
                Console.WriteLine("You don't have EB Bill History");
            }
        }
    }
}