using ModelMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelMVC.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void DeleteMember(int id)
        {
            //throw new NotImplementedException();
            MemberList.DeleteMemberList(id);
        }

        public void InsertMember(Member member)
        {
            //throw new NotImplementedException();
            MemberList.InsertMemberList(member);
        }

        public List<Member> SelectAllEmployees()
        {
            //throw new NotImplementedException();
            return MemberList.SelectMemberList();
        }

        public Member SelectMemberById(int id)
        {
            //throw new NotImplementedException();
            return MemberList.SelectMemberList().Find(x => x.MemberId == id);
        }

        public void UpdateMember(Member member)
        {
            //throw new NotImplementedException();
            MemberList.UpdateMemberList(member);
        }
    }
}
