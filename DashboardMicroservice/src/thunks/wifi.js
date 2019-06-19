import getWifisApi from '../api/wifi';
import { setWifis } from '../reducers/wifi';

export function getWifis() {
  return dispatch => getWifisApi()
    .then(({ data }) => {
      dispatch(setWifis(data));
    });
}
