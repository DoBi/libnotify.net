using System;
using System.Runtime.InteropServices;

namespace Notify
{
    /// <summary>
    /// Class with native methods from libnotify
    /// </summary>
    internal static class NativeMethods
    {
        /// <summary>
        /// Initialized libnotify. This must be called before any other functions.
        /// </summary>
        /// <param name="appName">The name of the application initializing libnotify.</param>
        /// <returns>True if successful or false on error</returns>
        [DllImport("libnotify.so.4", CharSet = CharSet.Ansi)]
        internal static extern bool notify_init([MarshalAs(UnmanagedType.LPStr)] string appName);
        
        /// <summary>
        /// Uninitialized libnotify.
        /// This should be called when the program no longer needs libnotify for the rest of its lifecycle, typically just before exitting.
        /// </summary>
        [DllImport("libnotify.so.4")]
        internal static extern void notify_uninit();
        
        /// <summary>
        /// Gets the application name registered.
        /// </summary>
        /// <returns>The registered application name, passed to <see cref="notify_init"/>.</returns>
        [DllImport("libnotify.so.4", CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        internal static extern string notify_get_app_name();
        
        /// <summary>
        /// Creates a new NotifyNotification. The summary text is required, but all other parameters are optional.
        /// </summary>
        /// <param name="summary">The required summary text.</param>
        /// <param name="body">The optional body text.</param>
        /// <param name="icon">The optional icon theme icon name or filename.</param>
        /// <returns>The new NotifyNotification.</returns>
        [DllImport("libnotify.so.4", CharSet = CharSet.Ansi)]
        internal static extern IntPtr notify_notification_new([MarshalAs(UnmanagedType.LPStr)] string summary,
                                                              [MarshalAs(UnmanagedType.LPStr)] string body,
                                                              [MarshalAs(UnmanagedType.LPStr)] string icon);
        
        /// <summary>
        /// Tells the notification server to display the notification on the screen.
        /// </summary>
        /// <param name="notification">The notification.</param>
        /// <param name="error">The returned error information.</param>
        /// <returns>True if successful. On error, this will return false and set error.</returns>
        [DllImport("libnotify.so.4", CharSet = CharSet.Ansi)]
        internal static extern bool notify_notification_show(IntPtr notification, out IntPtr error);
        
        /// <summary>
        /// Sets the timeout of the notification. 
        /// To set the default time, pass NOTIFY_EXPIRES_DEFAULT as timeout. To set the notification to never expire, pass NOTIFY_EXPIRES_NEVER.
        /// Note that the timeout may be ignored by the server.
        /// </summary>
        /// <param name="notification">The notification</param>
        /// <param name="timeout">The timeout in milliseconds.</param>
        [DllImport("libnotify.so.4", CharSet = CharSet.Ansi)]
        internal static extern void notify_notification_set_timeout(IntPtr notification, int timeout);
    }
}