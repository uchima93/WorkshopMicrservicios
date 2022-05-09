console.log("Oh Yeah!")
const express = require('express')
const database = require('./database')
const app = express()
var bodyParser = require('body-parser')

database.initializeMongo();

var jsonParser = bodyParser.json()

app.get("/client", async (request, response) => {
  const clients = await database.Client.find({});

  try {
    response.send(clients);
  } catch (error) {
    response.status(500).send(error);
  }
});

app.get("/client/:id", async (request, response) => {
  const clients = await database.Client.findById(request.params.id);

  try {
    response.send(clients);
  } catch (error) {
    response.status(500).send(error);
  }
});

app.post("/client", jsonParser, async (request, response) => {
  const clients = new database.Client(request.body);
  try {
    await clients.save();
    response.send(clients);
  } catch (error) {
    response.status(500).send(error);
  }
});

app.put("/client/:id", jsonParser, async (request, response) => { 
  await database.Client.findByIdAndUpdate(request.params.id, request.body);
  try {
    const clients = await database.Client.findById(request.params.id)
    response.send(clients);
  } catch (error) {
    response.status(500).send(error);
  }
});

app.delete("/client/:id", async (request, response) => {
  try {
    const clients = await database.Client.findByIdAndDelete(request.params.id);

    if (!clients) response.status(404).send("No item found");
    response.status(200).send();
  } catch (error) {
    response.status(500).send(error);
  }
});

app.listen(3000, function () {
  console.log('Example app listening on port 3000!')
})
