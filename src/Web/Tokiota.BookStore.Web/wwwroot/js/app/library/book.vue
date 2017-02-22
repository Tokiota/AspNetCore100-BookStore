<template>
    <li>
        <img class="bookPhoto" :src="book.photo" v-on:click="selectBook" />
        <!--<br />-->
        <!--<input type="button" v-on:click="selectBook" />-->
        <!--<span>{{book.name}}</span>-->
    </li>
</template>

<script>
    var Vue = require('vue/dist/vue.common');

    module.exports = Vue.extend({
        name: 'book',
        props: ['book'],
        methods: {
            selectBook: function () {
                this.$emit('selectBook', {
                    id: this.book.id,
                    genre: this.book.genre,
                    name: this.book.name,
                    photo: this.book.photo,
                    published: this.book.published
                });
            }
        }
    });
</script>

<style scoped>
    .bookPhoto {
        width: 15vh;
        height: 23vh;
    }
</style>
