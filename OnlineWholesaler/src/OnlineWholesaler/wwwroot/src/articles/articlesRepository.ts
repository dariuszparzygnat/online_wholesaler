import {inject} from 'aurelia-framework';
import {HttpClient as HttpFetch} from 'aurelia-fetch-client';

@inject('apiRoot', HttpFetch)
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
    articles;
}