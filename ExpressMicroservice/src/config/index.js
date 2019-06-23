require('dotenv').config();

const {
    PORT,
    MQTT_URL,

} = process.env;

const port = PORT || 3002;

module.exports = {
    port,
    mqttUrl: MQTT_URL,
};
