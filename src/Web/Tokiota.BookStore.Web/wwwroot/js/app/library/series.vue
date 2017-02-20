<template>
    <div class="series col-md-3">
        <h5>Series list</h5>
        <ul class="seriesList">
          <serie v-for="serie in series" v-bind:serie="serie"></serie>
        </ul>
  </div>
</template>
<script>
    var AjaxHelper = require('../core/ajaxHelper');
    var Vue = require('vue/dist/vue.common');
    var ajaxHelper = new AjaxHelper();
    module.exports = Vue.extend({
        name: 'series',
        mounted: function () {
            var self = this;
            ajaxHelper.get('api/series').done(function (data) {
                self.series = data;
            });
        },
        data:function() {
            return { series: [] };
        }
    });
</script>

<style scoped>
    .seriesList {
        display: flex;
        flex-direction: row;
        width: 40vh;
        flex-wrap: wrap;
    }
</style>