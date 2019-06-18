import axios from '.';

export default function getLocationAccuracies() {
  return axios.get('/api/LocationAccuracy');
}
