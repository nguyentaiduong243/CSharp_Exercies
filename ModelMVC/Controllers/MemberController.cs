using ModelMVC.Models;
using ModelMVC.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelMVC.Controllers
{
    public class MemberController : Controller
    {
        MemberRepository rep = new MemberRepository();
        // GET: MemberController
        public ActionResult Index()
        {
            IEnumerable<Member> obj = rep.SelectAllEmployees();
            return View(obj); 
        }

        // GET: MemberController/Details/5
        public ActionResult Details(int id)
        {
            Member obj = rep.SelectMemberById(id);
            return View(obj);
        }
        [Authorize("Admin")]
        // GET: MemberController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member)
        {
            try
            {
                rep.InsertMember(member);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize("Admin")]
        // GET: MemberController/Edit/5
        public ActionResult Edit(int id)
        {
            Member obj = rep.SelectMemberById(id);
            return View(obj);
        }

        // POST: MemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Member member)
        {
            try
            {
                rep.UpdateMember(member);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize("Admin")]
        // GET: MemberController/Delete/5
        public ActionResult Delete(int id)
        {
            Member obj = rep.SelectMemberById(id);
            return View(obj);
        }

        // POST: MemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                rep.DeleteMember(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
