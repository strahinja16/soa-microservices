require('dotenv').config();

const {
  PORT,
} = process.env;

const port = PORT || 3002;

module.exports = {
  port,
};
