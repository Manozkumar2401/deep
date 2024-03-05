<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admins.Master" AutoEventWireup="true" CodeBehind="BrandName.aspx.cs" Inherits="deep.Admin.BrandName" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="../Custom.css" rel="stylesheet" />
    <script src="../sweetalert/dist/sweetalert2.min.js"></script>
    <script src="../sweetalert/dist/sweetalert2.all.min.js"></script>
    <script src="../sweetalert/jquery/jqery.js"></script>


    <link href="../Custom.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <div class="center-page ">

        <div class="row">
            <label class="col-xs-11">Company name</label>
            <div class="col-xs-11">
                <asp:TextBox ID="txtcompany" runat="server" class="form-control"   placeholder="Enter Brand name"></asp:TextBox>
            </div>
             <label class="col-xs-11">Id</label>
            <div class="col-xs-11">
                <asp:TextBox ID="txtid" runat="server" class="form-control" AutoPostBack="true"  placeholder="Enter Brand id" OnTextChanged="txtid_TextChanged"></asp:TextBox>
            </div>
            <label class="col-xs-11"></label>

            <div class="col-xs-11">
                <asp:Button ID="btn_manage" Class="btn btn-success" runat="server" Text="Add Brand" OnClick="btn_manage_Click" />

            </div>
               <label class="col-xs-11"></label>

            <div class="col-xs-11">
            
            </div>
        </div>
    </div>

    <section>



         <div class="container">
   
   <hr />
    <div class="panel panel-primary">
      <div class="panel-heading"><h2>Product Report</h2> </div>
      <div class="panel-body">
           <div class="col-md-12">
              <div class="form-group">
                <div class="table table-responsive">


                     <asp:TextBox ID="TextBox1" runat="server" class="form-control"  Style="border: 2px solid red " CssClass="form-control" placeholder="Search User"
                       onkeyup="Search_Gridview(this)"  claceholder="re-password" ></asp:TextBox> 
            <asp:GridView ID="GridView1" runat="server" CssClass=" table table-hover table-border table-striped"  AutoGenerateColumns="False"  GridLines="Horizontal" HeaderStyle-BorderColor="Lime" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderWidth="2px" Font-Bold="True" >
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="CompanyId"></asp:BoundField>
                    <asp:BoundField DataField="name" HeaderText="Company Name"></asp:BoundField>
                    
            <asp:TemplateField>

                <ItemTemplate   >

                    <a href="BrandName.aspx?Updatebrand=<%#Eval("id")%>">UpdateBrandName </a>
                </ItemTemplate>
            </asp:TemplateField>
                   
                </Columns>
            </asp:GridView>

                    </div>
                 </div>
               </div>
                </div>
              </div>
              </div>
           



    </section>
    <script type="text/javascript">
    function Search_Gridview(strKey) {
        var strData = strKey.value.toLowerCase().split(" ");
        var tblData = document.getElementById("<%=GridView1.ClientID %>");
        var rowData;
        for (var i = 1; i < tblData.rows.length; i++) {
            rowData = tblData.rows[i].innerHTML;
            var styleDisplay = 'none';
            for (var j = 0; j < strData.length; j++) {
                if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                    styleDisplay = '';
                else {
                    styleDisplay = 'none';
                    break;
                }
            }
            tblData.rows[i].style.display = styleDisplay;
        }
    }  
    </script>--%>
</asp:Content>
