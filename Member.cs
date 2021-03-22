using System;
using System.Collections.Generic;

namespace Members 
{
    public class Members : Persons
    {
        public string firstName { get; set;}
        public string lastName { get; set;}
        public string gender { get; set;}
        public DateTime dateOfBirth { get; set;}
        public int phoneNum { get; set;}
        public string birthPalce { get; set;}
        public int age { get; set;}
        public bool isGraduated { get; set;}

        public Members (String firstName, String lastName, String gender, DateTime dateOfBirth, 
                        int phoneNumm, String birthPalce, int Age, bool isGraduated,
                        DateTime startDate, DateTime endDate) : base( startDate, endDate)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.dateOfBirth = dateOfBirth;
            this.phoneNum = phoneNum;
            this.birthPalce =  birthPalce;
            this.age = age;
            this.isGraduated = isGraduated;

        }

        public override void Input()
        {
            Console.WriteLine("Enter first name: ");
            firstName = Console.ReadLine();
            Console.WriteLine("Enter last name: ");
            lastName = Console.ReadLine();
            Console.WriteLine("Enter gender: ");
            gender = Console.ReadLine();
            Console.WriteLine("Enter date of birth: ");
            dateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter phone number: ");
            phoneNum = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter birth place: ");
            birthPalce = Console.ReadLine();
            Console.WriteLine("Enter age: ");
            age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter graduated(Yes/No): ");
            isGraduated = Boolean.Parse(Console.ReadLine());
            base.Input();
            
        }

        public override void Display()
        {
            Console.WriteLine("First Name: " + firstName);
            Console.WriteLine("Last Name: " + lastName);
            Console.WriteLine("Gender: " + gender);
            Console.WriteLine("Date of Birthe: " + dateOfBirth);
            Console.WriteLine("Phone Number: " + phoneNum);
            Console.WriteLine("Birth Place: " + birthPalce);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("Graduated: " + isGraduated);
            base.Display();
            
        }
    }
}

