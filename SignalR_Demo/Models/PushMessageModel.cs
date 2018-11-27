using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR_Demo.Models
{
    [Serializable]
    public class PushMessageModel
    {
        public int Id { get; set; }
        public string MSG_TITLE { get; set; }
        public string MSG_CONTENT { get; set; }
    }
}