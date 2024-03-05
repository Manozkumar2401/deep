using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.EnterpriseServices;
using System.Web.Profile;

namespace deep
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["deep"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter adp;
        DataTable dt;
        SqlCommandBuilder cb;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "_login";
                cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uname", txtuser.Text.Trim());
                cmd.Parameters.AddWithValue("@pass", txtpass.Text.Trim());
                //adp = new SqlDataAdapter(cmd);
                //dt = new DataTable();
                //adp.Fill(dt);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                int l = (int)cmd.ExecuteScalar();
                if (l >= 1)
                {
                    Session["username"] = txtuser.Text;
                  //  ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('welcome dear', 'success')", true);

                    Response.Redirect("Admin/Profilepage.aspx");
                }
                else
                {
                 ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire({ icon: 'error',title: 'Oops...', text: '!incorrect  Username & password', footer: '<a href=SignUp.aspx >Why do I have this issue?</a>'})", true);
                //    txtlabel.Text = "please create a account";
                //    Server.Transfer("account.aspx");
                //    Response.Write("<script>alert(' !incorrect  Username & password ')</script>");
                //    Response.Redirect("Login.aspx");

                }
            }
            catch( Exception ex)
            {
               // txtlabel.Text = "errror ";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire({ icon: 'error',title: 'Oops...', text: 'Something went wrong!', footer: '<a href=>Why do I have this issue?</a>'})", true);

            }
            finally
            {

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                reset();
            }

          

        }
        private void reset()
        {
            txtpass.Text = string.Empty;
            txtuser.Text = string.Empty;
     
        }
    }
}