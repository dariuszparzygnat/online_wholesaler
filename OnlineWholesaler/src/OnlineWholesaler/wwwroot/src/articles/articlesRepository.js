"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var aurelia_framework_1 = require('aurelia-framework');
var aurelia_fetch_client_1 = require('aurelia-fetch-client');
var ArticlesRepository = (function () {
    function ArticlesRepository(apiRoot, httpFetch) {
        this.apiRoot = apiRoot;
        this.httpFetch = httpFetch;
    }
    ArticlesRepository.prototype.getArticles = function () {
        var _this = this;
        var promise = new Promise(function (resolve, reject) {
            if (!_this.articles) {
                _this.httpFetch.fetch(_this.apiRoot + 'api/articles').then(function (response) { return response.json(); })
                    .then(function (data) {
                    _this.articles = data;
                    resolve(_this.articles);
                }).catch(function (err) { return reject(err); });
            }
            else {
                resolve(_this.articles);
            }
        });
        return promise;
    };
    ArticlesRepository = __decorate([
        aurelia_framework_1.inject('apiRoot', aurelia_fetch_client_1.HttpClient)
    ], ArticlesRepository);
    return ArticlesRepository;
}());
exports.ArticlesRepository = ArticlesRepository;
