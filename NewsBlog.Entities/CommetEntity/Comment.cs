using NewsBlog.Entities.BaseEntities;
using NewsBlog.Entities.NewEntity;
using System;
using System.Collections.Generic;

namespace NewsBlog.Entities.CommetEntity
{
    public class Comment : BaseEntity<int>
    {
        public Comment()
        {
            News = new HashSet<News>();
        }

        public string Header { get; set; }
        public string Ip { get; set; }
        public string Mail { get; set; }
        public string NameSurname { get; set; }
        public string Content { get; set; }
        public bool? IsActive { get; set; }
        public int? Likes { get; set; }
        public int? Tiksinti { get; set; }
        public int? NewsId { get; set; }
        public DateTime? AddedTime { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}