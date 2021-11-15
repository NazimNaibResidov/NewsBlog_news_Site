using NewsBlog.Base.BaseUnitOfWork;
using NewsBlog.DTO.Category;
using NewsBlog.Interfaces.EntitySerivices;
using NewsBlog.Interfaces.Facades;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog.Facades.Category
{
    public class CategoryFacade : ICategoryFacade
    {
        private readonly ICategoryService _categoryService;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryFacade(ICategoryService categoryService, IUnitOfWork unitOfWork)
        {
            _categoryService = categoryService;
            _unitOfWork = unitOfWork;
        }

        public async Task AddCategoryAsync(AddCategoryDTO addCategoryFacadeDTO)
        {
            await _categoryService.AddAsync(addCategoryFacadeDTO);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteCategoryAsync(DeleteCategoryDTO deleteCategoryFacadeDTO)
        {
            await _categoryService.DeleteAsync(deleteCategoryFacadeDTO);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<ListCategoryDTO> GetAllwithIdCategory()
        {
            return _categoryService.GetAll()
                .Select(x => new ListCategoryDTO
                {
                    Id = x.Id,
                    Description = x.Description,
                    Name = x.Name
                })
                .AsQueryable();
        }

        public IQueryable<ListCategoryDTO> GetAllCategory()
        {
            return _categoryService.GetAll()
                .Select(x => new ListCategoryDTO
                {
                    Description = x.Description,
                    Name = x.Name
                })
                .AsQueryable();
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDTO updateCategoryFacadeDTO)
        {
            await _categoryService.UpdateAsync(updateCategoryFacadeDTO);
            await _unitOfWork.CommitAsync();
        }
    }
}