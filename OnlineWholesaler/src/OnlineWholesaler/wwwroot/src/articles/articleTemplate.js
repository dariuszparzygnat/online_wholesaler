"use strict";
var ArticleTemplate = (function () {
    function ArticleTemplate() {
    }
    ArticleTemplate.prototype.activate = function (bindingContext) {
        this.model = bindingContext;
    };
    return ArticleTemplate;
}());
exports.ArticleTemplate = ArticleTemplate;
