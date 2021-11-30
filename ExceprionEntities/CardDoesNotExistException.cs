using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionEntities
{
    public class CardDoesNotExistException : Exception
    {
        public CardDoesNotExistException() : base("Карты с таким номером не существует")
        {

        }
    }
}
