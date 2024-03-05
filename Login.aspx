<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="deep.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="sweetalert/dist/sweetalert2.all.min.js"></script>
    
    <script src="sweetalert/dist/sweetalert2.min.js"></script>
    <script src="sweetalert/jquery/jqery.js"></script>
    <link href="styleloginsignup.css" rel="stylesheet" />
        <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
</head>
<body>
  
    <div class="signup-box">
        <h1>Sign In</h1>
        <%-- <h4> It's free and only take A Minute</h4>--%>


        <form id="form1" runat="server">


            <asp:Label ID="txtlabel" runat="server"></asp:Label>
            <br />


               <asp:Label ID="lbluser" runat="server"  Text="User name">UserName</asp:Label>       
            <asp:TextBox ID="txtuser" CssClass="I" runat="server" placeholder="Enter username"></asp:TextBox>
            <asp:RequiredFieldValidator ID="requser" runat="server" BackColor="Orange"
                BorderWidth="2px" CssClass="danger"
               Display="Dynamic" ErrorMessage="fill username" Font-Bold="True" 
             Font-Italic="False" ControlToValidate="txtuser" SetFocusOnError="True" 
          ToolTip="Enter username"><img src="image/username.png" height="20px"  width="20px" />  </asp:RequiredFieldValidator>
            <br />
                       <asp:Label ID="lblpass" runat="server" Text="Name">Password</asp:Label>    
            <asp:TextBox ID="txtpass" runat="server" placeholder="Enter Paasword"></asp:TextBox>

            <br />

            <asp:Button ID="btnsubmit" runat="server" Text="submit"  OnClick="btnsubmit_Click"  />

        </form>
        <p>
            <a href="#">
                <input type="checkbox" />
                Remember </a><a href="Forgetpassword.aspx">Forget password?</a>
        </p>
        <p class="para-2">Not a member?<a href="SignUp.aspx">create a account?</a></p>
    </div>

</body>
</html>
