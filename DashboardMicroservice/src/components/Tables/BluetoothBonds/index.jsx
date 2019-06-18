
import React from 'react';
import PropTypes from 'prop-types';
import moment from 'moment';
import { Table } from '../../elements/index';

const BluetoothBonds = ({ list }) => {
  const columns = {
    'Bond status': 'BondStatus',
    Count: 'Count',
    Time: 'Time',
    'Created at': 'createdAt',
    'Updated at': 'updatedAt',
  };
  const data = list.map(({
    _id, BondStatus, Count, Time, createdAt, updatedAt,
  }) => ({
    id: _id,
    BondStatus,
    Count,
    Time,
    createdAt: moment(createdAt).format('MM-DD-YYYY'),
    updatedAt: moment(updatedAt).format('MM-DD-YYYY'),
  }));
  return <Table columns={columns} data={data} />;
};

BluetoothBonds.defaultProps = {
  list: [],
};

BluetoothBonds.propTypes = {
  list: PropTypes.arrayOf(PropTypes.shape({})),
};

export default BluetoothBonds;
