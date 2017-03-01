using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokiota.BookStore.Entities;

namespace Tokiota.BookStore.Context
{
    public static class ContextInitializer
    {
        public static void Initialize(IContext context)
        {
            loadAuthors(context);
        }

        private static void loadAuthors(IContext context)
        {
            context.Authors = new List<Author>();
            context.Books = new List<Book>();
            context.Series = new List<Serie>();
            var authors = new List<Author>();
            // Simon 
            var simon = new Author()
            {
                Id = Guid.NewGuid(),
                Name = "Simon",
                LastName = "Scarrow",
                Born = 1962,
            };
            context.Authors.Add(simon);
            var eagle = new Serie
            {
                Id = Guid.NewGuid(),
                Name = "Eagles of the Empire",
                AuthorId = simon.Id
            };
            context.Series.Add(eagle);

            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "Under the Eagle", Published = 2000, Genre = "Historical novel", SerieId = eagle.Id });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "The Eagle's Conquest ", Published = 2001, Genre = "Historical novel", SerieId = eagle.Id });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "When the Eagle Hunts ", Published = 2002, Genre = "Historical novel", SerieId = eagle.Id });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "The Eagle and the Wolves", Published = 2003, Genre = "Historical novel", SerieId = eagle.Id });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "The Eagle's Prey", Published = 2004, Genre = "Historical novel", SerieId = eagle.Id });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "The Eagle's Prophecy", Published = 2005, Genre = "Historical novel", SerieId = eagle.Id });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "The Eagle in the Sand", Published = 2006, Genre = "Historical novel", SerieId = eagle.Id });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "Centurion", Published = 2008, Genre = "Historical novel", SerieId = eagle.Id });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "The Gladiator", Published = 2009, Genre = "Historical novel", SerieId = eagle.Id });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "The Legion", Published = 2010, Genre = "Historical novel", SerieId = eagle.Id });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "Praetorian", Published = 2011, Genre = "Historical novel", SerieId = eagle.Id });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "The Blood Crows", Published = 2013, Genre = "Historical novel", SerieId = eagle.Id });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "Brothers in Blood", Published = 2014, Genre = "Historical novel", SerieId = eagle.Id });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "Britannia", Published = 2015, Genre = "Historical novel", SerieId = eagle.Id });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "Invictus", Published = 2016, Genre = "Historical novel", SerieId = eagle.Id });

            // end Simon

            // posteguillo 
            var posteguillo = new Author()
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "Posteguillo",
                Born = 1967,
            };
            context.Authors.Add(posteguillo);
            var africanus = new Serie
            {
                Id = Guid.NewGuid(),
                Name = "Scipio Africanus",
                AuthorId = posteguillo.Id
            };
            context.Series.Add(africanus);

            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = posteguillo.Id, Name = "Africanus: Son of the Consul", Published = 2006, Genre = "Historical novel", SerieId = africanus.Id });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = posteguillo.Id, Name = "The Accursed Legions", Published = 2008, Genre = "Historical novel", SerieId = africanus.Id });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = posteguillo.Id, Name = "The Betrayal of Rome", Published = 2009, Genre = "Historical novel", SerieId = africanus.Id });

            var trajan = new Serie
            {
                Id = Guid.NewGuid(),
                Name = "Trajan",
                AuthorId = posteguillo.Id
            };
            context.Series.Add(trajan);

            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = posteguillo.Id, Name = "The Emperor's Assassins", Published = 2011, Genre = "Historical novel", SerieId = trajan.Id });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = posteguillo.Id, Name = "Circo Maximo - Trajan's rage", Published = 2013, Genre = "Historical novel", SerieId = trajan.Id });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = posteguillo.Id, Name = "The Lost Legion", Published = 2016, Genre = "Historical novel", SerieId = trajan.Id });

            // end posteguillo

            // orson 
            var orson = new Author()
            {
                Id = Guid.NewGuid(),
                Name = "Orson",
                LastName = "Scott Card",
                Born = 1951,
            };
            context.Authors.Add(orson);
            var ender = new Serie
            {
                Id = Guid.NewGuid(),
                Name = "Ender's Game",
                AuthorId = orson.Id
            };
            context.Series.Add(ender);

            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = orson.Id, Name = "Ender's Game", Published = 1985, Genre = "fiction", SerieId = ender.Id });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = orson.Id, Name = "Speaker for the Dead", Published = 1986, Genre = "fiction", SerieId = ender.Id });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = orson.Id, Name = "Xenocide", Published = 1991, Genre = "fiction", SerieId = ender.Id });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = orson.Id, Name = "Children of the Mind", Published = 1996, Genre = "fiction", SerieId = ender.Id });

            // end orson

            // patrick 
            var patrick = new Author()
            {
                Id = Guid.NewGuid(),
                Name = "Patrick",
                LastName = "Rothfuss",
                Born = 1973,
            };
            context.Authors.Add(patrick);
            var kingkiller = new Serie
            {
                Id = Guid.NewGuid(),
                Name = "The Kingkiller",
                AuthorId = patrick.Id
            };
            context.Series.Add(kingkiller);

            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = patrick.Id, Name = "The Name of the Wind", Published = 2007, Genre = "fantasy", SerieId = kingkiller.Id });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = patrick.Id, Name = "The Wise Man's Fear", Published = 2011, Genre = "fantasy", SerieId = kingkiller.Id });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = patrick.Id, Name = "The Doors of Stone", Published = 3100, Genre = "fantasy", SerieId = kingkiller.Id });

            // end patrick

        }
    }
}
