using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopluMailGonderimUygulamasi.Helper;

namespace TopluMailGonderimUygulamasi.Database
{
    public class DataAccessLayer: GlobalIslemler
    {
        public SqlConnection con;
        public SqlCommand cmd;
        SqlDataReader reader;
        int returnvalue;

        public DataAccessLayer()
        {
            con = new SqlConnection("Server=ABDULLAH\\SQLEXPRESS01;Database=TopluMailGonderimUygulamasi;User Id=AppUser;Password=SimpleTempPass123;Connection Timeout=30;");
        }

        public int Calistir(SqlCommand cmd)
        {
            cmd.Connection = con;
            con.Open();
            tryCatchKullan(() => 
            {
                returnvalue = cmd.ExecuteNonQuery();
            });
            con.Close();
            return returnvalue;

        }

        public SqlDataReader VeriGetir(SqlCommand cmd)
        {
            cmd.Connection = con;
            con.Open();
            tryCatchKullan(() =>
            {
                reader = cmd.ExecuteReader();
            });
            return reader;
        }

        public int CalistirINT(SqlCommand cmd)
        {
            cmd.Connection = con;
            con.Open();
            tryCatchKullan(() =>
            {
                returnvalue = Convert.ToInt32(cmd.ExecuteScalar());
            });
            con.Close();
            return returnvalue;
        }
    }
}
