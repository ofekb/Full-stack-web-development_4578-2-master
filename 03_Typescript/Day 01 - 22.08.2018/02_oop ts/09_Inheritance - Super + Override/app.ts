//A is base class of B
class A {
    public only_in_A(): string {
        return "A in only_in_A";
    }

    public only_in_A_B(): string {
        return "A in only_in_A_B";
    }

    public only_in_A_B_C(): string {
        return "A in only_in_A_B_C";
    }
}

//B is sub class of A
//B is base class of C
class B extends A {
    public only_in_A_B(): string {
        return super.only_in_A_B()+" & B in only_in_A_B";
    }

    public only_in_A_B_C(): string {
        return super.only_in_A_B_C()+" & B in only_in_A_B_C";
    }
}


//C is sub class of B
class C extends B {
    public only_in_A_B_C(): string {
        return super.only_in_A_B_C()+" & C in only_in_A_B_C";
    }
}


let objA: A = new A();
let objB: B = new B();
let objC: C = new C();

console.log(objA.only_in_A());  //"A in only_in_A"
console.log(objB.only_in_A());  //"A in only_in_A"
console.log(objC.only_in_A());  //"A in only_in_A"


console.log(objA.only_in_A_B());  //"A in only_in_A_B"
console.log(objB.only_in_A_B());  //"A in only_in_A_B & B in only_in_A_B"
console.log(objC.only_in_A_B());  //"A in only_in_A_B & B in only_in_A_B"


console.log(objA.only_in_A_B_C());  //"A in only_in_A_B_C"
console.log(objB.only_in_A_B_C());  //"A in only_in_A_B_C & B in only_in_A_B_C"
console.log(objC.only_in_A_B_C());  //"A in only_in_A_B_C & B in only_in_A_B_C & C in only_in_A_B_C""