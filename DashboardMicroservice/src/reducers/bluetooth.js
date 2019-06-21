
import { Map } from 'immutable';
import { createAction, handleActions } from 'redux-actions';
import {SET_BLUETOOTHS_ACTION, ADD_BLUETOOTH_ACTION } from '../consts/actions';

// CREATE ACTIONS
export const setBluetooths = createAction(SET_BLUETOOTHS_ACTION);
export const addBluetooth = createAction(ADD_BLUETOOTH_ACTION);

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
    [ADD_BLUETOOTH_ACTION](state, { payload }) {
      console.log(payload);
      return state.set('bluetooths', state.get('bluetooths').concat(payload));
    },
  },
  INITIAL_STATE,
);
