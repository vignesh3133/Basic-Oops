using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBBill
{
    public enum MeterType{Select,Commercial,Domestic}
    public enum PaymentStatus{Select,Paid,Unpaid}
    public class EBMeterDetails
    {
        private static int s_entryID=1000;
        public string EntryID { get; }
        public string CustomerID { get; set;}
         public int UnitUsed { get; set; }
        public double BillAmount { get; set; }
        public string BillDate { get; set; }
        public MeterType MeterTarrifType { get; set; }
        public PaymentStatus Status { get; set; }
        public EBMeterDetails(string customerID,int unitUsed,MeterType meter,string billMonth)
        {
            s_entryID++;
            EntryID=""+s_entryID;
            CustomerID=customerID;
            UnitUsed=unitUsed;
            MeterTarrifType=meter;
            BillDate=billMonth;
            Status=PaymentStatus.Unpaid;
            CalculateBill();
        }
        public void CalculateBill()
        {
         if(MeterTarrifType==MeterType.Commercial)
         {
            BillAmount=UnitUsed*5;
         }
         else if(MeterTarrifType==MeterType.Domestic)
         {
            BillAmount=UnitUsed*2.5;
         }
        }
        public void Pay()
        {
            Status=PaymentStatus.Paid;
        }

    }
}