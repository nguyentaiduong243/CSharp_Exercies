using ModelMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelMVC.Repository
{
    public static class MemberList
    {
        static List<Member> memList = null;
        static MemberList()
        {
            memList = new List<Member>()
            {
                new Member()
                {
                    MemberId = 1,
                    FirstName = "Hao",
                    LastName = "Nguyen",
                    Gender = "Name",
                    DateOfBirth = new DateTime(1999,01,01),
                    PhoneNumber ="123456",
                    BirthPlace ="Ha Noi",
                    StartDate = new DateTime(2021,03,22),
                    //RoleId =1
                }
            };
        }

        public static List<Member> SelectMemberList()
        {
            return memList;
        }
        public static void InsertMemberList(Member member)
        {
            memList.Add(member);
        }
        public static void UpdateMemberList(Member member)
        {
            Member memUpdate = memList.Find(x => x.MemberId == member.MemberId);
            memUpdate.FirstName = member.FirstName;
            memUpdate.LastName = member.LastName;
            memUpdate.Gender = member.Gender;
            memUpdate.DateOfBirth = member.DateOfBirth;
            memUpdate.BirthPlace = member.BirthPlace;
            memUpdate.StartDate = member.StartDate;
        }
        public static void DeleteMemberList(int id)
        {
            Member empDelete = memList.Find(x => x.MemberId == id);
            memList.Remove(empDelete);
        }
    }
}
