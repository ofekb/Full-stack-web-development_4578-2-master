import { Component } from '@angular/core';
import { MathService } from '../shared/services/math.service';

@Component({
  selector: 'app-child2',
  templateUrl: './child2.component.html',
  styleUrls: ['./child2.component.css']
})
export class Child2Component {
  subjectMsg:string[]=[];
  index=0;
  
  constructor(private mathService: MathService) {
    this.mathService.subject.subscribe(
      {
        next: (v:string) => this.subjectMsg.push(v)
      }
    );
   }

   onClick() {
    this.mathService.subject
    .next(`Child2 says: ${this.index++}`);
  }


}
