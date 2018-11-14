let privateSecret="I am a private property";

export function test1(){
    console.log("test1 privateSecret:",privateSecret);
}

export function test2(newSecret){
    privateSecret=newSecret;
    console.log("test2 privateSecret:",privateSecret);
}

export function test3(){
    console.log("test3");
}

