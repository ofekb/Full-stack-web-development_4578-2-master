let newTaskInfo = [
    {
        id: "content",
        isValid: x => x && x.length > 2,
        errorMsg: "Task must contain min 2 chars"
    },
    {
        id: "time"
    },
    {
        id: "date",
        isValid: x => x ? true : false,
        errorMsg: "Date is requierd"
    }
];

onload = () => {
    for (x of newTaskInfo) {
        x.element = document.getElementById(x.id);
    }
    showCurrentList();
}

let setSubmit = () => {
    let isValid = true;
    for (x of newTaskInfo) {
        let isElementValid = (!x.isValid) ? true : x.isValid(x.element.value);
        x.element.setCustomValidity((isElementValid) ? '' : x.errorMsg);
        isValid = isValid && isElementValid;
    }

    //if all input fields are valid
    if (isValid) {
        addTask();
    }
}

/**
 * @function addTask
 * save item to local storage + 
 * empty all input elements +
 * show all tasks in task board
 */
function addTask() {
    let newTask = {};
    for (key of newTaskInfo) {
        newTask[key.id] = key.element.value;
        key.element.value = "";
    }

    let currentList = getCurrentList();

    newTask.id = currentList.length ? 
                    currentList[currentList.length - 1].id + 1 : 0;

    currentList.push(newTask);
    localStorage.setItem("taskList", JSON.stringify(currentList));
    showCurrentList();
}

function getCurrentList() {
    let list = localStorage.getItem("taskList");
    return (list) ? JSON.parse(list) : [];
}

function showCurrentList() {
    document.getElementById("res").innerHTML = "";
    for (task of getCurrentList()) {
        document.getElementById("res").innerHTML += `
        <div class="col-sm-4 col-xs-12 slide-anim">
        <div class="panel panel-default text-center">
            <div class="panel-heading">
                <h1>Task ${task.id}</h1>
            </div>
            <div class="panel-body">
                <p><strong>Date</strong> ${task.date}</p>
                <p><strong>Time</strong>  ${task.time}</p>
                <p class="task-conent"><strong>Task content:</strong><br/> ${task.content}</p>
            </div>
            <div class="panel-footer">
                <button class="btn btn-lg" onclick="removeTask(${task.id})"><i class="glyphicon glyphicon-remove"></i>&nbsp; Remove task</button>
            </div>
        </div>
    </div>`;

    }
}

removeTask=id=>{
    let currentList = getCurrentList();
    currentList.splice(currentList.findIndex(x=>x.id==id),1);
    localStorage.setItem("taskList", JSON.stringify(currentList));
    showCurrentList();
}
