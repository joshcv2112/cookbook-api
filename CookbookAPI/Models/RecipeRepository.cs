using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CookbookAPI.Models
{
    public class RecipeRepository
    {
        private string connectionString;
        public RecipeRepository()
        {
            connectionString = @"Persist Security Info=False;User ID=CookbookAPI;Password=password;Server=LAPTOP-3R0QQVMN;Initial Catalog=CookbookDB;";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public void Add(Recipe rcp)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO Recipes(Title, Ingredients, Instructions, [Description], Source, Rating, PrepTime, ImageURL, SectionId, CookbookId) VALUES(@Title, @Ingredients, @Instructions, @Description, @Source, @Rating, @PrepTime, @ImageURL, @SectionId, @CookbookId);";
                dbConnection.Open();
                dbConnection.Execute(sQuery, rcp);
            }
        }

        public IEnumerable<Recipe> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM Recipes";
                dbConnection.Open();
                return dbConnection.Query<Recipe>(sQuery);
            }
        }

        public Recipe GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM Recipes WHERE Id=@Id";
                dbConnection.Open();
                return dbConnection.Query<Recipe>(sQuery, new { RecipeId = id }).FirstOrDefault();
            }
        }

        public IEnumerable<Recipe> GetAllFromSection(int sectionId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM Recipes WHERE SectionId=@SectionId";
                dbConnection.Open();
                return dbConnection.Query<Recipe>(sQuery, new { SectionId = sectionId });
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE FROM Recipes WHERE Id=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { RecipeId = id });
            }
        }

        public void Update(Recipe prod)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE Recipes SET Title=@Title, Ingredients=@Ingredients, Instructions=@Instructions, [Description]=@Description, Source=@Source, Rating=@Rating, PrepTime=@PrepTime, ImageURL=@ImageURL, SectionId=@SectionId, CookbookId=@CookbookId WHERE RecipeID=@RecipeID;";
                dbConnection.Open();
                dbConnection.Query(sQuery, prod);
            }
        }
    }
}
