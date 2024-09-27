using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace WebAppTwoTierAecht
{
    public class connectioncls
    {
        SqlConnection con;
        SqlCommand cmd;
        public connectioncls()
        {
             con = new SqlConnection(@"server = DESKTOP-IT4CQOE\SQLEXPRESS; database = twolayer; integrated security = true");
        }
        public int Fn_Nonquery(string sqlquery)
        {

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            int i=cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public string Fn_Scalar(string sqlquery)
        {

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            string s= cmd.ExecuteScalar().ToString();
            con.Close();
            return s;
        }
        public SqlDataReader Fn_Readser(string sqlquery)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            return rd;
        }
        public DataSet Fn_dataset(string sqlquery)
        {

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
            DataSet dset = new DataSet();
            da.Fill(dset);
            return dset;
        }
        public DataTable Fn_dataTable(string sqlquery)
        {

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
            DataTable dtable =new DataTable();
            da.Fill(dtable);
            return dtable;
        }
    }
}