"use strict";
var Article = (function () {
    function Article(id, name, description, imgpath) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.imgpath = imgpath;
    }
    Article.prototype.activate = function (model) {
        this.model = model;
    };
    return Article;
}());
exports.Article = Article;
