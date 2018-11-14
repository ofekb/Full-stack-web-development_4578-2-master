var cashier = new Cashier();
cashier.fullName = "Bob";
document.write("fullName: " + cashier.fullName + "<br/>");
//Compilation Error --> _cinemaName is private
//cashier._cinemaName = "YesPlanet";  
//***********way 1 - access a setter and a getter functions*********
document.write("Before set CinemaName: " + cashier.getCinemaName() + "<br/>");
cashier.setCinemaName("YesPlanet");
document.write("After set CinemaName : " + cashier.getCinemaName() + "<br/>");
//***********way 2 - access a setter and a getter property*********
// cashier.age calls to the get
document.write("Before set age: " + cashier.age + "<br/>");
// cashier.age = 24  calls to the set
cashier.age = 24;
document.write("after set age: " + cashier.age + "<br/>");
//# sourceMappingURL=app.js.map