const express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors');
const logger = require('services/logger');
const mqtt = require('mqtt');
const config = require('config');
const {
  addApplication, addAddress, addBluetooth, addLocation, addWifi, addCall,
} = require('services/pusher');
const router = require('./routes');

const app = express();

/**
 * Init middleware
 */
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: false }));
app.use(cors());

if (process.env.NODE_ENV === 'development') {
  app.use((req, res, next) => {
    logger.info(`${req.method}: ${req.url}`);
    next();
  });
}

app.use('/api', router);

const client = mqtt.connect(config.mqttUrl);
console.log(config.mqttUrl);

client.on('connect', () => {
  client.subscribe('wifi');
  client.subscribe('location');
  client.subscribe('address');
  client.subscribe('call');
  client.subscribe('bluetooth');
  client.subscribe('application');

  client.on('message', (topic, message) => {
    const data = JSON.parse(message);
    console.log(data);
    switch (topic) {
      case 'wifi':
        addWifi(data);
        break;
      case 'location':
        addLocation(data);
        break;
      case 'address':
        addAddress(data);
        break;
      case 'call':
        addCall(data);
        break;
      case 'bluetooth':
        addBluetooth(data);
        break;
      case 'application':
        addApplication(data);
        break;
    }
    client.end();
  });
});

/**
 * Exports express
 * @public
 */
module.exports = app;
