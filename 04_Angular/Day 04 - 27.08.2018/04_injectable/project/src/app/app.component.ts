import { Component } from '@angular/core';
import { CounterService } from './shared/services/counter.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  localIndex:{cnt:number};

  constructor(private counterService: CounterService) { 
    this.localIndex=this.counterService.index;
  }

  onIncrement() {
    this.counterService.incIndex();
  }
}
