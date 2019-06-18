
import React from 'react';
import PropTypes from 'prop-types';
import moment from 'moment';
import { Table } from '../../elements/index';

const ApplicationProcessCounts = ({ list }) => {
  const columns = {
    'Process name': 'ProcessName',
    Count: 'Count',
    Start: 'Start',
    'Created at': 'createdAt',
    'Updated at': 'updatedAt',
  };
  const data = list.map(({
    _id, ProcessName, Count, Start, createdAt, updatedAt,
  }) => ({
    id: _id,
    ProcessName,
    Count,
    Start,
    createdAt: moment(createdAt).format('MM-DD-YYYY'),
    updatedAt: moment(updatedAt).format('MM-DD-YYYY'),
  }));
  return <Table columns={columns} data={data} />;
};

ApplicationProcessCounts.defaultProps = {
  list: [],
};

ApplicationProcessCounts.propTypes = {
  list: PropTypes.arrayOf(PropTypes.shape({})),
};

export default ApplicationProcessCounts;
