using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppTwoTierAecht
{
    public partial class UserInsert : System.Web.UI.Page
    {
        connectioncls conobj = new connectioncls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string imgpath = "~/Images/"+fileupimage.FileName;
            fileupimage.SaveAs(MapPath(imgpath));
            string qury = "insert into twolayertable values('"+txtName.Text+"',"+txtAge.Text+"," +
                "'"+txtaddress.Text+"','"+imgpath+"','"+txtUserName.Text+"','"+txtPassword.Text+"')";
           
            int i=conobj.Fn_Nonquery(qury);
            if (i == 1)
            {
                lbloutput.Text = "insert";

            }

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
    }
}