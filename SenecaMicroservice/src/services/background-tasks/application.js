/* eslint-disable no-plusplus */

const moment = require('moment');
const { ApplicationProcessCount } = require('models');
const { getApplications } = require('../../api');

module.exports = async (mqttClient) => {
  const compareTime = moment().subtract(6, 'years');
  const compareProcessName = 'com.android.mms';
  const dateFormat = 'DD-MM-YYYY  HH:mm:ss';
  let count = 0;

  const applications = await getApplications();

  applications.forEach(({ start, processName }) => {
    const timeAsMoment = moment(start, dateFormat);
    if (compareTime.isBefore(timeAsMoment) && processName.includes(compareProcessName)) {
      count++;
    }
  });

  const applicationProcessCount = new ApplicationProcessCount({
    ProcessName: compareProcessName,
    Count: count,
    Start: compareTime.format(dateFormat),
  });

  mqttClient.publish('application', JSON.stringify(applicationProcessCount));
  await applicationProcessCount.save();
};
