import axios from '.';

export default function getWifiCapabilities() {
  return axios.get('/api/WifiCapability');
}
