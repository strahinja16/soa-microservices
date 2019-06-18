import axios from '.';

export default function getBluetooths() {
  return axios.get('/api/bluetooth/getAll');
}
