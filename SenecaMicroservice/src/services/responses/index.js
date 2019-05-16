const { getStatusText } = require('http-status-codes');

module.exports = code => getStatusText(code);
