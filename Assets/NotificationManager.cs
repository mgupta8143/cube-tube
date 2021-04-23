using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreateNotifChannel();
        SendNotification();
    }
    void CreateNotifChannel()
    {
        var c = new AndroidNotificationChannel()
        {
            Id = "notif1",
            Name = "notification",
            Importance = Importance.High,
            Description = "Reminds player to play the game"
        };
        AndroidNotificationCenter.RegisterNotificationChannel(c);

    }

    void SendNotification()
    {
        for (int i = 1; i < 2; i++)
        {
            var notification = new AndroidNotification();
            notification.Title = "Cube Tube";
            notification.Text = "What's wrong? Have fun dodging some tubes!";
            notification.FireTime = System.DateTime.Now.AddDays(2 * i);
            notification.LargeIcon = "icon_1";
            AndroidNotificationCenter.SendNotification(notification, "notif1");
        }
    }
}
