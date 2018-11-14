const models = require('./../models/index')

function addUserRoutes(app) {

    // Get all users:
    app.get("/users", function (request, response) {
        models.User.find({}, (err, users) => {
            response.send(users);
        });
    });
}


module.exports={addUserRoutes};