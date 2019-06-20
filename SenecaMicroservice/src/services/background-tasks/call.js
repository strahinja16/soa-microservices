/* eslint-disable no-plusplus */

const moment = require('moment');
const { CallDuration } = require('models');
const { getCalls } = require('../../api');

module.exports = async (mqttClient) => {
  const compareTime = moment().subtract(6, 'years');
  const compareDuration = 20;
  const dateFormat = 'DD-MM-YYYY  HH:mm:ss';
  let count = 0;

  const calls = await getCalls();

  calls.forEach(({ time, duration }) => {
    const timeAsMoment = moment(time, dateFormat);
    if (compareTime.isBefore(timeAsMoment) && duration >= compareDuration) {
      count++;
    }
  });

  const callDuration = new CallDuration({
    Duration: compareDuration,
    Count: count,
    Time: compareTime.format(dateFormat),
  });

  mqttClient.publish('call', JSON.stringify(callDuration));
  await callDuration.save();
};
