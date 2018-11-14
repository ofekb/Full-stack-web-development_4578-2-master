

let personDetails = ["firstName", "lastName", "age", "color"];


function addPerson() {
    let newPerson = {};
    for (key of personDetails) {
        newPerson[key] = document.getElementById(key).value;
        document.getElementById(key).value = "";
    }


    let currentList = getCurrentList();
    currentList.push(newPerson);
    localStorage.setItem("peopleList", JSON.stringify(currentList));
    showCurrentList();
}

function getCurrentList() {
    let list = localStorage.getItem("peopleList");  //if "peopleList" does not exist in the local storage we will get null
    return (list) ? JSON.parse(list) : [];
}

function showCurrentList() {
    document.getElementById("res").innerHTML = "";
    for (person of getCurrentList()) {
        document.getElementById("res").innerHTML +=
            `<li><ul style="color:${person.color}">${personDetails.map(e => `<li>${e} : ${person[e]}</li>`).join("")}</ul></li>`;
    }
}


function clearAllData() {
    localStorage.clear();
    showCurrentList();
}
