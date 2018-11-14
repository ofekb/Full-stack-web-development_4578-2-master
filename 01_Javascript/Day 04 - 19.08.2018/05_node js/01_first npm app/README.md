# How to create a basic node app with npm

* create a new folder with this command:
```bash
mkdir app
```
* change dir to the new app, with this command:
```bash
cd app
```
* init the folder with a new npm config, with this command:
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
* add a new package from npm (in this example we used `emoji-regex` pkg), with this command:
```bash
npm i -s emoji-regex
```
this command will add a new file named `package-lock.json`, and a new folder named `node_modules` that contains all the pkg's code. 
---
the `package.json` file has been changed by this command, and saves the name of the new installed pkg:
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
  "license": "ISC",
  "dependencies": {
    "emoji-regex": "^7.0.0"
  }
}

```
* add a new file, named `app.js`, with the following content:
```javascript
const emojiRegex = require('emoji-regex');

const text = `
\u{231A}: ⌚ default emoji presentation character (Emoji_Presentation)
\u{2194}\u{FE0F}: ↔️ default text presentation character rendered as emoji
\u{1F469}: 👩 emoji modifier base (Emoji_Modifier_Base)
\u{1F469}\u{1F3FF}: 👩🏿 emoji modifier base followed by a modifier
`;
 
const regex = emojiRegex();
let match;
while (match = regex.exec(text)) {
  const emoji = match[0];
  console.log(`Matched sequence ${ emoji } — code points: ${ [...emoji].length }`);
}
```
* run the file with this command:
```bash
node app.js
```
and get this output:
```bash
Matched sequence ⌚ — code points: 1
Matched sequence ⌚ — code points: 1
Matched sequence ↔️ — code points: 2
Matched sequence ↔️ — code points: 2
Matched sequence 👩 — code points: 1
Matched sequence 👩 — code points: 1
Matched sequence 👩🏿 — code points: 2
Matched sequence 👩🏿 — code points: 2
```
* Delete `package-lock.json` file, and `node_modules` folder
* run this command to re-install the sections that we removed in the prev step:
```bash
npm i
```