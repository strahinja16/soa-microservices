
import { Map } from 'immutable';
import { createAction, handleActions } from 'redux-actions';
import {SET_APPLICATIONS_ACTION, ADD_APPLICATION_ACTION } from '../consts/actions';

// CREATE ACTIONS
export const setApplications = createAction(SET_APPLICATIONS_ACTION);
export const addApplication = createAction(ADD_APPLICATION_ACTION);

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
    [ADD_APPLICATION_ACTION](state, { payload }) {
      return state.set('applications', state.get('applications').concat(payload));
    },
  },
  INITIAL_STATE,
);
