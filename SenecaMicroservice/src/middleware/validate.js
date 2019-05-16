const Joi = require('joi');

module.exports = schema => (request, response, next) => {
  const { error } = Joi.validate(request.body, schema, { abortEarly: false });

  if (error) {
    // If its a single message, use it.
    let { message } = error.details;

    // If we are dealing with array, extract messages.
    if (Array.isArray(error.details)) {
      message = error.details.map(e => e.message);
    }
    return response.status(400).send({
      message,
    });
  }

  return next();
};
