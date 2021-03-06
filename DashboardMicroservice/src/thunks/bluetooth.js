import getBluetoothsApi from '../api/bluetooth';
import { setBluetooths } from '../reducers/bluetooth';

export function getBluetooths() {
  return dispatch => getBluetoothsApi()
    .then(({ data: { blues } }) => blues)
    .then((payload) => {
      dispatch(setBluetooths(payload));
    });
}
