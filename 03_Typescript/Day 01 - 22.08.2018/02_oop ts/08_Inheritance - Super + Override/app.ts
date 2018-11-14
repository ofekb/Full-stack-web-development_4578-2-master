// base class - מחלקת בסיס
class A {
    public only_in_A(): string {
        return "A in only_in_A";
    }

    public only_in_A_B(): string {
        return "A in only_in_A_B";
    }

}

//sub class - נגזרת
class B extends A {
    public only_in_A_B(): string {
        return super.only_in_A_B()+" & B in only_in_A_B";
    }
}

let objA: A = new A();
let objB: B = new B();


console.log(objA.only_in_A());  //"A in only_in_A"
console.log(objB.only_in_A());  //"A in only_in_A"

console.log(objA.only_in_A_B());  //"A in only_in_A_B"
console.log(objB.only_in_A_B());  //"A in only_in_A_B & B in only_in_A_B"