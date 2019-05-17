const { CallDuration } = require('models');

const getAll = async (arg, done) => {
  const calls = await CallDuration.find({});

  done(null, { calls });
};

const create = async (arg, done) => {
  const call = new CallDuration({
    Duration: 42,
    Count: 15,
    Time: '1-1-2017 12:30',
  });

  await call.save();

  done(null, { call });
};

const update = async (arg, done) => {
  const id = '5cdefd34cc630d01dfa1c9af';
  const body = {
    Count: 24,
  };
  const success = await CallDuration.findByIdAndUpdate(id,
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
  const id = '5cdefd34cc630d01dfa1c9af';

  const call = await CallDuration
    .findOne({ _id: id });

  await call.remove();

  done(null, { call });
};

module.exports = [
  { role: 'role:call,cmd:getAll', handler: getAll },
  { role: 'role:call,cmd:create', handler: create },
  { role: 'role:call,cmd:update', handler: update },
  { role: 'role:call,cmd:remove', handler: remove },
];
