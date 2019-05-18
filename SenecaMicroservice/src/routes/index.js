const { ROUTES } = require('../consts');
const application = require('./application');
const bluetooth = require('./bluetooth');
const call = require('./call');

const { APPLICATION, BLUETOOTH, CALL } = ROUTES;

const applicationRoutes = {
  prefix: APPLICATION.PREFIX,
  pin: APPLICATION.PIN,
  map: {
    getAll: {
      GET: true,
    },
    getOne: {
      GET: true,
    },
    create: {
      POST: true,
    },
    update: {
      PUT: true,
    },
    remove: {
      DELETE: true,
    },
  },
};

const bluetoothRoutes = {
  prefix: BLUETOOTH.PREFIX,
  pin: BLUETOOTH.PIN,
  map: {
    getAll: {
      GET: true,
    },
    getOne: {
      GET: true,
    },
    create: {
      POST: true,
    },
    update: {
      PUT: true,
    },
    remove: {
      DELETE: true,
    },
  },
};

const callRoutes = {
  prefix: CALL.PREFIX,
  pin: CALL.PIN,
  map: {
    getAll: {
      GET: true,
    },
    getOne: {
      GET: true,
    },
    create: {
      POST: true,
    },
    update: {
      PUT: true,
    },
    remove: {
      DELETE: true,
    },
  },
};

const routes = [
  applicationRoutes,
  bluetoothRoutes,
  callRoutes,
];

const handlers = [
  ...application,
  ...bluetooth,
  ...call,
];

module.exports = {
  routes,
  handlers,
};
