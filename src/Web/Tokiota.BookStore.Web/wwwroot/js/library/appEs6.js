import AuthorVM from './AuthorVM';
import BookVM from './BookVM';
import SerieVM from './SerieVM';

let self = null;

class App {
    constructor() {
        self = this;

        self.declarations();
        self.ini();
    }

    declarations() {
        self.authorVM = new AuthorVM();
        self.bookVM = new BookVM();
        self.serieVM = new SerieVM();
    }

    ini() {
        self.authorVM.ini();
        self.bookVM.ini();
        self.serieVM.ini();
    }
}

var app = new App();