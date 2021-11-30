using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationEntities
{
    public class Response
    {
        public enum StatusList
        {
            OK,
            ERROR
        }
        
        public StatusList Status { get; set; }
        public string Data { get; set; }
    }
}
