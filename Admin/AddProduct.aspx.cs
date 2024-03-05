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
using System.Web.Services.Discovery;
using System.IO;
using static System.Net.WebRequestMethods;

namespace deep.Admin
{
    public partial class AddProduct : System.Web.UI.Page
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

                dropdowncompany();
                dropdowngender();
                ddlSubCategory.Enabled = false;
                ddlCategory.Enabled = false;
                ddlGender.Enabled = false;

            }

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

            ddlCategory.Enabled = true;
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

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSubCategory.Enabled = true;

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

            query = "select * from tblgender";
            cmd = new SqlCommand(query, con);
            adp = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adp.Fill(dt);
            ddlGender.DataSource = dt;
            ddlGender.DataValueField = "genderid";
            ddlGender.DataTextField = "gendername";
            ddlGender.DataBind();
            ddlGender.Items.Insert(0, new ListItem("--SelectGender--", "0"));



        }

        protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(ddlBrand.SelectedItem.Value);
            int cid = Convert.ToInt32(ddlCategory.SelectedItem.Value);
            int sid = Convert.ToInt32(ddlSubCategory.SelectedItem.Value);
            int genderid = Convert.ToInt32(ddlGender.SelectedItem.Value);

            query = "select * from tblsizes where id=@id and cid=@cid and sid=@sid and genderid=@genderid";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@cid", cid);
            cmd.Parameters.AddWithValue("@sid", sid);
            cmd.Parameters.AddWithValue("@genderid", genderid);
            adp = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adp.Fill(dt);
            cblSize.DataSource = dt;
            cblSize.DataValueField = "sizeid";
            cblSize.DataTextField = "sizename";
            cblSize.DataBind();

        }

        bool isValidTOExecute = false;

        private void insert()
        {
            string imagePath = string.Empty;
            string fileExtention = string.Empty;


            query = "_insertproduct";
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pname", txtProductName.Text.Trim());
            cmd.Parameters.AddWithValue("@pprice", txtPrice.Text.Trim());
            cmd.Parameters.AddWithValue("@pselprice", txtsellPrice.Text.Trim());
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(ddlBrand.SelectedItem.Value));
            cmd.Parameters.AddWithValue("@cid", Convert.ToInt32(ddlCategory.SelectedItem.Value));
            cmd.Parameters.AddWithValue("@sid", Convert.ToInt32(ddlSubCategory.SelectedItem.Value));
            cmd.Parameters.AddWithValue("@genderid", Convert.ToInt32(ddlGender.SelectedItem.Value));
            cmd.Parameters.AddWithValue("@pdiscreption", txtDescription.Text.Trim());
            cmd.Parameters.AddWithValue("@poroductdetails", txtPDetail.Text.Trim());
            cmd.Parameters.AddWithValue("@pmaterialcare", txtMatCare.Text.Trim());


            if (chFD.Checked == true)
            {
                cmd.Parameters.AddWithValue("@freedelivery", 1.ToString());
            }
            else
            {
                cmd.Parameters.AddWithValue("@freedelivery", 0.ToString());

            }
            if (ch30Ret.Checked == true)
            {
                cmd.Parameters.AddWithValue("@30dayrent", 1.ToString());
            }
            else
            {
                cmd.Parameters.AddWithValue("@30dayrent", 0.ToString());

            }
            if (cbCOD.Checked == true)
            {
                cmd.Parameters.AddWithValue("@cod", 1.ToString());
            }
            else
            {
                cmd.Parameters.AddWithValue("@cod", 0.ToString());

            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();


            }

            Int64 Pid = Convert.ToInt64(cmd.ExecuteScalar());


            for (int i = 0; i < cblSize.Items.Count; i++)
            {
                if (cblSize.Items[i].Selected == true)
                {
                    Int64 sizeid = Convert.ToInt64(cblSize.Items[i].Value);
                    int quantity = Convert.ToInt32(txtQuantity.Text.Trim());
                    // string query1 = "_insertproductSize";
                    string query1 = "insert  into tblproductsizequntity values(@pid,@sizeid,@quantity)";
                    SqlCommand cmd = new SqlCommand(query1, con);
                    cmd.Parameters.AddWithValue("@pid", Pid);
                    cmd.Parameters.AddWithValue("@sizeid", sizeid);
                    cmd.Parameters.AddWithValue("@quantity", quantity);

                    SqlDataAdapter adp3 = new SqlDataAdapter(cmd);
                    DataTable dt1 = new DataTable();
                    adp3.Fill(dt1);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire({icon: 'success',title: 'Your category has been inserted ',showConfirmButton: false,timer: 3300})", true);


                }




            }


            if (Fup1.HasFile)
            {
                // if (utils.isvalidextension(Fup1.FileName))
                //  {
                Guid obj = Guid.NewGuid();
                fileExtention = Path.GetExtension(Fup1.FileName);

               
                string savepath = Server.MapPath("~/Images/ProductImage/") + Pid;
                if (!Directory.Exists(savepath))
                {
                    Directory.CreateDirectory(savepath);
                }
                
           
                  Fup1.PostedFile.SaveAs(savepath + "\\" + txtProductName.Text.ToString().Trim() + obj.ToString()  + "01" + fileExtention);


                string query1 = "insert  into tblproductimages values(@productname,@pid,@fileextention)";
                SqlCommand cmd = new SqlCommand(query1, con);
                cmd.Parameters.AddWithValue("@pid", Pid);
                cmd.Parameters.AddWithValue("@productname",  txtProductName.Text.ToString().Trim() + obj.ToString() + "01");
                cmd.Parameters.AddWithValue("@fileextention", fileExtention);

                SqlDataAdapter adp4 = new SqlDataAdapter(cmd);
                DataTable dt2 = new DataTable();
                adp4.Fill(dt2);




            }

            else
            {
                Label21.Visible = true;
                Label21.Text = "Please select image";
                Label21.CssClass = "alert alert-danger";
                isValidTOExecute = false;
            }

            // else
            //   {

            //  }


            if (Fup2.HasFile)
            {
                // if (utils.isvalidextension(Fup1.FileName))
                //  {
                Guid obj = Guid.NewGuid();
                fileExtention = Path.GetExtension(Fup2.FileName);
                string savepath = Server.MapPath("~/Images/ProductImage/") + Pid;
               
                if (!Directory.Exists(savepath))
                {
                    Directory.CreateDirectory(savepath);
                }

             //   Fup2.SaveAs(savepath + "\\" + txtProductName.Text.ToString().Trim() + "02");
                Fup1.PostedFile.SaveAs(savepath + "\\" + txtProductName.Text.ToString().Trim() + obj.ToString()+ "02"+ fileExtention );

                string query1 = "insert  into tblproductimages values(@productname,@pid,@fileextention)";
                SqlCommand cmd = new SqlCommand(query1, con);
                cmd.Parameters.AddWithValue("@pid", Pid);
                cmd.Parameters.AddWithValue("@productname", txtProductName.Text.ToString().Trim() + obj.ToString() + "02");
                cmd.Parameters.AddWithValue("@fileextention", fileExtention);

                SqlDataAdapter adp5 = new SqlDataAdapter(cmd);
                DataTable dt3 = new DataTable();
                adp5.Fill(dt3);




            }

            else
            {
                Label21.Visible = true;
                Label21.Text = "Please select image";
                Label21.CssClass = "alert alert-danger";
                isValidTOExecute = false;
            }

            // else
            //   {

            //  }



            if (Fup3.HasFile)
            {
                // if (utils.isvalidextension(Fup1.FileName))
                //  {
                Guid obj = Guid.NewGuid();
                fileExtention = Path.GetExtension(Fup3.FileName);
                string savepath = Server.MapPath("~/Images/ProductImage/") + Pid;
            
                if (!Directory.Exists(savepath))
                {
                    Directory.CreateDirectory(savepath);
                }
                 Fup3.PostedFile.SaveAs(savepath + "\\" + txtProductName.Text.ToString().Trim() + obj.ToString()  + "03" + fileExtention);
              //  Fup3.SaveAs(savepath + "\\" + txtProductName.Text.ToString().Trim() + "03");



                string query1 = "insert  into tblproductimages values(@productname,@pid,@fileextention)";
                SqlCommand cmd = new SqlCommand(query1, con);
                cmd.Parameters.AddWithValue("@pid", Pid);
                cmd.Parameters.AddWithValue("@productname", txtProductName.Text.ToString().Trim() + obj.ToString() + "03");
                cmd.Parameters.AddWithValue("@fileextention", fileExtention);

                SqlDataAdapter adp6 = new SqlDataAdapter(cmd);
                DataTable dt4 = new DataTable();
                adp6.Fill(dt4);




            }

            else
            {
                Label21.Visible = true;
                Label21.Text = "Please select image";
                Label21.CssClass = "alert alert-danger";
                isValidTOExecute = false;
            }

            // else
            //   {

            //  }
            if (Fup4.HasFile)
            {
                // if (utils.isvalidextension(Fup1.FileName))
                //  {
                Guid obj = Guid.NewGuid();
                fileExtention = Path.GetExtension(Fup4.FileName);
                string savepath = Server.MapPath("~/Images/ProductImage/") + Pid;
          
                if (!Directory.Exists(savepath))
                {
                    Directory.CreateDirectory(savepath);
                }
               // Fup4.SaveAs(savepath + "\\" + txtProductName.Text.ToString().Trim() + "04");
                 Fup4.PostedFile.SaveAs(savepath + "\\" + txtProductName.Text.ToString().Trim() + obj.ToString()  + "04" + fileExtention);


                string query1 = "insert  into tblproductimages values(@productname,@pid,@fileextention)";
                SqlCommand cmd = new SqlCommand(query1, con);
                cmd.Parameters.AddWithValue("@pid", Pid);
                cmd.Parameters.AddWithValue("@productname", txtProductName.Text.ToString().Trim() + obj.ToString() + "04");
                cmd.Parameters.AddWithValue("@fileextention", fileExtention);

                SqlDataAdapter adp7 = new SqlDataAdapter(cmd);
                DataTable dt5 = new DataTable();
                adp7.Fill(dt5);




            }

            else
            {
                Label21.Visible = true;
                Label21.Text = "Please select image";
                Label21.CssClass = "alert alert-danger";
                isValidTOExecute = false;
            }

            // else
            //   {

            //  }
            if (Fup5.HasFile)
            {
                // if (utils.isvalidextension(Fup1.FileName))
                //  {
                Guid obj = Guid.NewGuid();
                fileExtention = Path.GetExtension(Fup5.FileName);
                string savepath = Server.MapPath("~/Images/ProductImage/") + Pid;
                if (!Directory.Exists(savepath))
                {
                    Directory.CreateDirectory(savepath);
                }


                Fup5.PostedFile.SaveAs(savepath + "\\" + txtProductName.Text.ToString().Trim() + obj.ToString()  + "05" + fileExtention);
               // Fup5.SaveAs(savepath + "\\" + txtProductName.Text.ToString().Trim() + "05");
                string query1 = "insert  into tblproductimages values(@productname,@pid,@fileextention)";
                SqlCommand cmd = new SqlCommand(query1, con);
                cmd.Parameters.AddWithValue("@pid", Pid);
                cmd.Parameters.AddWithValue("@productname", txtProductName.Text.ToString().Trim()+ obj.ToString() + "05");
                cmd.Parameters.AddWithValue("@fileextention", fileExtention);

                SqlDataAdapter adp8= new SqlDataAdapter(cmd);
                DataTable dt6 = new DataTable();
                adp8.Fill(dt6);




            }

            else
            {
                Label21.Visible = true;
                //   Label21.Text = "Please select .jpg or.jpeg or .png image";
                Label21.Text = "Please select image";
                Label21.CssClass = "alert alert-danger";
                isValidTOExecute = false;
            }

            // else
            //   {

            //  }




        }























        //adp = new SqlDataAdapter(cmd);
        //dt = new DataTable();
        //adp.Fill(dt);




        //string query3 = "select * from tblproduct  ";

        //SqlCommand cmd1 = new SqlCommand(query3, con);


        //SqlDataReader dr = cmd1.ExecuteReader();
        //if (dr.HasRows)
        //{

        //    while (dr.Read())
        //    {
        //        int pid = Convert.ToInt32(dr["pid"].ToString());


        //        for (int i = 0; i < cblSize.Items.Count; i++)
        //        {

        //            Int64 sizeid = Convert.ToInt64(cblSize.Items[i].Value);
        //            int quantity = Convert.ToInt32(txtQuantity.Text.Trim());
        //            string query1 = "_insertproductSize";
        //            string query1 = "insert  into tblproductsizequntity values(@pid,@sizeid,@quantity)";
        //            SqlCommand cmd2 = new SqlCommand(query1, con);
        //            cmd.Parameters.AddWithValue("@pid", pid);
        //            cmd.Parameters.AddWithValue("@sizeid", sizeid);
        //            cmd.Parameters.AddWithValue("@quantity", quantity);

        //            SqlDataAdapter adp3 = new SqlDataAdapter(cmd2);
        //            DataTable dt5 = new DataTable();
        //            adp3.Fill(dt5);
        //            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('inserted successfully', 'success')", true);






        //        }
        //    }
        //}
        //else
        //{
        //    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('invalid product id', 'success')", true);
        //}









        protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlSubCategory.SelectedIndex != 0)
            {
                ddlGender.Enabled = true;
            }
            else
            {
                ddlGender.Enabled = false;

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            insert();
        }
    }
}
//@pname nvarchar(max)
//           ,@pprice money
//          , @pselprice money
//           , @id int
//           , @cid int
//           , @sid int
//           , @genderid int
//           , @sizeid int
//           , @pdiscreption nvarchar(max)
//           ,@poroductdetails nvarchar(max)
//           ,@pmaterialcare nvarchar(max)
//           ,@freedelivery int
//           ,@30dayrent int
//           , @cod int