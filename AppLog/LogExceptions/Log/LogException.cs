using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogExceptions.Log
{
    public class LogException
    {
        public static void Save(object obj, Exception e, string pathFile)
        {
            string fecha = DateTime.Now.ToString("yyyyMMdd");
            string hora = DateTime.Now.ToString("HH:mm:ss");
            string path = pathFile;

            StreamWriter sw = new StreamWriter(path, true);

            StackTrace stackTrace = new StackTrace();
            sw.WriteLine(obj.GetType().FullName + " " + hora);
            sw.WriteLine(stackTrace.GetFrame(1).GetMethod().Name + " - " + e.Message);
            sw.WriteLine(e.InnerException);
            sw.WriteLine("");

            sw.Flush();
            sw.Close();
        }
    }
}
