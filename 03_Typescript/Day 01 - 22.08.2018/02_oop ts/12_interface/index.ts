interface A {
  funcA(num: number): void;
}

interface B extends A {
  funcB(): boolean;
}

interface C {
  myNum1: number;
  myNum2?: number;  //optional to implement
  funcC(): void;
}

class D implements B, C {
  public myNum1: number = 5;
  public funcA(num: number): void {
    console.log(num);
  }

  public funcB(): boolean {
    return true;
  }

  public funcC(): void {
    console.log("funcC");
  }
}

//type A can point to any object of a class that implements A
let objA:A=new D();



//let objA:A=new A();  //COMPILATION ERROR -> 'A' only refers to a type, but is being used as a value here.
