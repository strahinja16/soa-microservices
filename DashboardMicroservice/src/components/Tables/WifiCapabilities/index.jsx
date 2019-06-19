
import React from 'react';
import PropTypes from 'prop-types';
import moment from 'moment';
import { Table } from '../../elements/index';

const WifiCapabilities = ({ list }) => {
  const columns = {
    Time: 'Time',
    Capability: 'Capability',
    Count: 'Count',
    'Created at': 'createdAt',
    'Updated at': 'updatedAt',
  };
  const data = list.map(({
    _id, time, capability, count, createdAt, updatedAt,
  }) => ({
    id: _id,
    Time: moment(time).format('MM-DD-YYYY'),
    Capability: capability,
    Count: count,
    createdAt: moment(createdAt).format('MM-DD-YYYY'),
    updatedAt: moment(updatedAt).format('MM-DD-YYYY'),
  }));

  return <Table columns={columns} data={data} />;
};

WifiCapabilities.defaultProps = {
  list: [],
};

WifiCapabilities.propTypes = {
  list: PropTypes.arrayOf(PropTypes.shape({})),
};

export default WifiCapabilities;
