class Student {
  //לא יודעים מה תהיה התגובה - ידוע שתהיה תגובה
  //פונקציה שמקבלת מחרוזת ולא מחזירה ערך
  subjectReaction: (subject: string) => void;

  subject: string;
}

//we have an array with 2 students: Assa , Meir
let studentsArray: Student[] = [
  {
    subject: "Math",
    subjectReaction: (x) => {console.log(`Student 1 loves ${x}`)}
  },
  {
    subject: "Sport",
    subjectReaction: (x) => {console.log(`Student 2 loves ${x}`)}
  }
];


for (let student of studentsArray) {
  student.subjectReaction(student.subject);
}


/*
OUTPUT:
______________________
Student 1 loves Math
Student 2 loves Sport
*/