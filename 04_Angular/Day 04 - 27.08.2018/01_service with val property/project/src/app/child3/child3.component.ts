import { Component } from '@angular/core';
import { CounterService } from '../shared/services/counter.service';

@Component({
  selector: 'app-child3',
  templateUrl: './child3.component.html',
  styleUrls: ['./child3.component.css']
})
export class Child3Component {
  localIndex:number;

  constructor(private counterService: CounterService) { 
    this.localIndex=this.counterService.index;
  }

  onIncrement() {
    this.counterService.incIndex();
    this.localIndex=this.counterService.index;
  }

}
