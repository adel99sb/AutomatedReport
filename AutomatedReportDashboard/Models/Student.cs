using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string FatherName { get; set; }
        public string FatherPhoneNumber { get; set; }
        public string MotherName { get; set; }
        public string MotherPhoneNumber { get; set; }
        public double TotalFee { get; set; }
        public string FatherOrMother { get; set; }
        public bool IsFather { get; set; }
        public double agreedMonthlyPayment { get; set; }
        public double Avg { get; set; }
        public Guid? DivisionId { get; set; } = Guid.Empty;
        public string? DivisionName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
    }
}
