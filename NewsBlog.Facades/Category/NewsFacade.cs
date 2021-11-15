using NewsBlog.Base.BaseUnitOfWork;
using NewsBlog.DTO.News;
using NewsBlog.Interfaces.EntitySerivices;
using NewsBlog.Interfaces.Facades;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog.Facades.Category
{
    public class NewsFacade : INewsFacade
    {
        private INewsService _newsService;
        private IImageService _imageService;
        private ICategoryService _categoryService;
        private INewsTypeService _newsTypeService;
        private readonly IUnitOfWork _unitOfWork;

        public NewsFacade(INewsService newsService, IImageService imageService, ICategoryService categoryService, INewsTypeService newsTypeService, IUnitOfWork unitOfWork)
        {
            _newsService = newsService;
            _imageService = imageService;
            _categoryService = categoryService;
            _newsTypeService = newsTypeService;
            _unitOfWork = unitOfWork;
        }

        public async Task AddNewsAsync(AddNewsDTO addNewsFacadeDTO)
        {
            await _newsService.AddAsync(addNewsFacadeDTO);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteNewsAsync(DeleteNewsDTO deleteNewsFacadeDTO)
        {
            await _newsService.DeleteAsync(deleteNewsFacadeDTO);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<ListNewsDTO> GetAllNews()
        {
            return (from x in _newsService.GetAll()
                    join cat in _categoryService.GetAll()
                    on x.KateoriId equals cat.Id
                    join img in _imageService.GetAll()
                    on x.ImageId equals img.Id
                    join nt in _newsTypeService.GetAll()
                    on x.NewsTypeId equals nt.Id

                    select new ListNewsDTO
                    {
                        Content = x.Content,
                        Header = x.Header,
                        imagePath = x.Image.BigPath,
                        KateoriName = x.Category.Name,
                        NewsTime = x.NewsTime,
                        NewsType = x.NewsType.Name,
                        Summary = x.Summary,
                        UserName = x.User.UserName
                    }).AsQueryable();
        }

        public async Task UpdateNewsAsync(UpdateNewsDTO updateNewsFacadeDTO)
        {
            await _newsService.UpdateAsync(updateNewsFacadeDTO);
            await _unitOfWork.CommitAsync();
        }
    }
}