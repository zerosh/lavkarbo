using DBFactory;
using DBRavenImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewTestFramework.App_Start
{
    public class DatabaseConfig
    {
        public static void InstanciateDB()
        { 
            DB.Instance = DBFactory<DBMSSQL.DBMSSQL>.CreateDB();
        }
    }
}