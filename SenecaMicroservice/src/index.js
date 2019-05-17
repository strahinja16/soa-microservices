/* eslint-disable no-plusplus */
require('module-alias/register');
const express = require('express');
const http = require('http');
const seneca = require('seneca')();
const web = require('seneca-web');
const bodyParser = require('body-parser');
const cors = require('cors');
const logger = require('services/logger');
const { port } = require('config');
require('models');
require('services/db')();
const { routes, handlers } = require('./routes');
const cron = require('node-cron');
const { applicationTask, bluetoothTask, callTask } = require('./services/background-tasks');

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
  require('mongoose').set('debug', true).set('useFindAndModify', false);
}

const config = {
  context: app,
  routes,
  adapter: require('seneca-web-adapter-express'),
};

handlers.forEach(({ role, handler }) => seneca.add(role, handler));
seneca.use(web, config);

seneca.ready(() => {
  app.set('port', port);
  app.use('/test', async (req, res) => {

    res.send({ data: 'ASD' });
  });

  const server = http.createServer(app);

  server.listen(port, () => {
    console.log('listening on port 3000');

    cron.schedule('* * * * *', async () => {
      await bluetoothTask();
      await applicationTask();
      await callTask();
    });
  });
});

/**
 * Exports express
 * @public
 */
module.exports = app;
