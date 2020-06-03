namespace ResourceManager.Core
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
