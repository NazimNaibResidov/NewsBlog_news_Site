using NewsBlog.Entities.BaseEntities;
using NewsBlog.Entities.NewsTagEntity;
using System.Collections.Generic;

namespace NewsBlog.Entities.TagEntity
{
    public class Tag : BaseEntity<int>
    {
        public Tag()
        {
            NewsTags = new HashSet<NewsTag>();
        }

        public string Name { get; set; }

        public virtual ICollection<NewsTag> NewsTags { get; set; }
    }
}