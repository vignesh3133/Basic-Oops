using System;
using System.Collections.Generic;
namespace StudentAdmission;   //File scoped
class Program
{
    
    public static void Main(string[] args)
    {
         Operations operate= new Operations();
         operate.AddDefaultData();
         operate.MainMenu();
    } 

}