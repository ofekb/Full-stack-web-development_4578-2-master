let privateSecret="I am a private property";

function test1(){
    console.log("test1 privateSecret:",privateSecret);
}

function test2(newSecret){
    privateSecret=newSecret;
    console.log("test2 privateSecret:",privateSecret);
}


function test3(){
    console.log("test3");
}

