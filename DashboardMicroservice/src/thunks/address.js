import getAddressesApi from '../api/address';
import { setAddresses } from '../reducers/address';

export function getAddresses() {
  return dispatch => getAddressesApi()
    .then(({ data }) => data)
    .then((payload) => {
      dispatch(setAddresses(payload));
    });
}
