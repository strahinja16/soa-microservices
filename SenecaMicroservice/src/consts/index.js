module.exports = {
  ROUTES: {
    APPLICATION: {
      PREFIX: '/api/application',
      PIN: 'role:application,cmd:*',
    },
    BLUETOOTH: {
      PREFIX: '/api/bluetooth',
      PIN: 'role:bluetooth,cmd:*',
    },
    CALL: {
      PREFIX: '/api/call',
      PIN: 'role:call,cmd:*',
    },
  },
};
