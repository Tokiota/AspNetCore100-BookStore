<template>
    <div class="authors col-md-3">
        <h5>Authors list</h5>
        <h5 v-if="author != null">{{author.name}} {{author.lastName}}</h5>
        <h5 v-else="author == null">selecciona</h5>
        <ul class="authorsList">
            <author v-for="author in authors" v-bind:author="author" v-on:selectAuthor="authorSelected"></author>
        </ul>
    </div>
</template>
<script>
    var AjaxHelper = require('../core/ajaxHelper');
    var Vue = require('vue/dist/vue.common');
    var ajaxHelper = new AjaxHelper();
    module.exports = Vue.extend({
        name: 'authors',
        mounted: function () {
            var self = this;
            ajaxHelper.get('api/authors').done(function (data) {
                self.authors = data;
            });
        },
        data: function () {
            return {
                author:null,
                authors: []
            };
        },
        methods: {
            authorSelected: function (author) {
                this.author = author;
                this.$emit('authorSelected', this.author);
            }
        }
    });
</script>
<style scoped>
    .authorsList {
        display: flex;
        flex-direction: row;
        width: 40vh;
        flex-wrap: wrap;
    }
</style>