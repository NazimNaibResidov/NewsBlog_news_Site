using NewsBlog.Base.BaseUnitOfWork;
using NewsBlog.DTO.Images;
using NewsBlog.Interfaces.EntitySerivices;
using NewsBlog.Interfaces.Facades;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog.Facades.Category
{
    public class ImageFacade : IImageFacade
    {
        private readonly IImageService _imageService;
        private readonly IUnitOfWork _unitOfWork;

        public ImageFacade(IImageService imageService, IUnitOfWork unitOfWork)
        {
            _imageService = imageService;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddCategoryAsync(AddImageDTO addImageFacadeDTO)
        {
            var result = await _imageService.AddAsync(addImageFacadeDTO);
            await _unitOfWork.CommitAsync();
            return result.Id;
        }

        public async Task DeleteCategoryAsync(DeleteImageDTO deleteImageFacadeDTO)
        {
            await _imageService.DeleteAsync(deleteImageFacadeDTO);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<ListImageDTO> GetAllCategory()
        {
            return _imageService.GetAll()
                  .Select(x => new ListImageDTO
                  {
                      Name = x.Name,
                      BigPath = x.BigPath,
                      MidlePath = x.MidlePath,
                      SmallPath = x.SmallPath
                  })
                  .AsQueryable();
        }

        public IQueryable<ListImageDTO> GetAllWithIdImage()
        {
            return _imageService.GetAll()
                 .Select(x => new ListImageDTO
                 {
                     Name = x.Name,
                     BigPath = x.BigPath,
                     MidlePath = x.MidlePath,
                     SmallPath = x.SmallPath,
                     Id = x.Id
                 })
                 .AsQueryable();
        }

        public async Task UpdateCategoryAsync(UpdateImageDTO updateImageFacadeDTO)
        {
            await _imageService.UpdateAsync(updateImageFacadeDTO);
            await _unitOfWork.CommitAsync();
        }
    }
}