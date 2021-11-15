using AutoMapper;
using NewsBlog.Base.BaseUnitOfWork;
using NewsBlog.Entities.TagEntity;
using NewsBlog.Interfaces.EntitySerivices;

namespace NewsBlog.Services.Entites
{
    public class TagService : CoreService<Tag>, ITagService
    {
        public TagService(IUnitOfWork unitOfWork, IMapper mapper) : base(mapper, unitOfWork)
        {
        }
    }
}