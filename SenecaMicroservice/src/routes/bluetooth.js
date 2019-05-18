const { BluetoothBond } = require('models');
const logger = require('services/logger');

const getAll = async (req, res) => {
  try {
    const blues = await BluetoothBond.find({});

    res(null, { blues });
  } catch (e) {
    logger.log(e.toString());
  }
};

const getOne = async (req, res) => {
  try {
    const { args: { query: { id } } } = req;
    const blue = await BluetoothBond.findById(id);

    res(null, { blue });
  } catch (e) {
    logger.log(e.toString());
  }
};

const create = async (req, res) => {
  try {
    const { args: { body } } = req;

    const blue = new BluetoothBond({
      ...body,
    });

    await blue.save();

    res(null, { blue });
  } catch (e) {
    logger.log(e.toString());
  }
};

const update = async (req, res) => {
  try {
    const { args: { body } } = req;
    const { id, ...updatedBody } = body;

    const success = await BluetoothBond.findByIdAndUpdate(id,
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

    const blue = await BluetoothBond
      .findOne({ _id: id });

    await blue.remove();

    res(null, { blue });
  } catch (e) {
    logger.log(e.toString());
  }
};

module.exports = [
  { role: 'role:bluetooth,cmd:getAll', handler: getAll },
  { role: 'role:bluetooth,cmd:getOne', handler: getOne },
  { role: 'role:bluetooth,cmd:create', handler: create },
  { role: 'role:bluetooth,cmd:update', handler: update },
  { role: 'role:bluetooth,cmd:remove', handler: remove },
];
