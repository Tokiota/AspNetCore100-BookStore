namespace Tokiota.BookStore.Web
{
    using Entities;
    using Mapster;
    using Models;
    public class MapperResgiter : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            this.FromEntities(config);
            this.ToEntities(config);
        }

        public void FromEntities(TypeAdapterConfig config)
        {
            config.ForType<Author, AuthorDto>();
            config.ForType<Book, BookDto>();
            config.ForType<Serie, SerieDto>();
        }
        public void ToEntities(TypeAdapterConfig config)
        {
            config.ForType<AuthorDto, Author>();
            config.ForType<BookDto, Book>();
            config.ForType<SerieDto, Serie>();
        }
    }
}
