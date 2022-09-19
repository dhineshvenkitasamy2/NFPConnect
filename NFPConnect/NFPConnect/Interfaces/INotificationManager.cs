using System;
using System.Collections.Generic;
using System.Text;

namespace NFPConnect.Interfaces
{
    public interface INotificationManager
    {
        void SendNotification(string title, string message, DateTime? notifyTime = null);
    }
}
