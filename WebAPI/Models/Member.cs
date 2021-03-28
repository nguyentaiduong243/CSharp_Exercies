using System;
 
namespace WebAPI.Models
{
    public class Member : Person
    {
        public DateTime StartDate;
        public DateTime EndDate;

        public Member(
            string FirstName,
            string LastName,
            DateTime Dob,
            string Gender,
            string PhoneNumber,
            string BirthPlace,
            bool IsGraduated,
            DateTime StartDate,
            DateTime EndDate
        ) : base(FirstName, LastName, Dob, Gender, PhoneNumber, BirthPlace, IsGraduated)
        {
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }

        override
        public String ToString()
        {
            return 
                "First Name" + this.FirstName +
                "Last Name" + this.LastName +
                " Gender: " + this.Gender +
                " Date of Birth: " + GetDateOfBirth() +
                " Phone Number: " + this.PhoneNumber +
                " Birth Place: " + this.BirthPlace +
                " Is Graduated: " + (this.IsGraduated ? "Yes" : "No") +
                " Start Date: " + this.StartDate.ToString("yyyy/MM/dd") +
                " End Date: " + this.EndDate.ToString("yyyy/MM/dd");
        }
    }
}