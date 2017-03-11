import BaseVM from './baseVM'
let self = null;

class AuthorVM extends BaseVM {
    constructor() {
        super({
            url:'api/authors',
            listSelector: '.authors ul',
            buttonSelector: 'btnCreateAuthor'
        });

        self = this;
    }

    load(){
        super.load();
        let result = '';
        
        // this should be in book VM and serie VM 
        self.entities.forEach(function (entity){
               result += `<option value="${entity.id}">${entity.name}</option>`;         
        });

        self.$selectForBooks = self.$selectForBooks || document.getElementById('authorsForBooks');
        self.$selectForBooks.innerHTML = result;
        
        self.$selectForSeries = self.$selectForSeries || document.getElementById('authorsForSeries');
        self.$selectForSeries.innerHTML = result;
    }

    create() {
        let name = document.getElementById('authorName').value;
        
        if (name != null && name.trim() !== '') {
            var data = { 
                Name: name 
            };

            self.sendCreate(data);
        }
    }
}

module.exports = AuthorVM;