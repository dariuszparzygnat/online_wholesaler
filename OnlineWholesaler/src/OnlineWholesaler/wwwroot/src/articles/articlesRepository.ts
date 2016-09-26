import {inject, singleton} from 'aurelia-framework';
import {HttpClient as HttpFetch, json} from 'aurelia-fetch-client';
import {Article} from "./article";

@inject('apiRoot', HttpFetch)
@singleton()
export class ArticlesRepository {
    constructor(apiRoot, httpFetch) {
        this.apiRoot = apiRoot;
        this.httpFetch = httpFetch;
    }

    getArticles() {
        var promise = new Promise((resolve, reject) => {
            if (!this.articles) {
                this.httpFetch.fetch(this.apiRoot + 'api/articles').then(response => response.json())
                    .then(data => {
                        this.articles = data;
                        resolve(this.articles);
                    }).catch(err => reject(err));
            } else {
                resolve(this.articles);
            }
        });
        return promise;
    }

    httpFetch;
    apiRoot;
    articles: Article[];

    addArticle(article: Article) {
        var promise = new Promise((resolve, reject) => {
            this.httpFetch.fetch(this.apiRoot + 'api/articles', {
                method: 'POST',
                body: json(article)
            }).then(response => response.json())
                .then(data => {
                    this.articles.push(data);
                    resolve(data);
                }).catch(err => reject(err));
        });
        return promise;
    }
}