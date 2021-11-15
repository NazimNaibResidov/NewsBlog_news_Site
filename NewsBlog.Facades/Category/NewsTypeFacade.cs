using NewsBlog.Base.BaseUnitOfWork;
using NewsBlog.DTO.NewsType;
using NewsBlog.Interfaces.EntitySerivices;
using NewsBlog.Interfaces.Facades;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog.Facades.Category
{
    public class NewsTypeFacade : INewsTypeFacade
    {
        private readonly INewsTypeService _newsTypeService;
        private readonly IUnitOfWork _unitOfWork;

        public NewsTypeFacade(INewsTypeService newsTypeService, IUnitOfWork unitOfWork)
        {
            _newsTypeService = newsTypeService;
            _unitOfWork = unitOfWork;
        }

        public async Task AddNewsTypeAsync(NewsTypeDTO addNewsTypeDTO)
        {
            await _newsTypeService.AddAsync(addNewsTypeDTO);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteNewsTypeAsync(DeleteNewsTypeDTO deleteNewsTypeDTO)
        {
            await _newsTypeService.DeleteAsync(deleteNewsTypeDTO);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<ListNewsTypeDTO> GetAllNewsType()
        {
            return _newsTypeService.GetAll()
                 .Select(x => new ListNewsTypeDTO
                 {
                     Name = x.Name
                 })
                 .AsQueryable();
        }

        public IQueryable<ListNewsTypeDTO> GetAllNewsWithIdType()
        {
            return _newsTypeService.GetAll()
                 .Select(x => new ListNewsTypeDTO
                 {
                     Id = x.Id,
                     Name = x.Name
                 })
                 .AsQueryable();
        }

        public async Task UpdateNewsTypeAsync(UpdateNewsTypeDTO updateNewsTypeDTO)
        {
            await _newsTypeService.UpdateAsync(updateNewsTypeDTO);
            await _unitOfWork.CommitAsync();
        }
    }
}