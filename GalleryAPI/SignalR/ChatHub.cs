using Microsoft.AspNetCore.SignalR;

namespace GalleryAPI.SignalR
{
    public class ChatHub : Hub
    {
        //Getting message from client side and return it to client side chat.
        public async Task Send(string message)
        {
            //Returning to Client method Receive
            await Clients.All.SendAsync("Receive", message);
        }

        //When new user connected to our chat,we sending notif.to client side.
        public override async Task OnConnectedAsync()
        {
            //Returning to Client method Notify.
            await Clients.All.SendAsync("Notify","Say Hello,new User enters chat.");
            await base.OnConnectedAsync();
        }
    }
}
