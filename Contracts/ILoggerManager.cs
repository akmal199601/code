namespace Contracts;

public interface ILoggerManager
{
    void LOgInfo(string message);
    void LOgWarn(string message);
    void LOgDebug(string message);
    void LOgError(string message);
}