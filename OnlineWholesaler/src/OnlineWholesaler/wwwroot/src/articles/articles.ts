import {Article} from "./article"

export class Articles {
    constructor() {
        this.articles = [];
        this.articles.push(new Article(1, "Pomidor", "Fajny pomidor", ""));
        this.articles.push(new Article(2, "Ogórek", "Ogórek polski", ""));
    }
    
    articles: Article[];
}
