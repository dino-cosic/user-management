using UserManagement.Core.Interfaces;

namespace UserManagement.Infrastructure.Logging
{
    /// <summary>
    /// /// Does not have implementations. Could be used for logging the traces, info and exceptions across the application.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        // I did not have time to implement logger, but I can explain additionally how and for what I did use logging in other apps.
    }
}