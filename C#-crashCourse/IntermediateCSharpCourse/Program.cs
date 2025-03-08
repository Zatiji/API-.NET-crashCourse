using System.Data;
using Dapper;
using IntermediateCSharpCourse.Models;
using Microsoft.Data.SqlClient;

namespace IntermediateCSharpCourse {

    internal class Program {
        static void Main(string[] arg) {

            string connectionString = "Server=localhost;" + // connection for mac and linux
                                    "Database=DotNetCourseDatabase;" + 
                                    "TrustServerCertificate=true;" +
                                    "Trusted_Connection=false;" +
                                    "User Id=sa;" + 
                                    "Password=Ceron500!;";
            IDbConnection dbConnection = new SqlConnection(connectionString);

            string sqlCommand = "SELECT GETDATE()";
            DateTime rightNow = dbConnection.QuerySingle<DateTime>(sqlCommand); // to run a query
            Console.WriteLine(rightNow);

            Computer myComputer = new Computer() { // anonymous constructor
                Motherboard = "Z690",
                HasLTE = false,
                HasWifi = true,
                ReleaseDate = DateTime.Now,
                Price = 948.87m,
                VideoCard = "RTX 2060"
            };

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

            Console.WriteLine(sql);
            
            int result = dbConnection.Execute(sql); //result is an int because it tells us how many lines were affected

            Console.WriteLine(result);

            string sqlSelect = @"
            SELECT  
                Computer.Motherboard,
                Computer.HasWifi,
                Computer.HasLTE,
                Computer.ReleaseDate,
                Computer.Price,
                Computer.VideoCard
            FROM TutorialAppSchema.Computer";

            IEnumerable<Computer> computers = dbConnection.Query<Computer>(sqlSelect); //If we want to return a list, we nee to add '.toList()' at the end of the line
            
            Console.WriteLine("'MotherBoard', 'HasWifi', 'HasLTE', 'ReleaseDate', 'Price', 'VideoCard'");
            foreach (Computer singleComputer in computers) {
                Console.WriteLine("'" + myComputer.Motherboard 
                    + "','" + myComputer.HasWifi
                    + "','" + myComputer.HasLTE
                    + "','" + myComputer.ReleaseDate.ToString("yyyy-MM-dd") // pour que le serveur puisse lire la variable
                    + "','" + myComputer.Price
                    + "','" + myComputer.VideoCard
            + "'");
            }
        }
    }
}
