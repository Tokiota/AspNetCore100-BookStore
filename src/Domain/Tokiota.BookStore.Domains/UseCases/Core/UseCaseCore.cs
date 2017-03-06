namespace Tokiota.BookStore.Domains.UseCases.Core
{
    using System.Threading.Tasks;
    using XCutting;

    public abstract class UseCaseCore<TRequest, TResponse> where TRequest : RequestUseCaseCore
                                                  where TResponse : ResponseUseCaseCore
    {
        protected UseCaseCore(ILibraryUoW uow)
        {
            UoW = uow;
        }

        protected ILibraryUoW UoW { get; set; }


        public abstract TResponse Handle(TRequest request);
    }
}
