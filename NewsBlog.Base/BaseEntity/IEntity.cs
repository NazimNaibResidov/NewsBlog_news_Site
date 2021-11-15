namespace NewsBlog.Base.BaseEntity
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}