import Vue from 'vue/dist/vue.common';
import LibraryVue from './library.vue';
import AuthorVue from './author.vue';
import AuthorsVue from './authors.vue';
import BookVue from './book.vue';
import BooksVue from './books.vue';
import SerieVue from './serie.vue';
import SeriesVue from './series.vue';

Vue.component('library', LibraryVue);

Vue.component('author', AuthorVue);
Vue.component('authors', AuthorsVue);

Vue.component('book', BookVue);
Vue.component('books', BooksVue);

Vue.component('serie', SerieVue);
Vue.component('series', SeriesVue);

new Vue({
    el: '#libraryModule'   
});