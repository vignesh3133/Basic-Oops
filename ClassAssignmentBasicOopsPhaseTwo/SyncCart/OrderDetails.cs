using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncCart
{
    public enum OrderStatus {Default,Ordered,Cancelled}
    public class OrderDetails
    {
          /*Properties: 
•	OrderID (Auto Increment – OID1001)
•	CustomerID
•	ProductID
•	TotalPrice 
•	PurchaseDate
•	Quantity
•	OrderStatus – (Enum- Default, Ordered, Cancelled)
*/
       private static int s_orderID=1000;
       public string OrderID{get;}
       public string CustomerID{get;set;}
       public string ProductID{get;set;}
       public Double TotalPrice{get;set;}
       public DateTime PurchaseDate{get;set;}
       public int Quantity{get;set;}
       public  OrderStatus Status{get;set;}

       public OrderDetails(string customerID,string productID,Double totalPrice,DateTime purchaseDate,int quantity,OrderStatus status )
       {
            s_orderID++;
            OrderID="OID"+s_orderID;
            CustomerID=customerID;
            ProductID=productID;
            TotalPrice=totalPrice;
            PurchaseDate=purchaseDate;
            Quantity=quantity;
            Status=status;

       }
    }
}