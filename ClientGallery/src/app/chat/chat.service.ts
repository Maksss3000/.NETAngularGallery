import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Subject } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  private hubConnection: signalR.HubConnection;
  public messages$ = new Subject<string>();
  public notifications$ = new Subject<string>();
  env = environment;
  constructor() {
    //Connecting to our Hub chat that in Backend.
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(this.env.signalR + 'chat')
      .build();

    //When getting recieve message from our Hub(SignalR)
    this.hubConnection.on('Receive', (message: string) => {
      this.messages$.next(message);  
    });

    this.hubConnection.on('Notify', (notification: string) => {
      this.notifications$.next(notification);
    });

    this.hubConnection.start().catch(err => console.error(err));
  }

  public sendMessage(message: string) {
    //Sending our message to Server method Send.
    this.hubConnection.invoke('Send', message);
  }


  }

