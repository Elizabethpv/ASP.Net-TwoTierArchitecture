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
    public partial class Login : System.Web.UI.Page
    {
        connectioncls conobj = new connectioncls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string query = "select count(id)from twolayertable where Username='" + txtUseName.Text + "' " +
                             "and Password='" + txtPassword.Text + "'";
            string i=conobj.Fn_Scalar(query);
            if(i=="1")
            {
                int id1 = 0;
                string qry = "select id from twolayertable where Username='" + txtUseName.Text + "' " +
                             "and Password='" + txtPassword.Text + "'";
                SqlDataReader dr = conobj.Fn_Readser(qry);
                while(dr.Read())
                {
                    id1 = Convert.ToInt32(dr["id"].ToString());
                }
                Session["Uid"] = id1;

                Response.Redirect("UserProfile.aspx");
            }
            else
            {
                lblOutput.Text = "Incorrect UserName and Password";
            }
        }
    }
}