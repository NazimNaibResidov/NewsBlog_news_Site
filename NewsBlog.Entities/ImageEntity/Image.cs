using NewsBlog.Entities.BaseEntities;
using NewsBlog.Entities.NewEntity;
using System.Collections.Generic;

namespace NewsBlog.Entities.ImageEntity
{
    public class Image : BaseEntity<int>
    {
        public Image()
        {
            News = new HashSet<News>();
        }

        public string Name { get; set; }
        public string BigPath { get; set; }
        public string SmallPath { get; set; }
        public string MidlePath { get; set; }
        public virtual ICollection<News> News { get; set; }
    }
}