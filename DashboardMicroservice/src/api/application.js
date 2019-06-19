import axios from './seneca-micro';

export default function getApplications() {
  return axios.get('/api/application/getAll');
}
