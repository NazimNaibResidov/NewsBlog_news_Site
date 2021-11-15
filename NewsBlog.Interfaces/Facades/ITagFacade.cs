using NewsBlog.DTO.Comment;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog.Interfaces.Facades
{
    public interface ITagFacade
    {
        Task AddCategoryAsync(AddCommentDTO addCommentFacadeDTO);

        IQueryable<ListCommentDTO> GetAllCategory();

        Task UpdateCategoryAsync(UpdateCommentDTO updateCategoryFacadeDTO);

        Task DeleteCategoryAsync(DeleteCommentDTO deleteCategoryFacadeDTO);
    }
}