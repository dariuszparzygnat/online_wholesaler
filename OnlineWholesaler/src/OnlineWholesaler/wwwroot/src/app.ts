export class App {
    constructor() {
    }

    configureRouter(config, router) {
        this.router = router;
        config.title = "Strona główna";
        config.map([{ route: [''], moduleId: 'src/articles/articles', title: 'Main page', nav: true }
            ]);
    }

    router;
}