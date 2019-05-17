const { ApplicationProcessCount } = require('models');

const getAll = async (arg, done) => {
  const apps = await ApplicationProcessCount.find({});

  done(null, { apps });
};

const create = async (arg, done) => {
  const app = new ApplicationProcessCount({
    ProcessName: 'test',
    Count: 15,
    Start: '1-1-2017 12:30',
  });

  await app.save();

  done(null, { app });
};

const update = async (arg, done) => {
  const id = '5cdeed4b1825af2db99833de';
  const body = {
    Count: 15,
  };
  const success = await ApplicationProcessCount.findByIdAndUpdate(id,
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
  const id = '5cdee9be0ed76f00ec3e2b53';

  const app = await ApplicationProcessCount
    .findOne({ _id: id });

  await app.remove();

  done(null, { app });
};

module.exports = [
  { role: 'role:application,cmd:getAll', handler: getAll },
  { role: 'role:application,cmd:create', handler: create },
  { role: 'role:application,cmd:update', handler: update },
  { role: 'role:application,cmd:remove', handler: remove },
];
