"use strict";
function configure(aurelia) {
    aurelia.use.instance('apiRoot', 'http://localhost:5000/');
    aurelia.use.standardConfiguration().developmentLogging();
    aurelia.start().then(function (a) { return a.setRoot("src/app"); });
}
exports.configure = configure;
