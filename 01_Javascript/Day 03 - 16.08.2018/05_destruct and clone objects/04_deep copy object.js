let obj1 = {
    age: 11,
    hobbies: ["Sport"]
};

//every change in obj2 will affect obj1 
//because both point to the same object
let obj2=obj1;

//clone obj1 to obj3 (not deep copy)
let obj3={...obj1}

console.log(obj1,obj2,obj3);  //--> { age: 11, hobbies: [ 'Sport' ] } { age: 11, hobbies: [ 'Sport' ] } { age: 11, hobbies: [ 'Sport' ] }

obj3.age=13;
console.log(obj1,obj2,obj3);  //--> { age: 11, hobbies: [ 'Sport' ] } { age: 11, hobbies: [ 'Sport' ] } { age: 13, hobbies: [ 'Sport' ] }

obj3.hobbies[0]="Math";
console.log(obj1,obj2,obj3);  //--> { age: 11, hobbies: [ 'Math' ] } { age: 11, hobbies: [ 'Math' ] } { age: 13, hobbies: [ 'Math' ] }

