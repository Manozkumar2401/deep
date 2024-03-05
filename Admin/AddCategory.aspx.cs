using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace deep.Admin
{
    public partial class Category : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["deep"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter adp;
        DataTable dt;
        SqlCommandBuilder cb;
        string query;



        protected void Page_Load(object sender, EventArgs e)
        {
            //display();
            // if (Session["username"] != null)
            {
                if (!IsPostBack)
                {
                    displaycategory();
                  //  displaycompany();
                    dropdown();
                }


                //if (Request.QueryString["Updatebrand"] != null)
                //{
                //    txtcategory.Text = "Update brand";
                //    Displayuserintextboxbyquerystring();


                //}
                //else
                //{


                //    txtcategory.Text = "Add";
                //}


            }
            // else
            {

                // Server.Transfer("../Loginpage.aspx");
            }
        }


        private void dropdown()
        {
            query = " select * from company";
            cmd = new SqlCommand(query, con);
          //  cmd.CommandType = CommandType.StoredProcedure;
            adp = new SqlDataAdapter(cmd);
           DataTable  dt1 = new DataTable();
            adp.Fill(dt1);
            ddlBrand.DataSource = dt1;
            ddlBrand.DataTextField = "name";
            ddlBrand.DataValueField = "id";
            ddlBrand.DataBind();
            ddlBrand.Items.Insert(0, new ListItem(" --selectbrand--", "0"));
            // dd_state.Items.Insert(0, new ListItem("--select State--", "0"));




        }
        private void displaycategory()
        {
            string query = " select * from categoary s inner join company c on s.id=c.id  ";
            adp = new SqlDataAdapter(query, con);
            dt = new DataTable();
            adp.Fill(dt);




            if (!IsPostBack)
            {
                bind();
            }




        }
    
        private void bind()
        {



            rptrBrands.DataSource = dt;
            rptrBrands.DataBind();

        }
        public void checkduplicate()
        {
            try
            {
                string query = "select *  from categoary  where cname=@name";
                cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", txtcategory.Text);
                adp = new SqlDataAdapter(cmd);


                dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //  Response.Write("<script>alert('UserName is Dublicate Pls Enter Another Name')</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire({\r\n" +
                        "  icon: 'error',\r\n " +
                     " title: 'Oops...',\r\n " +
                     " text: 'category is duplicate!',\r\n" +
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
        public void insert()
        {



            string query = "insert into categoary values(@cname,getdate(),@id )";
            cmd = new SqlCommand(query, con);

            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@cname", txtcategory.Text.Trim());
            cmd.Parameters.AddWithValue("@id",ddlBrand.SelectedValue);

            adp = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adp.Fill(dt);
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire({icon: 'success',title: 'Your category has been inserted ',showConfirmButton: false,timer: 3300})", true);



        }
        public void reset()
        {
            txtcategory.Text = string.Empty;

        }
        private void Displayuserintextboxbyquerystring()
        {
            try
            {
                string query = "select * from  categoary where cid=@cid";
                //  string query = "";
                cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@cid", Request.QueryString["Updatecategory"]);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        txtcategory.Text = dr["cname"].ToString();

                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('error', 'success')", true);


                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {


                if (con.State == ConnectionState.Open)
                {
                    con.Close();

                }




            }
        }
        //private void Displaycompanyintextbox()
        //{
        //    try
        //    {
        //        // string query = "_updateuser";
        //        string query = "select * from  company where id=@id ";
        //        cmd = new SqlCommand(query, con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtid.Text.Trim()));

        //        if (con.State == ConnectionState.Closed)
        //        {
        //            con.Open();

        //        }
        //        SqlDataReader dr = cmd.ExecuteReader();


        //        if (dr.HasRows)
        //        {

        //            while (dr.Read())
        //            {
        //                txtBrand.Text = dr["name"].ToString();


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

        //}
        //private void Updatcategory()  
        //{

        //    try
        //    {


        //        string query = "_updatecategory";
        //        cmd = new SqlCommand(query, con);

        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@cname", txtcategory1.Text.Trim());
        //        cmd.Parameters.AddWithValue("@cid", Request.QueryString["Updatebrand"]);


        //        adp = new SqlDataAdapter(cmd);
        //        adp.Fill(dt);
        //        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire({icon: 'success',title: 'Your category has been updated',showConfirmButton: false,timer: 3000})", true);
        //        bind();


        //    }
        //    catch (Exception ex)
        //    {
        //        // txtlabel.Text = "errror " + ex.Message;

        //    }
        //    finally
        //    {
        //        reset();
        //    }

        //}

       

        protected void addcategorybtn_Click(object sender, EventArgs e)
        {
           // if (addcategorybtn.Text == "Add")
            {
                checkduplicate();

            }
           // else
            {
               // Updatcategory();
            }
        }
    }
}
