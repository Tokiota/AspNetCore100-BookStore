(function () {
    var ajaxHelper = window.app.common.helpers.$ajaxHelper,
        urls = {
            authors: 'api/authors',
            books: 'api/books',
            series: 'api/series',
        };
    function Library() {
        var self = this;

        ini.call(self);
    };

    function ini() {
        var self = this;

        ajaxHelper.get(urls.authors).done(function (data) {
            self.authors = data;
            loadAuthors.call(self);
        });

        ajaxHelper.get(urls.books).done(function (data) {
            self.books = data;
            loadBooks.call(self);
        });

        ajaxHelper.get(urls.series).done(function (data) {
            self.series = data;
            loadSeries.call(self);

        });
    };

    function loadAuthors() {
        var self = this;
        if (self.authors != null && self.authors.length > 0) {
            var $elem = document.querySelector('.authors ul');
            var result = '';
            self.authors.forEach(function (author) {
                result += "<li>" + author.name + "</li>";
            });
            $elem.innerHTML = result;
        }
    };

    function loadBooks() {
        var self = this;
        if (self.books != null && self.books.length > 0) {
            var $elem = document.querySelector('.books ul');
            var result = '';
            self.books.forEach(function (book) {
                result += "<li>" + book.name + "</li>";
            });
            $elem.innerHTML = result;
        }
    };

    function loadSeries() {
        var self = this;
        if (self.series != null && self.series.length > 0) {
            var $elem = document.querySelector('.series ul');
            var result = '';
            self.series.forEach(function (serie) {
                result += "<li>" + serie.name + "</li>";
            });
            $elem.innerHTML = result;
        }
    };

    return new Library();
})();