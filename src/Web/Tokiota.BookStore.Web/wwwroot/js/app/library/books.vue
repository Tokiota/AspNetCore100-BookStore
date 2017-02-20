<template>
    <div class="books">
        <h5>Books list</h5>
        <h5 v-if="author.id != null"> author -> {{author.id}}</h5>
        <h5 v-else="author.id == null"> author not selected</h5>
        <h5>{{selectedBook}}</h5>
        <ul class="booksList">
            <book v-for="book in booksFiltered" v-bind:book="book" v-on:selectBook="selected"></book>
        </ul>
    </div>
</template>
<script>
    var AjaxHelper = require('../core/ajaxHelper'),
        Vue = require('vue/dist/vue.common'),
        // bus = require('./library.bus.vue'),
        ajaxHelper = new AjaxHelper();

    module.exports = Vue.extend({
        name: 'books',
        mounted: function () {
            var self = this;
            ajaxHelper.get('api/books').done(function (data) {
                self.books = data;
            });
            //bus.$on('selectAuthor', function (author) {
            //    debugger;
            //    self.author = author;
            //});
        },
        props: ['author'],
        data: function () {
            return {
                books: [],
                selectedBook: 'selecciona',
                //author: {},
                serieId: null,
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
    .books {
        clear: both;
    }

    .booksList {
        display: flex;
        flex-direction: row;
        width: 150vh;
        flex-wrap: wrap;
    }
</style>