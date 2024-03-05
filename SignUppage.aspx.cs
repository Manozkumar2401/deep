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
    public partial class SuinUppage : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["deep"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter adp;
        DataTable dt;
        SqlCommandBuilder cb;

        protected void Page_Load(object sender, EventArgs e)
        {





        }

        //protected void btnsubmit_Click(object sender, EventArgs e)
        //{
        //    checkduplicate();
        //}
        public void checkduplicate()
        {
            try
            {
                string query = " select * from useraccount where Uname=@uname";
                cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@uname", txtuser.Text);
                adp = new SqlDataAdapter(cmd);


                dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                     // Response.Write("<script>alert('')</script>");
                    //       ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Good job!','Recored is Saved', 'success')", true);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire({\r\n" +
                     "  icon: 'error',\r\n " +
                     " title: 'Oops...',\r\n " +
                     " text: 'UserName is Dublicate Pls Enter Another Name!',\r\n" +
                     " timer: '3000',\r\n" +
                     "  footer: '<a href=>Why do I have this issue?</a>'" +
                     "\r\n})"


                     , true);

                    //reset();

                }
                else
                {
                    insert();
                   // Response.Write("<script>alert('inserted')</script>");
                  //  ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Good job!','Recored is Inserted', 'success')", true);


                }
            }
            catch (Exception ex)
            {
                txtlabel.Text = "errror " + ex;

            }
            finally
            {
                reset();
            }

        }



        public void insert()
        {
            string query = "_insert";
            cmd = new SqlCommand(query, con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uname", txtuser.Text.Trim());
            cmd.Parameters.AddWithValue("@name", txtname.Text.Trim());
            cmd.Parameters.AddWithValue("@mobile", txtmobile.Text.Trim());
            cmd.Parameters.AddWithValue("@pass", txtpass.Text.Trim());
            cmd.Parameters.AddWithValue("@conpass", txtconpass.Text.Trim());
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            cmd.Parameters.AddWithValue("@address", txtadd.Text);
            adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire({icon: 'success',title: 'Your work has been saved',showConfirmButton: false,timer: 3000})", true);
        }
        public void reset()
        {
            txtuser.Text = string.Empty;
            txtname.Text = string.Empty;
            txtpass.Text = string.Empty;
            txtconpass.Text = string.Empty;
            txtemail.Text = string.Empty;
            txtadd.Text = string.Empty;
        }

        protected void btn_manage_Click(object sender, EventArgs e)
        {
            checkduplicate();
        }
    }
}