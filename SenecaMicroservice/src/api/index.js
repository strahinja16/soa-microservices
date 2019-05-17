
const { domains: { apiMicroservice } } = require('config');
const axios = require('axios');

const apiMicroFetch = url => axios.get(`${apiMicroservice}${url}`)
  .then(({ data }) => data);

const getApplications = () => apiMicroFetch('/Application');
const getBluetooth = () => apiMicroFetch('/Bluetooth');
const getCalls = () => apiMicroFetch('/Call');

module.exports = {
  getApplications,
  getBluetooth,
  getCalls,
};
