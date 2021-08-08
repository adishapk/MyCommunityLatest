using System;
using System.IO;

namespace THOUGHTBOX.DOMAIN.Domain
{
    public class Log
    {
        public void LogError(string ex)
        {
            string message = "-------------------------------------------------------------" + DateTime.Now.ToString() + "--------------------------------------------------------------------";
            message = message + Environment.NewLine + ex;
            using (StreamWriter writer = System.IO.File.AppendText("log.txt"))
            {
                writer.WriteLine(message);
            }

        }
    }
}
