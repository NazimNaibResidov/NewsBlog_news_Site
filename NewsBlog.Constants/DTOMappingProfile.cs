using AutoMapper;
using NewsBlog.DTO.Category;
using NewsBlog.DTO.Comment;
using NewsBlog.DTO.Images;
using NewsBlog.DTO.News;
using NewsBlog.DTO.NewsType;
using NewsBlog.DTO.Tag;
using NewsBlog.Entities.CategoryEntity;
using NewsBlog.Entities.CommetEntity;
using NewsBlog.Entities.ImageEntity;
using NewsBlog.Entities.NewEntity;
using NewsBlog.Entities.NewsTagEntity;
using NewsBlog.Entities.NewsTypeEntity;
using NewsBlog.Entities.TagEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsBlog.Constants
{
   public class DTOMappingProfile : Profile
    {
        public DTOMappingProfile()
        {
            #region ::Category::
            CreateMap<Category, ListCategoryDTO>().ReverseMap();
            CreateMap<Category, AddCategoryDTO>().ReverseMap();
            CreateMap<Category, DeleteCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            #endregion

            #region ::Comment::
            CreateMap<Comment, ListCommentDTO>().ReverseMap();
            CreateMap<Comment, AddCommentDTO>().ReverseMap();
            CreateMap<Comment, DeleteCommentDTO>().ReverseMap();
            CreateMap<Comment, UpdateCommentDTO>().ReverseMap();
            #endregion

            #region ::Image::
            CreateMap<Image, ListImageDTO>().ReverseMap();
            CreateMap<Image, AddImageDTO>().ReverseMap();
            CreateMap<Image, DeleteImageDTO>().ReverseMap();
            CreateMap<Image, UpdateImageDTO>().ReverseMap();
            #endregion

            #region ::News::
            CreateMap<News, ListNewsDTO>().ReverseMap();
            CreateMap<News, AddNewsDTO>().ReverseMap();
            CreateMap<News, DeleteNewsDTO>().ReverseMap();
            CreateMap<News, UpdateNewsDTO>().ReverseMap();
            #endregion

            #region ::NewsType::
            CreateMap<NewsType, NewsTypeDTO>().ReverseMap();
            CreateMap<NewsType, ListNewsTypeDTO>().ReverseMap();
            CreateMap<NewsType, DeleteNewsTypeDTO>().ReverseMap();
            CreateMap<NewsType, UpdateNewsTypeDTO>().ReverseMap();
            #endregion

            #region ::Tag::
            CreateMap<Tag, TagDTO>().ReverseMap();
            CreateMap<Tag, ListTagDTO>().ReverseMap();
            CreateMap<Tag, DeleteTagDTO>().ReverseMap();
            CreateMap<Tag, UpdateTagDTO>().ReverseMap();
            #endregion





        }
    }
}
