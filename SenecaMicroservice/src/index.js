const express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors');
const logger = require('services/logger');
require('models');
require('services/db')();

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
app.use('/api', require('./routes'));

/**
 * Exports express
 * @public
 */
module.exports = app;
