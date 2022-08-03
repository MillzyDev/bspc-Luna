using Luna.Configuration;
using System;

namespace Luna.Logging
{
    internal class Logger : ILogger
    {
        private static Logger _instance;

        private Logger(ref PluginConfig)

        public static Logger GetInstance(ref PluginConfig config = null)
        {
            if (_instance == null)
        }

        public void Critical(string message)
        {
            if ()
        }

        public void Critical(Exception e)
        {
            throw new NotImplementedException();
        }

        public void Debug(string message)
        {
            throw new NotImplementedException();
        }

        public void Debug(Exception e)
        {
            throw new NotImplementedException();
        }

        public void Error(string message)
        {
            throw new NotImplementedException();
        }

        public void Error(Exception e)
        {
            throw new NotImplementedException();
        }

        public void Info(string message)
        {
            throw new NotImplementedException();
        }

        public void Info(Exception e)
        {
            throw new NotImplementedException();
        }

        public void Warn(string message)
        {
            throw new NotImplementedException();
        }

        public void Warn(Exception e)
        {
            throw new NotImplementedException();
        }
    }
}
