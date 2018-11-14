//A is base class of B
class A {
  public num1: number = 1;
}

//B is sub class of A
//B is base class of C
class B extends A {
  public num2: number = 2;
}

//C is sub class of B ( is sub class of A)
class C extends B {
  public num3: number = 3;
}

// objA can point to any object that is instance of A / sub class of A
let objA1: A = new B();

if (objA1 instanceof B) {
  //first way of down cast
  console.log((<B>objA1).num2);

  //second way of down cast
  console.log((objA1 as B).num2);
}
