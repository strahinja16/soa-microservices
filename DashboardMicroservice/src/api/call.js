import axios from '.';

export default function getCalls() {
  return axios.get('/api/call/getAll');
}
