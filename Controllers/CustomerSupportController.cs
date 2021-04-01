using AgileWorks_TestToo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgileWorks_TestToo.Controllers
{
    //tagasiside branch, et saaks teha pull requesti
    public class CustomerSupportController : Controller
    {
        public static List<Problem> ProblemList = new List<Problem>();
        public List<Problem> sortProblems()
        {
            return ProblemList.OrderByDescending(x => x.CompletionTime).ToList();
        }
        
        public ActionResult Index()
        {
            return View("Index",sortProblems());
        }
        

        [HttpPost]
        public ActionResult AddProblem(string problem, DateTime completionTime)
        {
            try
            {
                ProblemList.Add(new Problem() { Description = problem, CompletionTime = completionTime, InputTime = DateTime.Now });
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult RemoveProblem(DateTime issueTime)
        {
            try
            {
                // inputtime and issuetime seemingly have same value, but have difference in ticks
                //converting to ticks and dividing by 10000000 shows if values are same in seconds

                // in real world deleting should be managed by identificators like problemId, but per instructions of test task I used time to identify what should be deleted
                var findProblem =ProblemList.First(x=>x.InputTime.Ticks/10000000 == issueTime.Ticks / 10000000);
                ProblemList.Remove(findProblem); 
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
            return RedirectToAction("Index");

        }

    }
}