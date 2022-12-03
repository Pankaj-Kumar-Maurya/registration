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
    public partial class home : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-M07BDFTM;initial catalog=registration ;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                show();
            }
        }

        public void show()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_reg", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "JOINONE");
            cmd.Parameters.AddWithValue("@id",Session["id"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grid.DataSource = dt;
            grid.DataBind();
            lblname.Text = dt.Rows[0]["name"].ToString();

        }

    }
}