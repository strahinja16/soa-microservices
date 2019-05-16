const mongoose = require('mongoose');
const logger = require('services/logger');
const { db } = require('config');

module.exports = () => {
  const {
    host, user, password, database,
  } = db;

  mongoose
    .connect(
      `mongodb://${host}`,
      {
        user,
        pass: password,
        dbName: database,
        authSource: 'admin',
      },
    )
    .catch(ex => logger.log(ex));
};
