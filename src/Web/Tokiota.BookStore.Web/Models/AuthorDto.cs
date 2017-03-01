using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokiota.BookStore.Web.Models
{
    public class AuthorDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public int Born { get; set; }
        public string Photo { get; set; }
    }
}
