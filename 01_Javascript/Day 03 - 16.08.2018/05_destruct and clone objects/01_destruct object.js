let obj={
    b1:"A",
    b2:"B",
    b3:"C",
    b4:"D"
};


let a1=obj["b1"];
let a2=obj["b2"];
let a4=obj["b4"];

console.log(a1,a2,a4);  //--> A B D


let {b1,b2,b4}={...obj};

console.log(b1,b2,b4);  //--> A B D