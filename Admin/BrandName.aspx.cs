using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.EnterpriseServices;

namespace deep.Admin
{
    public partial class BrandName : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["deep"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter adp;
        DataTable dt;
        SqlCommandBuilder cb;
        protected void Page_Load(object sender, EventArgs e)
        {
        //    // if (Session["username"] != null)
        //    {
        //        //  if (!IsPostBack)
        //        {
        //            display();
        //        }


        //        if (Request.QueryString["Updatebrand"] != null)
        //        {
        //            btn_manage.Text = "Update brand";
        //            Displayuserintextboxbyquerystring();


        //        }
        //        else
        //        {


        //            btn_manage.Text = "Create Brand";
        //        }


        //    }
        //    //  else
        //    {

        //        // Server.Transfer("../Loginpage.aspx");
        //    }


        //}
        //private void display()
        //{
        //    string query = " select * from company";
        //    adp = new SqlDataAdapter(query, con);
        //    dt = new DataTable();
        //    adp.Fill(dt);




        //    if (!IsPostBack)
        //    {
        //        bind();
        //    }




        //}
        //private void bind()
        //{



        //    GridView1.DataSource = dt;
        //    GridView1.DataBind();

        //}
        //protected void btn_manage_Click(object sender, EventArgs e)
        //{
            //    if (btn_manage.Text == "Create Brand")
            //    {
            //        checkduplicate();

            //    }
            //    else
            //    {

            //        Updateuser();
            //    }

            //}
            //public void checkduplicate()
            //{
            //    try
            //    {
            //        string query = " select * from company where name=@name";
            //        cmd = new SqlCommand(query, con);
            //        cmd.CommandType = CommandType.Text;
            //        cmd.Parameters.AddWithValue("@name", txtcompany.Text);
            //        adp = new SqlDataAdapter(cmd);


            //        dt = new DataTable();
            //        adp.Fill(dt);
            //        if (dt.Rows.Count > 0)
            //        {
            //            //  Response.Write("<script>alert('UserName is Dublicate Pls Enter Another Name')</script>");
            //            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire({\r\n" +
            //                "  icon: 'error',\r\n " +
            //             " title: 'Oops...',\r\n " +
            //             " text: 'Username is duplicate!',\r\n" +
            //             "  footer: '<a href=\"\">Why do I have this issue?</a>'" +
            //             "\r\n})"


            //             , true);

            //            // reset();

            //        }
            //        else
            //        {
            //            insert();
            //            bind();

            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //      //  txtlabel.Text = "errror " + ex;

            //    }
            //    finally
            //    {
            //        reset();
            //    }

            //}
            //public void insert()
            //{



            //    string query = "_insertcompany";
            //    cmd = new SqlCommand(query, con);

            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@name", txtcompany.Text.Trim());

            //    adp = new SqlDataAdapter(cmd);
            //    adp.Fill(dt);
            //    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire({icon: 'success',title: 'Your work has been saved',showConfirmButton: false,timer: 1500})", true);



            //}
            //public void reset()
            //{
            //    txtcompany.Text = string.Empty;

            //}
            //private void Displayuserintextboxbyquerystring()
            //{
            //    try
            //    {
            //        string query = "select * from  company where id=@id";
            //        //  string query = "";
            //        cmd = new SqlCommand(query, con);
            //        cmd.CommandType = CommandType.Text;
            //        cmd.Parameters.AddWithValue("@id", Request.QueryString["Updatebrand"]);
            //        if (con.State == ConnectionState.Closed)
            //        {
            //            con.Open();

            //        }
            //        SqlDataReader dr = cmd.ExecuteReader();


            //        if (dr.HasRows)
            //        {

            //            while (dr.Read())
            //            {
            //                txtcompany.Text = dr["name"].ToString();

            //            }
            //        }
            //        else
            //        {
            //            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('welcome dear', 'success')", true);


            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Response.Write(ex.Message);
            //    }
            //    finally
            //    {


            //        if (con.State == ConnectionState.Open)
            //        {
            //            con.Close();

            //        }




            //    }
            //}
            //private void Displaycompanyintextbox()
            //{
            //    try
            //    {
            //     // string query = "_updateuser";
            //         string query = "select * from  company where id=@id ";
            //        cmd = new SqlCommand(query, con);
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@id",Convert.ToInt32(txtid.Text.Trim()));

            //        if (con.State == ConnectionState.Closed)
            //        {
            //            con.Open();

            //        }
            //        SqlDataReader dr = cmd.ExecuteReader();


            //        if (dr.HasRows)
            //        {

            //            while (dr.Read())
            //            {
            //                txtcompany.Text = dr["name"].ToString();


            //            }

            //        }


            //    }
            //    catch (Exception ex)
            //    {
            //        Response.Write(ex.Message);
            //    }
            //    finally
            //    {


            //        if (con.State == ConnectionState.Open)
            //        {
            //            con.Close();

            //        }




            //    }

            //    }
            //private void Updateuser()
            //{
            //    try
            //    {


            //        string query = "_updatebrand";
            //        cmd = new SqlCommand(query, con);

            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@name", txtcompany.Text.Trim());
            //        cmd.Parameters.AddWithValue("@id", Request.QueryString["Updatebrand"]);


            //        adp = new SqlDataAdapter(cmd);
            //        adp.Fill(dt);
            //        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire({icon: 'success',title: 'Your work has been saved',showConfirmButton: false,timer: 1500})", true);
            //        bind();


            //    }
            //    catch (Exception ex)
            //    {
            //       // txtlabel.Text = "errror " + ex.Message;

            //    }
            //    finally
            //    {
            //        reset();
            //    }

            //}

            //protected void txtid_TextChanged(object sender, EventArgs e)
            //{
            //    if (!IsPostBack)
            //    {

            //        Displaycompanyintextbox();


            //    }
            //}
        }

    }

        }

    
