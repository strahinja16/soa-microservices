
import { Map } from 'immutable';
import { createAction, handleActions } from 'redux-actions';
import {SET_LOCATIONS_ACTION, ADD_LOCATION_ACTION } from '../consts/actions';

// CREATE ACTIONS
export const setLocations = createAction(SET_LOCATIONS_ACTION);
export const addLocation = createAction(ADD_LOCATION_ACTION);

// SET INITIAL STATE
const INITIAL_STATE = Map({
  locations: [],
});

// WRITE HANDLERS FOR ACTIONS
export default handleActions(
  {
    [SET_LOCATIONS_ACTION](state, { payload }) {
      return state.set('locations', payload);
    },
    [ADD_LOCATION_ACTION](state, { payload }) {
      return state.set('locations', state.get('locations').concat(payload));
    },
  },
  INITIAL_STATE,
);
