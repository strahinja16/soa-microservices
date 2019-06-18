import axios from '.';

export default function getApplications() {
  return axios.get('/api/application/getAll');
}
