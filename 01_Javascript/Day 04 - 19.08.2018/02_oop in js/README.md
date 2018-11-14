# OOP IN JS


## SIMPLE OBJECT 
By default - js has JSON objects, this objects are not a blueprint to create new objects - They are singletones


* Simple object
```javascript
//first way too craete a json object
let obj1={
    name:"Bob",
    age:20
};


//second way too craete a json object
let obj2=new Object();
obj2.name="Bob";
obj2.age=20;
```

* Proto between JSON objects
```javascript
let person={
    name:"Bob",
    age:20
}


let student={
    grade:100,
    __proto__:person  //__proto__ is a js keyword
}


console.log(student.name, student.age, student.grade);  //--> Bob 20 100
```


## CLASS DECLERATION
* Constructor function 
```html
<!DOCTYPE html>
<html lang="en">

<head>
    <script>
        function Dog(color, age) {
            this.color = color;
            this.age = age;

            this.getDescription = () => {
                console.log(`color: ${this.color}, age: ${this.age}`);
            }
        }


        let dog1 = new Dog("black", 5);
        console.log(window.color, window.age);  //--> undefined undefined
        dog1.getDescription();  //--> color: black, age: 5


        let dog2 = Dog("white", 4);
        console.log(window.color, window.age);  //--> white 4
        dog2.getDescription();  //--> TypeError: Cannot read property 'getDescription' of undefined
    </script>
</head>

<body></body>

</html>
```


* Constructor function - prototype
```javascript
function Animal() {
    this.name = "Animal";
}


function Dog(){
    this.color="Brown";
}

Dog.prototype=new Animal();


let dog1=new Dog();
console.log(dog1.name);  //--> Animal
```

* class 
```javascript
class Animal {
    constructor(age) {
        this.name = "Animal"
        this.age=age;
    }

    getDescription() {
        return `I am an ${this.name}, and I am ${this.age} years old`;
    }
}


let animal1=new Animal(20);
console.log(animal1.getDescription());  //--> I am an Animal, and I am 20 years old

```

* class extending
```javascript
class Animal {
    constructor(age) {
        this.name = "Animal"
        this.age=age;
    }

    getDescription() {
        return `I am an ${this.name}, and I am ${this.age} years old`;
    }
}

class Dog extends Animal{
    constructor(age,color) {
       super(age);
       this.color=color;
    }


    getDescription() {
        return `${super.getDescription()}, and my color is ${this.color}`;
    }

}
let animal1=new Animal(20);
console.log(animal1.getDescription());  //--> I am an Animal, and I am 20 years old


let dog1=new Dog(20,"black");
console.log(dog1.getDescription());  //--> I am an Animal, and I am 20 years old, and my color is black

console.log(animal1 instanceof Object);     //-->  true
console.log(animal1 instanceof Animal);     //-->  true
console.log(animal1 instanceof Dog);        //-->  false


console.log(dog1 instanceof Object);        //-->  true
console.log(dog1 instanceof Animal);        //-->  true
console.log(dog1 instanceof Dog);           //-->  true
```

