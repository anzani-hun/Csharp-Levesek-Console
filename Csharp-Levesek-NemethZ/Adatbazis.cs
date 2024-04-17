using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

using MySqlConnector;       //mysqldata nuget

namespace Csharp_Levesek_NemethZ
{
    class Adatbazis
    {
        MySqlConnection connection = null;
        MySqlCommand sql = null;

        public Adatbazis()
        {
            string connectionString = "server=localhost;userid=root;password=;database=etelek";

            connection = new MySqlConnection(connectionString);
            connection.Open();

            sql = connection.CreateCommand();
            sql.CommandText = "SELECT * FROM levesek;";


        }


        public List<Levesek> LevesekBetoltese()       //lista a levesek betöltésésre
        {
            List<Levesek> levesek = new List<Levesek>();

            MySqlDataReader reader = sql.ExecuteReader();

            while (reader.Read())
            {
                Levesek leves = new Levesek(reader.GetString("megnevezes"), reader.GetInt32("kaloria"), reader.GetDecimal("feherje"), reader.GetDecimal("zsir"), reader.GetDecimal("szenhidrat"), reader.GetDecimal("hamu"), reader.GetDecimal("rost"));
                levesek.Add(leves);
            }
            return levesek;
        }



        public class Item
        {
            public int Id { get; set; }
            public string Megnevezes { get; set; }
        }


    }
}
