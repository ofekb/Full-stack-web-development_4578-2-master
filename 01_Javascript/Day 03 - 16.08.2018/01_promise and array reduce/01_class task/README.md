# Chain promise in dynamic way
## Exercise goal:
create html page, with js code that:
* repeats a timer 3 times, in the following order:
- sec to timer 1 : 2 sec
- sec to timer 2 : 4 sec
- sec to timer 3 : 1 sec

## Exercise Html code:
```html
<!DOCTYPE html>
<html lang="en">

<head>
    <script>
        let secToWait = [2, 4, 1];

        function callPromise(prevPromise, sec, timerIndex) {
            return prevPromise.then(() => new Promise((resolve, reject) => {
                setTimeout(
                    () => {
                        console.log(`Timer number ${timerIndex}, waited ${sec} sec (${(new Date()).toLocaleTimeString()})`);
                        resolve();
                    }, sec * 1000)
            }));
        }

        secToWait.reduce(callPromise,new Promise((x,y)=>{x()}))

    </script>
</head>

<body>
</body>

</html>
```
## Exercise output:
```bash
OUTPUT:
___________________________________
Timer number 1, waited 2 sec (9:15:58)
Timer number 2, waited 4 sec (9:16:02)
Timer number 3, waited 1 sec (9:16:03)
```


## `secToWait.reduce` - Running simulation:

### Step 1
##### prevPromise:
```javascript
(new Promise((x,y)=>{x()})) 
```
##### sec:
`2`
##### timerIndex:
`0`
##### return:
```javascript
    new Promise((x,y)=>{x()})
    .then(() => new Promise((resolve, reject) => {
        setTimeout(
            () => {
                console.log(`Timer number ${timerIndex}, waited ${sec} sec (${(new Date()).toLocaleTimeString()})`);
                resolve();
            }, 2 * 1000)
    }));
```

***

### Step 2
##### prevPromise:
```javascript
    new Promise((x,y)=>{x()})
    .then(() => new Promise((resolve, reject) => {
        setTimeout(
            () => {
                console.log(`Timer number ${timerIndex}, waited ${sec} sec (${(new Date()).toLocaleTimeString()})`);
                resolve();
            }, 2 * 1000)
    }));
```
##### sec:
`4`
##### timerIndex:
`1`
##### return:
```javascript
    new Promise((x,y)=>{x()})
    .then(() => new Promise((resolve, reject) => {
        setTimeout(
            () => {
                console.log(`Timer number ${timerIndex}, waited ${sec} sec (${(new Date()).toLocaleTimeString()})`);
                resolve();
            }, 2 * 1000)
    }))
    .then(() => new Promise((resolve, reject) => {
        setTimeout(
            () => {
                console.log(`Timer number ${timerIndex}, waited ${sec} sec (${(new Date()).toLocaleTimeString()})`);
                resolve();
            }, 4 * 1000)
    }))
```

***

### Step 3
##### prevPromise:
```javascript
  new Promise((x,y)=>{x()})
    .then(() => new Promise((resolve, reject) => {
        setTimeout(
            () => {
                console.log(`Timer number ${timerIndex}, waited ${sec} sec (${(new Date()).toLocaleTimeString()})`);
                resolve();
            }, 2 * 1000)
    }))
    .then(() => new Promise((resolve, reject) => {
        setTimeout(
            () => {
                console.log(`Timer number ${timerIndex}, waited ${sec} sec (${(new Date()).toLocaleTimeString()})`);
                resolve();
            }, 4 * 1000)
    }))
```
##### sec:
`1`
##### timerIndex:
`2`
##### return:
```javascript
  new Promise((x,y)=>{x()})
    .then(() => new Promise((resolve, reject) => {
        setTimeout(
            () => {
                console.log(`Timer number ${timerIndex}, waited ${sec} sec (${(new Date()).toLocaleTimeString()})`);
                resolve();
            }, 2 * 1000)
    }))
    .then(() => new Promise((resolve, reject) => {
        setTimeout(
            () => {
                console.log(`Timer number ${timerIndex}, waited ${sec} sec (${(new Date()).toLocaleTimeString()})`);
                resolve();
            }, 4 * 1000)
    }))
    .then(() => new Promise((resolve, reject) => {
        setTimeout(
            () => {
                console.log(`Timer number ${timerIndex}, waited ${sec} sec (${(new Date()).toLocaleTimeString()})`);
                resolve();
            }, 1 * 1000)
    }))
```




        
    
                       
         
         

      