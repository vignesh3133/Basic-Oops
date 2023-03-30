using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBBill
{
    public class UserDetails
    {
         private static int s_customerID=1000;
         public string CustomerID { get; }
        public string Name { get; set; }
        public string Phone { get; set; }
        private double _balance;
        public double Balance{get{return _balance;}}
        public string Address { get; set; }

        public UserDetails(string name,string phone,string address)
        {
            s_customerID++;
            CustomerID="EB"+s_customerID;
            Name=name;
            Phone=phone;
            Address=address;
        }
        public void Recharge(double amount)
        {
          _balance+=amount;
        }
        public void DeductBalance(double amount)
        {
            
            _balance-=amount;
        }
    }
}