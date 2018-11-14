const path = require('path');
const fs = require('fs');
const express = require('express');
const bodyParser = require("body-parser"); 

const app = express();

app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());


// curl -v -X POST -H "Content-type: application/json" -d "{\"name\":\"test\", \"pass\":\"1234\" }" http://localhost:3500/api/user

app.post("/api/user", (req, res) => {
    let currentList = require("./user.json");
    currentList.push(req.body);
    fs.writeFileSync("user.json", JSON.stringify(currentList));
    res.status(201).send(JSON.stringify(currentList));
});

const port = process.env.PORT || 3500;
app.listen(port, () => { console.log(`OK`); });
