
const { domains: { apiMicroservice } } = require('config');
const axios = require('axios');

const apiMicroFetch = url => axios.get(`${apiMicroservice}${url}`)
  .then(({ data }) => data);

const getApplications = () => apiMicroFetch('/api/Application');
const getBluetooth = () => apiMicroFetch('/api/Bluetooth');
const getCalls = () => apiMicroFetch('/api/Call');

module.exports = {
  getApplications,
  getBluetooth,
  getCalls,
};
