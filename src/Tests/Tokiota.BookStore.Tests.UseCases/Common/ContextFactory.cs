using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokiota.BookStore.Entities;
using Tokiota.BookStore.XCutting;

namespace Tokiota.BookStore.Tests.UseCases.Common
{
    public class ContextFactory
    {
        private ILibraryUoW _uow;
        private ContextFactory _instance;

        private ContextFactory() { }
        private ContextFactory(ILibraryUoW uow)
        {
            _uow = uow;
            Initialize();
        }

        public ContextFactory Instance(ILibraryUoW uow)
        {
            if (_instance == null) _instance = new ContextFactory(uow);
            return _instance;
        }

        public void Initialize()
        {
            SetAuthor();
        }

        private void SetAuthor()
        {

            _uow.AuthorRepository.Create(new Author()
            {

            });
        }
    }
}
