let shift1 = new Shift();
let cashierArray: Array<Cashier> = new Array<Cashier>(shift1.numOfCashiers);

for (let i: number = 0; i < cashierArray.length; i++) {
    cashierArray[i] = new Cashier();
}

shift1.cashierArr = cashierArray;


console.log(shift1);











