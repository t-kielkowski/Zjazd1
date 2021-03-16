using System;
using System.Data;
using System.Data.SqlClient;

namespace Crud
{
    public class DateBase
    {
        public SqlConnection connection;

        public DateBase(string connectionString)
        {
            connection = new SqlConnection(connectionString);

        }
        
        
        public void GetPracownicy(string query)
        {
            using var read = new SqlCommand(query, connection);
            using var reader = read.ExecuteReader();

            Console.WriteLine("Lista pracowników");
            Console.WriteLine();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Nazwisko"]} {reader["Imię"]}");
            }
        }

        public int AddPracownicy()
        {
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
            
            return create.ExecuteNonQuery();
        }

        public int UpdatePracownicy()
        {
            Console.WriteLine($"\nUzupełnienie stanowiska pracownika");
            
            using var update = new SqlCommand("update Pracownicy set Stanowisko=@stanowisko where IDpracownika=@id",
                connection);
            update.Parameters.AddWithValue("stanowisko", "Szefowa wszystkich szefów");
            update.Parameters.AddWithValue("id", value:10);

            return update.ExecuteNonQuery();
        }

        public int DeletePracownicy()
        {

            Console.WriteLine($"\nUsunięcie z listy ostatnio dodanego pracownika");

            using var delete = new SqlCommand("delete from Pracownicy where IDpracownika=@id",
                connection);
            delete.Parameters.AddWithValue("id", 10);

            return delete.ExecuteNonQuery();
        }

    }
}