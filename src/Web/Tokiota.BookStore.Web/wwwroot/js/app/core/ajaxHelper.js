import $ from 'jquery';

// template
class AjaxHelper {
    constructor() {
    };
    get(url) {
        var options = this.baseOptions(url, null, null, true);
        options.type = "GET";
        return $.ajax(options);
    };
    patch(url, data, options) {
        options = this.baseOptions(url, data, options, false);
        options.type = "PATCH";
        return $.ajax(options);
    };
    post(url, data, options) {
        options = this.baseOptions(url, data, options, false);
        options.type = "POST";
        return $.ajax(options);
    };
    put(url, data, options) {
        options = this.baseOptions(url, data, options, false);
        options.type = "PUT";
        return $.ajax(options);
    };
    delete (url, options) {
        options = this.baseOptions(url, null, options, false);
        options.type = "DELETE";
        return $.ajax(options);
    };
    baseOptions(url, data, options, showLoader) {
        options = options || {};
        options.url = this.getUrl(url);
        options.dataType = options.dataType || "text json";
        options.contentType = options.contentType || "application/json";
        //if (showLoader) {
        //    loader.show();
        //    options.complete() { loader.hide(); };
        //}
        if (options.data == undefined && data != null) {
            options.data = JSON.stringify(data);
        }
        return options;
    };
    getUrl(url) {
        return window.location.protocol + "//" + window.location.host + "/" + url;
    };
};

module.exports = AjaxHelper;