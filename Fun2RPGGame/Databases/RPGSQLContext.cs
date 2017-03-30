using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fun2RPGGame
{
    public class RPGSQLContext : IRPGContext
    {
        SqlConnection conString = new SqlConnection("Server=mssql.fhict.local;Database=dbi348991;User Id=dbi348991;Password=remiiscool;");

        public List<string> GetAllCharacters()
        {
            List<string> listacolumnas = new List<string>();

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT Name FROM Character";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conString;

            conString.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listacolumnas.Add(Convert.ToString(reader["Name"]));
            }
            conString.Close();
            return listacolumnas;
        }

        public string GetCharacter(string name)
        {
            throw new NotImplementedException();
        }
    }
}
