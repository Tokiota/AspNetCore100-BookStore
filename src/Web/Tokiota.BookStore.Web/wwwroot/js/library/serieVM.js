import BaseVM from './baseVM'
let self = null;

class SerieVM extends BaseVM {
    constructor() {
        super({
            url: 'api/series',
            listSelector: '.series ul',
            buttonSelector: 'btnCreateSerie'
        });

        self = this;
        self.$authors = document.getElementById('authorsForSeries');
    }
    
    load(){
        super.load();
        let result = '';
        
        // this should be in book VM and serie VM 
        self.entities.forEach(function (entity){
               result += `<option value="${entity.id}">${entity.name}</option>`;         
        });

        self.$seriesForBooks = self.$seriesForBooks || document.getElementById('seriesForBooks');
        self.$seriesForBooks.innerHTML = `<option default> </option>${result}`;
    }

    create() {
        let name = document.getElementById('serieName').value,
            authorSelected = self.$authors.value;
        
        if (name != null && name.trim() !== '' && authorSelected != null && authorSelected.trim() !== '') {
            var data = { 
                AuthorId: authorSelected,
                Name: name 
            };

            self.sendCreate(data);
        }
    }
}

module.exports = SerieVM;