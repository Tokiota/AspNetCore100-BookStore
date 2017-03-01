using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tokiota.BookStore.Entities;

namespace Tokiota.BookStore.Context
{
    public static class LibraryContextInitializer
    {
        public static void Initialize(LibraryContext context)
        {
            if (!context.Authors.Any())
            {
                LoadAuthors(context);
                context.SaveChanges();
            }
        }

        private static void LoadAuthors(ILibraryContext context)
        {
            var authors = new List<Author>();
            // Simon 
            var simon = new Author()
            {
                Id = Guid.NewGuid(),
                Name = "Simon",
                LastName = "Scarrow",
                Born = 1962,
                Photo = "http://simonscarrow.bookswarm.co.uk/wp-content/uploads/2014/08/simon.png"
            };
            context.Authors.Add(simon);
            var eagle = new Serie
            {
                Id = Guid.NewGuid(),
                Name = "Eagles of the Empire",
                AuthorId = simon.Id,
                Photo = "https://pictures.abebooks.com/isbn/9787421174855-us.jpg"
            };
            context.Series.Add(eagle);

            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "Under the Eagle", Published = 2000, Genre = "Historical novel", SerieId = eagle.Id, Photo = "https://inconsistentpacing.files.wordpress.com/2015/06/under-the-eagle.jpg" });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "The Eagle's Conquest", Published = 2001, Genre = "Historical novel", SerieId = eagle.Id, Photo = "http://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1355117222i/6460909._UY200_.jpg" });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "When the Eagle Hunts", Published = 2002, Genre = "Historical novel", SerieId = eagle.Id, Photo = "http://ecx.images-amazon.com/images/I/5194UJX%2B2JL.jpg" });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "The Eagle and the Wolves", Published = 2003, Genre = "Historical novel", SerieId = eagle.Id, Photo = "http://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1349126380i/7013830._UY200_.jpg" });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "The Eagle's Prey", Published = 2004, Genre = "Historical novel", SerieId = eagle.Id, Photo = "http://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1349129330i/6064639._UY200_.jpg" });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "The Eagle's Prophecy", Published = 2005, Genre = "Historical novel", SerieId = eagle.Id, Photo = "https://images.gr-assets.com/books/1408929000l/601301.jpg" });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "The Eagle in the Sand", Published = 2006, Genre = "Historical novel", SerieId = eagle.Id, Photo = "https://images-na.ssl-images-amazon.com/images/I/51lkS6VUEDL._SY346_.jpg" });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "Centurion", Published = 2008, Genre = "Historical novel", SerieId = eagle.Id, Photo = "http://3.bp.blogspot.com/_8WPhHS45xsI/SW4CE3ejKsI/AAAAAAAAKDE/7IS2V-ERlUU/s400/centurion.jpg" });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "The Gladiator", Published = 2009, Genre = "Historical novel", SerieId = eagle.Id, Photo = "http://images.gr-assets.com/books/1348743578l/6097176.jpg" });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "The Legion", Published = 2010, Genre = "Historical novel", SerieId = eagle.Id, Photo = "http://1.bp.blogspot.com/-IULtRvll-68/UWUyWfFvqVI/AAAAAAAAXCM/BrylF3wvls0/s1600/La+legi%C3%B3n+de+Simon+Scarrow.jpg" });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "Praetorian", Published = 2011, Genre = "Historical novel", SerieId = eagle.Id, Photo = "http://images.gr-assets.com/books/1348053656l/12101705.jpg" });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "The Blood Crows", Published = 2013, Genre = "Historical novel", SerieId = eagle.Id, Photo = "http://simonscarrow.co.uk/wp-content/uploads/2014/09/Blood-Crows.jpg" });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "Brothers in Blood", Published = 2014, Genre = "Historical novel", SerieId = eagle.Id, Photo = "https://images-na.ssl-images-amazon.com/images/I/81spvoF56fL.jpg" });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "Britannia", Published = 2015, Genre = "Historical novel", SerieId = eagle.Id, Photo = "http://simonscarrow.co.uk/wp-content/uploads/2015/09/9781472213303-195x300.jpg" });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = simon.Id, Name = "Invictus", Published = 2016, Genre = "Historical novel", SerieId = eagle.Id, Photo = "http://simonscarrow.co.uk/wp-content/uploads/2016/08/Invictus-HBR-frt-v9_RGB.jpg" });

            // end Simon

            // posteguillo 
            var posteguillo = new Author()
            {
                Id = Guid.NewGuid(),
                Name = "Santiago",
                LastName = "Posteguillo",
                Born = 1967,
                Photo = "http://d3iln1l77n73l7.cloudfront.net/couch_images/attachments/000/025/611/original/author-santiago-posteguillo-gomez.jpg?2013"
            };
            context.Authors.Add(posteguillo);
            var africanus = new Serie
            {
                Id = Guid.NewGuid(),
                Name = "Scipio Africanus",
                AuthorId = posteguillo.Id,
                Photo = "https://i.ytimg.com/vi/9m5_QPtkoyM/maxresdefault.jpg"
            };
            context.Series.Add(africanus);

            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = posteguillo.Id, Name = "Africanus: Son of the Consul", Published = 2006, Genre = "Historical novel", SerieId = africanus.Id, Photo = "http://2.bp.blogspot.com/-Bwla4nj7u5E/T24A8Qo4vjI/AAAAAAAAAUc/180j875wqsA/s1600/africanus.jpg" });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = posteguillo.Id, Name = "The Accursed Legions", Published = 2008, Genre = "Historical novel", SerieId = africanus.Id, Photo = "http://www.santiagoposteguillo.es/wp-content/uploads/legiones.jpg" });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = posteguillo.Id, Name = "The Betrayal of Rome", Published = 2009, Genre = "Historical novel", SerieId = africanus.Id, Photo = "http://1.bp.blogspot.com/-OnWf7XvAtvY/T8MV1SXG3XI/AAAAAAAAAv0/_KPIed3K8So/s1600/portada_latraicionderoma.jpg" });

            var trajan = new Serie
            {
                Id = Guid.NewGuid(),
                Name = "Trajan",
                AuthorId = posteguillo.Id,
                Photo = "https://i.ytimg.com/vi/pfqJWLJH_pc/maxresdefault.jpg"
            };
            context.Series.Add(trajan);

            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = posteguillo.Id, Name = "The Emperor's Assassins", Published = 2011, Genre = "Historical novel", SerieId = trajan.Id, Photo = "https://pictures.abebooks.com/isbn/9786070720437-es-300.jpg" });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = posteguillo.Id, Name = "Circo Maximo - Trajan's rage", Published = 2013, Genre = "Historical novel", SerieId = trajan.Id, Photo = "http://www.santiagoposteguillo.es/wp-content/uploads/santiago-posteguillo-circo-maximo-310x475.jpg" });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = posteguillo.Id, Name = "The Lost Legion", Published = 2016, Genre = "Historical novel", SerieId = trajan.Id, Photo = "https://imagessl1.casadellibro.com/a/l/t0/81/9788408151081.jpg" });

            // end posteguillo

            // orson 
            var orson = new Author()
            {
                Id = Guid.NewGuid(),
                Name = "Orson",
                LastName = "Scott Card",
                Born = 1951,
                Photo = "http://www.wired.com/images_blogs/underwire/2013/10/ut_endersgame_f1.jpg?w=240"
            };
            context.Authors.Add(orson);
            var ender = new Serie
            {
                Id = Guid.NewGuid(),
                Name = "Ender's Game",
                AuthorId = orson.Id,
                Photo = "http://www.gestornoticias.com/archivos/religionenlibertad.com/image/ender_orson_scott_card.jpg"
            };
            context.Series.Add(ender);

            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = orson.Id, Name = "Ender's Game", Published = 1985, Genre = "fiction", SerieId = ender.Id, Photo = "https://images-na.ssl-images-amazon.com/images/I/610KU5avW4L.jpg" });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = orson.Id, Name = "Speaker for the Dead", Published = 1986, Genre = "fiction", SerieId = ender.Id, Photo = "https://upload.wikimedia.org/wikipedia/en/0/05/Speaker_dead_cover.jpg" });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = orson.Id, Name = "Xenocide", Published = 1991, Genre = "fiction", SerieId = ender.Id, Photo = "https://upload.wikimedia.org/wikipedia/en/6/6f/Xenocide_cover.jpg" });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = orson.Id, Name = "Children of the Mind", Published = 1996, Genre = "fiction", SerieId = ender.Id, Photo = "https://upload.wikimedia.org/wikipedia/en/1/10/Children_mind_cover.jpg" });

            // end orson

            // patrick 
            var patrick = new Author()
            {
                Id = Guid.NewGuid(),
                Name = "Patrick",
                LastName = "Rothfuss",
                Born = 1973,
                Photo = "https://upload.wikimedia.org/wikipedia/commons/7/7f/Patrick-rothfuss-2014-kyle-cassidy.jpg"
            };
            context.Authors.Add(patrick);
            var kingkiller = new Serie
            {
                Id = Guid.NewGuid(),
                Name = "The Kingkiller",
                AuthorId = patrick.Id,
                Photo = "http://www.tracking-board.com/wp-content/uploads/2015/10/PicMonkey-Collage1.jpg"
            };
            context.Series.Add(kingkiller);

            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = patrick.Id, Name = "The Name of the Wind", Published = 2007, Genre = "fantasy", SerieId = kingkiller.Id, Photo = "http://www.patrickrothfuss.com/images/page/cover_277.jpg" });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = patrick.Id, Name = "The Wise Man's Fear", Published = 2011, Genre = "fantasy", SerieId = kingkiller.Id, Photo = "http://www.patrickrothfuss.com/images/page/cover-paperback-wise-man_277.jpg" });
            context.Books.Add(new Book() { Id = Guid.NewGuid(), AuthorId = patrick.Id, Name = "The Doors of Stone", Published = 3100, Genre = "fantasy", SerieId = kingkiller.Id, Photo = "http://4.bp.blogspot.com/-RkBSGaLLtg4/VlbYicCdSTI/AAAAAAAAU_E/gUduGPRl2Rw/s1600/The%2BDoor%2Bof%2BStone%2Bby%2BPatrick%2BRothfuss.jpg" });

            // end patrick

        }
    }
}
