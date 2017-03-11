let ajaxHelper = window.app.common.helpers.$ajaxHelper;

class BaseVM {
    constructor(data) {
        let self = this;
        self.$ul = document.querySelector(data.listSelector);
        self.$creation = document.getElementById(data.buttonSelector);
        self.getUrl = data.url;
        self.events();
    }

    events() {
        let self = this;

        self.$creation.addEventListener('click', self.create);

        self.$ul.addEventListener("click", function (e) {
            if (e.target && e.target.nodeName === "LABEL" && e.target.classList.contains("remove")) {
                self.remove(e.target.getAttribute("uid"));
            }
        });
    }

    ini() {
        let self = this;
        self.get();
    }
    
    get() {
        let self = this;

        ajaxHelper.get(self.getUrl).done(function (data) {
            self.entities = data;
            self.load.call(self);
        });
    }

    remove(id) {
        let self = this;
        ajaxHelper.delete(`${self.getUrl}/${id}`).done(function (data) {
            self.get();
        });
    }

    load() {
        let self = this;
        if (self.entities != null && self.entities.length > 0) {
            let result = '';
            self.entities.forEach(function (entity) {
                result += self.mapToDom(entity);
            });
            self.$ul.innerHTML = result;
        }
    }

    mapToDom(entity){
       return `<li><label uid="${entity.id}" class="remove">X </label><span>${entity.name}</span></li>`;
    }

    create() {
        // let name = document.getElementById('authorName').value;

        // if (authorName != null && authorName.trim() !== '') {
        //     var data = { Name: authorName };
        //     self.sendCreate(data);
        // }
    }

    sendCreate(data){
        let self = this;
        ajaxHelper
            .post(self.getUrl, data)
            .done(function () {
                self.get();
                console.log(`entity creation ${data}`);
            }).error(function() {
                console.log(`ERROR entity creation ${data} ERROR`);
            });
    }
}

module.exports = BaseVM;