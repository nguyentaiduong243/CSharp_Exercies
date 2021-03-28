using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Bizlogics;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private IMemberHandler _memberHandler;
        public MemberController(IMemberHandler memberHandler)
        {
            _memberHandler = memberHandler;
        }

        [HttpGet]
        [Route("/api/member/memberbygender/{gender}")]
        public List<Member> FilterMemberByGender(string gender)
        {
            return _memberHandler.FilterMemberByGender(gender);
        }
        [HttpGet]
        [Route("/api/member/memberbybirthplace/{gender}")]
        public List<Member> FilterMemberByBirthPlace(string place)
        {
            return _memberHandler.FilterMemberByBirthPlace(place);
        }
        [HttpGet]
        [Route("/api/member/memberbybirthyear/{gender}")]
        public List<Member> FilterMemberByBirthYear(int year)
        {
            return _memberHandler.FilterMemberByBirthYear(year);
        }
        [HttpGet]
        [Route("/api/member/memberbybirthyearthan/{gender}")]
        public List<Member> FilterMemberByBirthYearGreaterThan(int year)
        {
            return _memberHandler.FilterMemberByBirthYearGreaterThan(year);
        }
        [HttpGet]
        [Route("/api/member/memberbybirthyearless/{gender}")]
        public List<Member> FilterMemberByBirthYearLessThan(int year)
        {
            return _memberHandler.FilterMemberByBirthYearLessThan(year);
        }
        [HttpGet]
        [Route("/api/member/memberbyfullnameonly/{gender}")]
        public List<string> GetMemberWithFullNameOnly()
        {
            return _memberHandler.GetMemberWithFullNameOnly();
        }
        [HttpGet]
        [Route("/api/member/memberbyoldestmember/{gender}")]
        public Member ReturnTheOldestMember()
        {
            return _memberHandler.ReturnTheOldestMember();
        }

        [HttpPost]
        public List<Member> Post(Member member)
        {
            return _memberHandler.AddNewMember(member);
        }
    }
}