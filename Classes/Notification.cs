using System;
using System.Reflection;

namespace Notify
{
    /// <summary>
    /// A notification that should be shown with libnotify
    /// </summary>
    public class Notification 
    {
        private sealed class Destructor
        {
            ~Destructor()
            {
                NativeMethods.notify_uninit();
            }
        }

        private static readonly Destructor Finalise = new Destructor();

        protected static String AppName;
        /// <summary>
        /// The pointer to this notification
        /// </summary>
        private readonly IntPtr _notification;
        
        /// <summary>
        /// The title of this notification
        /// </summary>
        public String Title { get; }
        /// <summary>
        /// The body of this notification
        /// </summary>
        public String Body { get; }
        /// <summary>
        /// The icon of this notification
        /// </summary>
        public String Icon { get; }
        /// <summary>
        /// The timeout of this notification in milliseconds
        /// </summary>
        public Int32 Timeout { get; set; }
        
        /// <summary>
        /// Initializes libnotify
        /// </summary>
        static Notification() 
        {
            AppName = Assembly.GetEntryAssembly().GetName().Name;
            
            if (!NativeMethods.notify_init(AppName))
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
        public Notification(String title, String body, Int32 timeout) : this(title, body, timeout, null) 
        { }
        
        /// <summary>
        /// Creates a new notification with the given title, body and timeout
        /// </summary>
        /// <param name="title">The title</param>
        /// <param name="body">The body</param>
        /// <param name="icon">The icon file</param>
        public Notification(String title, String body, String icon) : this(title, body, NativeMethods.NOTIFY_EXPIRES_DEFAULT, icon)
        { }
        
        /// <summary>
        /// Creates a new notification with the given title, body and timeout
        /// </summary>
        /// <param name="title">The title</param>
        /// <param name="body">The body</param>
        /// <param name="timeout">The timeout in milliseconds</param>
        /// <param name="icon">The icon file</param>
        public Notification(String title, String body, Int32 timeout, String icon)
        {   
            this.Title = title;
            this.Body = body;
            this.Timeout = timeout;
            this.Icon = icon;
            
            _notification = NativeMethods.notify_notification_new(Title, Body, icon);
            NativeMethods.notify_notification_set_app_name(this._notification, AppName);
        }
        
        /// <summary>
        /// Show this notification
        /// </summary>
        public void Show()
        {
            NativeMethods.notify_notification_set_timeout(_notification, Timeout);
            IntPtr error;
            if (!NativeMethods.notify_notification_show(_notification, out error)) 
            {
                throw new Exception("There was an error while showing the notification!");
            }
        }
        
        public void Close() 
        {
            IntPtr error;
            if (!NativeMethods.notify_notification_close(_notification, out error)) 
            {
                throw new Exception("There was an error while closing the notification!");
            }
            
        }
    }
}