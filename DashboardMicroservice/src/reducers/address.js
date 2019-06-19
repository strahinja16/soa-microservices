
import { Map } from 'immutable';
import { createAction, handleActions } from 'redux-actions';
import { SET_ADDRESSES_ACTION, ADD_ADDRESS_ACTION } from '../consts/actions';

// CREATE ACTIONS
export const setAddresses = createAction(SET_ADDRESSES_ACTION);
export const addAddress = createAction(ADD_ADDRESS_ACTION);

// SET INITIAL STATE
const INITIAL_STATE = Map({
  addresses: [],
});

// WRITE HANDLERS FOR ACTIONS
export default handleActions(
  {
    [SET_ADDRESSES_ACTION](state, { payload }) {
      return state.set('addresses', payload);
    },
    [ADD_ADDRESS_ACTION](state, { payload }) {
      return state.set('addresses', state.get('addresses').concat(payload));
    },
  },
  INITIAL_STATE,
);
