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

    }
}
