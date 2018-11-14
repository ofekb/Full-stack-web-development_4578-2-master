import { Component } from '@angular/core';
import { MathService } from './shared/services/math.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  subjectMsg:string[]=[];
  
  constructor(private mathService: MathService) {
    this.mathService.fromVersion().subscribe((x) => {
      console.log(`fromVersion got ${x}`)
    });


    this.mathService.ofVersion().subscribe((x) => {
      console.log(`ofVersion got ${x}`)
    });

   
    this.mathService.subject.subscribe(
      {
        next: (v:string) => this.subjectMsg.push(v)
      }
    );

    this.mathService.subjectVersion(2);
  }
}
