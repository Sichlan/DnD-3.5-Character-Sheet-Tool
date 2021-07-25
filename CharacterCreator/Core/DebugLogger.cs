using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Core
{
    public static class DebugLogger
    {
        private static string logFilePath;

        private static void SetLogFilePath(string Path)
        {
            logFilePath = Path;
        }

        public static void SetupDebugLogger(bool test = false)
        {
            //Setting up the logger
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\DnDCharacterCreator\\Logs";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            DeleteOldLogs(folderPath);

            string logFilePath = folderPath + (test ? "\\Test" : "") + $"\\Log_{DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss_fff")}.log";
            File.CreateText(logFilePath).Dispose();
            SetLogFilePath(logFilePath);
            WriteLog("Starting up debug logger...", LogLevel.INFO);
        }

        /// <summary>
        /// Deletes all files older than 1 months with the ".log" extension from log folder
        /// </summary>
        /// <param name="folderPath"></param>
        private static void DeleteOldLogs(string folderPath)
        {
            Directory.GetFiles(folderPath).ToList().ForEach(x =>
            {
                FileInfo fi = new FileInfo(x);
                if (fi.LastAccessTime < DateTime.Now.AddMonths(-1) && x.EndsWith(".log"))
                    fi.Delete();
            });
        }

        public static void WriteLog(string message, LogLevel level )
        {
            using (StreamWriter writer = File.AppendText(logFilePath))
            {
                writer.WriteLine($"{DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss.fff")}\t[{level.ToString()}]:{(level.ToString().Length < 5 ? "\t" : "")}\t{message}");
            }
        }

        public enum LogLevel
        {
            FATAL,
            ERROR,
            WARNING,
            INFO,
            DEBUG,
            TRACE
        }
    }
}
