import { Component } from '@angular/core';
import { CounterService } from '../shared/services/counter.service';

@Component({
  selector: 'app-child1',
  templateUrl: './child1.component.html',
  styleUrls: ['./child1.component.css'],
  providers: [CounterService]
})
export class Child1Component {

  localIndex:{cnt:number};

  constructor(private counterService: CounterService) { 
    this.localIndex=this.counterService.index;
  }

  onIncrement() {
    this.counterService.incIndex();
  }

}
