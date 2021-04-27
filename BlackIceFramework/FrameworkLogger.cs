using System;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using UnityEngine;

namespace BlackIceFramework
{
    // ===================================================================
    //  Inspired off of https://github.com/ManlyMarco/RuntimeUnityEditor.
    // ===================================================================

    /*
    [Flags]
    public enum LogLevel
    {
        None = 0,
        Fatal = 1,
        Error = 2,
        Warning = 4,
        Message = 8,
        Info = 16,
        Debug = 32,
        All = Debug | Info | Message | Warning | Error | Fatal,
    }

    public interface ILoggerWrapper
    {
        void Log(LogLevel logLogLevel, object content);
    }

    class FrameworkLogger : ILoggerWrapper
    {
        private readonly ManualLogSource _logger;

        public FrameworkLogger(ManualLogSource logger)
        {
            _logger = logger;
        }

        public void Log(LogLevel logLogLevel, object content)
        {
            _logger.Log((BepInEx.Logging.LogLevel)logLogLevel, content);
        }
    }
    */
}
