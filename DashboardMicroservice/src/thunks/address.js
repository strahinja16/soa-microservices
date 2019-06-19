import getAddressesApi from '../api/address';
import { setAddresses } from '../reducers/address';

export function getAddresses() {
  return dispatch => getAddressesApi()
    .then(({ data }) => {
      dispatch(setAddresses(data));
    });
}
