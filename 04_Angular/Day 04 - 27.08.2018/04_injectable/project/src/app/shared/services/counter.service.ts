import { MathService } from "./math.service";
import { Injectable } from "../../../../node_modules/@angular/core";

@Injectable()
export class CounterService{

    constructor(private mathService:MathService){}
    index={cnt:0};

    incIndex(){
        this.index.cnt=
            this.mathService.incNum(this.index.cnt);
    }
}