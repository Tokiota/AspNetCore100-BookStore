<template>
    <div class="authors col-xs-6">
        <h5>Authors list</h5>
        <ul class="authorsList">
            <author v-for="author in authors" v-bind:author="author"></author><!--v-on:selectAuthor="authorSelected"-->
        </ul>
    </div>
</template>
<script>
    var AjaxHelper = require('../core/ajaxHelper'),
        bus = require('./library.bus.vue'),
        Vue = require('vue/dist/vue.common');
    var ajaxHelper = new AjaxHelper();

    module.exports = Vue.extend({
        name: 'authors',
        mounted: function () {
            var self = this;
            ajaxHelper.get('api/authors').done(function (data) {
                self.authors = data;
            });
            bus.$on('selectAuthor', function (author) {
                self.author = author;
            });
        },
        data: function () {
            return {
                author: null,
                authors: []
            };
        }        
    });
</script>
<style scoped>
    .authors {
        clear: both;
    }

    .authorsList {
        display: flex;
        flex-direction: row;
        width: 40vh;
        flex-wrap: wrap;
    }
</style>