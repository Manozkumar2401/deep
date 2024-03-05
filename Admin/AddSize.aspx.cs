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
    public partial class AddSize : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["deep"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter adp;
        DataTable dt;
        SqlCommandBuilder cb;
        string query;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dropdowngender();
                displaycategory();
                dropdowncompany();
            }
        }
        private void displaycategory()
        {
            string query = " select  t.sizeid ,t.sizename ,g.gendername,s.sname,c.cname,ca.name from tblsizes t inner join tblgender g on g.genderid=t.genderid inner join  subcategoary s on t.sid=s.sid inner join categoary c on s.cid=c.cid inner join company ca on c.id =ca.id   ";
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



            rptrSize.DataSource = dt;
            rptrSize.DataBind();

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

        protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddlBrand.SelectedItem.Value);
            query = "select * from categoary where id=@id";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            adp = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adp.Fill(dt);
            ddlCategory.DataSource = dt;
            ddlCategory.DataValueField = "cid";
            ddlCategory.DataTextField = "cname";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("--SelectCategory--", "0"));

        }

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {


            int cid = Convert.ToInt32(ddlCategory.SelectedItem.Value);
            query = "select * from subcategoary where cid=@cid";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@cid", cid);
            adp = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adp.Fill(dt);
            ddlSubCategory.DataSource = dt;
            ddlSubCategory.DataValueField = "sid";
            ddlSubCategory.DataTextField = "sname";
            ddlSubCategory.DataBind();
            ddlSubCategory.Items.Insert(0, new ListItem("--Selectsubcategory--", "0"));
        }


        private void dropdowngender()
        {

            query = "SELECT [genderid],[gendername] FROM [dbo].[tblgender]";
            cmd = new SqlCommand(query, con);
            adp = new SqlDataAdapter(cmd);
              dt = new DataTable();
            adp.Fill(dt);
           
            ddlGender.DataValueField = "genderid";
            ddlGender.DataTextField = "gendername";
            ddlGender.DataSource = dt;
            ddlGender.DataBind();
            ddlGender.Items.Insert(0, new ListItem("--selectgender--", "0"));


        }
        private void insert()
        {
            int id = Convert.ToInt32(ddlBrand.SelectedItem.Value);
            int cid = Convert.ToInt32(ddlCategory.SelectedItem.Value);
            int sid = Convert.ToInt32(ddlSubCategory.SelectedItem.Value);
            int genderid = Convert.ToInt32(ddlGender.SelectedItem.Value);
            //@sizename,@cid,@sid, @genderid
           string query = "_insertsize";
           // string query = "INSERT INTO [dbo].[tblsizes] ([sizename],[id],[cid],[sid],[genderid])VALUES(@sizename,@id,@cid,@sid, @genderid)";
            cmd = new SqlCommand(query, con);
           // cmd.CommandType = CommandType.Txt;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sizename",txtSize.Text.Trim());
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@cid", cid);
            cmd.Parameters.AddWithValue("@sid", sid);
            cmd.Parameters.AddWithValue("@genderid", genderid);
            dt = new DataTable();
            adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire({icon: 'success',title: 'Your Size has been inserted ',showConfirmButton: false,timer: 3300})", true);
        }

        protected void btnAddSize_Click(object sender, EventArgs e)
        {
            insert();
            reset();
        }



        public void checkduplicate()
        {
            try
            {
                string query = "select *  from  tblsizes  where sizename=@size ";
                cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@size", txtSize.Text);
                adp = new SqlDataAdapter(cmd);


                dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //  Response.Write("<script>alert('UserName is Dublicate Pls Enter Another Name')</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire({\r\n" +
                        "  icon: 'error',\r\n " +
                     " title: 'Oops...',\r\n " +
                     " text: 'Size is duplicate!',\r\n" +
                     "  footer: '<a href=\"\">Why do I have this issue?</a>'" +
                     "\r\n})"


                     , true);

                    reset();

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
       
        public void reset()
        {

            txtSize.Text = string.Empty;
            
        }

       
    }
}