//http://json2ts.com/

interface Post {
    userId: number;
    id: number;
    title: string;
    body: string;
}


let jsonObject: any = {
    userId: 1,
    id: 1,
    title: "sunt",
    body: "quia"
};


  let p0:Post=jsonObject;

  console.log(p0);  //--> { userId: 1, id: 1, title: 'sunt', body: 'quia' }