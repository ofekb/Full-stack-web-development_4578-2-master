import { Component } from '@angular/core';
import { MathService } from '../shared/services/math.service';

@Component({
  selector: 'app-child1',
  templateUrl: './child1.component.html',
  styleUrls: ['./child1.component.css']
})
export class Child1Component {

  constructor(private mathService: MathService) { }
  index = 0;

  onClick() {
    this.mathService.subject
    .next(`Child1 says: ${this.index++}`);
  }
}
