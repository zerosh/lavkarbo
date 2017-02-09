namespace DBMSSQL
{
    using DBFactory.Structures;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MySqlContext : DbContext
    {
        public MySqlContext()
            : base("name=SQL")
        {
        }

        public virtual DbSet<Recipe> Recipe { get; set; }
    }
}