const pusher = require('./pusher');

const addApplication = (application) => {
  pusher.trigger('application', 'add', application);
};

const addAddress = (address) => {
  pusher.trigger('address', 'add', address);
};

const addBluetooth = (bluetooth) => {
  pusher.trigger('bluetooth', 'add', bluetooth);
};

const addLocation = (location) => {
  pusher.trigger('location', 'add', location);
};

const addWifi = (wifi) => {
  pusher.trigger('wifi', 'add', wifi);
};

const addCall = (call) => {
  pusher.trigger('call', 'add', call);
};

module.exports = {
  addApplication,
  addAddress,
  addBluetooth,
  addCall,
  addLocation,
  addWifi,
};
