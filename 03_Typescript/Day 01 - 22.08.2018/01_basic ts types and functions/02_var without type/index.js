/*********************************
 * VARIABELS
**********************************/
//---------------assign value in decleration line (gets the type of the value)----------------------
var a1 = 5;
//a1="test";  //COMPILATION ERROR -> Type '"test"' is not assignable to type 'number'
a1 = 6;
//---------------non assigned value in decleration line (gets `any` type)----------------------
var a2;
a2 = 5;
a2 = "test";
//---------------non assigned value in decleration line - but defined a type----------------------
var a3;
a3 = 5;
//a3="test"; //COMPILATION ERROR -> Type '"test"' is not assignable to type 'number'
/*********************************
 * FUNCTION
**********************************/
//func1(n1: any): string
function func1(n1) {
    return "test";
}
//func2(n1: any): void
function func2(n1) {
}
