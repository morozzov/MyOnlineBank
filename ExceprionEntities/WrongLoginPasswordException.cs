using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionEntities
{
    public class WrongLoginPasswordException : Exception
    {
        public WrongLoginPasswordException() : base("Неверный логин или пароль")
        {

        }
    }
}
