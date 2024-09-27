using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebAppTwoTierAecht
{
    public partial class UserProfile : System.Web.UI.Page
    {
        connectioncls conobj = new connectioncls();
        protected void Page_Load(object sender, EventArgs e)
        {
            string qury= "select Name,Age,Address,Photo from twolayertable where id='"+Session["Uid"]+"'";
            SqlDataReader dr = conobj.Fn_Readser(qury);
            while(dr.Read())
            {
               Label5.Text = dr["Name"].ToString();
                Label6.Text = dr["Age"].ToString();
                Label7.Text = dr["Address"].ToString();
                imgImage.ImageUrl= dr["Photo"].ToString();
            }
            DataSet ds = conobj.Fn_dataset(qury);
            GridView1.DataSource = ds;
            GridView1.DataBind();

            DataTable dtable = conobj.Fn_dataTable(qury);
            DataList1.DataSource = dtable;
            DataList1.DataBind();
        }
    }
}