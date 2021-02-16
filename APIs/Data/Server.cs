using System;
using System.Collections.Generic;

namespace APIs.Data
{
    public partial class Server
    {
        public int ServerId { get; set; }
        public string Name { get; set; }
        public bool? IsOnline { get; set; }
    }
}
