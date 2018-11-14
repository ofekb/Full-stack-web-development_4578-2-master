class Shift {
  private _startTime: number;
  private _endTime: number;
  private _numOfCashiers: number;
  private _cashierArr: Array<Cashier>;

  public constructor(
    startTimeParam: number = 10,
    endTimeParam: number = 18,
    numOfCashiersParam: number = 3
  ) {
    this.startTime = startTimeParam;
    this.endTime = endTimeParam;
    this.numOfCashiers = numOfCashiersParam;
  }

  /////////set + get for private array
  public get cashierArr(): Array<Cashier> {
    return this._cashierArr;
  }

  public set cashierArr(arr: Array<Cashier>) {
    this._cashierArr = arr;
  }

  /////////set + get for private members
  public get startTime(): number {
    return this._startTime;
  }

  public set startTime(num: number) {
    this._startTime= (num >= 0 && num <= 24)?num:0;
  }

  public get endTime(): number {
    return this._endTime;
  }

  public set endTime(num: number) {
    this._endTime = (num >= 0 && num <= 24) ? num : 0;
  }

  public get numOfCashiers(): number {
    return this._numOfCashiers;
  }

  public set numOfCashiers(num: number) {
    this._numOfCashiers=(num >= 3 && num <= 20)?num:3;
  }

}
