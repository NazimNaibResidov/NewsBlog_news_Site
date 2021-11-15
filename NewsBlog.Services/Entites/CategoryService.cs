using AutoMapper;
using NewsBlog.Base.BaseUnitOfWork;
using NewsBlog.Entities.CategoryEntity;
using NewsBlog.Interfaces.EntitySerivices;

namespace NewsBlog.Services.Entites
{
    public class CategoryService : CoreService<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper) : base(mapper, unitOfWork)
        {
        }
    }
}