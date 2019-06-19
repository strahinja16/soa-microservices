import getLocationsApi from '../api/location';
import { setLocations } from '../reducers/location';

export function getLocations() {
  return dispatch => getLocationsApi()
    .then(({ data }) => {
      dispatch(setLocations(data));
    })
    .catch(e => console.log(e.toString()));
}
