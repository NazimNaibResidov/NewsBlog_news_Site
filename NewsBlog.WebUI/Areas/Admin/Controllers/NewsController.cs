using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsBlog.DTO.Images;
using NewsBlog.DTO.News;
using NewsBlog.Interfaces.Facades;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {
        private readonly INewsFacade _newsFacade;
        private readonly ICategoryFacade _categoryFacade;
        private readonly IImageFacade _imageFacade;
        private readonly INewsTypeFacade _newsTypeFacade;
        private readonly IWebHostEnvironment _env;
        public NewsController(INewsFacade newsFacade, ICategoryFacade categoryFacade, IImageFacade imageFacade, INewsTypeFacade newsTypeFacade, IWebHostEnvironment env)
        {
            _newsFacade = newsFacade;
            _categoryFacade = categoryFacade;
            _imageFacade = imageFacade;
            _newsTypeFacade = newsTypeFacade;
            _env = env;
        }

        public IActionResult Index()
        {
            var result = _newsFacade.GetAllNews();
            return View(result);
        }
        public IActionResult Add()
        {
            ViewBag.cat = _categoryFacade.GetAllwithIdCategory().ToList();
            ViewBag.type = _newsTypeFacade.GetAllNewsWithIdType();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddNewsDTO addNewsDTO)
        {
            var imgId =await Save(addNewsDTO.File);
            if (imgId > 0)
            {
                addNewsDTO.ImageId = imgId;
                addNewsDTO.NewsTime = DateTime.UtcNow;
                addNewsDTO.UserId = "34bbaa6a-23ac-43b7-ff32-08d9a6ffc401";
                
            }
            else
            {
               
                return View();
            }
            
            await _newsFacade.AddNewsAsync(addNewsDTO);

            return RedirectToAction("Index");
        }

        public async  Task<int> Save(IFormFile file)
        {
            int result = 0;
            if (file != null)
            {
                if (file.Length > 0)
                {
                    var uploads = "uploads\\img";
                    
                    var root = _env.WebRootPath;
                    var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
                    var dataPath = Path.Combine(uploads, fileName);
                    var core = Path.Combine(root, uploads, fileName);
                    using (var stream = new FileStream(core, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    AddImageDTO addImageDTO = new AddImageDTO()
                    {
                        Name = fileName,
                        BigPath = dataPath,
                        MidlePath = dataPath,
                        SmallPath = dataPath
                    };
                   
                result=  await  _imageFacade.AddCategoryAsync(addImageDTO);

                }
            }
            return result;
        }
    }
}
