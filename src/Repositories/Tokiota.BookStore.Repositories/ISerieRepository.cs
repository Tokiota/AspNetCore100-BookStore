using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokiota.BookStore.Context;
using Tokiota.BookStore.Entities;
using Tokiota.BookStore.Repositories.Core;

namespace Tokiota.BookStore.Repositories
{
    public interface ISerieRepository : IRepositoryCore<Serie, Guid>
    {

    }
}
