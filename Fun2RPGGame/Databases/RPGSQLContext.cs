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
            List<string> returnlist = new List<string>();

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
                returnlist.Add(Convert.ToString(reader["Name"]));
            }
            conString.Close();
            return returnlist;
        }

        public DataTable Query1(string query)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            //"Select C.Name, CL.Name as Classname, IT.Name as Itemname, CAT.Name as Category, IT.LevelRequirement "+
            //"From Inventory I " +
            //"join Character C on C.CharacterID = I.CharacterID " +
            //"join Class CL on CL.ClassID = C.ClassID " +
            //"join Item IT on IT.ItemID = I.ItemID " +
            //"join Category CAT on CAT.CategoryID = IT.CategoryID ";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conString;

            conString.Open();
            DataTable t1 = new DataTable();
            using (SqlDataAdapter a = new SqlDataAdapter(cmd))
            {
                a.Fill(t1);
            }
            conString.Close();
            return t1;
        }

        public string GetCharacter(string name)
        {
            throw new NotImplementedException();
        }
    }
}
