namespace DBMSSQL
{
    using DBFactory.Structures;
    using System.Data.Entity;
    using DBFactory;

    public class MySqlContext : DbContext
    {
        public DbsetContextBindings DbSetBindings { get; private set; }

        public MySqlContext()
            : base("name=SQL")
        {
            DbSetBindings = new DbsetContextBindings();
            DbSetBindings.AddBinding(DUser);
            //DbSetBindings.AddBinding(Recipe);
            //DbSetBindings.AddBinding(Users);
            //DbSetBindings.AddBinding(Ingredient);
            //DbSetBindings.AddBinding(Group);
            //DbSetBindings.AddBinding(RecipeIngredient);
        }

        // binding test.
        public virtual DbSet<DUser> DUser { get; set; }
        public virtual DbSet<Recipe> Recipe { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<RecipeIngredient> RecipeIngredient { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MySqlContext>());

            base.OnModelCreating(modelBuilder);
        }
    }
}