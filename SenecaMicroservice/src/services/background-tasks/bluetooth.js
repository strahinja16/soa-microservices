/* eslint-disable no-plusplus */

const moment = require('moment');
const { BluetoothBond } = require('models');
const { getBluetooth } = require('../../api');

module.exports = async () => {
  const compareTime = moment().subtract(6, 'years');
  const compareBondStatus = 'bonded';
  const dateFormat = 'LLLL';
  let count = 0;

  const blues = await getBluetooth();

  blues.forEach(({ time, bondStatus }) => {
    const timeAsMoment = moment(time, dateFormat);

    if (compareTime.isBefore(timeAsMoment)
      && bondStatus
      && bondStatus.includes(compareBondStatus)
    ) {
      count++;
    }
  });

  const bluetoothBond = new BluetoothBond({
    BondStatus: compareBondStatus,
    Count: count,
    Time: compareTime.format(dateFormat),
  });

  await bluetoothBond.save();
};
