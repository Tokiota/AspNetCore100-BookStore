<template>
    <li>
        <img class="seriePhoto" :src="serie.photo" />
        <br />
        <span>{{serie.name}}</span>
    </li>
</template>
<script>
    var Vue = require('vue/dist/vue.common');

    module.exports = Vue.extend({
        name: 'serie',
        props: ['serie'],
    });
</script>

<style scoped>
    .seriePhoto {
        width: 15vh;
    }
</style>
