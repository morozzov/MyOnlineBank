﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationEntities
{
    public class Request
    {
        public string Command { get; set; }
        public string Parameters { get; set; }
        public string APIKey { get; set; }
    }
}
