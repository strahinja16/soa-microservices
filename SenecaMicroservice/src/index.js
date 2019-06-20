/* eslint-disable no-plusplus */
require('module-alias/register');
const express = require('express');
const http = require('http');
const seneca = require('seneca')();
const web = require('seneca-web');
const bodyParser = require('body-parser');
const cors = require('cors');
const { port, mqttUrl } = require('config');
require('models');
require('services/db')();
const { routes, handlers } = require('./routes');
const cron = require('node-cron');
const { applicationTask, bluetoothTask, callTask } = require('./services/background-tasks');
const mqtt = require('mqtt');

const app = express();

/**
 * Init middleware
 */
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: false }));
app.use(cors());

if (process.env.NODE_ENV === 'development') {
  require('mongoose').set('debug', true).set('useFindAndModify', false);
}

const config = {
  context: app,
  routes,
  adapter: require('seneca-web-adapter-express'),
  options: { parseBody: false },
};

handlers.forEach(({ role, handler }) => seneca.add(role, handler));
seneca.use(web, config);

const client = mqtt.connect(mqttUrl);
client.on('connect', () => {
    console.log('CONNECTED');
});

seneca.ready(() => {
  app.set('port', port);
  app.use('/test', async (req, res) => {
    res.send({ data: 'ASD' });
  });

  const server = http.createServer(app);

  server.listen(port, () => {
    console.log('listening on port 3000');

    cron.schedule('*/3 * * * *', async () => {
        await bluetoothTask(client);
        await applicationTask(client);
        await callTask(client);
    });
  });
});

/**
 * Exports express
 * @public
 */
module.exports = app;
