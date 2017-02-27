using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokiota.BookStore.Context;
using Tokiota.BookStore.Entities;
using Tokiota.BookStore.Repositories.Core;

namespace Tokiota.BookStore.Repositories
{
    public class SerieRepository : RepositoryCore<Serie, Guid>, ISerieRepository
    {
        public SerieRepository(LibraryContext context):base(context)
        {
        }
        
    }
}
