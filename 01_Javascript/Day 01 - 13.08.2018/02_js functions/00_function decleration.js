function f1(){
    console.log("f1");
}

let f2=f1;


let f3=function(){
    console.log("f3");
};


let f4=()=>{
    console.log("f4");
};


f1();  //--> f1
f2();  //--> f1
f3();  //--> f3
f4();  //--> f4