using System.Threading.Tasks;

namespace Tokiota.BookStore.Repositories.UoW.Core
{
    public interface IUoW
    {
        Task<int> SaveChanges();
    }
}
