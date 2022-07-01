using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class SendRecieveMessageViewModel
    {
        public string TargetUserName { get; set; }
        public string Message { get; set; }
        public string DateTime { get; set; }
    }
}
