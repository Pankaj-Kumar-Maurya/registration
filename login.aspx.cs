using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;


namespace registration
{
    public partial class login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-M07BDFTM;initial catalog=registration ;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from form where email='"+txtemail.Text+"' and password='"+txtpassword.Text+"' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            if(dt.Rows.Count>0)
            {
                Session["id"]=dt.Rows[0]["id"];
                Response.Redirect("home.aspx");
            }
            else
            {
                lblmsg.Text = "Login Failed";
            }
        }
    }
}