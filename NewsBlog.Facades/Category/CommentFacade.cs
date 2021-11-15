using NewsBlog.DTO.Comment;
using NewsBlog.Interfaces.EntitySerivices;
using NewsBlog.Interfaces.Facades;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog.Facades.Category
{
    public class CommentFacade : ICommentFacade
    {
        private readonly ICommnetService _commnetService;

        public CommentFacade(ICommnetService commnetService)
        {
            _commnetService = commnetService;
        }

        public async Task AddCategoryAsync(AddCommentDTO addCommentFacadeDTO)
        {
            await _commnetService.AddAsync(addCommentFacadeDTO);
        }

        public async Task DeleteCategoryAsync(DeleteCommentDTO deleteCategoryFacadeDTO)
        {
            await _commnetService.DeleteAsync(deleteCategoryFacadeDTO);
        }

        public IQueryable<ListCommentDTO> GetAllCategory()
        {
            return _commnetService.GetAll()
                   .Select(x => new ListCommentDTO
                   {
                       AddedTime = x.AddedTime,
                       Content = x.Content,
                       Header = x.Header,
                       Ip = x.Ip,
                       IsActive = x.IsActive,
                       Likes = x.Likes,
                       Mail = x.Mail,
                       NameSurname = x.NameSurname,
                       NewsId = x.NewsId,
                       Tiksinti = x.Tiksinti
                   })
                   .AsQueryable();
        }

        public async Task UpdateCategoryAsync(UpdateCommentDTO updateCategoryFacadeDTO)
        {
            await _commnetService.UpdateAsync(updateCategoryFacadeDTO);
        }
    }
}