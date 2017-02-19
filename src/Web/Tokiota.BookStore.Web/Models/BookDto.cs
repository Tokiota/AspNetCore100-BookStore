using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokiota.BookStore.Web.Models
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Published { get; set; }
        public string Genre { get; set; }
        public string Photo { get; set; }
    }
}
