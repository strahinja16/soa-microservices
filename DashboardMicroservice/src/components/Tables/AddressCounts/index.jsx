
import React from 'react';
import PropTypes from 'prop-types';
import moment from 'moment';
import { Table } from '../../elements/index';

const AddressCounts = ({ list }) => {
  const columns = {
    Date: 'Date',
    Address: 'Address',
    Count: 'Count',
    'Created at': 'createdAt',
    'Updated at': 'updatedAt',
  };
  const data = list.map(({
    _id, Date, Address, Count, createdAt, updatedAt,
  }) => ({
    id: _id,
    Date: moment(Date).format('MM-DD-YYYY'),
    Address,
    Count,
    createdAt: moment(createdAt).format('MM-DD-YYYY'),
    updatedAt: moment(updatedAt).format('MM-DD-YYYY'),
  }));
  return <Table columns={columns} data={data} />;
};

AddressCounts.defaultProps = {
  list: [],
};

AddressCounts.propTypes = {
  list: PropTypes.arrayOf(PropTypes.shape({})),
};

export default AddressCounts;
