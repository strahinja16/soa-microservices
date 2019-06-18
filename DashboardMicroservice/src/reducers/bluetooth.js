
import { Map } from 'immutable';
import { createAction, handleActions } from 'redux-actions';
import { SET_BLUETOOTHS_ACTION } from '../consts/actions';

// CREATE ACTIONS
export const setBluetooths = createAction(SET_BLUETOOTHS_ACTION);

// SET INITIAL STATE
const INITIAL_STATE = Map({
  bluetooths: [],
});

// WRITE HANDLERS FOR ACTIONS
export default handleActions(
  {
    [SET_BLUETOOTHS_ACTION](state, { payload }) {
      return state.set('bluetooths', payload);
    },
  },
  INITIAL_STATE,
);
