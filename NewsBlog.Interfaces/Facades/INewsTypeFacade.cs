using NewsBlog.DTO.NewsType;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog.Interfaces.Facades
{
    public interface INewsTypeFacade
    {
        Task AddNewsTypeAsync(NewsTypeDTO addNewsTypeDTO);

        IQueryable<ListNewsTypeDTO> GetAllNewsType();

        Task UpdateNewsTypeAsync(UpdateNewsTypeDTO updateNewsTypeDTO);

        Task DeleteNewsTypeAsync(DeleteNewsTypeDTO deleteNewsTypeDTO);

        IQueryable<ListNewsTypeDTO> GetAllNewsWithIdType();
    }
}