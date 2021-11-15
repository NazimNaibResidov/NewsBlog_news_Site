using NewsBlog.DTO.News;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog.Interfaces.Facades
{
    public interface INewsFacade
    {
        Task AddNewsAsync(AddNewsDTO addNewsFacadeDTO);

        IQueryable<ListNewsDTO> GetAllNews();

        Task UpdateNewsAsync(UpdateNewsDTO updateNewsFacadeDTO);

        Task DeleteNewsAsync(DeleteNewsDTO deleteNewsFacadeDTO);
    }
}