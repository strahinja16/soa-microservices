const mongoose = require('mongoose');

const schema = new mongoose.Schema(
  {
    Duration: {
      type: Number,
      required: 'Duration is required',
    },

    Count: {
      type: Number,
      required: 'Count is required',
    },

    Time: {
      type: String,
      required: 'Time is required',
    },
  },
  {
    timestamps: true,
    minimize: false,
  },
);

module.exports = mongoose.model('CallDuration', schema);
