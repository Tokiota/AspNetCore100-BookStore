import BaseVM from './baseVM'
let self = null;

class BookVM extends BaseVM {
    constructor() {
        super({
            url: 'api/books',
            listSelector: '.books ul',
            buttonSelector: 'btnCreateBook'
        });

        self = this;
        self.$authors = document.getElementById('authorsForBooks');
        self.$series = document.getElementById('seriesForBooks');
    }
  
    create() {
        let name = document.getElementById('bookName').value,
            authorSelected = self.$authors.value;
        
        if (name != null && name.trim() !== '' && authorSelected != null && authorSelected.trim() !== '') {
            var data = { 
                AuthorId: authorSelected,
                SerieId: self.$series.value,
                Name: name 
            };

            self.sendCreate(data);
        }
    }
}

module.exports = BookVM;