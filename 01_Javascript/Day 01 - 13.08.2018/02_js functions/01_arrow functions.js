//----------- declare a function that gets no parametrs and returns void ---------------
let f1=()=>{console.log("f1")};


//----------- declare a function that gets no parametrs and returns number ---------------
let f2=()=>{return 4;};
let f3=()=>4;  // if the body is only return command, we can remove `{return ;};`


//----------- declare a function that gets one parametr and returns number ---------------
let f4=(num)=>{return num;};
let f5=num=>num;  // if the function gets only one parameter we can remove the ()


f1();  //--> f1
console.log(f2());  //--> 4
console.log(f3());  //--> 4
console.log(f4(8));  //--> 8
console.log(f5(8));  //--> 8

