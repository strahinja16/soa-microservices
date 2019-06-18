import getCallsApi from '../api/call';
import { setCalls } from '../reducers/call';

export function getCalls() {
  return dispatch => getCallsApi()
    .then(({ calls }) => calls)
    .then((payload) => {
      dispatch(setCalls(payload));
    });
}
