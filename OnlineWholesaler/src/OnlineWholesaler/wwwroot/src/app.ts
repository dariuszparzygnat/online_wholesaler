export class App {
    constructor() {
    }

    configureRouter(config, router) {
        this.router = router;
        config.title = "Strona główna";
        config.map([{ route: ['', 'articles'], moduleId: 'src/articles/articles', title: 'Main page', nav: true }, { route: ['articlescreator'], moduleId: 'src/articles/articleCreator', title:'Article Creator', nav:true}
            ]);
    }

    router;
}