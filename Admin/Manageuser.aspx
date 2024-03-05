<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admins.Master" AutoEventWireup="true" CodeBehind="Manageuser.aspx.cs" Inherits="deep.Admin.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <%--<link href="../styleloginsignup.css" rel="stylesheet" />--%>
    <link href="../Custom.css" rel="stylesheet" />
    <script src="../sweetalert/dist/sweetalert2.min.js"></script>
    <script src="../sweetalert/dist/sweetalert2.all.min.js"></script>
    <script src="../sweetalert/jquery/jqery.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
   
            
     <div class="container ">
         <asp:Label ID="txtlabel" runat="server" Text=""></asp:Label>
         
 
         <div class="center-page " style="margin-top:60px" >
      <div class="row">
              <label  class="col-xs-11">Username</label> 
              <div class="col-xs-11">
              <asp:TextBox ID="txtuser" runat="server" class="form-control" placeholder="Enter Username" ></asp:TextBox>
              </div>
              <label  class="col-xs-11">Name</label>
    <div class="col-xs-11">     
       <asp:TextBox ID="txtname" runat="server" class="form-control" placeholder="Enter Name" ></asp:TextBox>
    </div>
            <div class="row">
       </div>
          <label  class="col-xs-11">Mobile</label>
    <div class="col-xs-11">

        <asp:TextBox ID="txtmobile" runat="server" class="form-control"   placeholder=" Monile no" ></asp:TextBox>
    </div>
       <label  class="col-xs-11">Email</label>
    <div class="col-xs-11">
        <asp:TextBox ID="txtemail" runat="server" class="form-control"   placeholder="Enter email" ></asp:TextBox>
    </div>



     <label  class="col-xs-11">Address</label>
    <div class="col-xs-11">
        <asp:TextBox ID="txtadd" runat="server" class="form-control"        placeholder="Enter address" ></asp:TextBox>
    </div>
     <label  class="col-xs-11">Password</label>
    <div class="col-xs-11">
      <asp:TextBox ID="txtpass" runat="server" class="form-control"     placeholder="Enter Password" ></asp:TextBox>
    </div>


     <label  class="col-xs-11">re-password</label>
    <div class="col-xs-11">
     <asp:TextBox ID="txtconpass" runat="server" class="form-control"   placeholder="re-password" ></asp:TextBox> 
    </div>

     

    

   <label  class="col-xs-11"></label>

    <div class="col-xs-11">
        <asp:Button ID="btn_manage" Class="btn btn-success" runat="server" Text="Create User" OnClick="Button1_Click" /> 
            
    </div>

<%-- </div>
             <p> By Clicking  The Sign Up Button,You Agree To Your
        <a href="#">Term And Condition </a> and<a href="#">Policy Privecy</a>
            </p>
        <p class="para-2"> Alredy Have an Account?<a href="Loginpage.aspx">Login Here </a></p>
    </div>
         --%>

          <br />
          <hr />

          
   <label  class="col-xs-11"></label>

    <div class="col-xs-11">
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            
    </div>
          </div>
             </div>
    

  
        </div>

     <div class="container">
   
   <hr />
    <div class="panel panel-primary">
      <div class="panel-heading"><h2>Manage user</h2> </div>
      <div class="panel-body">
           <div class="col-md-12">
              <div class="form-group">
                <div class="table table-responsive">
                  <asp:TextBox ID="TextBox1" runat="server" class="form-control"  Style="border: 2px solid red " Width="30%" CssClass="form-control" placeholder="Search User"
                       onkeyup="Search_Gridview(this)"  claceholder="re-password" ></asp:TextBox> 
         <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-border" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting">
        <Columns>
            <asp:BoundField DataField="Uid" HeaderText="UserId"></asp:BoundField>
            <asp:BoundField DataField="Uname" HeaderText="username"></asp:BoundField>
            <asp:BoundField DataField="name" HeaderText="name"></asp:BoundField>
            <asp:CommandField ShowDeleteButton="True"></asp:CommandField>
        
            <asp:TemplateField>

                <ItemTemplate>

                    <a href="Manageuser.aspx?Updateuser=<%#Eval("uid")%>">Update User</a>

                </ItemTemplate>

            </asp:TemplateField>
          

        </Columns>




    </asp:GridView>
                </div>
              
              </div>
           
           </div>
      
      
      </div>
      <div class="panel-footer">Panel Footer</div>
    </div>
    
</div>
    
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
</script>
</asp:Content>
