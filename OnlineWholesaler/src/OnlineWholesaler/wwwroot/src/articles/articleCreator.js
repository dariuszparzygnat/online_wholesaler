"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var article_1 = require("./article");
var articlesRepository_1 = require("./articlesRepository");
var aurelia_framework_1 = require("aurelia-framework");
var ArticleCreator = (function () {
    function ArticleCreator(articlesRepository, article) {
        if (article === void 0) { article = new article_1.Article(); }
        this.article = article;
        this.lblName = "Name";
        this.articlesRepository = articlesRepository;
    }
    ArticleCreator.prototype.activate = function (params, routeConfig, navigationInstruction) {
        this.router = navigationInstruction.router;
    };
    ArticleCreator.prototype.save = function () {
        var _this = this;
        this.articlesRepository.addArticle(this.article).then(function (article) { return _this.router.navigate('articless'); });
    };
    ArticleCreator = __decorate([
        aurelia_framework_1.inject(articlesRepository_1.ArticlesRepository)
    ], ArticleCreator);
    return ArticleCreator;
}());
exports.ArticleCreator = ArticleCreator;
