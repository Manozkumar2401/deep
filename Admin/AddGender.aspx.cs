using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace deep.Admin
{
    public partial class Gender : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["deep"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter adp;
        DataTable dt;
        SqlCommandBuilder cb;
        string query;
        protected void Page_Load(object sender, EventArgs e)
        {

            displaygender();

        }


        private void displaygender()
        {
            string query = " select * from tblgender  ";
            adp = new SqlDataAdapter(query, con);
            dt = new DataTable();
            adp.Fill(dt);




            if (!IsPostBack)
            {
                bind();
            }




        }
        //private void displaycompany()
        //{
        //    string query = " select * from company ";
        //    adp = new SqlDataAdapter(query, con);
        //    dt = new DataTable();
        //    adp.Fill(dt);




        //    if (!IsPostBack)
        //    {
        //        bind();
        //    }




        //}
        private void bind()
        {



            rptrGender.DataSource = dt;
            rptrGender.DataBind();

        }
        public void checkduplicate()
        {
            try
            {
                string query = "select *  from tblgender where gendername=@name";
                cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", txtGender.Text);
                adp = new SqlDataAdapter(cmd);


                dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //  Response.Write("<script>alert('UserName is Dublicate Pls Enter Another Name')</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire({\r\n" +
                        "  icon: 'error',\r\n " +
                     " title: 'Oops...',\r\n " +
                     " text: 'Username is duplicate!',\r\n" +
                     "  footer: '<a href=\"\">Why do I have this issue?</a>'" +
                     "\r\n})"


                     , true);

                    // reset();

                }
                else
                {
                    insert();
                  

                }
            }
            catch (Exception ex)
            {
                //  txtlabel.Text = "errror " + ex;

            }
            finally
            {
                reset();
            }

        }
        public void insert()
        {



            string query = "insert into tblgender values(@name)";
            cmd = new SqlCommand(query, con);

            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", txtGender.Text.Trim());
           // cmd.Parameters.AddWithValue("@id", ddlBrand.SelectedValue);

            adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire({icon: 'success',title: 'Your Brand has been inserted ',showConfirmButton: false,timer: 3300})", true);



        }
        public void reset()
        {
            txtGender.Text = string.Empty;

        }

        protected void btnAddBrand_Click(object sender, EventArgs e)
        {
            checkduplicate();
        }
    }
}