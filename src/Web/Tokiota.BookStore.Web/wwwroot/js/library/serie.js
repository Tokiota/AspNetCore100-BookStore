const seriesUrl = 'api/series';
let self = null,
    ajaxHelper = window.app.common.helpers.$ajaxHelper;

class Serie {
    constructor() {
        self = this;
    }

    ini() {
        ajaxHelper.get(seriesUrl).done(function (data) {
            self.series = data;
            self.loadSeries.call(self);
        });
    }

    loadSeries() {
        var self = this;
        if (self.series != null && self.series.length > 0) {
            var $elem = document.querySelector('.series ul');
            var result = '';
            self.series.forEach(function (serie) {
                result += "<li>" + serie.name + "</li>";
            });
            $elem.innerHTML = result;
        }
    }
}

module.exports = Serie;