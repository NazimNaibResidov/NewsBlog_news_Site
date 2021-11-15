using AutoMapper;
using NewsBlog.Base.BaseUnitOfWork;
using NewsBlog.Entities.ImageEntity;
using NewsBlog.Interfaces.EntitySerivices;

namespace NewsBlog.Services.Entites
{
    public class ImageService : CoreService<Image>, IImageService
    {
        public ImageService(IUnitOfWork unitOfWork, IMapper mapper) : base(mapper, unitOfWork)
        {
        }
    }
}