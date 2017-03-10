import Author from './Author';
import Book from './Book';
import Serie from './Serie';

let self = null;

class App {
    constructor() {
        self = this;

        self.declarations();
        self.ini();
    }

    declarations() {
        self.author = new Author();
        self.book = new Book();
        self.serie = new Serie();
    }

    ini() {
        self.author.ini();
        self.book.ini();
        self.serie.ini();
    }
}

var app = new App();