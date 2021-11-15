using NewsBlog.DTO.Images;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog.Interfaces.Facades
{
    public interface IImageFacade
    {
        Task<int> AddCategoryAsync(AddImageDTO addImageFacadeDTO);

        IQueryable<ListImageDTO> GetAllCategory();

        IQueryable<ListImageDTO> GetAllWithIdImage();

        Task UpdateCategoryAsync(UpdateImageDTO updateImageFacadeDTO);

        Task DeleteCategoryAsync(DeleteImageDTO deleteImageFacadeDTO);
    }
}