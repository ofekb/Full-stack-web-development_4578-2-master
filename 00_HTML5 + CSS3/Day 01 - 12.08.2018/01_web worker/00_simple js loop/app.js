let index=0;

function callLoop() {
    for(var res = 0; res<10**10; res++);
    document.getElementById("res").innerHTML +=`<p>res: ${res}, index: ${index++}</p>`;
}