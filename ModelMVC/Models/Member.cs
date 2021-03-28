using System;
using System.Collections.Generic;

namespace ModelMVC.Models{
    public class Member{
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public string Gender{get;set;}
        public DateTime DoB{get;set;}
        public string PhoneNumber{get;set;}
        public string BirthPlace{get;set;}
        public Boolean IsGraduated{get;set;}
        public DateTime StartDate{get;set;}
        public DateTime EndDate{get;set;}

        public Member(){}

        public Member(string FirstName, string LastName, string BirthPlace, DateTime DoB, string Gender,Boolean IsGraduated, string PhoneNumber, DateTime StartDate, DateTime EndDate){
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.BirthPlace = BirthPlace;
            this.DoB = DoB;
            this.Gender = Gender;
            this.IsGraduated = IsGraduated;            
            this.PhoneNumber = PhoneNumber;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }
    }
}