
import { combineReducers } from 'redux';
import { persistReducer } from 'redux-persist';
import immutableTransform from 'redux-persist-transform-immutable';
import storage from 'redux-persist/lib/storage';
import application from './application';
import address from './address';
import bluetooth from './bluetooth';
import call from './call';
import location from './location';
import wifi from './wifi';

const persistConfig = {
  key: 'root',
  transforms: [immutableTransform()],
  storage,
  whitelist: ['auth'],
};

const combinedReducers = combineReducers({
  application,
  address,
  bluetooth,
  call,
  location,
  wifi,
});

export default persistReducer(persistConfig, combinedReducers);
