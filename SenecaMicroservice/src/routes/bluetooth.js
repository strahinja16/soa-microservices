const { BluetoothBond } = require('models');

const getAll = async (arg, done) => {
  const blues = await BluetoothBond.find({});

  done(null, { blues });
};

const create = async (arg, done) => {
  const blue = new BluetoothBond({
    BondStatus: 'WPATest',
    Count: 15,
    Time: '1-1-2017 12:30',
  });

  await blue.save();

  done(null, { blue });
};

const update = async (arg, done) => {
  const id = '5cdefc1e0dc4c201861a4667';
  const body = {
    Count: 24,
  };
  const success = await BluetoothBond.findByIdAndUpdate(id,
    {
      $set: {
        ...body,
      },
    },
    {
      new: true, useFindAndModify: false,
    });

  if (success) {
    done(null, { message: 'success' });
  } else {
    done({ message: 'fail ' }, {});
  }
};

const remove = async (arg, done) => {
  const id = '5cdefc1e0dc4c201861a4667';

  const blue = await BluetoothBond
    .findOne({ _id: id });

  await blue.remove();

  done(null, { blue });
};

module.exports = [
  { role: 'role:bluetooth,cmd:getAll', handler: getAll },
  { role: 'role:bluetooth,cmd:create', handler: create },
  { role: 'role:bluetooth,cmd:update', handler: update },
  { role: 'role:bluetooth,cmd:remove', handler: remove },
];
