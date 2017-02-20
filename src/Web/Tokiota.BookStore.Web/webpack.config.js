"use strict";
var path = require('path');
module.exports = {
    entry: {
        libraryapp: path.resolve(__dirname + '/wwwroot/js/app/library/app'),
        vendor: [
             'vue',
        ]
    },
    stats: {
        colors: true
    },
    devtool: 'source-map',
    output: {
        filename: '[name].js',
        path: __dirname + '/wwwroot/js/app/modules'
    },

    resolve: {
        root: path.resolve(__dirname),
        alias: {
            'vue$': 'vue/dist/vue.common.js'
        }
    },
    module: {
        loaders: [
          {
              test: /\.js$/,
              loader: 'babel-loader',
              exclude: /node_modules/,
              query: {
                  presets: ['es2015']
              }
          },
          {
              test: /\.vue$/,
              loader: 'vue'
          }
        ]
    },
    vue: {
        loaders: {
            js: 'babel'
        }
    }
}