using ModelMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelMVC.Repository
{
    interface IMemberRepository
    {
        List<Member> SelectAllEmployees();
        Member SelectMemberById(int id);
        void InsertMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(int id);
    }
}
