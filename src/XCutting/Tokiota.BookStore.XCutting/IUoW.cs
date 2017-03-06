namespace Tokiota.BookStore.XCutting
{
    using System.Threading.Tasks;

    public interface IUoW
    {
        Task<int> SaveChanges();
    }
}
