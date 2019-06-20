const express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors');
const logger = require('services/logger');
const router = require('./routes');
const mqtt = require('mqtt')
const config = require('service/config');
const { addApplication, addAddress, addBluetooth, addLocation, addWifi, addCall } = requuire('services/pusher');

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

client.on('connect', () => {
    client.subscribe('wifi', err => console.log('Wifi subscription error!'));
    client.subscribe('location', err => console.log('Location subscription error!'));
    client.subscribe('address', err => console.log('Address subscription error!'));
    client.subscribe('call', err => console.log('Call subscription error!'));
    client.subscribe('bluetooth', err => console.log('Bluetooth subscription error!'));
    client.subscribe('application', err => console.log('Application subscription error!'));

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
        client.end()
    });
});

/**
 * Exports express
 * @public
 */
module.exports = app;
