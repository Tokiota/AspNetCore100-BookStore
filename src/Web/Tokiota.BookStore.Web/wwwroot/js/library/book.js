const booksUrl = 'api/books';
let self = null,
    ajaxHelper = window.app.common.helpers.$ajaxHelper;

class Book {
    constructor() {
        self = this;
    }

    ini() {
        ajaxHelper.get(booksUrl).done(function (data) {
            self.books = data;
            self.loadBooks.call(self);
        });
    }

    loadBooks() {
        if (self.books != null && self.books.length > 0) {
            let $elem = document.querySelector('.books ul');
            let result = '';
            self.books.forEach(function (book) {
                result += "<li>" + book.name + "</li>";
            });
            $elem.innerHTML = result;
        }
    }
}

module.exports = Book;