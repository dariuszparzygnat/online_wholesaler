"use strict";
var App = (function () {
    function App() {
    }
    App.prototype.configureRouter = function (config, router) {
        this.router = router;
        config.title = "Strona główna";
        config.map([{ route: [''], moduleId: 'src/articles/articles', title: 'Main page', nav: true }
        ]);
    };
    return App;
}());
exports.App = App;
