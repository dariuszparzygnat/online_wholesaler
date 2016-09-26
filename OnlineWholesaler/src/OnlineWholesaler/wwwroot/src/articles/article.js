"use strict";
var Article = (function () {
    function Article(id, name, description, imgpath) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.imgpath = imgpath;
    }
    return Article;
}());
exports.Article = Article;
