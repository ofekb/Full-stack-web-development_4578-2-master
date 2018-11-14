# How to run an import + export app with webpack?
* Create a new folder with this command:
```bash
mkdir app
```
* change dir to the new app, with this command:
```bash
cd app
```
* Init the folder with a new npm config, with this command:
```bash
npm init -y
```
this command will add to the folder, a new file named `package.json` with this content:
```json
{
  "name": "app",
  "version": "1.0.0",
  "description": "",
  "main": "index.js",
  "scripts": {
    "test": "echo \"Error: no test specified\" && exit 1"
  },
  "keywords": [],
  "author": "",
  "license": "ISC"
}
```
* Add a new package from npm , with this command:
```bash
npm i --save-dev webpack 
npm i --save-dev webpack-cli 
```
this command will add a new file named `package-lock.json`, and a new folder named `node_modules` that contains all the pkg's code. 
   
the `package.json` file has been changed by this command, and saves the name of the new installed pkg:
```json
{
  "name": "webpack-demo",
  "version": "1.0.0",
  "description": "",
  "main": "index.js",
  "scripts": {
    "test": "echo \"Error: no test specified\" && exit 1",
  },
  "keywords": [],
  "author": "",
  "license": "ISC",
  "devDependencies": {
    "webpack": "^4.16.1",
    "webpack-cli": "^3.0.8"
  }
}
```
* Add to `package.json` file in the `scripts` part the following content:
```json
  "scripts": {
    "build": "webpack --mode production"
  }
```
* Add to app folder, two new sub-folders , with this command:
```bash
mkdir src dist
```
* Add to `app/src` a new file, named `calc.js`, with the following content:
```javascript
export function add(n1,n2){
    return n1+n2;
}
```
* Add to `app/src` a new file, named `app.js`, with the following content:
```javascript
import {add} from './calc.js';
document.write("import + export worked!!! "+add(1,2));
```
* Add to `app/dist` a new file, named `index.html`, with the following content:
```html
<!doctype html>
<html>
  <head>
    <title>Hello Webpack</title>
  </head>
  <body>
    <script src="bundle.js"></script>
  </body>
</html>
```
* Add to `app` folder a new file named `webpack.config.js` with the following content:

```javascript
const path = require('path')

module.exports = {
  entry: './src/app.js',
  output: {
    filename: 'bundle.js',
    path: path.resolve(__dirname, 'dist')
  }
}
```

* Run the following command (the path in the cmd should be in tha app folder):
```bash
npm run build
```
and as output you will get a new file `bundle.js` in the `app/dist` folder 
* Run `app/dist/index.html` in the browser, and get this result in the window:
```
import + export worked!!! 3
```
