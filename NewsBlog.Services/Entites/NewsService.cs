using AutoMapper;
using NewsBlog.Base.BaseUnitOfWork;
using NewsBlog.Entities.NewEntity;
using NewsBlog.Interfaces.EntitySerivices;

namespace NewsBlog.Services.Entites
{
    public class NewsService : CoreService<News>, INewsService
    {
        public NewsService(IUnitOfWork unitOfWork, IMapper mapper) : base(mapper, unitOfWork)
        {
        }
    }
}