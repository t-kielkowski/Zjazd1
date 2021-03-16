using System;
using System.Data;
using System.Data.SqlClient;


namespace Crud
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new DateBase(
                "Data Source = PC-DOM; Initial Catalog = ZNorthwind; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");

            db.connection.Open();

            var wyświetl = "Select * FROM Pracownicy";

            //db.GetPracownicy(wyświetl);
            //Console.WriteLine(db.AddPracownicy());
            //Console.WriteLine(db.UpdatePracownicy());
            //Console.WriteLine(db.DeletePracownicy());
            
            db.connection.Close();
        }
    }
}