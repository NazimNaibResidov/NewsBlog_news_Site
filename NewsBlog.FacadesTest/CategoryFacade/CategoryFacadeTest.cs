using Moq;
using NewsBlog.DTO.Category;
using NewsBlog.Interfaces.Facades;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsBlog.FacadesTest.CategoryFacade
{
   public class CategoryFacadeTest
    {
        private Mock<ICategoryFacade>  _categoryFacade;

        [SetUp]
        public async Task Setup()
        {
            _categoryFacade = new Mock<ICategoryFacade>();
        }
        [Test, Order(10)]
        public async Task AddAsyc()
        {
            AddCategoryDTO addCategoryDTO = new AddCategoryDTO
            {
                Description = "zzz",
                Name = "mmm"
             };

           _categoryFacade.Setup(x => x.AddCategoryAsync(addCategoryDTO)).Returns(Task.FromResult(addCategoryDTO));

        }
    }
}
