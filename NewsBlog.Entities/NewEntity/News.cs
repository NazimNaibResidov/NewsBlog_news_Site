using NewsBlog.Entities.BaseEntities;
using NewsBlog.Entities.CategoryEntity;
using NewsBlog.Entities.CommetEntity;
using NewsBlog.Entities.ImageEntity;
using NewsBlog.Entities.NewsTagEntity;
using NewsBlog.Entities.NewsTypeEntity;
using NewsBlog.Entities.UserEntity;
using System;
using System.Collections.Generic;

namespace NewsBlog.Entities.NewEntity
{
    public class News : BaseEntity<int>
    {
        public News()
        {
            NewsTag = new HashSet<NewsTag>();
        }

        public string Header { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public int? KateoriId { get; set; }
        public int? ImageId { get; set; }
        public int? NewsTypeId { get; set; }
        public DateTime? NewsTime { get; set; }
        public string UserId { get; set; }

        public virtual Image Image { get; set; }
        public virtual Category Category { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual NewsType NewsType { get; set; }
        public ApplicationUser User { get; set; }
        public virtual ICollection<NewsTag> NewsTag { get; set; }
    }
}