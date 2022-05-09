console.log("Oh Yeah!")
const express = require('express')
const database = require('./database')
const app = express()
var bodyParser = require('body-parser')

database.initializeMongo();

var jsonParser = bodyParser.json()

app.get("/ClientInfo", async (request, response) => {
  const clients = await database.Client.find({});

  try {
    response.send(clients);
  } catch (error) {
    response.status(500).send(error);
  }
});

app.listen(3001, function () {
  console.log('Example app listening on port 3001!')
})
