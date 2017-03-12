using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Tokiota.BookStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    public class LibraryController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Es6()
        {
            return View();
        }

        public IActionResult Vue()
        {
            return View();
        }
    }
}
