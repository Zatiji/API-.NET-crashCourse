using System.Data;
using Dapper;
using IntermediateCSharpCourse.Data;
using IntermediateCSharpCourse.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Design;

namespace IntermediateCSharpCourse
{

    internal class Program
    {
        static void Main(string[] arg)
        {

            DataContextDapper dapper = new DataContextDapper();
            DataContextEF entityFramework = new DataContextEF();

            DateTime rightNow = dapper.loadDataSingle<DateTime>("SELECT GETDATE()");

            Computer myComputer = new Computer()
            { // anonymous constructor
                Motherboard = "Z690",
                HasLTE = false,
                HasWifi = true,
                ReleaseDate = DateTime.Now,
                Price = 948.87m,
                VideoCard = "RTX 2060"
            }; 

            entityFramework.Add(myComputer);
            entityFramework.SaveChanges(); // The two lines do the same thing that the sql query and command just below (done by dapper)

            string sql = @"INSERT INTO TutorialAppSchema.Computer (
                Motherboard,
                HasWifi,
                HasLTE,
                ReleaseDate,
                Price,
                VideoCard
            ) VALUES (' " + myComputer.Motherboard
                    + "','" + myComputer.HasWifi
                    + "','" + myComputer.HasLTE
                    + "','" + myComputer.ReleaseDate.ToString("yyyy-MM-dd") // pour que le serveur puisse lire la variable
                    + "','" + myComputer.Price
                    + "','" + myComputer.VideoCard
            + " ')";

            bool result = dapper.ExecuteSql(sql); //result is an int because it tells us how many lines were affected

            string sqlSelect = @"
            SELECT  
                Computer.Motherboard,
                Computer.HasWifi,
                Computer.HasLTE,
                Computer.ReleaseDate,
                Computer.Price,
                Computer.VideoCard
            FROM TutorialAppSchema.Computer";

            IEnumerable<Computer>? computersEF = entityFramework.Computer.ToList<Computer>(); // to list objects with entity framework
        }
    }
}

