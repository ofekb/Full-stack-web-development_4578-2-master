const path = require('path');
const fs = require('fs');
const express = require('express');

const app = express();
const basePath = path.join(__dirname + "/dist");


app.get(`/`, (req, res) => {
    let linkList = "";
    let resPage=fs.readFileSync("links.html","utf-8");
   console.log(resPage);
    fs.readdir(basePath, (err, files) => {
        files.forEach((file) => {
            linkList += `<li><a href="/${file}" target="blank">${file}</a></li>`;
        })
        res.send(resPage.replace("placeHolder", linkList));
    });

});

fs.readdir(basePath, (err, files) => {
    files.forEach((file) => {
        app.use(express.static(`${basePath}/${file}`));
        app.get(`/${file}`, (req, res) => {
            res.sendFile(`${basePath}/${file}/index.html`);
        });
    })
});

const port = process.env.PORT || 3500;
app.listen(port, () => { console.log(`OK`); });
