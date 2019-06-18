
import { Map } from 'immutable';
import { createAction, handleActions } from 'redux-actions';
import { SET_WIFIS_ACTION } from '../consts/actions';

// CREATE ACTIONS
export const setWifis = createAction(SET_WIFIS_ACTION);

// SET INITIAL STATE
const INITIAL_STATE = Map({
  wifis: [],
});

// WRITE HANDLERS FOR ACTIONS
export default handleActions(
  {
    [SET_WIFIS_ACTION](state, { payload }) {
      return state.set('wifis', payload);
    },
  },
  INITIAL_STATE,
);
