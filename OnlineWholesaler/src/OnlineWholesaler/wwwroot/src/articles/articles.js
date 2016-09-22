"use strict";
var article_1 = require("./article");
var Articles = (function () {
    function Articles() {
        this.articles = [];
        this.articles.push(new article_1.Article(1, "Pomidor", "Fajny pomidor", ""));
        this.articles.push(new article_1.Article(2, "Ogórek", "Ogórek polski", ""));
    }
    return Articles;
}());
exports.Articles = Articles;
