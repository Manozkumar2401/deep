using System;
using System.Collections;
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
    public partial class SubCategory : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["deep"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter adp;
        DataTable dt;
        SqlCommandBuilder cb;
        string query;
        protected void Page_Load(object sender, EventArgs e)
        {


            // dropdown();
            dropdowncompany();


            if (!IsPostBack)
            {
                displaycategory();
              
                // dropdown1();

            }
        }

        private void displaycategory()
        {
            string query = " select * from subcategoary s inner join categoary c on s.cid=c.cid  ";
            cmd = new SqlCommand(query, con);
            adp = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adp.Fill(dt);




            if (!IsPostBack)
            {
                bind();
            }




        }
        private void bind()
        {



            rptrSubCat.DataSource = dt;
            rptrSubCat.DataBind();

        }
        private void dropdowncompany()
        {



            query = "select * from company";
            cmd = new SqlCommand(query, con);
            adp = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adp.Fill(dt);
            ddlBrand.DataSource = dt;
            ddlBrand.DataValueField = "id";
            ddlBrand.DataTextField = "name";
            ddlBrand.DataBind();
            ddlBrand.Items.Insert(0, new ListItem("--Selectcompany--", "0"));



        }
        protected void ddlBrand_SelectedIndexChanged1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddlBrand.SelectedItem.Value);
            query = "select * from categoary where id=@id";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            adp = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adp.Fill(dt);
            ddlcategory.DataSource = dt;
            ddlcategory.DataValueField = "cid";
            ddlcategory.DataTextField = "cname";
            ddlcategory.DataBind();
            ddlcategory.Items.Insert(0, new ListItem("--SelectCategory--", "0"));
        }






        public void checkduplicate()
        {
            try
            {
                string query = "SELECT * FROM   SUBcategoary where sname=@sname";
                cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Sname", txtSubCategory.Text);
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



            string query = "insert into subcategoary values(@Sname,getdate(),@Cid )";
            cmd = new SqlCommand(query, con);

            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Sname", txtSubCategory.Text.Trim());
            cmd.Parameters.AddWithValue("@Cid", ddlcategory.SelectedValue);


            adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire({icon: 'success',title: 'Your Brand has been inserted ',showConfirmButton: false,timer: 3300})", true);

            bind();

        }
        public void reset()
        {
            txtSubCategory.Text = string.Empty;

        }

        protected void btnAddSubCategory_Click(object sender, EventArgs e)
        {
            checkduplicate();
        }

      
    }
}