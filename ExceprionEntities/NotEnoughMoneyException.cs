using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionEntities
{
    public class NotEnoughMoneyException : Exception
    {
        public NotEnoughMoneyException() : base("Недостаточно средств на балансе карты")
        {
            
        }
    }
}
