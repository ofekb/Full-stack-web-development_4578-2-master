let num=0;


let stringWorkerContent=`
onmessage = function (e) {
    console.log(e.data);
    
    let limit = e.data.limit;
    for (var num = 0; num < limit; num++);

    // postMessage in this file will call "onmessage" in the app.js file
    postMessage("res: "+num+", index:"+e.data.index);
};`;

function callLoop() {
   var blob = new Blob([stringWorkerContent],{ type: "text/javascript" });

   var worker = new Worker(window.URL.createObjectURL(blob));

    // postMessage in this file will call "onmessage" in the worker
    worker.postMessage({index: num++, limit:10 ** 10});

    worker.onmessage = function (res) {
        console.log(res)
        document.getElementById("res").innerHTML += `<p>${res.data}</p>`;
    };


}
