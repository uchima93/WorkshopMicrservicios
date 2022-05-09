const mongoose = require('mongoose');

const DATABASE_CONECTION = 'mongodb://mongo/test';

var clientSchema = mongoose.Schema({
  nombres: {
    type: String,
    required: true
  },
  apellidos: {
    type: String,
    required: true
  },
  correoElectronico: {
    type: String,
    required: true
  },
  tipoCliente: {
    type: String,
    required: true
  },
  fechaCreacion: {
    type: Date,
    required: true
  },
  
},{collection:'clientSchema',
versionKey: false
});

Client = exports.Client = mongoose.model('Client', clientSchema);

exports.initializeMongo = function() {
  mongoose.connect(DATABASE_CONECTION);

  console.log('Trying to connect to ' + DATABASE_CONECTION);

  var db = mongoose.connection;
  db.on('error', console.error.bind(console, 'connection error: We might not be as connected as I thought'));
  db.once('open', function() {
    console.log('We are connected you and I!');
  });
}