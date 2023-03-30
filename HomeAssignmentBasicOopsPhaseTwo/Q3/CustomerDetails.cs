using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q3
{
    public class CustomerDetails
    {
        private static int s_meterID=1001;
        public string MeterID{get;}
        public string Name{get;set;}
        public long Phone{get;set;}
        public string MailID{get;set;}
        public int UnitsUsed{get;set;}


        public CustomerDetails(string name,long phone,string mailID,int unitsUsed)
        {
            s_meterID++;
            MeterID="EB"+s_meterID;
            Name=name;
            Phone=phone;
            MailID=mailID;
            UnitsUsed=unitsUsed;
        }

        public int CalculateAmount(int unitsUsed)
        {
            int amount=unitsUsed*5;
            return amount;
        }

    }
}