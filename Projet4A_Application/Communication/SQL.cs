using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    public class SQL
    {

        public List<List<string>> SqlRequest(string request)
        {
            request = SQL_constants.selectAllQuery; //TEMPORAIRE POUR VOIR SI CA FONCTIONNE !!!!!!!!!!!!!

            //==================
            List<List<string>> rows = new List<List<String>>();
            List<String> rowsElement = new List<String>();


            string connectionString = "User=root;Password=root;Database=mydb;Server=192.168.0.14;Port=3306;";
            MySqlConnection conn = new MySqlConnection(connectionString);
           // await conn.OpenAsync();

            MySqlCommand cmd = new MySqlCommand(request, conn);
            cmd.Connection = conn;

            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    Console.WriteLine("==============\n OUTPUTE : " + rdr[0]);
                    // rdr[0].ToString();
                    //rdr.ToString();
                    //rowsElement.Add(rdr[0].ToString() + " - " + rdr[1].ToString() + " - " + rdr[2].ToString());

                    rowsElement.Clear();
                    for (int i = 0; i < rdr.Depth; i++)
                    {
                        rowsElement.Add(rdr[i].ToString());
                    }
                    
                    //rdr.
                    rows.Add(rowsElement);
                    
                }
                rdr.Close();
            }







            //=================
            /*
            Console.WriteLine("\n ======\n Deuxième méthode \n =====");

            using (var connection = new MySqlConnection("Server=192.168.0.14;User ID=root;Password=root;Database=mydb"))
            {
                connection.Open();

                using (var command = new MySqlCommand(request, connection))
                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetString(0));
                    }
                       
            }
            */

            return rows;
        }



        
    }
}
