
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
    _id, Time, Capability, Count, createdAt, updatedAt,
  }) => ({
    id: _id,
    Time: moment(Time).format('MM-DD-YYYY'),
    Capability,
    Count,
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
