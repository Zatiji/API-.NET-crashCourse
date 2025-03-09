using System.Data;
using Dapper;
using IntermediateCSharpCourse.Data;
using IntermediateCSharpCourse.Models;
using Microsoft.Data.SqlClient;

namespace IntermediateCSharpCourse
{

    internal class Program
    {
        static void Main(string[] arg)
        {

            DataContextDapper dapper = new DataContextDapper();
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
        }
    }
}

