import getLocationsApi from '../api/location';
import { setLocations } from '../reducers/location';

export function getLocations() {
  return dispatch => getLocationsApi()
    .then(({ data }) => data)
    .then((payload) => {
      dispatch(setLocations(payload));
    });
}
