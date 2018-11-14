import { Component } from '@angular/core';
import { CounterService } from '../shared/services/counter.service';

@Component({
  selector: 'app-child2',
  templateUrl: './child2.component.html',
  styleUrls: ['./child2.component.css']
})
export class Child2Component  {

  localIndex:number;

  constructor(private counterService: CounterService) { 
    this.localIndex=this.counterService.index;
  }

  onIncrement() {
    this.counterService.incIndex();
    this.localIndex=this.counterService.index;
  }

}
