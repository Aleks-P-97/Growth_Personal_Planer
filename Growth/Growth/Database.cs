using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO; //Needed for files
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Growth
{
    class Database
    {
        public SQLiteConnection connection = new SQLiteConnection();
    }
}
