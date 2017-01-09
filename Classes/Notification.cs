using System;
using System.Reflection;

namespace Notify
{
    /// <summary>
    /// A notification that should be shown with libnotify
    /// </summary>
    public class Notification 
    {
        /// <summary>
        /// The pointer to this notification
        /// </summary>
        protected IntPtr _notification;
        
        /// <summary>
        /// The title of this notification
        /// </summary>
        public String Title { get; }
        /// <summary>
        /// The body of this notification
        /// </summary>
        public String Body { get; }
        /// <summary>
        /// The timeout of this notification in milliseconds
        /// </summary>
        public Int32 Timeout { get; set; }
        
        /// <summary>
        /// Initializes libnotify
        /// </summary>
        static Notification() 
        {
            if (!NativeMethods.notify_init(Assembly.GetEntryAssembly().GetName().Name))
            {
                throw new Exception("There was an error while initializing libnotify!");
            }
        }
        
        /// <summary>
        /// Creates a new notification with the given title and body
        /// </summary>
        /// <param name="title">The title</param>
        /// <param name="body">The body</param>
        public Notification(String title, String body) : this(title, body, NativeMethods.NOTIFY_EXPIRES_DEFAULT) 
        { }
        
        /// <summary>
        /// Creates a new notification with the given title, body and timeout
        /// </summary>
        /// <param name="title">The title</param>
        /// <param name="body">The body</param>
        /// <param name="timeout">The timeout in milliseconds</param>
        public Notification(String title, String body, Int32 timeout) {
            this.Title = title;
            this.Body = body;
            this.Timeout = timeout;
            
            _notification = NativeMethods.notify_notification_new(Title, Body, null);
        }
        
        /// <summary>
        /// Show this notification
        /// </summary>
        public void Show()
        {
            NativeMethods.notify_notification_set_timeout(_notification, Timeout);
            IntPtr error = IntPtr.Zero;
            if (!NativeMethods.notify_notification_show(_notification, out error)) 
            {
                throw new Exception("There was an error while showing the notification!");
            }
        }
        
        public void Close() 
        {
            IntPtr error = IntPtr.Zero;
            if (!NativeMethods.notify_notification_close(_notification, out error)) 
            {
                throw new Exception("There was an error while closing the notification!");
            }
            
        }
    }
}