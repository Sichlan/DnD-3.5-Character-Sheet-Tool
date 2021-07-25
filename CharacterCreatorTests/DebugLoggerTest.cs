using CharacterCreator.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreatorTests
{
    [TestClass]
    public class DebugLoggerTest
    {
        [TestMethod]
        public void TestDebugLogger()
        {
            DebugLogger.SetupDebugLogger();

            DebugLogger.WriteLog("Starting test logging...", DebugLogger.LogLevel.INFO);

            foreach (var item in Enum.GetValues(typeof(DebugLogger.LogLevel)))
            {
                var logLevel = item as DebugLogger.LogLevel?;
                Trace.Assert(logLevel != null, "ERROR: logLevel is null");
                DebugLogger.WriteLog($"Current log level is {logLevel.ToString()}", logLevel.Value);
            }

            DebugLogger.WriteLog("Finished test logging.", DebugLogger.LogLevel.INFO);
        }
    }
}
