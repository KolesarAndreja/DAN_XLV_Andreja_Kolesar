using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLV
{
    class Publisher
    {
        public string path { get; } = @"..\..\Log.txt";
  
        //delegate and event based on that delegate
        public delegate void Notification(string content);
        public event Notification onNotification;


        //raising event 
        public void Notify(string content)
        {
            onNotification?.Invoke(content);
        }

        /// <summary>
        /// Print currrent action with current time into file
        /// </summary>
        /// <param name="content"></param>
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
