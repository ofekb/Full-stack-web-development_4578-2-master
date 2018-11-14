class Cashier {

    public fullName: string;

    private _cinemaName: string;

    //***********way to create a setter and a getter function*********

    //get - will return the value of the private member
    //will allways return the member type, and will never get parameters
    public getCinemaName(): string{
        return this._cinemaName;
    }


    //set - will change the value of the private member
    //will allways return void, and will get a single parameter with the member type
    public setCinemaName(cinemaName: string): void {
        if (cinemaName) {
            this._cinemaName = cinemaName;
        }
       
    }
}