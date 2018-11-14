/*
When we use a JSON object in TS 
we can assign it to a class or to an interface.
What is the right way?
JSON object - is a ready object that needs to have all the class members
that the class contains.
So the right way is to create an interface that only declares a struct. 
*/

class Post {
    userId: number=2;
    id: number=2;
    title: string="Test";
    body: string="Bob & Alice";
  
    getPost(): string {
      return `${this.title}:${this.body}`;
    }
  }
  
  let jsonObj: any = {
    userId: 1,
    id: 1,
    title: "sunt",
    body: "quia",
    getPost: function(): string {
      return `I am json - ${this.title}:${this.body}`;
    }
  };
  
  let p1: Post = new Post();
  let p2: Post = jsonObj;
  
    
  console.log(p1); //--> { userId: 2, id: 2, title: 'Test', body: 'Bob & Alice' }
  console.log(p2); //--> { userId: 1, id: 1, title: 'sunt', body: 'quia' }
  
  console.log(p1.getPost());  //--> Test:Bob & Alice
  console.log(p2.getPost());  //--> I am json - sunt:quia
  