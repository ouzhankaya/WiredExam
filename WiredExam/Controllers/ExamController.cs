using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WiredExamDomain;
using WiredExamDomain.Models;
using WiredExamServices;

namespace WiredExam.Controllers
{
    public class ExamController : Controller
    {
        private WiredNewsServices wns = new WiredNewsServices();
        private BaseClassContext db = new BaseClassContext();
        // GET: Exam
        public ActionResult Index(UserProfile userProfile)
        {
            if (userProfile != null)
            {
                //news ekle
                if (wns.saveNews())
                {
                    List<articles> articles = wns.getNews();
                    Exam e = new Exam()
                    {
                        articles = articles,
                        userId = userProfile.userId
                    };
                    return View(e);
                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpPost]
        public ActionResult Exam(Exam e)
        {
            try
            {
                if (e != null)
                {
                    db.Exams.Add(e);
                    db.SaveChanges();
                    return Json(new { Success = true });
                }
                else
                {

                    return Json(new { Success = false });
                }
            }
            catch (Exception)
            {
                return Json(new { Success = false });
            }
          
        }

        public ActionResult MyExam()
        {
            return View(db.Exams.ToList());
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exam exam = db.Exams.Find(id);
            db.Exams.Remove(exam);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}