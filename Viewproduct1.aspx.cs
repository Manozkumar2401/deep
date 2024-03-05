using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace deep
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["deep"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter adp;
        DataTable dt;
        SqlCommandBuilder cb;
        string query;
        protected void Page_Load(object sender, EventArgs e)
        {


            if(!IsPostBack)
            {

                getproduct();
            }



          
        }
        public void getproduct()
        {


            //   query = "select a.*, b.*,c.* , a.pname as ProductName ,A.pprice,A.pselprice, (A.pprice-A.pselprice) AS DISCOUNTAMOUNT ,B.imgname AS  ImageName , c.name as BrandName from tblproduct a inner join company c ON A.id=c.id  cross apply(select top 1 * from tblproductimages b where b.pid=a.pid  order by b.pid desc) b order by a.pid desc  select  pid, count(*) as pimage  from tblproductimages  group by pid order by pimage";


            query = "_selectproductrptr";
            cmd = new SqlCommand(query, con);
            adp = new  SqlDataAdapter(cmd);
            dt = new DataTable();
            adp.Fill(dt);
            RepterProduct.DataSource = dt;
            RepterProduct.DataBind();

            

        }
    }
}