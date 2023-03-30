using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q2
{
    public enum Location{Select,Chennai,Bangalore}
    public enum Gender{Select,Male,Female}
    public class EmployeeDetails
    {
        private static int s_employeeID=1001;
        public string EmployeeID{get;}
        public string Name{get;set;}
        public string Role{get;set;}
        public Location WorkLocation{get;set;}
        public string TeamName{get;set;}
        public int WorkDays{get;set;}
        public int LeaveDays{get;set;}
        public Gender gender{get;set;}

        public EmployeeDetails(string name,string role,Location workLocation,string teamName,int workDays,int leaveDays,Gender gender)
        {
            s_employeeID++;
            EmployeeID="SF"+s_employeeID;
            Name=name;
            Role=role;
            WorkLocation=workLocation;
            TeamName=teamName;
            WorkDays=workDays;
            LeaveDays=leaveDays;
        }

       public double SalaryCalculation(int workDays,int leaveDays )
       {
            double salary=(workDays-leaveDays)*500;
            return salary;
       }



        
    }
}