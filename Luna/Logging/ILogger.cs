using System;

namespace Luna.Logging
{
    internal interface ILogger : IInitializable
    {
        void Critical(string message);
        void Critical(Exception e);

        void Error(string message);
        void Error(Exception e);

        void Warn(string message);
        void Warn(Exception e);

        void Info(string message);
        void Info(Exception e);

        void Debug(string message);
        void Debug(Exception e);
    }
}
