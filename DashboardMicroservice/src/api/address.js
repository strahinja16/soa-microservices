import axios from '.';

export default function getAddresses() {
  return axios.get('/api/AddressCount');
}
