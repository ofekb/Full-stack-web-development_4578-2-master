# Steps to run ts file with vs code
## Step 1 - open node command prompt
![picture](step1.png)
---
## Step 2 - check current global npm pkgs
```bash
cd "AppData\Roaming\npm"  # change current path to the folder that stores all the global npm pkgs
ls  # show all content of currnt folder
```
As output we got:
```bash
etc/  node_modules/ 
``` 
## Step 3 - install tsc global (with npm)
![picture](step2.png)
---
## Step 4 - check current global npm pkgs after ts install
```bash
cd "AppData\Roaming\npm"  # change current path to the folder that stores all the global npm pkgs
ls  # show all content of currnt folder
```
As output we got:
```bash
etc/  node_modules/           
tsserver*   tsserver.cmd   tsc*  tsc.cmd
```
## Step 5 - create a new ts file named `index.ts`, with the following content:
```typescript
let num:number=4;
```

## Step 6 - open command prompt
* click *right click* on the `index.ts` file
* choose `open in command prompt`
As output we got:
```bash
etc/  node_modules/ 
```
---
## Step 7 - run command to craete js file
* in the command prompt that we opened in the prev step, write this command:
```bash
tsc index.ts
```
* this command will create a `index.js` file, with this content:
```javascript
var num=4;
```
---
## Step 8 - transpile all ts files with one command:
* add to the app folder a new filenamed `tsconfig.json`, with the following content:
```json
{
    "compilerOptions": {
        "target": "es5",
        "module": "commonjs",
        "sourceMap": true
    }
}
```
* click `control + shift + b` and run:
***
![picture](step3.png)




