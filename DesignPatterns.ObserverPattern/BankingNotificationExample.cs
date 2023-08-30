using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ObserverPattern
{
    public class NotificationManager
    {
        private List<INotificationSender> observers = new();

        public void Register(INotificationSender notificationSender, NotificationType notificationType)
        {
            observers.Add(notificationSender);
        }

        public void UnRegister(INotificationSender notificationSender)
        {
            observers.Remove(notificationSender);
        }

        public void NotifyWithAllType(NotificationInformation notificationInformation)
        {
            foreach (var observer in observers)
            {
                observer.Notify(notificationInformation);
            }
        }

        public void NotifyWithType(NotificationInformation notificationInformation)
        {
            foreach (var observer in observers)
            {
                if (observer.NotificationType == notificationInformation.NotificationType)
                {
                    observer.Notify(notificationInformation);
                }
            }
        }
    }

    public enum NotificationType
    {
        SMS,
        Push
    }

    public interface INotificationSender
    {
        public NotificationType NotificationType { get; }
        void Notify(NotificationInformation notificationInformation);
    }

    public class SmsNotificationSender : INotificationSender
    {
        public NotificationType NotificationType { get; }

        public SmsNotificationSender(NotificationType notificationType)
        {
            this.NotificationType = notificationType;
        }

        public void Notify(NotificationInformation notificationInformation)
        {
            if (notificationInformation.ToNumber.StartsWith("+90"))
            {
                Console.WriteLine($"Sending {notificationInformation.NotificationType} to {notificationInformation.ToNumber} at {notificationInformation.NotifyDate} with message {notificationInformation.Message}");
            }
            else
            {
                Console.WriteLine($"Wrong Number Format For SMS");
            }            
        }
    }

    public class PushNotificationSender : INotificationSender
    {
        public NotificationType NotificationType { get; }

        public PushNotificationSender(NotificationType notificationType)
        {
            this.NotificationType = notificationType;
        }

        public void Notify(NotificationInformation notificationInformation)
        {
            Console.WriteLine($"Sending {notificationInformation.NotificationType} to {notificationInformation.ToNumber} at {notificationInformation.NotifyDate} with message {notificationInformation.Message}");
        }
    }

    public class NotificationInformation
    {
        public string ToNumber { get; set; }
        public DateTime NotifyDate { get; set; }
        public string Message { get; set; }
        public NotificationType NotificationType { get; set; }
    }

    public static class BankingNotificationExample
    {
        public static void RunSample()
        {
            var notificationMessageSms = new NotificationInformation
            {
                ToNumber = "+901234567890",
                NotifyDate = DateTime.Now,
                Message = "Your account has been credited with $1000",
                NotificationType = NotificationType.SMS
            };

            var notificationMessagePush = new NotificationInformation
            {
                ToNumber = "136013601360",
                NotifyDate = DateTime.Now,
                Message = "Your account has been credited with $5000",
                NotificationType = NotificationType.Push
            };

            var notificationMessageAll = new NotificationInformation
            {
                ToNumber = "+901234567890",
                NotifyDate = DateTime.Now,
                Message = "Your account has been credited with $5000",
                NotificationType = NotificationType.Push
            };

            var notificationManager = new NotificationManager();
            var smsNotificationObserver = new SmsNotificationSender(NotificationType.SMS);
            var pushNotificationObserver = new PushNotificationSender(NotificationType.Push);

            notificationManager.Register(smsNotificationObserver, NotificationType.SMS);
            notificationManager.Register(pushNotificationObserver, NotificationType.Push);

            notificationManager.NotifyWithType(notificationMessageSms);
            notificationManager.NotifyWithType(notificationMessagePush);
            notificationManager.NotifyWithAllType(notificationMessageAll);
        }
    }
}
