using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using webapplicationtest.Models;

namespace webapplicationtest.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(string email, string firstname, string lastname, string password)
        {
            using(var ctx = new UserContext())
            {
                if(ctx.Users.Where(u=>u.email == email).FirstOrDefault() != null)
                {
                    ViewData["Error"] = "User Already Exists!";
                    return View();
                }
                User rgst = new User()
                {
                    email = email,
                    FirstName = firstname,
                    LastName = lastname,
                    pwd = this.ComputeHash(password, new SHA256CryptoServiceProvider())
                };

                ctx.Users.Add(rgst);
                ctx.SaveChanges();
                ViewData["success"] = true;
            }
            return View();
        }

        private string ComputeHash(string input, HashAlgorithm alg)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = alg.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }
    }
}
