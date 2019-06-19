import axios from './seneca-micro';

export default function getBluetooths() {
  return axios.get('/api/bluetooth/getAll');
}
