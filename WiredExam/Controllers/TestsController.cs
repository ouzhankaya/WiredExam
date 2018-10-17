using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WiredExamDomain;
using WiredExamDomain.Models;
using WiredExamServices;

namespace WiredExam.Controllers
{
    public class TestsController : Controller
    {
        private WiredNewsServices wns = new WiredNewsServices();
        private BaseClassContext db = new BaseClassContext();
        // GET: Tests
        public ActionResult Tests()
        {
            List<Exam> dbtests = db.Exams.ToList();
            List<Exam> dbmodel = new List<Exam>();
            foreach (var item in dbtests)
            {
                dbmodel.Add(new Exam()
                {
                    examId = item.examId,
                    description = item.description,
                    title = item.title,
                    userId = item.userId,
                    quetions = db.questions.Where(x => x.examId == item.examId).ToList()
                });
            }
            return View(dbmodel);
        }

        public ActionResult ViewTest(int? examId)
        {
            Exam exam = db.Exams.Where(x => x.examId == examId).FirstOrDefault();
            exam.quetions = db.questions.Where(x => x.examId == examId).ToList();
            return View(exam);
        }

        [HttpPost]
        public ActionResult getJson(Exam e)
        {
            return Json(e.quetions);
        }

    }
}