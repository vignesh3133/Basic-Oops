using System;
namespace SyncCart;
    class Program{
        public static void Main(string[] args)
        {
            Operations operation=new Operations();
            operation.DefaultData();
            operation.MainMenu();
        }
}
