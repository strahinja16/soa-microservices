
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
    _id, Time, Accuracy, Count, createdAt, updatedAt,
  }) => ({
    id: _id,
    Time: moment(Time).format('MM-DD-YYYY'),
    Accuracy,
    Count,
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
