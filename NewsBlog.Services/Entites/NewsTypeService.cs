using AutoMapper;
using NewsBlog.Base.BaseUnitOfWork;
using NewsBlog.Entities.NewsTypeEntity;
using NewsBlog.Interfaces.EntitySerivices;

namespace NewsBlog.Services.Entites
{
    public class NewsTypeService : CoreService<NewsType>, INewsTypeService
    {
        public NewsTypeService(IUnitOfWork unitOfWork, IMapper mapper) : base(mapper, unitOfWork)
        {
        }
    }
}