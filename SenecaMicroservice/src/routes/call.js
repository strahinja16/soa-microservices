const { CallDuration } = require('models');
const logger = require('services/logger');

const getAll = async (req, res) => {
  try {
    const calls = await CallDuration.find({});

    console.log(req);
    res(null, { calls });
  } catch (e) {
    logger.log(e.toString());
  }
};

const getOne = async (req, res) => {
  try {
    const { args: { query: { id } } } = req;
    const call = await CallDuration.findById(id);

    res(null, { call });
  } catch (e) {
    logger.log(e.toString());
  }
};

const create = async (req, res) => {
  try {
    const { args: { body } } = req;

    const call = new CallDuration({
      ...body,
    });

    await call.save();

    res(null, { call });
  } catch (e) {
    logger.log(e.toString());
  }
};

const update = async (req, res) => {
  try {
    const { args: { body } } = req;
    const { id, ...updatedBody } = body;

    const success = await CallDuration.findByIdAndUpdate(id,
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
    logger.log(e.toString());
  }
};

const remove = async (req, res) => {
  try {
    const { args: { body: { id } } } = req;

    const call = await CallDuration
      .findOne({ _id: id });

    await call.remove();

    res(null, { call });
  } catch (e) {
    logger.log(e.toString());
  }
};

module.exports = [
  { role: 'role:call,cmd:getAll', handler: getAll },
  { role: 'role:call,cmd:getOne', handler: getOne },
  { role: 'role:call,cmd:create', handler: create },
  { role: 'role:call,cmd:update', handler: update },
  { role: 'role:call,cmd:remove', handler: remove },
];
