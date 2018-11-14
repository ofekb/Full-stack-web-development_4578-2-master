onmessage = function (e) {
    console.log(e.data);
    
    let limit = e.data.limit;
    for (var num = 0; num < limit; num++);

    // postMessage in this file will call "onmessage" in the app.js file
    postMessage(`res: ${num}, index: ${e.data.index}`);
};
