const mongoose = require('mongoose');

const schema = new mongoose.Schema(
  {
    ProcessName: {
      type: String,
      required: 'Process name is required',
    },

    Count: {
      type: Number,
      required: 'Count is required',
    },

    Start: {
      type: String,
      required: 'Start is required',
    },
  },
  {
    timestamps: true,
    minimize: false,
  },
);

module.exports = mongoose.model('ApplicationProcessCount', schema);
