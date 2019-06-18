
import React from 'react';
import PropTypes from 'prop-types';
import moment from 'moment';
import { Table } from '../../elements/index';

const CallDurations = ({ list }) => {
  const columns = {
    Duration: 'Duration',
    Count: 'Count',
    Time: 'Time',
    'Created at': 'createdAt',
    'Updated at': 'updatedAt',
  };
  const data = list.map(({
    _id, Duration, Count, Time, createdAt, updatedAt,
  }) => ({
    id: _id,
    Duration,
    Count,
    Time,
    createdAt: moment(createdAt).format('MM-DD-YYYY'),
    updatedAt: moment(updatedAt).format('MM-DD-YYYY'),
  }));
  return <Table columns={columns} data={data} />;
};

CallDurations.defaultProps = {
  list: [],
};

CallDurations.propTypes = {
  list: PropTypes.arrayOf(PropTypes.shape({})),
};

export default CallDurations;
