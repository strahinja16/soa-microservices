import axios from './statistic-micro';

export default function getWifiCapabilities() {
  return axios.get('/api/WifiCapability');
}
