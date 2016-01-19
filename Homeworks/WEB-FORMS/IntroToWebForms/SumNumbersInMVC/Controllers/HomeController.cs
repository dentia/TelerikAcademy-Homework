namespace SumNumbersInMVC.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index(int? sum)
        {
            this.ViewBag.Sum = sum;
            return this.View();
        }
        
        public ActionResult Sum(int sumA, int sumB)
        {
            return this.RedirectToAction("Index", new { sum = sumA + sumB });
        }
    }
}