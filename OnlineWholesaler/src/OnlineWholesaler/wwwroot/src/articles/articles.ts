import {Article} from "./article";
import {ArticlesRepository} from "./articlesRepository";
import {inject} from "aurelia-framework";

@inject(ArticlesRepository)
export class Articles {
    constructor(articlesRepository) {
        this.articlesRepository = articlesRepository;
    }

    activate(params) {
        this.articlesRepository.getArticles().then(articles => {
            this.articles = articles;
        });
    }

    
    articles;
    articlesRepository;
}
