using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CookbookAPI.Models
{
    public class NoteRepository
    {
        private string connectionString;
        public NoteRepository()
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

        public void Add(Note note)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO Notes(NoteMessage, CreatedOn, ModifiedOn, RecipeId) VALUES(@NoteMessage, GETDATE(), GETDATE(), @RecipeId);";
                dbConnection.Open();
                dbConnection.Execute(sQuery, note);
            }
        }

        public IEnumerable<Note> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM Notes";
                dbConnection.Open();
                return dbConnection.Query<Note>(sQuery);
            }
        }
    }
}
