const mongoose = require("mongoose");
const { seedMongoDb } = require('./seeders/seeder');

// Connect to MongoDB: 
let uri = "mongodb://test:test@cluster0-shard-00-00-e0hcb.mongodb.net:27017,cluster0-shard-00-01-e0hcb.mongodb.net:27017,cluster0-shard-00-02-e0hcb.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true";

mongoose.connect(uri, { useNewUrlParser: true })
    .then(() => {
        console.log("We're connected to MongoDB.");
        seedMongoDb();
    })
    .catch((e) => { console.log("We're not connected to MongoDB.", e); });

module.exports = {
    mongoose
}
