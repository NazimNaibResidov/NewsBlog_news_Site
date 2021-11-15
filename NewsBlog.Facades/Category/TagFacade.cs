using NewsBlog.DTO.Comment;
using NewsBlog.Interfaces.Facades;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog.Facades.Category
{
    public class TagFacade : ITagFacade
    {
        public Task AddCategoryAsync(AddCommentDTO addCommentFacadeDTO)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteCategoryAsync(DeleteCommentDTO deleteCategoryFacadeDTO)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<ListCommentDTO> GetAllCategory()
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateCategoryAsync(UpdateCommentDTO updateCategoryFacadeDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}