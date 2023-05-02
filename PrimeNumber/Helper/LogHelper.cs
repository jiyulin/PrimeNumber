using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace PrimeNumber.Helper
{
    public class LogHelper
    {
        static string assemblyDirPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <returns></returns>
        public static bool CreateFolder(string path)
        {
            //try
            //{

            //目录已存在等同于创建成功处理
            if (Directory.Exists(path.Trim('\\')))
            {
                return true;
            }
            else
            {
                //创建文件夹
                DirectoryInfo dirInfo = Directory.CreateDirectory(path);
                return true;
            }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    return false;
            //}
        }

        /// <summary>
        ///  //创建文件
        /// </summary>
        /// <param name="path">path 文件路径</param>
        public static void CreateFile(string path)
        {
            //try
            //{
            if (CreateFolder(path.Substring(0, path.LastIndexOf("\\"))))
            {
                if (!File.Exists(path))
                {
                    FileStream fs = File.Create(path);
                    fs.Close();
                }
            }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    return;
            //}
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path"></param>
        public void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="content">文本内容</param>
        public static void WriteFile(string path, string content)
        {
            try
            {
                if (!File.Exists(path))
                    CreateFile(path);

                using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(content);
                    sw.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        /// <summary>
        /// 将即时日志保存入日志文件（asp.net WebForm）
        /// </summary>
        //public static void WriteAppDataLog(string content)
        //{
        //    //string assemblyDirPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //    string assemblyDirPath = HttpRuntime.AppDomainAppPath.ToString();

        //    string logPath = assemblyDirPath + "\\App_Data\\Log";
        //    string logName = string.Format("Log_{0}.txt", DateTime.Now.ToString("yyyyMMdd"));
        //    content = DateTime.Now.ToString("HH:mm:ss.ffffff") + " ,  " + content;
        //    WriteLogFile(logPath, content, logName);
        //}

        /// <summary>
        /// 将即时日志保存入日志文件（bin目录下创建Log文件夹，按天生成日志文件）
        /// </summary>
        public static void WriteBinLog(string content, string forder = "Log", string fileName = "", bool autoTime = true, bool autoTimeFileName = true)
        {
            try
            {
                //string assemblyDirPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                //string assemblyDirPath = HttpRuntime.AppDomainAppPath.ToString();
                string logPath = assemblyDirPath;
                string logName = string.Format("{0}.txt", fileName);

                if (!string.IsNullOrEmpty(forder))
                    logPath = Path.Combine(assemblyDirPath, forder);

                if (string.IsNullOrEmpty(fileName))
                    fileName = forder;
                if (string.IsNullOrEmpty(fileName))
                    autoTimeFileName = true;
                if (autoTimeFileName)
                    logName = string.Format("{0}_{1}.txt", fileName, DateTime.Now.ToString("yyyyMMdd"));

                if (autoTime)
                    content = string.Format("{0}，{1}", DateTime.Now.ToString("HH:mm:ss.ffffff"), content);

                WriteLogFile(logPath, content, logName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //故意吞噬异常
            }
        }

        private static object objLock = "";
        /// <summary>
        /// 将即时日志保存入日志文件
        /// </summary>
        public static void WriteLogFile(string directoryPath, string content, string fileName)
        {
            //写入新的文件
            string filePath = "";
            if (directoryPath.Trim().Trim('/').Trim('\\') == "")
            {
                filePath = fileName;
            }
            else
            {
                if (!Directory.Exists(directoryPath))
                    CreateFolder(directoryPath);
                filePath = directoryPath + "\\" + fileName;
            }
            lock (objLock)
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(content);
                    //sw.Flush();
                    sw.Close();
                    fs.Close();
                }
            }
        }

        #region 控制台输出日志
        static object cwLock = new object();
        public static void WriteLine(string msg, object arg0, object arg1, object arg2)
        {
            string tips = string.Format(msg, arg0, arg1, arg2);
            WriteLine(tips);
        }
        public static void WriteLine(string msg, object arg0, object arg1)
        {
            string tips = string.Format(msg, arg0, arg1);
            WriteLine(tips);
        }
        public static void WriteLine(string msg, object arg0)
        {
            string tips = string.Format(msg, arg0);
            WriteLine(tips);
        }
        public static void WriteLine(string msg, ConsoleColor color = ConsoleColor.Gray, bool prefixTime = true)
        {
            try
            {
                //关闭控制台显示时候，Console已释放，可能会调用到 Console.WriteLine，所以要吞噬异常
                //if (color != ConsoleColor.Gray)
                //{
                lock (cwLock)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine("{0}, {1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fffffff"), msg);
                    Console.ResetColor();
                }
                //}
                //else
                //{
                //    Console.WriteLine("{0}, {1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fffffff"), msg);
                //}
            }
            catch (Exception)
            {
            }
        }
        #endregion

    }
}
