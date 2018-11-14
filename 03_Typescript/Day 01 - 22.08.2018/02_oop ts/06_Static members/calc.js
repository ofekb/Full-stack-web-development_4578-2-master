/*
static function can only access:
    1)static function
    2)static properties
static function can not access:
    1)non-static function
    2)non-static properties

---------------------------------
non-static function can access:
    1)static function
    2)static properties
    3)non-static function
    4)non-static properties
*/
var Calc = /** @class */ (function () {
    function Calc() {
        this.localCounter = 0;
        console.log("localCounter:" + this.localCounter++ + ",staticCounter:" + Calc.staticCounter++);
    }
    Calc.prototype.nonStaticFunc = function () {
        console.log("nonStaticFunc:" + this.localCounter + "," + Calc.staticCounter);
    };
    Calc.staticFunc = function () {
        console.log("staticFunc:," + Calc.staticCounter);
    };
    Calc.staticCounter = 0;
    return Calc;
}());
//# sourceMappingURL=calc.js.map