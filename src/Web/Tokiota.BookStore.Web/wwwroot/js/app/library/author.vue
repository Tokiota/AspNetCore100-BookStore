<template>
    <li  v-on:click="selectAuthor">
        <img class="authorPhoto" :src="author.photo" />
        <br />
        <span>{{author.name}}</span>
        <span>{{author.lastName}}</span>
    </li>
</template>
<script>
    var Vue = require('vue/dist/vue.common');//,
        //bus = require('./library.bus.vue');

    module.exports = Vue.extend({
        name: 'author',
        props: ['author'],
        methods: {
            selectAuthor: function () {
                //bus
                this.$emit('selectAuthor', {
                    id: this.author.id,
                    name: this.author.name,
                    lastName: this.author.lastName,
                });
            }
        }
    });
</script>

<style scoped>
    .authorPhoto {
        width: 15vh;
        height: 15vh;
    }
</style>
