require('dotenv').config();

const {
  PORT,
  APP_KEY,
  MONGODB_HOST,
  MONGODB_USER,
  MONGODB_PASSWORD,
  MONGODB_DATABASE,
  API_MICROSERVICE_DOMAIN,
  APP_DOMAIN,
} = process.env;

const port = PORT || 3000;

module.exports = {
  port,
  appKey: APP_KEY,
  domains: {
    apiMicroservice: API_MICROSERVICE_DOMAIN,
    api: APP_DOMAIN,
  },
  db: {
    host: MONGODB_HOST,
    user: MONGODB_USER,
    password: MONGODB_PASSWORD,
    database: MONGODB_DATABASE,
  },
};
