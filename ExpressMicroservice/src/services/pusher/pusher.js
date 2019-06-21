const Pusher = require('pusher');

const pusher = new Pusher({
  appId: '807601',
  key: '643195db8fa19364791b',
  secret: '9d7e64eca84aa519dbbe',
  cluster: 'eu',
  encrypted: true,
});

module.exports = pusher;
