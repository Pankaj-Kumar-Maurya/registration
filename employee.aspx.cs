using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace registration
{
    public partial class employee : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LAPTOP-M07BDFTM;initial catalog=registration ;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
         if(!IsPostBack)
            {
                bindgrid();
            }
        }

        public void bindgrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblemployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "DISPLAY");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            employeegrid.DataSource = dt;
            employeegrid.DataBind();

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (btnsubmit.Text == "Submit")
            {

                string FN = Path.GetFileName(fuimage.PostedFile.FileName);
                fuimage.SaveAs(Server.MapPath("EMPLOYEEPICS" + "//" + FN));

                con.Open();
                SqlCommand cmd = new SqlCommand("sp_tblemployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "INSERT");
                cmd.Parameters.AddWithValue("@ename", txtname.Text);
                cmd.Parameters.AddWithValue("@egender", rblgender.SelectedValue);
                cmd.Parameters.AddWithValue("@eimage", FN);

                cmd.ExecuteNonQuery();
                con.Close();
                bindgrid();
            }
            else if(btnsubmit.Text=="Update")
            {
                string FN = Path.GetFileName(fuimage.PostedFile.FileName);
                if (FN != "")
                {
                    fuimage.SaveAs(Server.MapPath("EMPLOYEEPICS" + "//" + FN));
                    File.Delete(Server.MapPath("EMPLOYEEPICS" + "//" + ViewState["img"]));
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_tblemployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "UPDATE");
                cmd.Parameters.AddWithValue("@eid", ViewState["id"]);
                cmd.Parameters.AddWithValue("@ename", txtname.Text);
                cmd.Parameters.AddWithValue("@egender", rblgender.SelectedValue);
                if (FN != "")
                {
                    cmd.Parameters.AddWithValue("@eimage", FN);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@eimage", ViewState["img"]);
                }

                cmd.ExecuteNonQuery();
                con.Close();
                bindgrid();
                btnsubmit.Text = "Submit";
            }
        }

        protected void employeegrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName=="A")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_tblemployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", e.CommandArgument);
                cmd.Parameters.AddWithValue("@action", "EDIT");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                employeegrid.DataSource = dt;
                employeegrid.DataBind();
                txtname.Text = dt.Rows[0]["ename"].ToString();
                rblgender.SelectedValue = dt.Rows[0]["egender"].ToString();
                ViewState["img"] = dt.Rows[0]["eimage"].ToString();
                btnsubmit.Text = "Update";
                ViewState["id"] = e.CommandArgument;
                bindgrid();

            }
            else if(e.CommandName=="B")
            {
                string[] arr= e.CommandArgument.ToString().Split(',');
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_tblemployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "DELETE");
                cmd.Parameters.AddWithValue("@eid", arr[0]);
                cmd.ExecuteNonQuery();
                con.Close();
                bindgrid();
                File.Delete(Server.MapPath("EMPLOYEEPICS" + "//" + arr[1]));
            }
        }
    }
}