import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";


@Injectable()
export class CountryService {
    private link = "https://restcountries.eu/rest/v2/name/israel?fields=population";  // returns: [{"population":8527400}]

    wrapObject = { population: undefined };

    constructor(private myHttpClient: HttpClient) { }


    getFirstWay(): void {
        this.myHttpClient.get(this.link).subscribe(
            (res) => { this.wrapObject.population = res[0].population }
        )
    }

    getSecondWay(): Observable<Object> {
        let req: Observable<Object> = this.myHttpClient.get(this.link);
        return req;
    }


    getThirdWay(funcParam:(num:number)=>void):void{
        this.myHttpClient.get(this.link).subscribe(
            (res) => { funcParam(res[0].population) }
        )
    }

}