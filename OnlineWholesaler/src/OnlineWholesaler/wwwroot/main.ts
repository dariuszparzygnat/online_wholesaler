export function configure(aurelia) {
    aurelia.use.instance('apiRoot', 'http://localhost:5000/');
    aurelia.use.standardConfiguration().developmentLogging().plugin('aurelia-validation');
    aurelia.start().then(a => a.setRoot("src/app"));
}