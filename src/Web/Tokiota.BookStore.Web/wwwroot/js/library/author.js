const authorsUrl = 'api/authors';
let self = null,
    ajaxHelper = window.app.common.helpers.$ajaxHelper;

class Author {
    constructor() {
        self = this;
        self.$authorUl = document.querySelector('.authors ul');

        self.events();
    }

    events() {
        let button = document.getElementById('btnCreateAuthor');
        button.addEventListener('click', self.createAuthor);

        document.querySelector('.authors ul').addEventListener("click", function (e) {
            if (e.target && e.target.nodeName === "LABEL" && e.target.classList.contains("remove")) {
                self.removeAuthor(e.target.getAttribute("uid"));
            }
        });
    }

    ini() {
        self.getAuthors();
    }
    
    getAuthors() {
        ajaxHelper.get(authorsUrl).done(function (data) {
            self.authors = data;
            self.loadAuthors.call(self);
        });
    }

    removeAuthor(id) {
        ajaxHelper.delete(`${authorsUrl}/${id}`).done(function (data) {
            self.getAuthors();
        });
    }

    loadAuthors() {
        if (self.authors != null && self.authors.length > 0) {
            let result = '';
            self.authors.forEach(function (author) {
                result += `<li><label uid="${author.id}" class="remove">X </label><span>${author.name}</span></li>`;
            });
            self.$authorUl.innerHTML = result;
        }
    }

    createAuthor() {
        let authorName = document.getElementById('authorName').value;

        if (authorName != null && authorName.trim() !== '') {
            var data = { Name: authorName };
            ajaxHelper
                .post(authorsUrl, data)
                .done(function () {
                    self.getAuthors();
                    console.log(`author creation ${authorName}`);
                }).error(function() {
                    console.log(`ERROR author creation ${authorName} ERROR`);
                });
        }
    }
}

module.exports = Author;