import * as signalR from '@microsoft/signalr';

class SignalRService {
  constructor(url) {
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl(url)
      .configureLogging(signalR.LogLevel.Information)
      .build();

    this.isConnected = false;

    this.connection.onclose(async () => {
      console.log('SignalR disconnected. Attempting to reconnect...');
      this.isConnected = false;
      await this.reconnect();
    });
  }

  async startConnection() {
    try {
      await this.connection.start();
      console.log('SignalR Connected.');
      this.isConnected = true;
    } catch (err) {
      console.error('SignalR connection failed:', err);
      setTimeout(() => this.startConnection(), 5000); // Thử kết nối lại sau 5 giây
    }
  }

  async stopConnection() {
    try {
      await this.connection.stop();
      console.log('SignalR Disconnected.');
      this.isConnected = false;
    } catch (err) {
      console.error('Error stopping SignalR connection:', err);
    }
  }

  async reconnect() {
    console.log('Reconnecting...');
    await this.startConnection();
  }

  addHandler(eventName, callback) {
    if (this.connection) {
      this.connection.on(eventName, callback);
    }
  }

  removeHandler(eventName) {
    if (this.connection) {
      this.connection.off(eventName);
    }
  }

  async sendMessage(methodName, ...args) {
    try {
      if (this.connection) {
        await this.connection.invoke(methodName, ...args);
        console.log(`Message sent to method ${methodName}`, args);
      }
    } catch (err) {
      console.error(`Error sending message to ${methodName}:`, err);
    }
  }

  isConnected() {
    return this.isConnected;
  }

  onError(callback) {
    this.connection.onclose(callback);
  }
}

export default SignalRService;
