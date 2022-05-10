const express = require("express");
const mongoose = require("mongoose");
const foodRouter = require("./routes/foodRoutes.js");

const app = express();

app.use(express.json());

exports.initializeMongo = function() {
    mongoose.connect(DATABASE_CONECTION);
  
    console.log('Trying to connect to ' + DATABASE_CONECTION);
  
    var db = mongoose.connection;
    db.on('error', console.error.bind(console, 'connection error: We might not be as connected as I thought'));
    db.once('open', function() {
      console.log('We are connected you and I!');
    });
  }

app.use(foodRouter);

app.listen(3001, () => {
  console.log("Server is running...");
});