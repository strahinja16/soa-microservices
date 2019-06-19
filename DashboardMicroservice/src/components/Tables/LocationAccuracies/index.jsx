
import React from 'react';
import PropTypes from 'prop-types';
import moment from 'moment';
import { Table } from '../../elements/index';

const LocationAccuracies = ({ list }) => {
  const columns = {
    Time: 'Time',
    Accuracy: 'Accuracy',
    Count: 'Count',
    'Created at': 'createdAt',
    'Updated at': 'updatedAt',
  };
  const data = list.map(({
    _id, time, accuracy, count, createdAt, updatedAt,
  }) => ({
    id: _id,
    Time: moment(time).format('MM-DD-YYYY'),
    Accuracy: accuracy,
    Count: count,
    createdAt: moment(createdAt).format('MM-DD-YYYY'),
    updatedAt: moment(updatedAt).format('MM-DD-YYYY'),
  }));
  return <Table columns={columns} data={data} />;
};

LocationAccuracies.defaultProps = {
  list: [],
};

LocationAccuracies.propTypes = {
  list: PropTypes.arrayOf(PropTypes.shape({})),
};

export default LocationAccuracies;
