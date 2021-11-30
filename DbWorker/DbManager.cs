using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbWorker.Tables;

namespace DbWorker
{
    public class DbManager
    {
        private static DbManager instance = null;

        public static DbManager GetInstance()
        {
            if (instance == null)
            {
                instance = new DbManager();
            }

            return instance;
        }

        public TableCards TableCards { get; private set; }
        public TableUsers TableUsers { get; private set; }

        private DbManager()
        {
            TableCards = new TableCards();
            TableUsers = new TableUsers();
        }

    }
}
