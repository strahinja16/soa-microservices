import axios from './statistic-micro';

export default function getLocationAccuracies() {
  return axios.get('/api/LocationAccuracy');
}
