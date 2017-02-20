<template>
    <div class="books">
        <h5>Books list</h5>
        <ul class="booksList">
            <book v-for="book in booksFiltered" v-bind:book="book" v-on:selectBook="selected"></book>
        </ul>
        <modal v-if="selectedBook != null">
            <h3 slot="header">{{selectedBook.name}}</h3>
            <div slot="body">
                <div class="col-xs-6 col-md-3">
                    <img class="bookPhoto" :src="selectedBook.photo"/>
                </div>
                <div class="col-xs-6 col-md-9">
                    <label class="col-md-3">Code: </label><span>{{selectedBook.id}}</span>
                    <br /><label class="col-md-3">Name: </label><span>{{selectedBook.name}}</span>
                    <br /><label class="col-md-3">Genre: </label><span>{{selectedBook.genre}}</span>
                    <br /><label class="col-md-3">Published: </label><span>{{selectedBook.published}}</span>
                </div>
            </div>
            <button slot="footer" class="modal-default-button" v-on:click="selectedBook = null">
                OK
            </button>
        </modal>
    </div>
</template>
<script>
    var AjaxHelper = require('../core/ajaxHelper'),
        Vue = require('vue/dist/vue.common'),
        bus = require('./library.bus.vue'),
        ajaxHelper = new AjaxHelper();

    module.exports = Vue.extend({
        name: 'books',
        mounted: function () {
            var self = this;

            ajaxHelper.get('api/books').done(function (data) {
                self.books = data;
            });

            bus.$on('selectAuthor', function (author) {
                self.author = author;
            });

            bus.$on('selectSerie', function (serie) {
                self.serieId = serie.id;
            });
        },
        data: function () {
            return {
                books: [],
                author: {},
                selectedBook: null,
                //author: {},
                serieId: null
            };
        },
        computed: {
            booksFiltered: function () {
                var self = this,
                    books = this.books.filter(function (book) {
                        return ((self.author == null || self.author.id == null) || self.author.id == book.authorId)
                            && (self.serieId == null || self.serieId == book.serieId);
                    });
                return books;
            }
        },
        methods: {
            selected: function (book) {
                this.selectedBook = book;
            },
            authorSelected: function (book) {
                debugger;
            }
        }
    });
</script>

<style scoped>
    label {
        margin-bottom: 0;
        margin-left: 0;
        padding-left: 0;
    }

    .books {
        clear: both;
    }

    .bookPhoto {
        width: 16vh;
        height: 26vh;
    }

    .booksList {
        display: flex;
        flex-direction: row;
        width: 100vh;
        flex-wrap: wrap;
    }
</style>