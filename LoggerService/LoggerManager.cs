using Contracts;
using NLog;
namespace LoggerService;

public class LoggerManager : ILoggerManager
{
    private static ILogger logger = LogManager.GetCurrentClassLogger();
    public void LOgInfo(string message) => logger.Info(message);
    public void LOgWarn(string message) => logger.Warn(message);
    public void LOgDebug(string message) => logger.Debug(message);
    public void LOgError(string message) => logger.Error(message);

}