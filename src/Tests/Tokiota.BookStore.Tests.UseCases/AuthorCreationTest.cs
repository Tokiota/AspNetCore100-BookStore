//namespace Tokiota.BookStore.Tests.UseCases
//{
//    using System.Threading.Tasks;
//    using Domains.UseCases.CreateAuthor;
//    using TestStack.BDDfy;
//    using Web.Models;
//    using Xunit;

//    [Story(AsA = "User of the application",
//            IWant = "To create an author",
//            SoThat = "Author is created"
//        )]
//    public class AuthorCreationTest
//    {
//        private AuthorDto _request;
//        private CreateAuthorUseCase _useCase;

//        public AuthorCreationTest()
//        {
//            _unitOfWork = new AgendaUOW(Factories.EntityFrameworkFactory.GetMemoryDbContext());
//            _useCase = new CreateAuthorUseCase(_unitOfWork);
//            FillExpectedResponses();
//        }


//        [Fact]
//        public async Task CustomScheduleView()
//        {
//            _factory = await BusinessFactory.Create(_unitOfWork);
//            this.Given(x => x.AnAuthorGivenByTheApplicationUser())
//                .When(x => x.CreateAnAuthor())
//                .Then(x => x.IFindAnAppointmentsCustom())
//                .BDDfy();
//        }

//        #region Given

//        public void AnAuthorGivenByTheApplicationUser()
//        {
//            _request = new AuthorDto()
//            {
//                Name = "author name",
//                LastName = " author last name",
//                Born = 1999,
//                Photo = "this is an url"
//            };
//        }

//        #endregion Given

//        #region When 

//        public async Task CreateAuthor()
//        {

//        }

//        #endregion When 

//        #region Then

//        public void ICreateAnAuthor()
//        {

//        }

//        #endregion Then
//    }
//}
