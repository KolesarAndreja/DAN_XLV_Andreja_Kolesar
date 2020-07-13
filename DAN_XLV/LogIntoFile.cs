using System;
using System.IO;

namespace DAN_XLV
{
    class LogIntoFile
    {
        public string path { get; } = @"..\..\Log.txt";

        Publisher publisher = new Publisher();
        

        public LogIntoFile(string content)
        {
            publisher.onNotification += PrintActionIntoFile;
            publisher.Notify(content);
        }

        /// <summary>
        /// Print currrent action with current time into file
        /// </summary>
        /// <param name="content"></param>
        /// 
        public void PrintActionIntoFile(string content)
        {
            try
            {
                string currentDate = DateTime.Now.ToShortDateString();
                string currentTime = DateTime.Now.ToShortTimeString();
                content = currentDate + " " + currentTime + " " + content;
                //print to file
                StreamWriter str = new StreamWriter(path, true);
                str.WriteLine(content);
                str.Close();
            }
            catch (FileNotFoundException)
            {

            }
        }
    }
}
