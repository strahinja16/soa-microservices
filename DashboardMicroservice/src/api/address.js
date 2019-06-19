import axios from './statistic-micro';

export default function getAddresses() {
  return axios.get('/api/AddressCount');
}
