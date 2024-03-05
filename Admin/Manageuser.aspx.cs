using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Timers;
using System.Diagnostics.Eventing.Reader;

namespace deep.Admin
{
   
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["deep"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter adp;
        DataTable dt;
        SqlCommandBuilder cb;
        protected void Page_Load(object sender, EventArgs e)
        {

           if (Session["username"]!=null)
            {
                //  if (!IsPostBack)
                {
                    display();
                }


                if (Request.QueryString["Updateuser"]!= null)
                {
                    btn_manage.Text = "Update user";
                    Displayuserintextboxbyquerystring();
                }
                else
                {
                    btn_manage.Text = "Create user";
                }
               

            }
           else
            {

             Server.Transfer("../Loginpage.aspx");
            }

         
        }

       private void display()
        {
            string query = " select * from useraccount";
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



            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataRow[] dr = dt.Select("uid=" + Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[0].Text));
            dr[0].Delete();
            cb = new SqlCommandBuilder(adp);
            adp.Update(dt);
            bind();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        { 
            

         
           

        }
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

                    //Response.Write("<script>alert('inserted')</script>");

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
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire({position: 'top-end',icon: 'success',title: 'Your work has been saved',showConfirmButton: false,timer: 1500})" ,true);



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
        protected void Button1_Click(object sender, EventArgs e)
        {   if (btn_manage.Text == "Create user") 
            { 
                checkduplicate();
            
            }
            else 
            {
                Updateuser();
            }
        

        }
        private void Updateuser()
        {
            try
            {


                string query = "_updateuserbyadmin";
                cmd = new SqlCommand(query, con);

                cmd.CommandType = CommandType.StoredProcedure;              
                cmd.Parameters.AddWithValue("@name", txtname.Text.Trim());
                cmd.Parameters.AddWithValue("@mobile", txtmobile.Text.Trim());
                cmd.Parameters.AddWithValue("@pass", txtpass.Text.Trim());
                cmd.Parameters.AddWithValue("@conpass", txtconpass.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@address", txtadd.Text);
                adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire({position: 'top-end',icon: 'success',title: 'Your work has been saved',showConfirmButton: false,timer: 1500})", true);





            }
            catch (Exception ex)
            {
                txtlabel.Text = "errror " + ex.Message;

            }
            finally
            {
                reset();
            }

        }
        private void Displayuserintextboxbyquerystring()
        {
            try
            {
                string query = "_updateuser";
              //  string query = "select * from  useraccount where  uname=@uname  and uid=@uid";
                cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uname", Session["username"].ToString());
                cmd.Parameters.AddWithValue("@uid", Request.QueryString["Updateuser"]);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        txtuser.Text = dr["Uname"].ToString();
                        txtname.Text = dr["name"].ToString();
                        txtmobile.Text = dr["mobile"].ToString();
                        txtemail.Text = dr["email"].ToString();
                        //   txtpass.Text = dr["pass"].ToString();
                    
                      //  txtconpass.Text = dr["conpass"].ToString();
                        txtadd.Text = dr["Address"].ToString();

                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('welcome dear', 'success')", true);


                }
            }
            catch( Exception ex)
            {
                Response.Write(ex.Message); 
            }
            finally {


                if (con.State == ConnectionState.Open)
                {
                    con.Close();

                }
            



            }




             
        }
            
    }
}
