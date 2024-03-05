using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace deep
{
    public partial class Loginpage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["deep"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter adp;
        DataTable dt;
        SqlCommandBuilder cb;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["UNAME"] != null && Request.Cookies["UPWD"] != null)
            {
                txtuser.Text = Request.Cookies["UNAME"].Value;
                txtpass.Text = Request.Cookies["UPWD"].Value;
                CheckBox1.Checked = true;
            }


        }

        protected void login() 
        {
            try
            {
                string query = "_login";
                cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uname", txtuser.Text.Trim());
                cmd.Parameters.AddWithValue("@pass", txtpass.Text.Trim());
                //adp = new SqlDataAdapter(cmd);5
                //dt = new DataTable();
                //adp.Fill(dt);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                int l = (int)cmd.ExecuteScalar();
                if (l >= 1)
                {

                    if (CheckBox1.Checked)
                    {
                        Request.Cookies["UNAME"].Value = txtuser.Text;
                        Request.Cookies["UPWD"].Value = txtpass.Text;
                        Request.Cookies["UNAME"].Expires = DateTime.Now.AddDays(10);
                        Request.Cookies["UPWD"].Expires = DateTime.Now.AddDays(10);
                    }
                    else
                    {
                        Request.Cookies["UNAME"].Expires = DateTime.Now.AddDays(-1);
                        Request.Cookies["UPWD"].Expires = DateTime.Now.AddDays(-1);
                    }


                    //  ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('welcome dear', 'success')", true);
                    Session["username"] = txtuser.Text;

                    Response.Redirect("Admin/Profilepage.aspx");
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire({ icon: 'error',title: 'Oops...', text: '!incorrect  Username & password', footer: '<a href=SignUp.aspx >Why do I have this issue?</a>',timer:3000})", true);
                    //    txtlabel.Text = "please create a account";
                    //    Server.Transfer("account.aspx");
                    //    Response.Write("<script>alert(' !incorrect  Username & password ')</script>");
                    //    Response.Redirect("Login.aspx");


                }
            }
            catch (Exception ex)
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

        protected void btn_manage_Click(object sender, EventArgs e)
        {
            login();
        }
    }
}