namespace Tokiota.BookStore.Entities.Core
{
    public class EntityCore<TId>
    {
        public EntityCore() { }
        public EntityCore(TId id)
        {
            this.Id = id;
        }

        public TId Id { get; set; }
    }
}
