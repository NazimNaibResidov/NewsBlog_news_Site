using Microsoft.AspNetCore.Mvc;
using NewsBlog.DTO.News;
using NewsBlog.DTO.NewsType;
using NewsBlog.Facades.Category;
using NewsBlog.Interfaces.Facades;
using System.Threading.Tasks;

namespace NewsBlog.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsTypeController : Controller
    {
        private readonly NewsTypeFacade _newsTypeFacade;

        public NewsTypeController(NewsTypeFacade newsTypeFacade)
        {
            this._newsTypeFacade = newsTypeFacade;
        }
        public IActionResult Index()
        {
            var result = _newsTypeFacade.GetAllNewsType();
            return View(result);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(NewsTypeDTO newsTypeDTO)
        {
            await _newsTypeFacade.AddNewsTypeAsync(newsTypeDTO);
            return View();
        }
    }
}
