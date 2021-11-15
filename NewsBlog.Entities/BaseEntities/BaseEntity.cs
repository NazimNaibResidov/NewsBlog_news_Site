using NewsBlog.Base.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace NewsBlog.Entities.BaseEntities
{
    public abstract class BaseEntity
    {
    }

    public abstract class BaseEntity<T> : BaseEntity, IEntity<T>
    {
        [Key]
        public virtual T Id { get; set; }
    }
}