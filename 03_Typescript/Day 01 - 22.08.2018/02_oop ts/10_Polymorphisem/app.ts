//A is base class of B
class A {}

//B is sub class of A
//B is base class of C
class B extends A {}


//C is sub class of B ( is sub class of A)
class C extends B {}


// objA can point to any object that is instance of A / sub class of A
let objA1: A = new A();
let objA2: A = new B();
let objA3: A = new C();

// objB can point to any object that is instance of B / sub class of B
let objB1: B = new B();
let objB2: B = new C();

// objC can point to any object that is instance of C / sub class of C
let objC: C = new C();