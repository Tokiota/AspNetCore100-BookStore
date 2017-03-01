<template>
    <article>
        <section>
            <h1>Library</h1>
            <span>{{ message }}</span>
        </section>
        <section class="content col-xs-6 col-md-4">
            <filters></filters>
            <authors></authors>
            <series></series>
        </section>
        <section class="content col-xs-12 col-md-8">
            <books></books>
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
            };
        },
        //methods: {
        //    authorSelectedOnApp: function (author) {
        //        this.author = author;
        //    }
        //}
    });
</script>