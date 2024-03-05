<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ftpassword.aspx.cs" Inherits="deep.Forgetpassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="styleloginsignup.css" rel="stylesheet" />
       <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
     <link rel="stylesheet" href="sweetalert/dist/sweetalert2.min.css"/>
    
</head>
<body>
  
    <div class="signup-box">
        <h1>Forget Password</h1>
        <%-- <h4> It's free and only take A Minute</h4>--%>


        <form id="form1" runat="server">


            <asp:Label ID="txtlabel" runat="server"></asp:Label>
            <br />


               <asp:Label ID="lbluser" runat="server"  Text="User name">UserName</asp:Label>       
            <asp:TextBox ID="txtuser" CssClass="I" runat="server" placeholder="Enter username"></asp:TextBox>
            <asp:RequiredFieldValidator ID="requser" runat="server" 
                BorderWidth="2px" CssClass="danger"
               Display="Dynamic" ErrorMessage="fill username" Font-Bold="True" 
             Font-Italic="False" ControlToValidate="txtuser" SetFocusOnError="True" 
          ToolTip="Enter username"><img src="images/username.png" height="20px"  width="20px" />  </asp:RequiredFieldValidator>
            <br />
                       <asp:Label ID="lblpass" runat="server" Text="Name">Password</asp:Label>    
            <asp:TextBox ID="txtpass" ReadOnly="true" runat="server" ></asp:TextBox>
            <br />

            <asp:Button ID="btnsubmit" runat="server" Text="submit"  onclick="btnsubmit_Click"  />
            <input type="button" value="btn" id="id"  />

        </form>
        <p>
            <a href="#">
                <input type="checkbox" />
                Remember </a><a href="#">Forget password?</a>
        </p>
        <p class="para-2">Not a member?<a href="SignUp.aspx">create a account?</a></p>
    </div>
    
    <script src="sweetalert/jquery/jqery.js"> </script>
    <script src="sweetalert/dist/sweetalert2.all.min.js" > </script>
    <script>
        $(document).ready(function () {

            $("#btnsubmit").click(function () {

                //Swal.fire({
                //    title: 'Error!',
                //    text: 'Do you want to continue',
                //    icon: 'error',
                //    timer: 3000,
                //    confirmButtonText: 'Cool'

                //});
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Something went wrong!',
                    footer: '<a href="">Why do I have this issue?</a>'
                })
            });
        });

        /////////////////////////////////////
        $(document).ready(function () {

            $("#id").click(function () {

                Swal.fire({
                    title: 'Error!',
                    text: 'Do you want to continue',
                    icon: 'error',
                    timer: 3000,
                    confirmButtonText: 'Cool'

                });
            });
        });


    </script>

</body>
</html>

