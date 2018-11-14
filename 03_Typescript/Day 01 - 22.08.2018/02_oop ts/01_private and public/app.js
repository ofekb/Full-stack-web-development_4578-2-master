var cashier = new Cashier();
cashier.fullName = "Bob";
document.write("fullName: " + cashier.fullName + "<br/>");
//Compilation Error --> _cinemaName is private
//cashier._cinemaName = "YesPlanet";  
document.write("Before set: " + cashier.getCinemaName() + "<br/>");
cashier.setCinemaName("YesPlanet");
document.write("After set: " + cashier.getCinemaName() + "<br/>");
//# sourceMappingURL=app.js.map