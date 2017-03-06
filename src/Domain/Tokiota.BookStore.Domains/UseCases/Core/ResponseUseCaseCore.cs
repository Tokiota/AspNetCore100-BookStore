namespace Tokiota.BookStore.Domains.UseCases.Core
{
    using XCutting;

    public class ResponseUseCaseCore
    {
        public Enums.Responses.eResponseType Response { get; set; }
        public bool IsValid { get { return Response == Enums.Responses.eResponseType.Ok} }
    }
}

