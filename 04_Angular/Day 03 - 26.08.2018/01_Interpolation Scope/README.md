# Interpolation scope in angular

### Important rules:
* every value / function that we use in the `html template` in the component, adds by default the prefix of `this` that refers to the ts class of the componenet
* If we want to use a `static class member` in the interpolation, we have to ceate a non-static way to access this static property, via `this` keyword
* If want to use an exusting type in the interpolation, we have to ceate a class-memner that points to this type so we can access this type, via `this` keyword (in tghis example we created a class pointer to an enum)


### Code of this project
##### \src\app\shared\models\color.model.ts:
```typescript
export enum Color{
    Yellow,
    Green,
    Red,
    Black,
    Brown
}
```
##### \src\app\app.component.ts:
```typescript
import { Component } from '@angular/core';
import { Color } from './shared/models/color.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  //-------acess static via interpolation--------
  static fullStaticName = "Saldat";
  get fullname() {
        return AppComponent.fullStaticName;
  }

  //-------acess type via interpolation--------
  enumHolder: typeof Color = Color;
  selectedColor: Color = 0;

  setColor(newColor:number){
    this.selectedColor=newColor;
  }

  get colorList() {
    return Object.keys(Color).filter(x => isNaN(Number(x)))
  }

 
}

```
##### \src\app\app.component.html:
```html
<h1>Color Selection</h1>
<select (change)="setColor($event.target.value)">
  <option *ngFor="let y of colorList, let i=index" [value]="i">{{y}}</option>
</select>

<h3>Selected color: {{enumHolder[selectedColor]}}</h3>

<hr/>
<p>static name: {{fullname}}</p>
```
## Run this app in dev mode:
```bash
npm i
ng serve --open
```

## See live demo:
https://saldat-angular.herokuapp.com/InterpolationScope






