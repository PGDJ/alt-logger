using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standard.Common.Logger
{
    /// <summary>
    /// Verbosity of Events for logging thresholds
    /// </summary>
    public enum EventVerbosityLevels
    {
        /// <summary>
        /// SHOW ALL OF THEM
        /// </summary>
        ALL = 0,

        /// <summary>
        /// DEBUG
        /// </summary>
        EVENT = 1,

        /// <summary>
        /// DEBUG LEVEL
        /// </summary>
        DEBUG = 2,

        /// <summary>
        /// INFO LEVEL
        /// </summary>
        INFO = 3,

        /// <summary>
        /// WARN_LOW
        /// </summary>
        WARN_LOW = 4,

        /// <summary>
        /// WARN_MID
        /// </summary>
        WARN_MID = 5,

        /// <summary>
        /// WARN_HIGH
        /// </summary>
        WARN_HIGH = 6,

        /// <summary>
        /// ERROR TRADITIONAL ERROR
        /// </summary>
        ERROR = 7,

        /// <summary>
        /// FATAL
        /// </summary>
        FATAL = 8,

        /// <summary>
        /// TURN THEM ALL OFF
        /// </summary>
        OFF = 9
    }

    public enum EventVerbosity
    {
        /// <summary>
        /// DEBUG
        /// </summary>
        EVENT = 1,

        /// <summary>
        /// DEBUG LEVEL
        /// </summary>
        DEBUG = 2,

        /// <summary>
        /// INFO LEVEL
        /// </summary>
        INFO = 3,

        /// <summary>
        /// WARN_LOW
        /// </summary>
        WARN_LOW = 4,

        /// <summary>
        /// WARN_MID
        /// </summary>
        WARN_MID = 5,

        /// <summary>
        /// WARN_HIGH
        /// </summary>
        WARN_HIGH = 6,

        /// <summary>
        /// ERROR TRADITIONAL ERROR
        /// </summary>
        ERROR = 7,

        /// <summary>
        /// FATAL
        /// </summary>
        FATAL = 8
    }
}
