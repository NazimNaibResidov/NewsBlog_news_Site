using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NewsBlog.Facades.Category;
using NewsBlog.Interfaces.Facades;
using System;
using System.IO;

namespace NewsBlog.Extensions
{
    public static class SaveImage
    {
      
    }
    public static class FacadesInjection
    {
        public static void FacadeInjectionExtenrions(this IServiceCollection services)
        {
            services.AddTransient<ICategoryFacade, CategoryFacade>();
            services.AddTransient<ICommentFacade, CommentFacade>();
            services.AddTransient<IImageFacade, ImageFacade>();
            services.AddTransient<INewsFacade,NewsFacade>();
            services.AddTransient<INewsTypeFacade, NewsTypeFacade>();
            services.AddTransient<ITagFacade, TagFacade>();
            services.AddTransient<INewsTypeFacade, NewsTypeFacade>();
        }
    }
}