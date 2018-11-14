var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    }
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
//A is base class of B
var A = /** @class */ (function () {
    function A() {
    }
    A.prototype.only_in_A = function () {
        return "A in only_in_A";
    };
    A.prototype.only_in_A_B = function () {
        return "A in only_in_A_B";
    };
    A.prototype.only_in_A_B_C = function () {
        return "A in only_in_A_B_C";
    };
    return A;
}());
//B is sub class of A
//B is base class of C
var B = /** @class */ (function (_super) {
    __extends(B, _super);
    function B() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    B.prototype.only_in_A_B = function () {
        return _super.prototype.only_in_A_B.call(this) + " & B in only_in_A_B";
    };
    B.prototype.only_in_A_B_C = function () {
        return _super.prototype.only_in_A_B_C.call(this) + " & B in only_in_A_B_C";
    };
    return B;
}(A));
//C is sub class of B
var C = /** @class */ (function (_super) {
    __extends(C, _super);
    function C() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    C.prototype.only_in_A_B_C = function () {
        return _super.prototype.only_in_A_B_C.call(this) + " & C in only_in_A_B_C";
    };
    return C;
}(B));
var objA = new A();
var objB = new B();
var objC = new C();
console.log(objA.only_in_A()); //"A in only_in_A"
console.log(objB.only_in_A()); //"A in only_in_A"
console.log(objC.only_in_A()); //"A in only_in_A"
console.log(objA.only_in_A_B()); //"A in only_in_A_B"
console.log(objB.only_in_A_B()); //"A in only_in_A_B & B in only_in_A_B"
console.log(objC.only_in_A_B()); //"A in only_in_A_B & B in only_in_A_B"
console.log(objA.only_in_A_B_C()); //"A in only_in_A_B_C"
console.log(objB.only_in_A_B_C()); //"A in only_in_A_B_C & B in only_in_A_B_C"
console.log(objC.only_in_A_B_C()); //"A in only_in_A_B_C & B in only_in_A_B_C & C in only_in_A_B_C""
//# sourceMappingURL=app.js.map