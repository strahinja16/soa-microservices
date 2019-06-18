
import { Map } from 'immutable';
import { createAction, handleActions } from 'redux-actions';
import { SET_CALLS_ACTION } from '../consts/actions';

// CREATE ACTIONS
export const setCalls = createAction(SET_CALLS_ACTION);

// SET INITIAL STATE
const INITIAL_STATE = Map({
  calls: [],
});

// WRITE HANDLERS FOR ACTIONS
export default handleActions(
  {
    [SET_CALLS_ACTION](state, { payload }) {
      return state.set('calls', payload);
    },
  },
  INITIAL_STATE,
);
