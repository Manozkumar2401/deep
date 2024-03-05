//using System;
//using System.Collections.Generic;
//using System.Data.Common;
//using System.Data.SqlClient;
//using System.Data;
//using System.Linq;
//using System.Web;
//using System.Web.Configuration;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Xml.Linq;

//namespace deep.Admin
//{
//    public partial class WebForm3 : System.Web.UI.Page
//    {

//        //  SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["deep"].ConnectionString);
//        SqlConnection con = new SqlConnection(" server=MANOZKUMAR2401\\SQLEXPRESS01; initial catalog =project8; integrated security=true");
//        SqlCommand cmd;
//        string Query;
//        SqlDataAdapter adp;
//        DataTable dt;

//        //SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["constr"].ToString());
//        //SqlCommand cmd;
//        //string Query;
//        //SqlDataAdapter adp;
//        //DataTable dt = new DataTable();

//        protected void Page_Load(object sender, EventArgs e)
//        {

//        }

//        //protected void Button1_Click(object sender, EventArgs e)
//        //{
//        //    Dublicate();
//        //}

//        ////protected void Button2_Click(object sender, EventArgs e)
//        ////{

//        ////}

//        protected void Button1_Click(object sender, EventArgs e)
//        {

//        }

//        protected void Button1_Click1(object sender, EventArgs e)
//        {
//            Dublicate();
//        }
//        protected void Dublicate()
//        {
//            try
//            {

//                Query = "Select * from UserLogin where UMobile =@UMobile";
//                cmd = new SqlCommand(Query, con);
//                cmd.CommandType = CommandType.Text;
//                cmd.Parameters.AddWithValue("@UMobile", Convert.ToInt64(txtmobile.Text.Trim()));
//                adp = new SqlDataAdapter(cmd);
//                //DataTable dt1 = new DataTable();
//                adp.Fill(dt);
//                if (dt.Rows.Count > 0)
//                {
//                    Response.Write("<script>alter('Recored is Dublicate')</script>");
//                }
//                else
//                {
//                    Insert();
//                }
//            }
//            catch (Exception ex) { }
//            finally
//            {
//                if (con.State == ConnectionState.Open)
//                {
//                    con.Close();
//                }
//            }

//        }
//        protected void Insert()
//        {
//            try
//            {
//                Query = "_UserLogin";
//                cmd = new SqlCommand(Query, con);
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("@UName", txtname.Text.Trim());
//                cmd.Parameters.AddWithValue("@UPass", txtpass.Text.Trim());
//                cmd.Parameters.AddWithValue("@UEmail", txtemail.Text.Trim());
//                cmd.Parameters.AddWithValue("@UMobile", Convert.ToInt64(txtmobile.Text.Trim()));
//                if (con.State == ConnectionState.Closed)
//                {
//                    con.Close();
//                }
//                cmd.ExecuteNonQuery();
//                Response.Write("Saved the Add");
//            }
//            catch (Exception ex) { }
//            finally
//            {
//                if (con.State == ConnectionState.Open)
//                {
//                    con.Close();
//                }
//            }

//        }
//        protected void Reset()
//        {
//            txtname.Text = "";
//            txtemail.Text = string.Empty;
//        }
//    }
//}