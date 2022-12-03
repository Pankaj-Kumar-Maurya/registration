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
    public partial class changepassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-M07BDFTM;initial catalog=registration ;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
       
        }

        protected void btnchangepassword_Click(object sender, EventArgs e)
        {
            if (txtnewpassword.Text == txtconfirmpassword.Text)
            {


                con.Open();
                SqlCommand cmd = new SqlCommand("sp_reg", con);
                cmd.Parameters.AddWithValue("@action", "CP");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", Session["id"]);
                cmd.Parameters.AddWithValue("@password", txtnewpassword.Text);
                cmd.Parameters.AddWithValue("@oldpassword", txtoldpassword.Text);
               int i= cmd.ExecuteNonQuery();
                con.Close();
                if(i==0)
                {
                    lblmsg.Text = "Your Password is not change";
                }
                else
                {
                lblmsg.Text = "Your Password is Change Successfully";
                }
            }
            else
            {
                lblmsg.Text = "Your Password is Not Match";

            }
        }
    }
}