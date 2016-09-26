export class Article {
    constructor(id, name, description, imgpath) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.imgpath = imgpath;
    }

    activate(model) {
        this.model = model;
    }

    description;
    imgpath;
    name;
    id;
    model;
}