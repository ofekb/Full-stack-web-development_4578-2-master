let arr1=[{num1:2},{num2:3}];

//every change in arr2 will affect arr1 
//because both point to the same array
let arr2=arr1;

//clone arr1 to arr3 (not deep copy)
let arr3=[...arr1];
console.log(arr1,arr2,arr3);  //-->  [ { num1: 2 }, { num2: 3 } ] [ { num1: 2 }, { num2: 3 } ] [ { num1: 2 }, { num2: 3 } ]


arr3[0].num1=8;
console.log(arr1,arr2,arr3);  //--> [ { num1: 8 }, { num2: 3 } ] [ { num1: 8 }, { num2: 3 } ] [ { num1: 8 }, { num2: 3 } ]

arr2[0].num1=9;
console.log(arr1,arr2,arr3);  //--> [ { num1: 9 }, { num2: 3 } ] [ { num1: 9 }, { num2: 3 } ] [ { num1: 9 }, { num2: 3 } ]

