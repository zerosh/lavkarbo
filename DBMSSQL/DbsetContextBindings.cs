using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DBMSSQL
{
    public class DbsetContextBindings
    {
        public void AddBinding<T>(DbSet<T> dbset) where T : class
        {
            Bindings[typeof(T)] = dbset;
        }

        public DbSet<T> GetBinding<T>() where T : class
        {
            return Bindings[typeof(T)].Cast<T>();
        }

        private Dictionary<Type, DbSet> Bindings = new Dictionary<Type, DbSet>();
    }
}
