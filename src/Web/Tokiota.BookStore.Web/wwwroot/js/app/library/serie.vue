<template>
    <li  v-on:click="selectSerie">
        <img class="seriePhoto" :src="serie.photo" />
        <br />
        <span>{{serie.name}}</span>
    </li>
</template>
<script>
    var Vue = require('vue/dist/vue.common'),
        bus = require('./library.bus.vue');

    module.exports = Vue.extend({
        name: 'serie',
        props: ['serie'],
        methods: {
            selectSerie: function () {
                bus.$emit('selectSerie', {
                    id: this.serie.id,
                    name: this.serie.name
                });
            }
        }
    });
</script>

<style scoped>
    .seriePhoto {
        width: 15vh;
    }
</style>
