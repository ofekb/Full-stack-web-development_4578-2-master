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
// base class - מחלקת בסיס
var A = /** @class */ (function () {
    function A() {
    }
    A.prototype.only_in_A = function () {
        return "A in only_in_A";
    };
    A.prototype.only_in_A_B = function () {
        return "A in only_in_A_B";
    };
    return A;
}());
//sub class - נגזרת
var B = /** @class */ (function (_super) {
    __extends(B, _super);
    function B() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    B.prototype.only_in_A_B = function () {
        return _super.prototype.only_in_A_B.call(this) + " & B in only_in_A_B";
    };
    return B;
}(A));
var objA = new A();
var objB = new B();
console.log(objA.only_in_A()); //"A in only_in_A"
console.log(objB.only_in_A()); //"A in only_in_A"
console.log(objA.only_in_A_B()); //"A in only_in_A_B"
console.log(objB.only_in_A_B()); //"A in only_in_A_B & B in only_in_A_B"
//# sourceMappingURL=app.js.map