using System;
using System.Collections.Generic;
using WebAPI.Bizlogics;
using WebAPI.Models;

namespace WebAPI.Bizlogics
{
    public interface IMemberHandler
    {
        //1. Return list member who is male
        List<Member> FilterMemberByGender(string gender);
        //2. Return the oldest member
        Member ReturnTheOldestMember();
        //3. Return full name
        List<string> GetMemberWithFullNameOnly();
        //4.1 Return a list of member who has birth year is 2000
        List<Member> FilterMemberByBirthYear(int year);
        //4.2 Return a list of member who has birth year greater than 2000
        List<Member> FilterMemberByBirthYearGreaterThan(int year);
        //4.1 Return a list of member who has birth year less than 2000
        List<Member> FilterMemberByBirthYearLessThan(int year);
        //5. Return list member who born in HN
        List<Member> FilterMemberByBirthPlace(string place);
        //6. Add new member to class
        List<Member> AddNewMember(Member member);
    }
}