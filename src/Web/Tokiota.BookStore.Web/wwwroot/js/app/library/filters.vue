<template>
    <div class="filters col-xs-6">
        <h3 v-if="author != null || serie != null">Filters</h3>
        <label v-if="author != null" v-on:click="removeAuthor" class="red">{{author.name}} {{author.lastName}}</label>
        <label v-if="serie != null" v-on:click="removeSerie" class="red">{{serie.name}}</label>
    </div>
</template>
<script>
    var Vue = require('vue/dist/vue.common'),
        bus = require('./library.bus.vue');

    module.exports = Vue.extend({
        name: 'filters',
        mounted: function () {
            var self = this;

            bus.$on('selectAuthor', function (author) {
                self.author = author;
            });

            bus.$on('selectSerie', function (serie) {
                self.serie = serie;
            });
        },
        data: function () {
            return {
                author: null,
                serie: null
            };
        },
        methods: {
            removeAuthor: function () {
                bus.$emit('selectAuthor', { id: null, name: null });
            },
            removeSerie: function () {
                bus.$emit('selectSerie', { id: null, name: null });
            }
        }
    });
</script>

<style scoped>
    .red {
        color: red;
    }

    .series {
        clear: both;
    }

    .seriesList {
        display: flex;
        flex-direction: row;
        width: 40vh;
        flex-wrap: wrap;
    }
</style>