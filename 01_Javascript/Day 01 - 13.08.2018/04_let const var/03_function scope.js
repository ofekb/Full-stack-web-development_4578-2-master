

function testScope() {
    //---------scope function-------------- (NOT OK OUTSIDE FUNCTION)
    function f1() {
        console.log("f1 V1");
    }

    //---------scope var-------------- (NOT OK OUTSIDE FUNCTION)
    var a1 = 0;



    //---------scope const-------------- (NOT OK OUTSIDE FUNCTION)
    const b1 = 0;


    //---------scope let-------------- (NOT OK OUTSIDE FUNCTION)
    let c1 = 0;

    f1();  //--> f1 V1
    console.log(a1);  //--> 0
    console.log(b1);  //--> 0
    console.log(c1);  //--> 0

}


testScope();

f1();  //--> ReferenceError: f1 is not defined
console.log(a1);  //--> ReferenceError: a1 is not defined
console.log(b1);  //--> ReferenceError: b1 is not defined
console.log(c1);  //--> ReferenceError: c1 is not defined





