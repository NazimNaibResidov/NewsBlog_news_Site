using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog.WebUI.Controllers
{
    public class SearchsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Search(string txtsearch)
        {
            return View();
        }
    }
}
