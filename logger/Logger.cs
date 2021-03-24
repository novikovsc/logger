using System;
using System.Collections.Generic;
using System.IO;

namespace logger
{
    public class Logger : ILog
    {
        private string path;
        private void CreateDir()
        {
            path = @"D:\logger\" + DateTime.Now.ToShortDateString();
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
        }
        public void Fatal(string message)
        {
            CreateDir();
            using (StreamWriter sw = new StreamWriter(path + "\\" + "fatal.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString() + " " + message);
            }
        }

        public void Fatal(string message, Exception e)
        {
            CreateDir();
            using (StreamWriter sw = new StreamWriter(path + "\\" + "fatal.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString() + " " + message + e.Message);
            }
        }

        public void Error(string message)
        {
            CreateDir();
            using (StreamWriter sw = new StreamWriter(path + "\\" + "error.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString() + " " + message);
            }
        }

        public void Error(Exception ex)
        {
            CreateDir();
            using (StreamWriter sw = new StreamWriter(path + "\\" + "error.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString() + " " + ex.Message);
            }
        }

        public void Error(string message, Exception e)
        {
            CreateDir();
            using (StreamWriter sw = new StreamWriter(path + "\\" + "error.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString() + " " + message + e.Message);
            }
        }

        public void ErrorUnique(string message, Exception e)
        {
            CreateDir();
            bool check_unique = false;
            using (StreamReader sr = new StreamReader(path + @"\" + "error.txt"))
            {
                string read = sr.ReadToEnd();
                if (!read.Contains(e.Message))
                {
                    check_unique = true;
                }
            }

            if (check_unique)
            {
                using (StreamWriter sw = new StreamWriter(path + "\\" + "error.txt", true))
                {
                    sw.WriteLine(DateTime.Now.ToString() + " " + message + " " + e.Message);
                }
            }
        }

        public void Warning(string message)
        {
            CreateDir();
            using (StreamWriter sw = new StreamWriter(path + "\\" + "warning.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString() + " " + message);
            }
        }

        public void Warning(string message, Exception e)
        {
            CreateDir();
            using (StreamWriter sw = new StreamWriter(path + "\\" + "warning.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString() + " " + message + " " + e.Message);
            }
        }

        public void WarningUnique(string message)
        {
            CreateDir();
            bool check_unique = false;
            using (StreamReader sr = new StreamReader(path + "\\" + "warning.txt"))
            {
                string read = sr.ReadToEnd();
                if (!read.Contains(message))
                {
                    check_unique = true;
                }
            }

            if (check_unique)
            {
                using (StreamWriter sw = new StreamWriter(path + "\\" + "warning.txt", true))
                {
                    sw.WriteLine(DateTime.Now.ToString() + " " + message);
                }
            }
        }

        public void Info(string message)
        {
            CreateDir();
            using (StreamWriter sw = new StreamWriter(path + "\\" + "info.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString() + " " + message);
            }
        }

        public void Info(string message, Exception e)
        {
            CreateDir();
            using (StreamWriter sw = new StreamWriter(path + "\\" + "info.txt", true))      
            {
                sw.WriteLine(DateTime.Now.ToString() + " " + message + " " + e.Message);
            }
        }

        public void Info(string message, params object[] args)
        {    
            CreateDir();
            using (StreamWriter sw = new StreamWriter(path + "\\" + "info.txt", true))
            {
                sw.Write(DateTime.Now.ToString() + " " + message + " ");
                foreach (var arg in args)
                {
                    sw.Write(arg + " ");
                }
                sw.WriteLine();
            }
        }

        public void Debug(string message)
        {
            CreateDir();
            using (StreamWriter sw = new StreamWriter(path + "\\" + "debug.txt", true))      
            {
                sw.WriteLine(DateTime.Now.ToString() + " " + message);
            }
        }

        public void Debug(string message, Exception e)
        {
            CreateDir();
            using (StreamWriter sw = new StreamWriter(path + "\\" + "debug.txt", true))      
            {
                sw.WriteLine(DateTime.Now.ToString() + " " + message + " " + e.Message);
            }
        }

        public void DebugFormat(string message, params object[] args)
        {
            CreateDir();
            using (StreamWriter sw = new StreamWriter(path + "\\" + "debugformat.txt", true))
            {
                sw.Write(DateTime.Now.ToString() + " " + message + " ");
                foreach (var arg in args)
                {
                    sw.Write(arg + " ");
                }
                sw.WriteLine();
            }
        }

        public void SystemInfo(string message, Dictionary<object, object> properties = null)
        {
            CreateDir();
            using (StreamWriter sw = new StreamWriter(path + "\\" + "systeminfo.txt", true))
            {
                sw.Write(DateTime.Now.ToString() + " " + message + " ");
                if (properties != null)
                {
                    foreach (KeyValuePair<object,object> proper in properties)
                    {
                        sw.Write(proper + " ");
                    }
                }
                sw.WriteLine();
            }
        }
    }
}