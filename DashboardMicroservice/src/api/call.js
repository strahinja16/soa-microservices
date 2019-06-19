import axios from './seneca-micro';

export default function getCalls() {
  return axios.get('/api/call/getAll');
}
