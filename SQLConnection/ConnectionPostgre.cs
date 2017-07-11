using System;
using System.Collections.Generic;
using System.Text;

namespace SQLConnection
{
    class ConnectionPostgre : Connection
    {
        public string ConnectionString
        {
            get
            {
                return String.Format("host=" + Host + ";username=" + Username + ";password=" + Password + ";database=" + Database);
                //Host=localhost;Username=postgres;Password=haslo;Database=Testy
            }
        }
    }
}
