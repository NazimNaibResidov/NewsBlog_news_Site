using NewsBlog.Entities.BaseEntities;
using NewsBlog.Entities.NewEntity;
using NewsBlog.Entities.TagEntity;

namespace NewsBlog.Entities.TagNewsEntity
{
    public class TagNews : BaseEntity<int>
    {
        public int NewsId { get; set; }
        public int TagId { get; set; }

        public virtual News News { get; set; }
        public virtual Tag Tag { get; set; }
    }
}