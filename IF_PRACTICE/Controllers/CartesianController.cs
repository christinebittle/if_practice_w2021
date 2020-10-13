using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IF_PRACTICE.Controllers
{
    public class CartesianController : Controller
    {
        // GET: Cartesian
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LineShow(int x1, int x2, int y1, int y2)
        {
            IfPracticeController Controller = new IfPracticeController();

            int quadrants = Controller.LineQuadrant(x1,x2,y1,y2);
            int boundX = Controller.GetScale(x1, x2);
            int boundY = Controller.GetScale(y1, y2);

            int bound = Math.Max(boundX, boundY);

            ViewBag.quadrants = quadrants;
            ViewBag.boundX = bound;
            ViewBag.boundY = bound;
            ViewBag.x1 = x1;
            ViewBag.y1 = y1;
            ViewBag.x2 = x2;
            ViewBag.y2 = y2;

            return View();
        }
    }
}