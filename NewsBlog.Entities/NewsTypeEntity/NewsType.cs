using NewsBlog.Entities.BaseEntities;
using NewsBlog.Entities.NewEntity;
using System.Collections.Generic;

namespace NewsBlog.Entities.NewsTypeEntity
{
    public class NewsType : BaseEntity<int>
    {
        public NewsType()
        {
            News = new HashSet<News>();
        }

        public string Name { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}