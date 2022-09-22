using MySql.Data.MySqlClient;
using System;


try
{
    MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder()
    {
        Server = "localhost",
        Database = "empresa_1170441",
        UserID = "root",
        Password = "sebastronio09",
        Port = 3306,
    };
    Console.WriteLine(builder.ConnectionString);
    using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
    {
        Console.WriteLine("\nQuery data example:");
        Console.WriteLine("=========================================\n");

        connection.Open();

        String sql = "SELECT nombre FROM empresa_1170441.empleado";

        using (MySqlCommand command = new MySqlCommand(sql, connection))
        {
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0}", reader.GetString(0));
                }
            }
        }
    }
}
catch (MySqlException e)
{
    Console.WriteLine(e.ToString());
}
Console.WriteLine("\nDone. Press enter.");
Console.ReadLine();
