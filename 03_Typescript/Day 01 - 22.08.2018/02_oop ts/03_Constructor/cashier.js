var Cashier = /** @class */ (function () {
    //the constructor is called every time when we create a "new Cashier()"
    function Cashier() {
        document.write("we have a new Cashier!!!!<br/>");
    }
    //***********way 1 -  to create a setter and a getter function*********
    //get - will return the value of the private member
    //will allways return the member type, and will never get parameters
    Cashier.prototype.getCinemaName = function () {
        return this._cinemaName;
    };
    //set - will change the value of the private member
    //will allways return void, and will get a single parameter with the member type
    Cashier.prototype.setCinemaName = function (cinemaName) {
        if (cinemaName == "YesPlanet" || cinemaName == "CinemaCity") {
            this._cinemaName = cinemaName;
        }
    };
    Object.defineProperty(Cashier.prototype, "age", {
        //***********way 2 -  to create a setter and a getter property*********
        get: function () {
            return this._age;
        },
        set: function (ageProp) {
            if (ageProp >= 16 && ageProp <= 80)
                this._age = ageProp;
        },
        enumerable: true,
        configurable: true
    });
    return Cashier;
}());
//# sourceMappingURL=cashier.js.map