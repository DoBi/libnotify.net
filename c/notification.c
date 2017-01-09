#include "notification.h"
#include <libnotify/notification.h>

/**
 * notify_notification_get:
 * @notification: The pointer to a NotifyNotification struct
 *
 * Returns: The NotifyNotificationPrivate struct of the NotifyNotification
 */
NotifyNotificationPrivate *
notify_notification_get(NotifyNotification *notification)
{
    return notification->priv;
}