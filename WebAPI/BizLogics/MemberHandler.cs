using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Bizlogics
{
    public class MemberHandler : IMemberHandler
    {
        private List<Member> _listMembers;

        public MemberHandler()
        {
            SeedingDate();
        }
        public List<Member> FilterMemberByBirthPlace(string place)
        {
            var result = _listMembers.Where(x => x.BirthPlace == place).ToList();

            return result;
        }

        public List<Member> FilterMemberByBirthYear(int year)
        {
            var result = _listMembers.Where(x => x.DoB.Year == year).ToList();

            return result;
        }

        public List<Member> FilterMemberByBirthYearGreaterThan(int year)
        {
            var result = _listMembers.Where(x => x.DoB.Year < year).ToList();

            return result;
        }

        public List<Member> FilterMemberByBirthYearLessThan(int year)
        {
            var result = _listMembers.Where(x => x.DoB.Year > year).ToList();

            return result;
        }

        public List<string> GetMemberWithFullNameOnly()
        {
            var result = _listMembers.Select(x => $"(x.FistName + x.LastName)").ToList();

            return result;
        }

        public List<Member> FilterMemberByGender(string gender)
        {
            var result = _listMembers.Where(x => x.Gender == gender).ToList();

            return result;
        }

        public Member ReturnTheOldestMember()
        {
            var minDob = _listMembers.Min(x => x.DoB);
            var result = _listMembers.FirstOrDefault(x => x.DoB == minDob);

            return result;
        }

        private void SeedingDate()
        {
            _listMembers = new List<Member>
            {
                new Member("Thanh", "Le",DateTime.Now.AddYears(-30), "Male", "0123456789","Ha Noi",true,DateTime.Now.AddYears(-10),DateTime.Now.AddYears(5)),
                new Member("Thanh", "Le",DateTime.Now.AddYears(-30), "Male", "0123456789","Ha Noi",true,DateTime.Now.AddYears(-10),DateTime.Now.AddYears(5)),
                new Member("Thanh", "Le",DateTime.Now.AddYears(-30), "Male", "0123456789","Ha Noi",true,DateTime.Now.AddYears(-10),DateTime.Now.AddYears(5)),
                new Member("Thanh", "Le",DateTime.Now.AddYears(-30), "Male", "0123456789","Ha Noi",true,DateTime.Now.AddYears(-10),DateTime.Now.AddYears(5)),
                new Member("Thanh", "Le",DateTime.Now.AddYears(-30), "Male", "0123456789","Ha Noi",true,DateTime.Now.AddYears(-10),DateTime.Now.AddYears(5))
            };
        }

        List<Member> IMemberHandler.AddNewMember(Member member)
        {
            _listMembers.Add(member);
            return _listMembers;
        }
    }
}