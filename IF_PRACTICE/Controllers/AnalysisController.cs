using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IF_PRACTICE.Controllers
{
    public class AnalysisController : Controller
    {
        // GET: Analysis/DiceGame
        public ActionResult DiceGame()
        {
            return View();
        }

        // POST : Analysis/DiceGameResults
        [HttpPost]
        public ActionResult DiceGameResults(int n, int m, int goal)
        {
            J2Controller j2Controller = new J2Controller();

            List<int> standardResults = j2Controller.DiceGameStandard(n, m, goal);

            ViewBag.StandardSolution = standardResults[0];
            ViewBag.StandardSteps = standardResults[1];

            List<int> optimizedResults = j2Controller.DiceGameOptimized(n, m, goal);

            ViewBag.OptimizedSolution = optimizedResults[0];
            ViewBag.OptimizedSteps = optimizedResults[1];

            List<int> optimalResults = j2Controller.DiceGameOptimal(n, m, goal);

            ViewBag.OptimalSolution = optimalResults[0];
            ViewBag.OptimalSteps = optimalResults[1];

            return View();
        }
    }
}