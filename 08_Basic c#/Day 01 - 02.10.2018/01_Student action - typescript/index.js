var Student = /** @class */ (function () {
    function Student() {
    }
    return Student;
}());
//we have an array with 2 students: Assa , Meir
var studentsArray = [
    {
        subject: "Math",
        subjectReaction: function (x) { console.log("Student 1 loves " + x); }
    },
    {
        subject: "Sport",
        subjectReaction: function (x) { console.log("Student 2 loves " + x); }
    }
];
for (var _i = 0, studentsArray_1 = studentsArray; _i < studentsArray_1.length; _i++) {
    var student = studentsArray_1[_i];
    student.subjectReaction(student.subject);
}
