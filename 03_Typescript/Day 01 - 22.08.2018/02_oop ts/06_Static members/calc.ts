
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

class Calc {

  public localCounter:number=0;
  public static staticCounter:number=0;

  public nonStaticFunc(){
    console.log(`nonStaticFunc:${this.localCounter},${Calc.staticCounter}`);
  }


  public static staticFunc(){
    console.log(`staticFunc:${Calc.staticCounter}`);
  }

  public constructor(){
      console.log(`localCounter:${this.localCounter++},staticCounter:${Calc.staticCounter++}`);
  }

}