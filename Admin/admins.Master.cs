using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace deep.Admin
{
    public partial class admins : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"]!=null)
            {


                lblsession.Text = Session["username"].ToString();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
         //   Session.Clear();
          //  Session.Abandon();
           // Response.Redirect("../loginpage.aspx");
        }
    }
}