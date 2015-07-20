using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard.Common.Logger
{
    public class Event
    {
        /// <summary>
        /// Message for the event
        /// </summary>
        public String eventMessage { get; set; }

        /// <summary>
        /// Severity of verbosity
        /// </summary>
        public EventVerbosity verbosityLevel { get; set; }

        /// <summary>
        /// Process ID for Event
        /// </summary>
        public int processID { get; set; }

        /// <summary>
        /// Application name for Event
        /// </summary>
        public String applicationName { get; set; }

        /// <summary>
        /// The basic eventType should it be system event logging
        /// </summary>
        public EventLogEntryType basicType { get; set; }

        /// <summary>
        /// Constructor for when there is no processID
        /// </summary>
        /// <param name="message">message of the event or error</param>
        /// <param name="verbosity"> verbosity level as enumerated</param>
        /// <param name="appName">application name</param>
        public Event(String message, EventVerbosity verbosity, String appName)
        {
            eventMessage = message;
            verbosityLevel = verbosity;
            processID = int.MinValue;
            applicationName = appName;
            switch (verbosity)
            {
                case EventVerbosity.DEBUG:
                case EventVerbosity.EVENT:
                case EventVerbosity.INFO:
                    basicType = EventLogEntryType.Information;
                    break;
                case EventVerbosity.WARN_LOW:
                case EventVerbosity.WARN_MID:
                case EventVerbosity.WARN_HIGH:
                    basicType = EventLogEntryType.Warning;
                    break;
                case EventVerbosity.ERROR:
                case EventVerbosity.FATAL:
                    basicType = EventLogEntryType.Error;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Constructor that uses application name
        /// </summary>
        /// <param name="message">The message of the event or error</param>
        /// <param name="verbosity">Verbosity level as enumerated</param>
        /// <param name="appName"> Appication name</param>
        /// <param name="processId"> Process ID</param>
        public Event(String message, EventVerbosity verbosity, String appName, int processId)
        {
            eventMessage = message;
            verbosityLevel = verbosity;
            processID = processId;
            applicationName = appName;
            switch(verbosity)
            {
                case EventVerbosity.DEBUG:
                case EventVerbosity.EVENT:
                case EventVerbosity.INFO:
                    basicType = EventLogEntryType.Information;
                    break;
                case EventVerbosity.WARN_LOW:
                case EventVerbosity.WARN_MID:
                case EventVerbosity.WARN_HIGH:
                    basicType = EventLogEntryType.Warning;
                    break;
                case EventVerbosity.ERROR:
                case EventVerbosity.FATAL:
                    basicType = EventLogEntryType.Error;
                    break;
                default:
                    break;
            }
        }
    }
}
