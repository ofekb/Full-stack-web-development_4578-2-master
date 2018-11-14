# Ways to update controller when a http response was returned to a service:

* create a property in the service, and in the `subscribe` - save the response value to this property 
(in this way - we need to take care that the component should point to the same value that the service points)
* return from the service the whole request object (is an `observable` type), and in the component write the `subscribe` method
* get to the function in the service a callback (parameter that is a function created by the component), and in the `subscribe` - the service will execute the callback function that will affect the component that sent this callback

# See live demo
https://saldat-angular.herokuapp.com/HttpClient

# Full examle 
## service (\src\app\shared\services\country.service.ts)
```typescript

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
        let req: Observable<Object>;
        req = this.myHttpClient.get(this.link);
        return req;
    }


    getThirdWay(funcParam:(num:number)=>void):void{
        this.myHttpClient.get(this.link).subscribe(
            (res) => { funcParam(res[0].population) }
        )
    }


}
```

## compnent class (\src\app\app.component.ts)
```typescript
import { Component } from '@angular/core';
import { CountryService } from './shared/services/country.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  firstWay: any;
  secondWay: number;
  thirdWay:number;

  constructor(private myCountryService: CountryService) {
    
    this.firstWay = this.myCountryService.wrapObject;
    this.myCountryService.getFirstWay();

    this.myCountryService.getSecondWay().subscribe(
      (res) => { this.secondWay = res[0].population }
    );


    this.myCountryService.getThirdWay(
      (n:number)=>{this.thirdWay=n}
    );
  }
}

```

## compnent template (\src\app\app.component.html)
```html
<h1>First way</h1>
<p>population: {{firstWay.population}}</p>

<h1>Second way</h1>
<p>population: {{secondWay}}</p>

<h1>Third way</h1>
<p>population: {{thirdWay}}</p>
```


# Example result:
![picture](screenshot.png)
