using NewsBlog.DTO.Category;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog.Interfaces.Facades
{
    public interface ICategoryFacade
    {
        Task AddCategoryAsync(AddCategoryDTO addCategoryFacadeDTO);

        IQueryable<ListCategoryDTO> GetAllCategory();

        Task UpdateCategoryAsync(UpdateCategoryDTO updateCategoryFacadeDTO);

        Task DeleteCategoryAsync(DeleteCategoryDTO deleteCategoryFacadeDTO);

        IQueryable<ListCategoryDTO> GetAllwithIdCategory();
    }
}