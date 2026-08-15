using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using static Star_Simulation.Program;

namespace Star_Simulation
{
    internal partial class Libary
    {
        private static readonly object ConsoleLogWriteLock = new object();
        public static void ConsoleLogWrite(string message = "")
        {
            lock (ConsoleLogWriteLock)
            {
                ConsoleLog(message);
                LogWrite(message);
            }
        }
        public static void ConsoleLogWrite(string[] message) { ConsoleLogWrite(string.Join('\n', message)); }

        private static readonly object ConsoleLogLock = new object();
        public static void ConsoleLog(string message = "")
        {
            lock (ConsoleLogLock)
            {
                string[] message2 = message.Split("\n");
                foreach (string m in message2)
                {
                    string DT = System.DateTime.Now.ToString("dd.MM.yy, HH:mm:ss.ff");
                    string actstring = (m != null ? $"[{DT}] {m}\n" : "\n");
                    Console.Write(actstring);
                }
            }
        }
        public static void ConsoleLog(string[] message) { ConsoleLog(string.Join('\n', message)); }

        /*
         * I Learned this week(02.07.2026) that Logging to a File is really bad for Performance, and not the Easy way.
         * 
         * So now i moved the Logging-Functions to a new File, and made(with some Help from Gemini and
         * GitHub Copilot) a separate Thread, to Handle all Writing.
         * I also learned about ConcurrentQueue() and ich Love it, it is such a Useful Function.
         * 
         * At first I tried to just Manually removing each Log from a List<LogStruct> and this was of course
         * a problem. So i asked Gemini for Help, and after a Quick "Research" he Explained me the Problem why
         * File.AppendAllText Bad for Performance was etc. so with this new code it will only log every 50ms
         * and it will do it in a Separate Thread.
         * The Performance got Way better from aa VERY VERY Inconsistent 1 Second(No joke, sometimes it will
         * write the same stuff in <50ms and sometimes like 1.5s) to just 0.2ms (Every System has a Different
         * Time).
         * 
         * I don't know if this is a Hardware Thing, but i solved it, so it is time to forget what i
         * was coding here for another 30 Days just to come pack and not Understanding what this all is.
         */

        private static readonly object LogWriteLock = new object();
        public struct LogStruct { public string path; public string message; public bool raw; public bool overwriteOriginal; }
        public static ConcurrentQueue<LogStruct> LogValues { get; private set; } = new ConcurrentQueue<LogStruct>();
        private static Thread LogWriteThread = new(() =>
        {
            if (!Directory.Exists(LogFolderName)) Directory.CreateDirectory(LogFolderName);
            while (RUNNING || LogValues.Count > 0)
            {
                // Code from GitHub Copilot
                if (LogValues.TryDequeue(out LogStruct e))
                {
                    try
                    {
                        string file = e.path ?? $"{LogFolderName}/{LogFileName}";
                        string message = e.message ?? string.Empty;

                        if (string.IsNullOrEmpty(file)) file = LogFileName;

                        string? finalDir = Path.GetDirectoryName(file);
                        if (!string.IsNullOrEmpty(finalDir))
                        {
                            Directory.CreateDirectory(finalDir);
                        }

                        if (!e.raw)
                        {
                            string[] message2 = message.Split('\n');
                            foreach (string m in message2)
                            {
                                string DT = System.DateTime.Now.ToString("dd.MM.yy, HH:mm:ss.ff");
                                string actstring = (m != null ? $"[{DT}] {m}\n" : "\n");
                                File.AppendAllText(file, actstring);
                            }
                        }
                        else
                        {
                            if (File.Exists(file) && e.overwriteOriginal) { File.Delete(file); }

                            File.AppendAllText(file, message);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"LogWrite thread error: {ex.Message}");
                        throw;
                    }
                }
                else
                {
                    Thread.Sleep(1);
                }
            }
        });

        public static void LogWrite(string message = "", string file = null!, bool raw = false, bool overwrite = false)
        {
            if (RUNNING && !LogWriteThread.IsAlive) LogWriteThread.Start();
            if (RUNNING) LogValues.Enqueue(new LogStruct { message = message, path = file, raw = raw, overwriteOriginal = overwrite });
        }
        //public static void LogWrite(string message = "", string file = null!)
        //{
        //    lock (LogWriteLock)
        //    {
        //        if (string.IsNullOrEmpty(file)) file = LogFileName;

        //        string[] dir = file.Split("/");
        //        string finalDir = "";
        //        for (int i = 0; i < dir.Length - 1; i++)
        //        {
        //            finalDir += dir[i] + "/";
        //        }
        //        Directory.CreateDirectory(finalDir);

        //        string[] message2 = message.Split("\n");
        //        foreach (string m in message2)
        //        {
        //            string DT = System.DateTime.Now.ToString("dd.MM.yy, HH:mm:ss.ff");
        //            string actstring = (m != null ? $"[{DT}] {m}\n" : "\n");
        //            File.AppendAllText(file, actstring);
        //        }
        //    }
        //}
        public static void LogWrite(string[] message) { LogWrite(string.Join('\n', message)); }

        public static void LogWriteStart() { if (RUNNING && !LogWriteThread.IsAlive) LogWriteThread.Start(); if (!Directory.Exists(LogFolderName)) Directory.CreateDirectory(LogFolderName); }
    }
}
