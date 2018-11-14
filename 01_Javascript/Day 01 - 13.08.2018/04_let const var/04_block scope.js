

if(true){
    //---------scope function-------------- (OK OUTSIDE BLOCK)
    function f1() {
        console.log("f1 V1");
    }

    //---------scope var-------------- (OK OUTSIDE BLOCK)
    var a1 = 0;



    //---------scope const-------------- (NOT OK OUTSIDE BLOCK)
    const b1 = 0;


    //---------scope let-------------- (NOT OK OUTSIDE BLOCK)
    let c1 = 0;

    f1();  //--> f1 V1
    console.log(a1);  //--> 0
    console.log(b1);  //--> 0
    console.log(c1);  //--> 0

}


f1();  //--> f1 V1
console.log(a1);  //--> 0
console.log(b1);  //--> ReferenceError: b1 is not defined
console.log(c1);  //--> ReferenceError: c1 is not defined





