using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionEntities
{
    public class WrongAPIKeyException : Exception
    {
        public WrongAPIKeyException() : base("Неверный API Key, но ты не расстраивайся, попробуй другой)")
        {

        }
    }
}
