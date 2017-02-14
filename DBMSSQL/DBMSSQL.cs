using DBFactory;
using System.Collections.Generic;
using DBFactory.Structures;
using System.Linq;
using System;

namespace DBMSSQL
{
    public class DBMSSQL : IDBBase
    {
        MySqlContext context = new MySqlContext();

        public List<Recipe> GetRecipes(int Count)
        {
            return context.Recipe.Take(Count).ToList();
        }

        public List<Recipe> GetRecipesDecendingOrder(int Count)
        {
            return context.Recipe.OrderByDescending(p => p.ID).Take(Count).ToList();
        }

        public List<Recipe> GetRecipesPublishedDecendingOrder(int Count)
        {
            return context.Recipe.Where(p => p.Published == true).OrderByDescending(p => p.ID).Take(Count).ToList();
        }

        public Recipe GetRecipe(int ID)
        {
            return context.Recipe.Find(ID);
        }

        public List<Recipe> GetRecipesFromGroup(int groupId)
        {
            return context.Recipe.Where(p => p.GroupId == groupId).ToList();
        }

        public int SaveRecipe(Recipe Recipe)
        {
            // TODO: Temporary dirty hack for updating recipe.
            var current = GetRecipe(Recipe.ID);

            if (current != null)
            {
                current.Title = Recipe.Title;
                current.Published = Recipe.Published;
                current.GroupId = Recipe.GroupId;
                current.ShortDescription = Recipe.ShortDescription;
                current.FullDescription = Recipe.FullDescription;
                current.Difficulty = Recipe.Difficulty;
                current.PreparationTime = Recipe.PreparationTime;
                context.SaveChanges();
                return current.ID;
            }

            context.Recipe.Add(Recipe);
            context.SaveChanges();

            return Recipe.ID;
        }

        public void DeleteRecipe(int ID)
        {
            context.Recipe.Remove(GetRecipe(ID));
            context.SaveChanges();
        }

        public int SaveIngredient(Ingredient Ingredient)
        {
            context.Ingredient.Add(Ingredient);
            context.SaveChanges();
            return Ingredient.Id;
        }

        public List<Ingredient> GetIngredients(int Count)
        {
            return context.Ingredient.Take(Count).ToList();
        }

        public void DeleteIngredient(int Id)
        {
            var recipeIngredients = context.RecipeIngredient.Where(p => p.IngredientId == Id).ToList();

            foreach (var ingredient in recipeIngredients)
            {
                DeleteRecipeIngredient(ingredient.Id);
            }

            context.Ingredient.Remove(GetIngredient(Id));
            context.SaveChanges();
        }

        public Ingredient GetIngredient(int Id)
        {
            return context.Ingredient.Where(p => p.Id == Id).FirstOrDefault();
        }

        public Ingredient GetIngredient(string Name)
        {
            return context.Ingredient.Where(p => p.Name == Name).FirstOrDefault();
        }

        public int SaveGroup(Group Group)
        {
            context.Group.Add(Group);
            context.SaveChanges();

            return Group.Id;
        }

        public Group GetGroup(int Id)
        {
            return context.Group.Find(Id);
        }

        public List<Group> GetGroups(int Count)
        {
            return context.Group.Take(Count).ToList();
        }

        public void DeleteGroup(int Id)
        {
            context.Group.Remove(GetGroup(Id));
            context.SaveChanges();
        }

        public User SaveUser(User User)
        {
            context.Users.Add(User);
            context.SaveChanges();

            return User;
        }

        public User GetUser(string Username)
        {
            return context.Users.Where(x => x.Username == Username).FirstOrDefault();
        }

        public void DeleteUser(string Username)
        {
            context.Users.Remove(GetUser(Username));
        }

        public RecipeIngredient GetRecipeIngredient(int Id)
        {
            return context.RecipeIngredient.Where(p => p.Id == Id).FirstOrDefault();
        }

        public void DeleteRecipeIngredient(int Id)
        {
            context.RecipeIngredient.Remove(GetRecipeIngredient(Id));
            context.SaveChanges();
        }

        /* IDatabaseQuery implementations */
        public List<T> GetList<T>() where T : DBBaseItem
        {
            return context.DbSetBindings.GetBinding<T>().ToList();
        }

        public List<T> GetList<T>(int Count) where T : DBBaseItem
        {
            return context.DbSetBindings.GetBinding<T>().Take(Count).ToList();
        }

        public T Load<T>(int Id) where T : DBBaseItem
        {
            return context.DbSetBindings.GetBinding<T>().Find(Id);
        }

        public int Store<T>(T obj) where T : DBBaseItem
        {
            var set = context.DbSetBindings.GetBinding<T>();

            /* Update the object if it already exists */
            var previousObject = Load<T>(obj.Id);

            if (previousObject != null)
            {
                context.SaveChanges();
                return previousObject.Id;
            }

            set.Add(obj);
            context.SaveChanges();

            return obj.Id;
        }

        public List<int> Store<T>(List<T> list) where T : DBBaseItem
        {
            var set = context.DbSetBindings.GetBinding<T>();

            set.AddRange(list);
            context.SaveChanges();

            return list.Select(p => p.Id).ToList();
        }

        public void Delete<T>(int Id) where T : DBBaseItem
        {
            context.DbSetBindings.GetBinding<T>().Remove(Load<T>(Id));
            context.SaveChanges();
        }

        public void Delete<T>(T obj) where T : DBBaseItem
        {
            context.DbSetBindings.GetBinding<T>().Remove(obj);
            context.SaveChanges();
        }
    }
}
