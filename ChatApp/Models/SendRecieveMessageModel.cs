using System;

namespace ChatApp.Models
{
    public class SendRecieveMessageModel
    {
        public string TargetUserName { get; set; }
        public string Message { get; set; }
        public string DateTime { get; set; }
    }
}
