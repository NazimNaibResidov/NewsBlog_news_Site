using Microsoft.AspNetCore.Mvc;
using NewsBlog.Interfaces.Facades;
using NewsBlog.DTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryFacade categoryFacade;

        public CategoryController(ICategoryFacade categoryFacade)
        {
            this.categoryFacade = categoryFacade;
        }

        public IActionResult Index()
        {
            var result = categoryFacade.GetAllCategory()
                .ToList();
            return View(result);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryDTO addCategoryDTO)
        {
            await categoryFacade.AddCategoryAsync(addCategoryDTO);
            return RedirectToAction("Index");
        }
    }

}
