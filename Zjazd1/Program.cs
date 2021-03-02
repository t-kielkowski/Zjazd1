using System;
using System.Data;
using System.Data.SqlClient;


namespace Crud
{
    class Program
    {
        static void Main(string[] args)
        {
            var conncectionstring =
                "Data Source = PC-DOM; Initial Catalog = ZNorthwind; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

            using SqlConnection connection = new SqlConnection(conncectionstring);

            connection.Open();

            var query = "Select * FROM Pracownicy";
            using var read = new SqlCommand(query, connection);
            using var reader = read.ExecuteReader();

            Console.WriteLine("Lista pracowników");
            Console.WriteLine();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Nazwisko"]} {reader["Imię"]}");
            }

            Console.WriteLine();
            Console.WriteLine("Dodaj nowego pracownika\nPodaj nazwisko nowego pracownika");
            var secondName = Console.ReadLine();
            Console.WriteLine("Podaj imie nowego pracownika");
            var name = Console.ReadLine();


            using var create =
                new SqlCommand("insert into Pracownicy(IDpracownika, Nazwisko, Imię) values (@id, @nazwisko, @imie)",
                    connection);
            create.Parameters.AddRange(new[]
            {
                new SqlParameter("id", SqlDbType.Int)
                {
                    Value = 10
                },
                new SqlParameter("nazwisko", SqlDbType.VarChar)
                {
                    Value = secondName
                },
                new SqlParameter("imie", SqlDbType.VarChar)
                {
                    Value = name
                }
            });

            var result = create.ExecuteNonQuery();
            Console.WriteLine(result);

            Console.WriteLine($"\nUzupełnienie stanowiska pracownika {secondName} {name}");

            using var update = new SqlCommand("update Pracownicy set Stanowisko=@stanowisko where IDpracownika=@id",
                connection);
            update.Parameters.AddWithValue("stanowisko", "Szef wszystkich szefów");
            update.Parameters.AddWithValue("id", 14);

            result = update.ExecuteNonQuery();
            Console.WriteLine(result);

            Console.WriteLine($"\nUsunięcie z listy ostatnio dodanego pracownika");

            using var delete = new SqlCommand("delete from Pracownicy where IDpracownika=@id",
                connection);
            delete.Parameters.AddWithValue("id", 10);
            
            result = delete.ExecuteNonQuery();
            Console.WriteLine(result);

            connection.Close();
            
        }
    }
}