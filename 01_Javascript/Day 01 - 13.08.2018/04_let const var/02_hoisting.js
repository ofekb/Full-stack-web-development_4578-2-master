
f1();  //--> f1 V1
console.log(a1);  //--> undefined
console.log(b1);  //--> ReferenceError: b1 is not defined
console.log(c1);  //--> ReferenceError: c1 is not defined

//---------hoisting function-------------- (OK - CAN USE THE FUNCTION)
function f1(){
    console.log("f1 V1");
} 

//---------hoisting var-------------- (OK - VAR IS UNDEFINED)
var a1=0;



//---------hoisting const-------------- (NOT OK)
const b1=0;


//---------hoisting let-------------- (NOT OK)
let c1=0;








