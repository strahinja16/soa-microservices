const logger = require('services/logger');
const validate = require('./validate');

const mapping = {
  validate,
};

module.exports = (middleware) => {
  if (mapping[middleware]) {
    return mapping[middleware];
  }

  logger.warn(`Middleware ${middleware} not registered.`);
  return (req, res, next) => next();
};
