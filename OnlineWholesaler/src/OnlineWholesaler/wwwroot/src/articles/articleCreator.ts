import {Article} from "./article";
import {ArticlesRepository} from "./articlesRepository";
import {inject} from "aurelia-framework";

@inject(ArticlesRepository)
export class ArticleCreator {
    constructor(articlesRepository, article: Article = new Article()) {
        this.article = article;
        this.lblName = "Name";
        this.articlesRepository = articlesRepository;
    }

    activate(params, routeConfig, navigationInstruction) {
        this.router = navigationInstruction.router;
    }

    save() {
        this.articlesRepository.addArticle(this.article).then(article => this.router.navigate('articless'));
    }


    article: Article;
    lblName: string;
    articlesRepository: ArticlesRepository;
    router;
}