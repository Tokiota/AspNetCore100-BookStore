window.app = window.app || {};
window.app.common = window.app.common || {};
window.app.common.helpers = window.app.common.helpers || {};

window.app.common.helpers.$ajaxHelper = (function () {
    function baseOptions(url, data, options, showLoader) {
        options = options || {};
        options.url = getUrl(url);
        options.dataType = options.dataType || "text json";
        options.contentType = options.contentType || "application/json";
        //if (showLoader) {
        //    loader.show();
        //    options.complete = function () { loader.hide(); };
        //}

        if (options.data == undefined && data != null) {
            options.data = JSON.stringify(data);
        }

        return options;
    };

    function getUrl(url) {
        return window.location.protocol + "//" + window.location.host + "/" + url;
    };

    return {
        get: function (url) {
            options = baseOptions(url, null, {}, true);
            options.type = "GET";

            return $.ajax(options);
        },
        put: function (url, data, options) {

            options = baseOptions(url, data, options);
            options.type = "PUT";

            return $.ajax(options);
        },
        post: function (url, data, options) {
            options = baseOptions(url, data, options);
            options.type = "POST";

            return $.ajax(options);
        },
        patch: function (url, data, options) {
            options = baseOptions(url, data, options);
            options.type = "PATCH";

            return $.ajax(options);
        },
        delete: function (url, options) {
            options = baseOptions(url, null, options);
            options.type = "DELETE";

            return $.ajax(options);
        }
    };
})();

//$(document).ajaxError(function (event, xhr, settings) {
//    var message;
//    if (xhr.responseText.trim().startsWith('<'))
//        message = xhr.status + ' ' + xhr.statusText
//    else {
//        var err = eval("(" + xhr.responseText + ")");
//        message = err.message || err.Message || err.error || err.Error || 'undefined error';
//    }

//    toastr.error(message);
//});
