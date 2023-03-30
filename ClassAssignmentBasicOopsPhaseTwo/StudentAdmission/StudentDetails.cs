using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public enum Gender{Select,Male,Female,Transgenger}
    public class StudentDetails
    {

        private static int s_studentID=3000;
        public string StudentID{get;}
        public string StudentName{get;set;}
        public string FatherName{get;set;}
        public DateTime DOB{get;set;}
        public Gender StudentGender{get;set;}
        public int Physics{get;set;}
        public int Chemistry{get;set;}
        public int Maths{get;set;}

        public StudentDetails(string studentName,string fatherName,DateTime dob,Gender gender,int physics,int chemistry,int maths)
        {
            s_studentID++;
            StudentID="SF"+s_studentID;
            StudentName=studentName;
            FatherName=fatherName;
            DOB=dob;
            StudentGender=gender;
            Physics=physics;
            Chemistry=chemistry;
            Maths=maths;
        }

        public bool CheckEligibilty(int total)
        {
            float average=(float)total/3;
            if(average>=75.0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

    

    }
}