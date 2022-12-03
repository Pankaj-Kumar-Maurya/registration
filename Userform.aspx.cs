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
    public partial class Userform : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-M07BDFTM;initial catalog=registration ;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null && Session["id"].ToString() != " ")
            {



                if (Request.QueryString["k"] != null && Request.QueryString["k"].ToString() != " ")
                {
                    if (!IsPostBack)
                    {
                        edit();
                    }
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }

        }

        public void edit()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_user", con);
            cmd.Parameters.AddWithValue("@action", "EDIT");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uid", Request.QueryString["k"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            txtname.Text = dt.Rows[0]["uname"].ToString();
            txtage.Text = dt.Rows[0]["uage"].ToString();
            string[] arr = dt.Rows[0]["uhobbies"].ToString().Split(',');
            for (int i = 0; i < cblhobbies.Items.Count; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (cblhobbies.Items[i].Text == arr[j])
                    {
                        cblhobbies.Items[i].Selected = true;
                    }
                }

            }

            btnsave.Text = "Update";
            ViewState["id"] = Request.QueryString["k"];
        }

      

        protected void btnsave_Click(object sender, EventArgs e)
        {

            string HOBS = "";
            for (int i = 0; i < cblhobbies.Items.Count; i++)
            {
                if (cblhobbies.Items[i].Selected == true)
                {
                    HOBS += cblhobbies.Items[i].Text + ",";
                }
            }
            HOBS = HOBS.TrimEnd(',');
               

            if (btnsave.Text=="Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_user", con);
                cmd.Parameters.AddWithValue("@action", "INSERT");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uname", txtname.Text);
                cmd.Parameters.AddWithValue("@uage", txtage.Text);
                cmd.Parameters.AddWithValue("@uhobbies", HOBS);
                cmd.ExecuteNonQuery();
                con.Close();
               
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_user", con);
                cmd.Parameters.AddWithValue("@action", "UPDATE");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", ViewState["id"]);
                cmd.Parameters.AddWithValue("@uname", txtname.Text);
                cmd.Parameters.AddWithValue("@uage", txtage.Text);
                cmd.Parameters.AddWithValue("@uhobbies", HOBS);
                cmd.ExecuteNonQuery();
                con.Close();
               
                btnsave.Text = "Save";
            }



            
        }

       
    }
}