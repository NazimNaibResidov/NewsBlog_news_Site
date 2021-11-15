using Microsoft.AspNetCore.Mvc;

namespace NewsBlog.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ImageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
