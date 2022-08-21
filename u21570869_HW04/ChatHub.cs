using System;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace u21570869_HW04
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message, string type, string description, string status, string gender)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message, type, description, status, gender);
        }
    }
}