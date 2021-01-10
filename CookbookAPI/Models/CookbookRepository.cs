using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CookbookAPI.Models
{
    public class CookbookRepository
    {
        private string connectionString;
        public CookbookRepository()
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

        public void Add(Cookbook cookbook)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO Cookbooks(CookbookName, UserId, CreatedOn, ModifiedOn) VALUES(@CookbookName, @UserId, GETDATE(), GETDATE());";
                dbConnection.Open();
                dbConnection.Execute(sQuery, cookbook);
            }
        }

        public IEnumerable<Cookbook> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM Cookbooks";
                dbConnection.Open();
                return dbConnection.Query<Cookbook>(sQuery);
            }
        }

        public Cookbook GetById(int cookbookId)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM Cookbooks WHERE CookbookId=@CookbookId";
                dbConnection.Open();
                return dbConnection.Query<Cookbook>(sQuery, new { CookbookId = cookbookId }).FirstOrDefault();
            }
        }

        public void Delete(int cookbookId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE FROM Cookbooks WHERE CookbookId=@CookbookId";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { CookbookId = cookbookId });
            }
        }

        public void Update(Cookbook cookbook)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE Cookbooks SET CookbookName=@CookbookName, UserId=@UserId, ModifiedOn=GETDATE() WHERE CookbookId=@CookbookId;";
                dbConnection.Open();
                dbConnection.Query(sQuery, cookbook);
            }
        }
    }
}
