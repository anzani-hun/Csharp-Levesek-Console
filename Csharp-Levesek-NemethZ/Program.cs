using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySqlConnector;       //mysqldata nuget




namespace Csharp_Levesek_NemethZ
{
    internal class Program
    {
        //kívűl kell meghívni
        static Adatbazis db = new Adatbazis();
        static List<Levesek> levesek = db.LevesekBetoltese();


        static void Main(string[] args)
        {

            //1. feladat:
            Console.WriteLine("001. kérdés: Az adattáblában hány leves szerepel? ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Az adatbázisban [{levesek.Count} db] leves szerepel.\n\n");



            //2. feladat:
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("002. kérdés: Melyik levesben van a legtöbb kalória? ");

            int legtobbKaloria = 0;
            foreach (Levesek item in levesek)
            {
                if (item.Kaloria > legtobbKaloria)
                {
                    legtobbKaloria = item.Kaloria;
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"A legtöbb kalória {legtobbKaloria}.\n\n");



            //3. feladat:
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("003. kérdés: Írasd ki azokat a leveseket, amelyek nevében nem szerepel a leves szó! ");
            foreach (Levesek item in levesek)
            {
                if (!item.Megnevezes.Contains("leves"))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{item.Megnevezes}");
                }
            }




            Console.ReadKey();
        }

}
}
