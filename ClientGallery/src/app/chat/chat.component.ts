import { Component, OnInit } from '@angular/core';
import { ChatService } from './chat.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit {


  messages: string[] = [];
  userMessage: string = '';
  constructor(private chatService: ChatService) {
    this.chatService.messages$.subscribe(msg => this.messages.push(msg));
    this.chatService.notifications$.subscribe(notification => this.messages.push(notification));
  }

  ngOnInit(): void {
  }

  sendMessage() {

    if (this.userMessage.trim() === '') {
      return; 
    }
    this.chatService.sendMessage(this.userMessage);
    this.userMessage = ''; 
  }


}
