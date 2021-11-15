using Microsoft.AspNetCore.Mvc;
using NewsBlog.Interfaces.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog.WebUI.ViewComponents.Slider
{
    public class BringSliderViewComponent : ViewComponent
    {
        private INewsFacade _newsFacade;
        public BringSliderViewComponent(INewsFacade newsFacade)
        {
            _newsFacade = newsFacade;
        }
        public IViewComponentResult Invoke()
        {
            var result = _newsFacade.GetAllNews().ToList();
                result.Where(x => x.NewsType == "Manset")
                .OrderByDescending(x => x.NewsTime)
                .Take(10);
            return View(result);
        }
    }
}
