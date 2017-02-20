<template>
    <article>
        <section>
            <h1>Library</h1>
            <span>{{ message }}</span>
            <br />
            <span>{{author.id}}</span>

        </section>

        <section class="content row">
            <authors v-on:authorSelected="authorSelectedOnApp"></authors>
            <series></series>
            <br />
            <books v-bind:author="author"></books>
        </section>
    </article>
</template>
<script>
    var Vue = require('vue/dist/vue.common');
    module.exports = Vue.extend({
        name: 'library',
        data: function () {
            return {
                message: "Hello from Vue",
                author: { id: null }
            };
        },
        methods: {
            authorSelectedOnApp: function (author) {
                this.author = author;
            }
        }
    });
</script>