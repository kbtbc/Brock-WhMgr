﻿namespace WhMgr.Diagnostics
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;

    public class EventLogger : IEventLogger
    {
        private const string DefaultLoggerName = "default";

        #region Static Variables

        //private static EventLogger _instance;
        private static readonly Dictionary<string, EventLogger> _instances = new Dictionary<string, EventLogger>();
        //private static readonly object _lock = new object();
        private static readonly EventWaitHandle _waitHandle = new EventWaitHandle(true, EventResetMode.AutoReset, Strings.BotName + new Random().Next(10000, 90000));

        #endregion

        #region Properties

        public string Name { get; set; }

        public Action<LogType, string> LogHandler { get; set; }

        public static EventLogger GetLogger(string name = null)
        {
            var instanceName = (name ?? DefaultLoggerName).ToLower();
            if (_instances.ContainsKey(instanceName))
            {
                return _instances[instanceName];
            }

            _instances.Add(instanceName, new EventLogger(instanceName));
            return _instances[instanceName];

            //if (_instance == null)
            //{
            //    CreateLogsDirectory();

            //    _instance = new EventLogger();
            //    _instance.Info("Logging started...");
            //}

            //return _instance;
        }

        #endregion

        #region Constructor(s)

        public EventLogger() 
            : this(DefaultLoggerName)
        {
        }

        public EventLogger(string name)
        {
            Name = name;
            LogHandler = new Action<LogType, string>(DefaultLogHandler);
            //_instances = new Dictionary<string, IEventLogger>();
            CreateLogsDirectory();
        }

        public EventLogger(Action<LogType, string> logHandler) 
            : this(DefaultLoggerName, logHandler)
        {
        }

        public EventLogger(string name, Action<LogType, string> logHandler)
        {
            Name = name;
            LogHandler = logHandler;
            //_instances = new Dictionary<string, EventLogger>();
            CreateLogsDirectory();
        }

        #endregion

        #region Public Methods

        public void Trace(string format, params object[] args)
        {
            LogHandler(LogType.Trace, args.Length > 0 ? string.Format(format, args) : format);
        }

        public void Debug(string format, params object[] args)
        {
            LogHandler(LogType.Debug, args.Length > 0 ? string.Format(format, args) : format);
        }

        public void Info(string format, params object[] args)
        {
            LogHandler(LogType.Info, args.Length > 0 ? string.Format(format, args) : format);
        }

        public void Warn(string format, params object[] args)
        {
            LogHandler(LogType.Warning, args.Length > 0 ? string.Format(format, args) : format);
        }

        public void Error(string format, params object[] args)
        {
            LogHandler(LogType.Error, args.Length > 0 ? string.Format(format, args) : format);
        }

        public void Error(Exception ex)
        {
            LogHandler(LogType.Error, ex?.ToString());
        }

        #endregion

        #region Private Methods

        private void DefaultLogHandler(LogType logType, string message)
        {
            var msg = $"{DateTime.Now.ToShortTimeString()} [{logType.ToString().ToUpper()}] [{Name.ToUpper()}] {message}";

            switch (logType)
            {
                case LogType.Debug:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case LogType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogType.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogType.Trace:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case LogType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }
            Console.WriteLine(msg);

            //lock (_lock)
            //{
            _waitHandle.WaitOne();
            File.AppendAllText(Path.Combine(Strings.LogsFolder, $"{Program.ManagerName}_{DateTime.Now.ToString("yyyy-MM-dd")}.log"), msg + Environment.NewLine);
            _waitHandle.Set();
            //}
        }

        private static void CreateLogsDirectory()
        {
            if (Directory.Exists(Strings.LogsFolder))
                return;

            Directory.CreateDirectory(Strings.LogsFolder);
        }

        #endregion
    }
}