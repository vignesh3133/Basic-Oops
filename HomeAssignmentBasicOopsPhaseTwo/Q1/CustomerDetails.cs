using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q1
{
    public enum Gender{Select,Male,Female}
    public class CustomerDetails
    {
        private static int s_customerID=1000;
        public string CustomerID{get;}
        public string Name { get; set; }
        public int Balance{get;set;}
        public Gender Gender { get; set; }
        public long Phone { get; set; }

        public string MailID { get; set; }
        public DateTime DOB { get; set; }

        public CustomerDetails(string name,int balance,Gender gender, long phone, string mailID,DateTime dob)
        {
            //incrementing id and assign to property
            //s_studentID++;
            //studentID ="SID"+s_studentID;
            // assigning
            s_customerID++;
            CustomerID="HDFC"+s_customerID; 
            Name = name;
            Balance=balance;
            Gender = gender;
            Phone = phone;
            MailID = mailID;
            DOB = dob;
        }


        //method creating
        public int add(int deposit,int balance)
        {
            return balance+=deposit;
        }

        public int sub(int withdraw,int balance)
        {
            return balance-=withdraw;
        }



    }
}