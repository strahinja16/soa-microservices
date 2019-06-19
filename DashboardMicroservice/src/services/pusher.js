import * as Pusher from "pusher-js";
import config from './config';

class PusherService {
  constructor() {
    const { key, additionalConfig } = config;
    this.pusher = new Pusher(key, additionalConfig);
  }

  subscribe(channel, event, callback) {
    this.pusher
      .subscribe(channel)
      .bind(event, ({ data }) => callback(data));
  }

  unsubscribe(channel) {
    this.pusher.unsubscribe(channel);
  }
}

const pusherService = new PusherService();

export default pusherService; //singleton
