using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace registration
{
    public partial class manageuser : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=PANKAJ;initial catalog=registration ;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                display();
            }

        }

        public void display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_user", con);
            cmd.Parameters.AddWithValue("@action", "DISPLAY");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grid.DataSource = dt;
            grid.DataBind();
        }

        protected void grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_user", con);
                cmd.Parameters.AddWithValue("@action", "DELETE");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                display();
            }
            else if (e.CommandName == "B")
            {
                Response.Redirect("Userform.aspx?k=" +e.CommandArgument);
            }
        }
    }
}