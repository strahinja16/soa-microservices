const { createLogger, format, transports } = require('winston');

const customFormat = format.printf(info => `${info.timestamp} ${info.level}: ${info.message}`);

module.exports = createLogger({
  format: format.combine(
    format.colorize(),
    format.timestamp(),
    format.splat(),
    format.simple(),
    customFormat,
  ),
  transports: [
    new transports.Console(),
  ],
});
