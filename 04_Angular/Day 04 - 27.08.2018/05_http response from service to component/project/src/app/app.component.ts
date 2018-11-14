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
  thirdWay: number;

  constructor(private myCountryService: CountryService) {

    this.firstWay = this.myCountryService.wrapObject;
    this.myCountryService.getFirstWay();

    this.myCountryService.getSecondWay().subscribe(
      (res) => { this.secondWay = res[0].population }
    );


    this.myCountryService.getThirdWay(
      (n: number) => { this.thirdWay = n }
    );
  }
}
