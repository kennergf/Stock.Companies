using System.Collections.Generic;
using Stock.Companies.Domain.Entities;

namespace Stock.Companies.Domain.Interfaces
{
    public interface INotifier
    {
        bool HasNotification();

        List<Notification> GetNotifications();

        void Add(Notification notification);
    }
}