namespace Tokiota.BookStore.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AuthorDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required, Range(-5000, 2100)]
        public int Born { get; set; }

        public string Photo { get; set; }

    }
}
