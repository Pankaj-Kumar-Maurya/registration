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
    public partial class registrationform : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-M07BDFTM;initial catalog=registration ;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                show();
                showquli();
                showcountry();
                ddlstate.Enabled = false;
                ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }

        public void clear()
        {
            txtname.Text = "";
            txtemail.Text = "";
            txtpassword.Text = "";
            rblbg.ClearSelection();
            ddlqli.SelectedValue = "0";
            ddlcountry.SelectedValue = "0";
            ddlstate.SelectedValue = "0";
        }
        public void show()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_reg", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "JOIN");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grid.DataSource = dt;
            grid.DataBind();

        }

        public void showquli()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_reg", con);
            cmd.Parameters.AddWithValue("@action", "QULI");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlqli.DataValueField = "qid";
            ddlqli.DataTextField = "qname";
            ddlqli.DataSource = dt;
            ddlqli.DataBind();
            ddlqli.Items.Insert(0, new ListItem("--Select--", "0"));

        }

        public void showcountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_reg", con);
            cmd.Parameters.AddWithValue("@action", "COUNTRY");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlstate.Enabled = false;
            ddlcountry.DataValueField = "cid";
            ddlcountry.DataTextField = "cname";
            ddlcountry.DataSource = dt;
            ddlcountry.DataBind();
            ddlcountry.Items.Insert(0, new ListItem("--Select--", "0"));

        }

        public void showstate()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_reg", con);
            cmd.Parameters.AddWithValue("@action", "STATE");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@country", ddlcountry.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlstate.DataValueField = "sid";
            ddlstate.DataTextField = "sname";
            ddlstate.DataSource = dt;
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));

        }


        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Register")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_reg", con);
                cmd.Parameters.AddWithValue("@action", "INSERT");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                cmd.Parameters.AddWithValue("@blood",rblbg.SelectedValue);
                cmd.Parameters.AddWithValue("@qli",ddlqli.SelectedValue);
                cmd.Parameters.AddWithValue("@country",ddlcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@state",ddlstate.SelectedValue);
                cmd.ExecuteNonQuery();
                con.Close();
                show();
            }
            else if(btnsave.Text=="Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_reg", con);
                cmd.Parameters.AddWithValue("@action", "UPDATE");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                cmd.Parameters.AddWithValue("@blood",rblbg.SelectedValue);
                cmd.Parameters.AddWithValue("@qli",ddlqli.SelectedValue );
                cmd.Parameters.AddWithValue("@country",ddlcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@state",ddlstate.SelectedValue);
                cmd.Parameters.AddWithValue("@id",ViewState["kk"]);
                cmd.ExecuteNonQuery();
                con.Close();
                show();
                btnsave.Text = "Register";
            }
            clear();
        }

        protected void grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_reg", con);
                cmd.Parameters.AddWithValue("@action", "DELETE");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                show();
            }
            else if(e.CommandName=="B")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_reg", con);
                cmd.Parameters.AddWithValue("@action", "EDIT");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0]["name"].ToString();
                txtemail.Text = dt.Rows[0]["email"].ToString();
                txtpassword.Text = dt.Rows[0]["password"].ToString();
                rblbg.SelectedValue = dt.Rows[0]["bloodgroup"].ToString();
                ddlqli.SelectedValue = dt.Rows[0]["qulification"].ToString();
                ddlcountry.SelectedValue = dt.Rows[0]["country"].ToString();
                showstate();
                ddlstate.SelectedValue = dt.Rows[0]["state"].ToString();
                btnsave.Text = "Update";
                ViewState["kk"] = e.CommandArgument;
            }
        }

        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlcountry.SelectedValue=="0")
            {
                ddlstate.Enabled = false;
            }
            else
            {

            showstate();
            ddlstate.Enabled = true;

            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("search_proc ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@search", txtsearch.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
           if (dt.Rows.Count > 0)
           {
                grid.DataSource = dt;
                grid.DataBind();
               message.Text = "Record Founded succesfully";
               
                message.ForeColor = Color.BlueViolet;
          }
            else
            {
                grid.DataSource = dt;
                grid.DataBind();
                message.Text = "No Record Found";
                message.ForeColor = Color.Red;
           }

        }
    }
}