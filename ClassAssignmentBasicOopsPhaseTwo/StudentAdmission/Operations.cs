using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public class Operations
    {
        public StudentDetails currentStudent=null;
        public List<StudentDetails> studentList = new List<StudentDetails>();
        public List<DepartmentDetails> departmentList = new List<DepartmentDetails>();
        public List<AdmissionDetails> admissionList = new List<AdmissionDetails>();


        public void MainMenu()
        {
            string choice="YES";
            do{
            Console.WriteLine("select 1.Registration 2.login 3.departmentwise seats available  4.exit");
            int option=int.Parse(Console.ReadLine());
            switch(option)
            {
                case 1:{
                    Registration();
                    break;
                }
                case 2:{
                    Login();
                    break;
                }
                case 3:{
                    DepartmentWiseSeats();
                    break;
                }
                case 4:{
                    choice="NO";
                    break;
                }
            }
            }while(choice=="YES");

        }

        public void Registration()
        {
            Console.WriteLine("enter student name: ");
            string name=Console.ReadLine();
            Console.WriteLine("enter your  father name");
            string fatherName=Console.ReadLine();

            Console.WriteLine("enter your DOB:");
            DateTime dob=new DateTime(2022,11,02);
            Console.WriteLine($"{dob}");

            Console.WriteLine("enter your  gender");
            Gender studentGender=Enum.Parse<Gender>(Console.ReadLine());
            Console.WriteLine("enter your  physics mark");
            int physics=int.Parse(Console.ReadLine());
            Console.WriteLine("enter your chemistry mark");
            int chemistry=int.Parse(Console.ReadLine());
            Console.WriteLine("enter your maths mark");
            int maths=int.Parse(Console.ReadLine());

            StudentDetails student=new StudentDetails(name,fatherName,dob,studentGender,physics,chemistry,maths);
            studentList.Add(student);
            Console.WriteLine($"Student Registered Successfully and StudentID is {student.StudentID}");
        }

        public void Login()
        {
            Console.WriteLine("enter student id");
            string studentID=Console.ReadLine().ToUpper();
            bool flag=true;
            foreach(StudentDetails student in studentList)
            {
                if(studentID==student.StudentID)
                {
                    Console.WriteLine("logged in successfully");
                    currentStudent=student;
                    flag=false;
                    SubMenu();
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid student id");
            }
        }

        public void SubMenu()
        {
            string answer="YES";
            do
            {
            Console.WriteLine("select a.Check Eligibility\n b.Show Details\n c.Take Admission\n d.Cancel Admission\n e.Show Admission Details\n f.Exit");
            char option=char.Parse(Console.ReadLine());
            switch(option)
            {
                case 'a':
                {
                    CheckEligible();
                    break;
                }
                case 'b':
                {
                    ShowDetails();
                    break;
                }
                case 'c':
                {
                    TakeAdmission();
                    break;
                }
                case 'd':
                {
                    CancelAdmission();
                    break;
                }
                case 'e':
                {
                    ShowAdmissionDetails();
                    break;
                }
                case 'f':
                {
                    answer="NO";
                    break;
                }
            }
            }while(answer=="YES");
        }

        public void CheckEligible()
        {
            int total=currentStudent.Physics+currentStudent.Chemistry+currentStudent.Maths;
            bool result=currentStudent.CheckEligibilty(total);
            if(result)
            {
                Console.WriteLine("You are eligible");
            }
            else
            {
                Console.WriteLine("You are not eligible");
            }

        }

        public void ShowDetails()
        {
            
              Console.WriteLine($"{currentStudent.StudentID} | {currentStudent.StudentName} | {currentStudent.FatherName} | {currentStudent.DOB} | {currentStudent.StudentGender} | {currentStudent.Physics} | {currentStudent.Chemistry} | {currentStudent.Maths}");
            
        }

        public void TakeAdmission()
        {
            foreach(DepartmentDetails department in departmentList)
            {
                Console.WriteLine($"the available departments and seats {department.DepartmentName} | {department.NumberOfSeats}");

            }
            Console.WriteLine("enter department id");
            string deparmentID=Console.ReadLine();
            bool flag=true;
            foreach(DepartmentDetails department in departmentList)
            {
                if(deparmentID==department.DepartmentID)
                {
                    flag=false;
                    int total=currentStudent.Physics+currentStudent.Chemistry+currentStudent.Maths;
                    if(currentStudent.CheckEligibilty(total))
                    {
                        if(department.NumberOfSeats>0)
                        {
                            int count=0;
                            foreach(AdmissionDetails admission in admissionList)
                            {
                                if(currentStudent.StudentID==admission.StudentID && admission.Status==AdmissionStatus.Booked)
                                {
                                    count++;
                                }
                            }
                            if(count==0)
                            {
                                department.NumberOfSeats=department.NumberOfSeats-1;
                                AdmissionDetails admission10 =new AdmissionDetails(currentStudent.StudentID,deparmentID,DateTime.Now,AdmissionStatus.Booked);
                                admissionList.Add(admission10);
                                Console.WriteLine($"Admission took successfully. Your admission ID -{admission10.AdmissionID}");
                            }
                            else
                            {
                                Console.WriteLine("Already Admission taken");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Seats are not available");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not eligible");
                    }

                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid department id");
            }
        }

        public void CancelAdmission()
        {
            bool flag=true;
            foreach(AdmissionDetails admission in admissionList)
            {
                if(currentStudent.StudentID==admission.StudentID && admission.Status==AdmissionStatus.Booked)
                {
                    flag=false;
                    Console.WriteLine($"{admission.Status=AdmissionStatus.Cancelled}");
                    foreach(DepartmentDetails department in departmentList)
                    {
                        if(admission.DepartmentID==department.DepartmentID)
                        {
                            department.NumberOfSeats=department.NumberOfSeats+1;
                        }
                    }
                    Console.WriteLine("admission cancelled successfully");
                }
            }
            if(flag)
            {
                Console.WriteLine("So far no admission taken");
            }
        }

        public void ShowAdmissionDetails()
        {
            bool flag=true;
            foreach(AdmissionDetails admission in admissionList)
            {
                if(admission.StudentID==currentStudent.StudentID)
                {
                    flag=false;
                    Console.WriteLine($"{admission.AdmissionID} | {admission.StudentID} | {admission.DepartmentID} | {admission.AdmissionDate} | {admission.Status}");
                }
            }
            if(flag)
            {
                Console.WriteLine("there is no admission history.");
            }
        }

        public void DepartmentWiseSeats()
        {
            foreach(DepartmentDetails department in departmentList)
            {
                Console.WriteLine($"the seats are {department.DepartmentID} | {department.DepartmentName} | {department.NumberOfSeats}");
            }
        } 


        public void AddDefaultData()
        {
            StudentDetails student=new StudentDetails("Ravichandran E","Ettapparajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
            studentList.Add(student);
            StudentDetails student1=new StudentDetails("Baskaran S","Sethurajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
            studentList.Add(student1);
            DepartmentDetails department =new DepartmentDetails("EEE",29);
            departmentList.Add(department);
            DepartmentDetails department1 =new DepartmentDetails("CSE",29);
            departmentList.Add(department1);
            DepartmentDetails department2 =new DepartmentDetails("MECH",30);
            departmentList.Add(department2);
            DepartmentDetails department3 =new DepartmentDetails("ECE",30);
            departmentList.Add(department3);
            AdmissionDetails admission =new AdmissionDetails("SF3001","DID101",new DateTime(2022,11,5),AdmissionStatus.Booked);
            admissionList.Add(admission);
            AdmissionDetails admission1 =new AdmissionDetails("SF3002","DID102",new DateTime(2022,12,5),AdmissionStatus.Booked);
            admissionList.Add(admission1);
/*
            foreach(StudentDetails student8 in studentList)
            {
                Console.WriteLine($"{student8.StudentName} | {student8.FatherName} | {student8.DOB} | {student8.StudentGender} | {student8.Physics} | {student8.Chemistry} | {student8.Maths}");
            }
            foreach(DepartmentDetails department8 in departmentList)
            {
                Console.WriteLine($"{department8.DepartmentName} | {department8.NumberOfSeats}");
            }
            foreach(AdmissionDetails admission8 in admissionList)
            {
                Console.WriteLine($"{admission8.StudentID} | {admission8.DepartmentID} | {admission8.AdmissionDate} | {admission8.Status}");
            }
            */
        } 

    }
}