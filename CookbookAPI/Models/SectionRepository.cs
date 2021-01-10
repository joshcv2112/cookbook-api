using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CookbookAPI.Models
{
    public class SectionRepository
    {
        private string connectionString;
        public SectionRepository()
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

        public void Add(Section section)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO Sections(SectionName, CookbookId) VALUES(@SectionName, @CookbookId);";
                dbConnection.Open();
                dbConnection.Execute(sQuery, section);
            }
        }

        public IEnumerable<Section> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM Sections";
                dbConnection.Open();
                return dbConnection.Query<Section>(sQuery);
            }
        }
        public Section GetById(int sectionId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM Sections WHERE SectionId=@SectionId";
                dbConnection.Open();
                return dbConnection.Query<Section>(sQuery, new { SectionId = sectionId }).FirstOrDefault();
            }
        }

        public void Delete(int sectionId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE FROM Sections WHERE SectionId=@SectionId";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { SectionId = sectionId });
            }
        }

        public void Update(Section prod)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE Sections SET SectionName=@SectionName, CookbookId=@CookbookId WHERE SectionID=@SectionID;";
                dbConnection.Open();
                dbConnection.Query(sQuery, prod);
            }
        }
    }
}
