
// 3 ways to declare a string in js:
let str1 = "1+1=" + (1 + 1);
let str2 = '1+1=' + (1 + 1);
let str3 = `1+1=${1 + 1}`;

console.log(str1);  //--> 1+1=2
console.log(str2);  //--> 1+1=2
console.log(str3);  //--> 1+1=2

let num = 4;

str1 = num + " * " + num + " = " + (num * num);
str2 = num + ' * ' + num + ' = ' + (num * num);
str3 = `${num} * ${num} = ${num * num}`;

console.log(str1);  //--> 4 * 4 = 16
console.log(str2);  //--> 4 * 4 = 16
console.log(str3);  //--> 4 * 4 = 16

