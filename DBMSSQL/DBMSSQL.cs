﻿using DBFactory;
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

        public List<Ingredient> GetIngredients(int RecipeId, int Count)
        {
            var data = from d in context.Ingredient where d.RecipeId == RecipeId select d;
            return data.Take(Count).ToList();
        }

        public void DeleteIngredient(int Id)
        {
            throw new NotImplementedException();
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
    }
}
