/*
When we use a JSON object in TS
we can assign it to a class or to an interface.
What is the right way?
JSON object - is a ready object that needs to have all the class members
that the class contains.
So the right way is to create an interface that only declares a struct.
*/
var Post = /** @class */ (function () {
    function Post() {
        this.userId = 2;
        this.id = 2;
        this.title = "Test";
        this.body = "Bob & Alice";
    }
    Post.prototype.getPost = function () {
        return this.title + ":" + this.body;
    };
    return Post;
}());
var jsonObj = {
    userId: 1,
    id: 1,
    title: "sunt",
    body: "quia"
};
var p1 = new Post();
var p2 = jsonObj;
console.log(p1); //--> { userId: 2, id: 2, title: 'Test', body: 'Bob & Alice' }
console.log(p2); //--> { userId: 1, id: 1, title: 'sunt', body: 'quia' }
console.log(p1.getPost()); //--> Test:Bob & Alice
console.log(p2.getPost()); //--> I am json - sunt:quia
