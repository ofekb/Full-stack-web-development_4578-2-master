# ViewEncapsulation
Defines template and style encapsulation options available for Component's:
* `Emulated` - This is the default option -Emulate scoping of styles by adding an attribute containing surrogate id to the Host
* `None` - Don't provide any template or style encapsulation 
* `ShadowDom`- For the DOM this means using modern ShadowDOM and creating a ShadowRoot for Component's Host Element.
* `Native` -Deprecated (in angular 6) - use {ViewEncapsulation.ShadowDom} instead

## Run this app in dev mode:
```bash
npm i
ng serve --open
```

## See live demo:
https://saldat-angular.herokuapp.com/ViewEncapsulation






