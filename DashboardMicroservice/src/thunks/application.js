import getApplicationsApi from '../api/application';
import { setApplications } from '../reducers/application';

export function getApplications() {
  return dispatch => getApplicationsApi()
    .then(({ apps }) => apps)
    .then((payload) => {
      dispatch(setApplications(payload));
    });
}
