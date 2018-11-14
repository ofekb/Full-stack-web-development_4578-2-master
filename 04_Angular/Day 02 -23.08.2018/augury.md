# Add `augury` to chrome
* Clone `augury ` from github, and build it, with the following command:
```bash
git config --global http.sslVerify "false"
git clone https://github.com/rangle/augury.git
cd augury
npm install
npm run build:dev
```
* Navigate to chrome://extensions and enable Developer mode.
* Choose "Load unpacked extension".
* In the dialog, open the directory you just cloned.