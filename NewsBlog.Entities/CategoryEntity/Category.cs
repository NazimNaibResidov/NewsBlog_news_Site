using NewsBlog.Entities.BaseEntities;
using NewsBlog.Entities.NewEntity;
using System.Collections.Generic;

namespace NewsBlog.Entities.CategoryEntity
{
    public class Category : BaseEntity<int>
    {
        public Category()
        {
            News = new HashSet<News>();
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}