<template>
    <div class="series col-xs-6">
        <h5>Series list</h5>
        <ul class="seriesList">
            <serie v-for="serie in seriesFiltered" v-bind:serie="serie"></serie>
        </ul>
    </div>
</template>
<script>
    var AjaxHelper = require('../core/ajaxHelper'),
        Vue = require('vue/dist/vue.common'),
        bus = require('./library.bus.vue');
    var ajaxHelper = new AjaxHelper();
    module.exports = Vue.extend({
        name: 'series',
        mounted: function () {
            var self = this;
            ajaxHelper.get('api/series').done(function (data) {
                self.series = data;
            });

            bus.$on('selectAuthor', function (author) {
                self.author = author;
            });

            bus.$on('selectSerie', function (serie) {
                self.serie = serie;
            });
        },
        data: function () {
            return {
                series: [],
                author: null,
                serie: null
            };
        },
        computed: {
            seriesFiltered: function () {
                var self = this,
                    seriesFiltered = this.series.filter(function (serie) {
                        return ((self.author == null || self.author.id == null) || self.author.id == serie.authorId);
                    });
                return seriesFiltered;
            }
        }
    });
</script>

<style scoped>
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