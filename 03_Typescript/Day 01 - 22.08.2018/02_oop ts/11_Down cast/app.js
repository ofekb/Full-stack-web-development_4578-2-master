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
        this.num1 = 1;
    }
    return A;
}());
//B is sub class of A
//B is base class of C
var B = /** @class */ (function (_super) {
    __extends(B, _super);
    function B() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.num2 = 2;
        return _this;
    }
    return B;
}(A));
//C is sub class of B ( is sub class of A)
var C = /** @class */ (function (_super) {
    __extends(C, _super);
    function C() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.num3 = 3;
        return _this;
    }
    return C;
}(B));
// objA can point to any object that is instance of A / sub class of A
var objA1 = new B();
if (objA1 instanceof B) {
    //first way of down cast
    console.log(objA1.num2);
    //second way of down cast
    console.log(objA1.num2);
}
//# sourceMappingURL=app.js.map