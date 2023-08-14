using Plugin.LocalNotification;

namespace Panulu.Services;

public class Notification
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Subtitle { get; set; }
    public DateTime ScheduleDateTime { get; set; }
    public bool Repeat { get; set; }
    public int RepeatInterval { get; set; }


    public void CreateNotification()
    {
        Random random = new();
        int repeatInterval = 0;
        if(Repeat)
        {
            repeatInterval = RepeatInterval;
        }
        var notification = new NotificationRequest()
        {
            Title = Title,
            Description = Description,
            Subtitle = Subtitle,
            BadgeNumber = random.Next(),

            Schedule = new NotificationRequestSchedule()
            {
                NotifyTime = ScheduleDateTime,
                NotifyRepeatInterval = TimeSpan.FromDays(repeatInterval)
            }
        };
        LocalNotificationCenter.Current.Show(notification);
    }
}
