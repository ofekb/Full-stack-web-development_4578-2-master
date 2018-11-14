let f1=function(){
    console.log("I am f1");
}



let f2=function f3(nonSelfCall){
    console.log("I am f2");
    if(nonSelfCall)
        f3(false); //here is the only place that we can use the `f3` name
}


f1();  //--> I am f1
f2(true);  //--> I am f2   I am f2
f3(true);  //--> ReferenceError: f3 is not defined