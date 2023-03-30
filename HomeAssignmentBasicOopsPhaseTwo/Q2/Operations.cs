using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q2
{

    public class Operations
    {
        public static List<EmployeeDetails> employeeList = new List<EmployeeDetails>();
        
        
        public static void MainMenu()
        {
            string answer = "YES";
            do{
            Console.WriteLine("select 1.registration 2.login 3.exit");
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
                        answer = "NO";
                        break;
                    }
            }
        }while(answer=="YES");

        }

    public static void Registration()
    {
        Console.WriteLine("enter the name");
        string name = Console.ReadLine();
        Console.WriteLine("enter the role");
        string role = Console.ReadLine();
        Console.WriteLine("enter worklocation");
        Location workLocation = Enum.Parse<Location>(Console.ReadLine());
        Console.WriteLine("enter a team name");
        string teamName = Console.ReadLine();
        Console.WriteLine("enter the number of workdays");
        int workDays = int.Parse(Console.ReadLine());
        Console.WriteLine("enter number of leaves taken");
        int leaveDays = int.Parse(Console.ReadLine());
        Console.WriteLine("enter gender");
        Gender gender = Enum.Parse<Gender>(Console.ReadLine());

        EmployeeDetails employee = new EmployeeDetails(name, role, workLocation, teamName, workDays, leaveDays, gender);
        employeeList.Add(employee);
        Console.WriteLine("your employeeid is successfully created:"+ employee.EmployeeID);
    }

    public static void Login()
    {
        Console.WriteLine("enter a loginid");
        string loginID = Console.ReadLine();
        foreach (EmployeeDetails employee in employeeList)
        {
            bool flag=true;
            if (employee.EmployeeID == loginID)
            {
                flag=false;
                submenu();
            }
            if(flag)
            {
                Console.WriteLine("Invalid user id");
            }
        
    }
    }

    public static void submenu(){
            string number = "YES";
                do{
                Console.WriteLine("select 1.calculate salary 2.display details 3.exit");
                
                    
                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            {
                                CalculateSalary();
                                break;

                            }
                        case 2:
                            {
                                Displaydetails();
                                break;
                            }
                        case 3:
                            {
                                number = "No";
                                break;
                            }
                    }
                } while (number == "YES");
            }
    

    public static void CalculateSalary()
    {
        foreach (EmployeeDetails employee in employeeList)
        {
            double salary = employee.SalaryCalculation(employee.WorkDays, employee.LeaveDays);
            Console.WriteLine($"The salary is {salary}");
        }
    }

    public static void Displaydetails()
    {
        foreach (EmployeeDetails employee in employeeList)
        {
            Console.WriteLine(employee.EmployeeID);
            Console.WriteLine(employee.Name);
            Console.WriteLine(employee.Role);
            Console.WriteLine(employee.WorkLocation);
            Console.WriteLine(employee.TeamName);
            Console.WriteLine(employee.WorkDays);
            Console.WriteLine(employee.LeaveDays);
            Console.WriteLine(employee.gender);
        }
    }
}
}