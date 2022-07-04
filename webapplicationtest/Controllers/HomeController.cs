using Microsoft.AspNetCore.Mvc;

namespace webapplicationtest.Controllers
{
    public class HomeController : Controller
    {
        // [Route("/Home/Calculator/{?id}")]
        public IActionResult Index() // (int? id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(int partOne, char operand, int partTwo)
        {
            switch (operand)
            {
                case '+':
                    ViewData["result"] = partOne + partTwo;
                    break;
                case '-':
                    ViewData["result"] = partOne - partTwo;
                    break;
                case '/':
                    ViewData["result"] = (float) partOne / (float) partTwo;
                    break;
                case '*':
                    ViewData["result"] = partOne * partTwo;
                    break;
                case '%':
                    ViewData["result"] = partOne % partTwo;
                    break;
            }

            ViewData["partOne"] = partOne;
            ViewData["partTwo"] = partTwo;
            ViewData["operand"] = operand;
            return View();
        }
    }
}
