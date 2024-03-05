using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace deep.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
                {


               // ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('welcome dear', 'success')", true);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
                       "swal('Good job!','Recored is Saved', 'success')", true);
            }
            else
            {
                Server.Transfer("../Login.aspx");
                
            }
            
        }

    }
}