using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;

namespace ConferenceHallAPI
{
    public static class Database
    {
        //Підключення до вбудованої, локальної бази даних
        public const string ConnectionString = "Data Source=app.db";
        public static void Initialize()
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            //Якщо ще не існує, Створення таблиці, яка містить інформацію про послуги, з якими створюються зали
            string createTable = "CREATE TABLE IF NOT EXISTS Services (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL, Price REAL NOT NULL);";
            using var command = new SqliteCommand(createTable, connection);
            command.ExecuteNonQuery();

            //Якщо ще не існує, Створення таблиці, яка містить інформацію про орендовані зали
            string createTableRent = "CREATE TABLE IF NOT EXISTS Rentals (Id INTEGER PRIMARY KEY AUTOINCREMENT, Hall_Id INTEGER NOT NULL, RentStart TEXT NOT NULL, RentEnd TEXT NOT NULL, Projector INTEGER NOT NULL DEFAULT 0, WiFi INTEGER NOT NULL DEFAULT 0, Sound INTEGER NOT NULL DEFAULT 0, TotalPrice REAL NOT NULL, FOREIGN KEY (Hall_Id) REFERENCES Hall(Id));";
            using var Rent_command = new SqliteCommand(createTableRent, connection);
            Rent_command.ExecuteNonQuery();

            AddInitialData(connection);
        }
        private static void AddInitialData(SqliteConnection connection)
        {
            //Інформація про послуги
            AddService(connection, "Проєктор", 500);
            AddService(connection, "Wi-Fi", 300);
            AddService(connection, "Звук", 700);
        }
        private static void AddService(SqliteConnection connection, string name, double price)
        {
            string sql = "INSERT INTO Services(Name, Price) SELECT $name, $price WHERE NOT EXISTS(SELECT 1 FROM Services WHERE Name = $name)";                    
            using var command = new SqliteCommand(sql, connection);

            command.Parameters.AddWithValue("$name", name);
            command.Parameters.AddWithValue("$price", price);
            command.ExecuteNonQuery();

        }

        public static void AddHall(string H_name, double P_amount, decimal Rent, string Projector, string WIFI, string Sound)
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            string createTable = "CREATE TABLE IF NOT EXISTS Hall (Id INTEGER PRIMARY KEY AUTOINCREMENT, Hall_Name TEXT NOT NULL, Size REAL NOT NULL, Base_Price REAL NOT NULL, Projector INTEGER NOT NULL DEFAULT 0, WiFi INTEGER NOT NULL DEFAULT 0, Sound INTEGER NOT NULL DEFAULT 0)";
            using var createCommand =  new SqliteCommand(createTable, connection);

            createCommand.ExecuteNonQuery();


            // Якщо послуга вибрана → 1
            // Якщо не вибрана → 0
            int projector = string.IsNullOrEmpty(Projector) ? 0 : 1;
            int wifi = string.IsNullOrEmpty(WIFI) ? 0 : 1;
            int sound = string.IsNullOrEmpty(Sound) ? 0 : 1;

            // Додаємо новий зал
            string sql_hall = "  INSERT INTO Hall  (Hall_Name, Size, Base_Price, Projector, WIFI, Sound)        VALUES        ($name, $size, $price, $projector, $wifi, $sound);";

    using var command = new SqliteCommand(sql_hall, connection);

            command.Parameters.AddWithValue("$name", H_name);
            command.Parameters.AddWithValue("$size", P_amount);
            command.Parameters.AddWithValue("$price", Rent);
            command.Parameters.AddWithValue("$projector", projector);
            command.Parameters.AddWithValue("$wifi", wifi);
            command.Parameters.AddWithValue("$sound", sound);

            command.ExecuteNonQuery();
        }
        // Орендовані зали
        public static void AddRentedHalls(int hall_id, string RentStart, string RentEnd, bool projector, bool wifi, bool sound, decimal tPrice)
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            

            // Додаємо новий орендований зал
            string sql_hall = "  INSERT INTO Rentals  (Hall_Id, RentStart, RentEnd, Projector, WIFI, Sound, TotalPrice) VALUES ($rID, $rStart, $rEnd, $projector, $wifi, $sound, $totalprice);";

            using var Rent_command = new SqliteCommand(sql_hall, connection);

            Rent_command.Parameters.AddWithValue("$rID", hall_id);
            Rent_command.Parameters.AddWithValue("$rStart", RentStart);
            Rent_command.Parameters.AddWithValue("$rEnd", RentEnd);
            Rent_command.Parameters.AddWithValue("$totalprice", tPrice);
            Rent_command.Parameters.AddWithValue("$projector", projector);
            Rent_command.Parameters.AddWithValue("$wifi", wifi);
            Rent_command.Parameters.AddWithValue("$sound", sound);

            Rent_command.ExecuteNonQuery();
        }
        


    } 
   
}
