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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MySqlContext>());
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Recipe> Recipe { get; set; }
        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<Group> Group { get; set; }
    }
}