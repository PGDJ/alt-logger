using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Standard.Common.Logger
{
    public class LoggingUtil
    {
        /// <summary>
        /// The logFile name deault is null for standard system logging
        /// </summary>
        private static EventLog _logFile = new EventLog("Application");

        /// <summary>
        /// File name for logging to a file
        /// also should be driven from config folder reading but not for this purpose
        /// </summary>
        protected String fileName = "log.txt";

        /// <summary>
        /// Default File Directory is my Documents unless specified
        /// Should be using a config and reading from config files but this
        /// fine and easy
        /// </summary>
        //protected String directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        protected String directoryPath = ("C:\\Users\\astobie\\Documents\\");

        /// <summary>
        /// Default minimum level is DEBUG
        /// </summary>
        protected EventVerbosityLevels levelMin = EventVerbosityLevels.ALL;

        /// <summary>
        /// default for standard logging minimum
        /// </summary>
        protected EventLogEntryType minSysLevel = EventLogEntryType.Information;

        /// <summary>
        /// Default level is maximum
        /// </summary>
        protected EventVerbosityLevels levelMax = EventVerbosityLevels.OFF;

        /// <summary>
        /// maximum default value for system is null for all
        /// </summary>
        protected EventLogEntryType maxSysLevel;

        /// <summary>
        /// determines if this is a system event event loggger or not
        /// </summary>
        protected bool isSytemEvent = false;

        /// <summary>
        /// FileStream to write to file
        /// </summary>
        protected FileStream fs;


        public LoggingUtil(bool isSystem, String applicationName)
        {
            isSytemEvent = isSystem;
            _logFile.Source = applicationName;
        }

        public LoggingUtil(EventLogEntryType min, String applicationName)
        {
            isSytemEvent = true;
            minSysLevel = min;
            _logFile.Source = applicationName;
        }


        public LoggingUtil(EventLogEntryType min, EventLogEntryType max, String applicationName)
        {
            isSytemEvent = true;
            minSysLevel = min;
            maxSysLevel = max;
            _logFile.Source = applicationName;
        }

        public LoggingUtil()
        {
            isSytemEvent = false;
        }

        public LoggingUtil(String logFileName)
        {
            isSytemEvent = false;
            fileName = logFileName;
            if (!fileName.Contains(".txt"))
                throw new ArgumentException("LOG FILE MUST BE A .TXT FILE", "LogFileName");
        }

        public LoggingUtil(String logFileName, String directory)
        {
            isSytemEvent = false;
            fileName = logFileName;
            if (!fileName.Contains(".txt"))
                throw new ArgumentException("LOG FILE MUST BE A .TXT FILE", "LogFileName");
            directoryPath = directory;
        }

        public LoggingUtil(EventVerbosityLevels min)
        {
            isSytemEvent = false;
            levelMin = min;
        }

        public LoggingUtil(EventVerbosityLevels min, EventVerbosityLevels max)
        {
            isSytemEvent = false;
            levelMin = min;
            levelMax = max;
        }

        public LoggingUtil(String logFileName, EventVerbosityLevels min)
        {
            isSytemEvent = false;
            fileName = logFileName;
            if (!fileName.Contains(".txt"))
                throw new ArgumentException("LOG FILE MUST BE A .TXT FILE", "LogFileName");
            levelMin = min;
        }

        public LoggingUtil(String logFileName, EventVerbosityLevels min, EventVerbosityLevels max)
        {
            isSytemEvent = false;
            fileName = logFileName;
            if (!fileName.Contains(".txt"))
                throw new ArgumentException("LOG FILE MUST BE A .TXT FILE", "LogFileName");
            levelMin = min;
            levelMax = max;
        }

        public LoggingUtil(String logFileName, String directory, EventVerbosityLevels min)
        {
            isSytemEvent = true;
            fileName = logFileName;
            if (!fileName.Contains(".txt"))
                throw new ArgumentException("LOG FILE MUST BE A .TXT FILE", "LogFileName");
            directoryPath = directory;
            levelMin = min;
        }

        public LoggingUtil(String logFileName, String directory, EventVerbosityLevels min, EventVerbosityLevels max)
        {
            isSytemEvent = false;
            fileName = logFileName;
            if (!fileName.Contains(".txt"))
                throw new ArgumentException("LOG FILE MUST BE A .TXT FILE", "LogFileName");
            directoryPath = directory;
            levelMin = min;
            levelMax = max;
        }

        public EventVerbosityLevels getLevelMin()
        {
            return levelMin;
        }

        public EventVerbosityLevels getLevelMax()
        {
            return levelMax;
        }

        public EventLogEntryType getSysLevelMin()
        {
            return minSysLevel;
        }

        public EventLogEntryType getSysLevelMax()
        {
            return maxSysLevel;
        }

        public void setLevelMin(EventVerbosityLevels val)
        {
            levelMin = val;
        }

        public void getLevelMax(EventVerbosityLevels val)
        {
            levelMax = val;
        }

        public void setSysLevelMin(EventVerbosityLevels val)
        {
            switch (val)
            {
                case EventVerbosityLevels.ALL:
                case EventVerbosityLevels.DEBUG:
                case EventVerbosityLevels.EVENT:
                case EventVerbosityLevels.INFO:
                    minSysLevel = EventLogEntryType.Information;
                    break;
                case EventVerbosityLevels.WARN_LOW:
                case EventVerbosityLevels.WARN_MID:
                case EventVerbosityLevels.WARN_HIGH:
                    minSysLevel = EventLogEntryType.Warning;
                    break;
                case EventVerbosityLevels.ERROR:
                case EventVerbosityLevels.FATAL:
                    minSysLevel = EventLogEntryType.Error;
                    break;
                case EventVerbosityLevels.OFF:
                default:
                    break;
            }
        }

        public void setSysLevelMax(EventVerbosityLevels val)
        {
            switch (val)
            {
                case EventVerbosityLevels.ALL:
                case EventVerbosityLevels.DEBUG:
                case EventVerbosityLevels.EVENT:
                case EventVerbosityLevels.INFO:
                    maxSysLevel = EventLogEntryType.Information;
                    break;
                case EventVerbosityLevels.WARN_LOW:
                case EventVerbosityLevels.WARN_MID:
                case EventVerbosityLevels.WARN_HIGH:
                    maxSysLevel = EventLogEntryType.Warning;
                    break;
                case EventVerbosityLevels.ERROR:
                case EventVerbosityLevels.FATAL:
                    maxSysLevel = EventLogEntryType.Error;
                    break;
                case EventVerbosityLevels.OFF:
                default:
                    break;
            }
        }

        public void LogEvents(Event e)
        {
            if (isSytemEvent && minSysLevel != null)
            {
                if (minSysLevel <= e.basicType && (levelMax == null || e.basicType <= maxSysLevel))
                    _logFile.WriteEntry(e.eventMessage, e.basicType);
            }
            else
            {
                if (compareVerbosity(levelMin, e.verbosityLevel) <= 0 && compareVerbosity(levelMax, e.verbosityLevel) >= 0)
                {
                    String str = String.Format("{0} {1}    {2,9} : Application Name: {3}, Process ID: {4} -- {5}\n", DateTime.Now.ToLongTimeString(),
                        DateTime.Now.ToLongDateString(), e.verbosityLevel.ToString(), e.applicationName, (e.processID == int.MinValue ? "NONE" : e.processID.ToString()), e.eventMessage);
                    using (FileStream fs = new FileStream(directoryPath+fileName,FileMode.Append,FileAccess.Write))
                    {
                        using (StreamWriter w = new StreamWriter(fs))
                        {
                            w.WriteLine(str);
                        }
                    }

                }
            }

        }

        public int compareVerbosity(EventVerbosityLevels vl, EventVerbosity v)
        {
            switch (vl)
            {
                case EventVerbosityLevels.ALL:
                    return -1;
                    break;
                case EventVerbosityLevels.EVENT:
                    if (v == EventVerbosity.EVENT)
                        return 0;
                    else
                        return -1;
                    break;
                case EventVerbosityLevels.DEBUG:
                    if (v == EventVerbosity.EVENT)
                        return 1;
                    else if (v == EventVerbosity.DEBUG)
                        return 0;
                    else
                        return -1;
                    break;
                case EventVerbosityLevels.INFO:
                    if (v < EventVerbosity.INFO)
                        return 1;
                    else if (v == EventVerbosity.INFO)
                        return 0;
                    else
                        return -1;
                    break;
                case EventVerbosityLevels.WARN_LOW:
                    if (v < EventVerbosity.WARN_LOW)
                        return 1;
                    else if (v == EventVerbosity.WARN_LOW)
                        return 0;
                    else
                        return -1;
                    break;
                case EventVerbosityLevels.WARN_MID:
                    if (v < EventVerbosity.WARN_MID)
                        return 1;
                    else if (v == EventVerbosity.WARN_MID)
                        return 0;
                    else
                        return -1;
                    break;
                case EventVerbosityLevels.WARN_HIGH:
                    if (v < EventVerbosity.WARN_HIGH)
                        return 1;
                    else if (v == EventVerbosity.WARN_HIGH)
                        return 0;
                    else
                        return -1;
                    break;
                case EventVerbosityLevels.ERROR:
                    if (v < EventVerbosity.ERROR)
                        return 1;
                    else if (v == EventVerbosity.ERROR)
                        return 0;
                    else
                        return -1;
                    break;
                case EventVerbosityLevels.FATAL:
                    if (v == EventVerbosity.FATAL)
                        return 0;
                    else
                        return 1;
                    break;
                case EventVerbosityLevels.OFF:
                default:
                    return 1;
            }
        }
    }
}
