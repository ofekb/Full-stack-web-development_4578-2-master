# How to deploy an node.js app to Heroku

* craete a new account in heroku: 
https://signup.heroku.com/login
* download nodeJS 
* open the nodeJS command prompt, and install globaly the heroku app:
```bash
npm i -g heroku
```
* go to : `"C:\Users\jbt\AppData\Roaming\npm"`, and check that heroku was installed successfully
* craete a new folder for the node js app:
```bash
mkdir test
```
* change your path to this folder:
```bash
cd test
```
* now, init this app with a package.json folder, with the following command:
```bash
npm init -y
```
* install localy to your nodejs app the express pkg:
```bash
npm i -s express
```
* create in the "test" folder, a new file, named `app.js`
* insert into `app.js` the following code:
```javascript
var express = require('express');
var app = express();

app.get("/", function(req,res){
  res.send("<h1>Welcome to our first app</h1>")
});

app.listen(process.env.PORT||3500, function () {
    console.log("server is listening on port 3000");
});
```

* go to package.json file , and add this config:
```json
 {
 "scripts": {
    "start": "node app"
  },
  "engines": {
    "node":"8.11.3"
  }
}
```

* init `test` directory wit git, by the fiollowing command:
```bash
git init
```

* add to the git stage all the `test` durectory content:
```bash
git add .
```


* save to git  all the `test` directory content:
```bash
git commit -m "your message"
```
*NOTE*: if you get an alert that you are not signed in, please sign in, and run the commit aommand again.

* login to your heroku account with the following command:
```bash
heroku login
```


* create a new heroku app to the `test` project
```bash
heroku create
```

* push all the saved git content, to the new heroku app:
```bash
git push heroku master
```

* open your new app in the browser, by the follwing command:
```bash
heroku open
```

