
import { Map } from 'immutable';
import { createAction, handleActions } from 'redux-actions';
import { SET_APPLICATIONS_ACTION } from '../consts/actions';

// CREATE ACTIONS
export const setApplications = createAction(SET_APPLICATIONS_ACTION);

// SET INITIAL STATE
const INITIAL_STATE = Map({
  applications: [],
});

// WRITE HANDLERS FOR ACTIONS
export default handleActions(
  {
    [SET_APPLICATIONS_ACTION](state, { payload }) {
      return state.set('applications', payload);
    },
  },
  INITIAL_STATE,
);
