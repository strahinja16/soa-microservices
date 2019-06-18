import getWifisApi from '../api/wifi';
import { setWifis } from '../reducers/wifi';

export function getWifis() {
  return dispatch => getWifisApi()
    .then(({ data }) => data)
    .then((payload) => {
      dispatch(setWifis(payload));
    });
}
