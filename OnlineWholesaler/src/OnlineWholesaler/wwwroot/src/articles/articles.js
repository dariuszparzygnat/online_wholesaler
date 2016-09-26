"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var articlesRepository_1 = require("./articlesRepository");
var aurelia_framework_1 = require("aurelia-framework");
var Articles = (function () {
    function Articles(articlesRepository) {
        this.articlesRepository = articlesRepository;
    }
    Articles.prototype.activate = function (params) {
        var _this = this;
        this.articlesRepository.getArticles().then(function (articles) {
            _this.articles = articles;
        });
    };
    Articles = __decorate([
        aurelia_framework_1.inject(articlesRepository_1.ArticlesRepository)
    ], Articles);
    return Articles;
}());
exports.Articles = Articles;
