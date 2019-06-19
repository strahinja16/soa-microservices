
import { Map } from 'immutable';
import { createAction, handleActions } from 'redux-actions';
import {SET_WIFIS_ACTION, ADD_WIFI_ACTION } from '../consts/actions';

// CREATE ACTIONS
export const setWifis = createAction(SET_WIFIS_ACTION);
export const addWifi = createAction(ADD_WIFI_ACTION);

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
    [ADD_WIFI_ACTION](state, { payload }) {
      return state.set('wifis', state.get('wifis').concat(payload));
    },
  },
  INITIAL_STATE,
);
