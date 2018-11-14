let obj1 = {
    age: 11,
    grade:100,
    isMale:true
};

//copy
let obj2={...obj1};

//destruct
let {age}={...obj1};
console.log(age); //--> 11
