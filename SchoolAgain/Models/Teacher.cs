using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAgain.Models
{
    public class Teacher
    {
        public Teacher(int id, string fName, string lName, int salary, DateTime birthDate)
        {
            Id = id;
            FName = fName;
            LName = lName;
            Salary = salary;
            BirthDate = birthDate;
        }

        public int Id { get; set; }
        public string FName { get; set; }

        public string LName { get; set; }
        public int Salary { get; set; }
        public DateTime BirthDate { get; set; }
    }
}