import getApplicationsApi from '../api/application';
import { setApplications } from '../reducers/application';

export function getApplications() {
  return dispatch => getApplicationsApi()
    .then(({ data: { apps } }) => apps)
    .then((payload) => {
      dispatch(setApplications(payload));
    });
}
