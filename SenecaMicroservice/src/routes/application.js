const logger = require('services/logger');
const { ApplicationProcessCount } = require('models');

const getAll = async (req, res) => {
  try {
    const apps = await ApplicationProcessCount.find({});

    res(null, { apps });
  } catch (e) {
    console.log(e.toString());
  }
};

const getOne = async (req, res) => {
  try {
    const { args: { query: { id } } } = req;
    const app = await ApplicationProcessCount.findById(id);

    res(null, { app });
  } catch (e) {
    console.log(e.toString());
  }
};

const create = async (req, res) => {
  try {
    const { args: { body } } = req;

    const app = new ApplicationProcessCount({
      ...body,
    });

    await app.save();

    res(null, { app });
  } catch (e) {
    console.log(e.toString());
  }
};

const update = async (req, res) => {
  try {
    const { args: { body } } = req;
    const { id, ...updatedBody } = body;

    const success = await ApplicationProcessCount.findByIdAndUpdate(id,
      {
        $set: {
          ...updatedBody,
        },
      },
      {
        new: true, useFindAndModify: false,
      });

    if (success) {
      res(null, { message: 'success' });
    } else {
      res({ message: 'fail ' }, {});
    }
  } catch (e) {
    console.log(e.toString());
  }
};

const remove = async (req, res) => {
  try {
    const { args: { body: { id } } } = req;

    const app = await ApplicationProcessCount
      .findOne({ _id: id });

    await app.remove();

    res(null, { app });
  } catch (e) {
    console.log(e.toString());
  }
};

module.exports = [
  { role: 'role:application,cmd:getAll', handler: getAll },
  { role: 'role:application,cmd:getOne', handler: getOne },
  { role: 'role:application,cmd:create', handler: create },
  { role: 'role:application,cmd:update', handler: update },
  { role: 'role:application,cmd:remove', handler: remove },
];
