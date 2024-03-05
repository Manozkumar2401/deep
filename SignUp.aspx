<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="deep.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <link href="styleloginsignup.css" rel="stylesheet" />
    <link rel="stylesheet" href="sweetalert/dist/sweetalert2.min.css" />


</head>
<body>
    <%-- <form id="form1"  runat="server">

    <div>
            
          <!-- Fixed navbar -->
            <nav class="navbar navbar-default navbar-fixed-top">
                <div class="container">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="#">deep</a>
                    </div>
                    <div id="navbar" class="navbar-collapse collapse">
                        <ul class="nav navbar-nav ">
                            <li class="active"><a href="Index.aspx">Home</a></li>
                            <li><a href="About.aspx">About</a></li>
                            <li><a href="Contect.aspx">Contact</a></li>
                            <li><a href="Service.aspx">Services</a></li>
                                <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button"
                                    aria-haspopup="true" aria-expanded="false">Service <span class="caret"></span></a>
                                <ul class="dropdown-menu">
                                     <li class="dropdown-header"> Men</li>
                               <li><a href="#">Shirt</a> </li>
                               <li><a href="#">T-shirt</a> </li>
                               <li><a href="#">Denims</a> </li>
                               <li role="separator" class="dropdown-divider" style="color:red"></li>
                               <li class="dropdown-header"> Women</li>
                               <li><a href="#">Top</a> </li>
                               <li><a href="#">laggings</a> </li>
                               <li><a href="#">Denims</a> </li>
                              <li role="separator" class="dropdown-divider"></li>    
                                </ul>
                            </li>
                      
                        </ul>

                        <ul class="nav navbar-nav navbar-right">
                            <li><a href="login.aspx">Login</a></li>
                         
                       
                        </ul>
                    </div>
                    <!--/.nav-collapse -->
                </div>
            </nav>--%>


    <%--<div class="container ">
 
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

        <asp:TextBox ID="txtmobile" runat="server" class="form-control"    placeholder=" Monile no" ></asp:TextBox>
    </div>
       <label  class="col-xs-11">Email</label>
    <div class="col-xs-11">
        <asp:TextBox ID="txtemail" runat="server" class="form-control"     placeholder="Enter email" ></asp:TextBox>
    </div>



     <label  class="col-xs-11">Address</label>
    <div class="col-xs-11">
        <asp:TextBox ID="txtadd" runat="server" class="form-control"      placeholder="Enter address" ></asp:TextBox>
    </div>
     <label  class="col-xs-11">Password</label>
    <div class="col-xs-11">
      <asp:TextBox ID="txtpass" runat="server" class="form-control"       placeholder="Enter Password" ></asp:TextBox>
    </div>


     <label  class="col-xs-11">re-password</label>
    <div class="col-xs-11">
     <asp:TextBox ID="txtconpass" runat="server" class="form-control"     placeholder="re-password" ></asp:TextBox> 
    </div>

     

    

   <label  class="col-xs-11"></label>

    <div class="col-xs-11">
        <asp:Button ID="Button1" Class="btn btn-success" runat="server" Text="Button" OnClick="Button1_Click" /> 
            
    </div>

 </div>
             <p> By Clicking  The Sign Up Button,You Agree To Your
        <a href="#">Term And Condition </a> and<a href="#">Policy Privecy</a>
            </p>
        <p class="para-2"> Alredy Have an Account?<a href="Loginpage.aspx">Login Here </a></p>
    </div>
          

         
  </div>






         </div>


      
             <div class="container-fluid">
                 <footer class="footer-pos">
                    <div class="container">
                        <p class="pull-right"><a href="#" >Back To Page </a>  </p>
                        <p> 
                            <a href="Index.aspx">Home</a>&middot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="About.aspx">About</a>&middot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="Contect.aspx">Contect</a>&middot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="Service.aspx">Services</a>&middot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;


                        </p>
                        <hr />
                    </div>
                 </footer>--%>
    <%-- </div>--%>





    <%-- </form>--%>



    <div class="signup-box">
        <h1>Sign UP</h1>
        <h4>It's free and only take A Minute</h4>


        <form id="form1" runat="server">

            <asp:Label ID="txtlabel" runat="server"></asp:Label>
            <br />



            <asp:Label ID="lbluser" runat="server" Text="User name">UserName</asp:Label>
            <asp:TextBox ID="txtuser"  runat="server" placeholder="Enter username"></asp:TextBox>
            <asp:RequiredFieldValidator ID="requser" runat="server"
                 CssClass="danger"
                Display="Dynamic" ErrorMessage="fill username" Font-Bold="True"
                Font-Italic="False" ControlToValidate="txtuser" SetFocusOnError="True"
                ToolTip="Enter username"><img src="image/username.png" height="20px"  width="20px" />
            </asp:RequiredFieldValidator>


            <asp:Label ID="lblname" runat="server" Text="Name"> Name</asp:Label>


            <asp:TextBox ID="txtname" runat="server" placeholder="Enter Name"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqname" runat="server" BackColor="Orange"
                CssClass="danger"
                Display="Dynamic" ErrorMessage="Please enter Name" Font-Bold="True"
                Font-Italic="False" ControlToValidate="txtname" SetFocusOnError="True"
                ToolTip="Enter username"><img src="image/user.png" height="20px" width="20px" /></asp:RequiredFieldValidator>

            <asp:Label ID="lblmobile" runat="server">Mobile</asp:Label>


            <asp:TextBox ID="txtmobile" runat="server" placeholder="Enter Mobile"></asp:TextBox>


            <asp:Label ID="lblemail" runat="server"> Email</asp:Label>


            <asp:TextBox ID="txtemail" runat="server" placeholder="Enter Email"></asp:TextBox>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" BackColor="Orange"
                CssClass="danger"
                Display="Dynamic" ErrorMessage="Please enter Email" Font-Bold="True"
                Font-Italic="False" ControlToValidate="txtemail" SetFocusOnError="True"
                ToolTip="Enter username"><img src="image/em.png" height="20px" width="20px" />  </asp:RequiredFieldValidator>


            <asp:Label ID="lbladd" runat="server"> Address</asp:Label>


            <asp:TextBox ID="txtadd" runat="server" placeholder="Enter address"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" BackColor="Orange"
                CssClass="danger"
                Display="Dynamic" ErrorMessage="Please enter Email" Font-Bold="True"
                Font-Italic="False" ControlToValidate="txtadd" SetFocusOnError="True"
                ToolTip="Enter username"><img src="image/em.png" height="20px" width="20px" />  </asp:RequiredFieldValidator>



            <asp:Label ID="lblpass" runat="server">Password</asp:Label>

            <asp:TextBox ID="txtpass" runat="server" placeholder="Enter Paasword"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" BackColor="Orange"
                CssClass="danger"
                Display="Dynamic" ErrorMessage="Please enter password" Font-Bold="True"
                Font-Italic="False" ControlToValidate="txtpass" SetFocusOnError="True"
                ToolTip="Enter username"><img src="image/username1.png" height="20px" width="20px" />  </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                ControlToValidate="txtpass" Enabled="True"
                SetFocusOnError="True" ToolTip="please enter valid password"
                ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"
                ErrorMessage="Password must contain: Minimum 8 characters atleast 1 Alphabet and 1 Number">
            </asp:RegularExpressionValidator>


            <asp:Label ID="lblconpass" runat="server">Password</asp:Label>

            <asp:TextBox ID="txtconpass" runat="server" placeholder="confirm Paasword"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" BackColor="Orange"
                CssClass="danger"
                Display="Dynamic" ErrorMessage="Re-enter password" Font-Bold="True"
                Font-Italic="False" ControlToValidate="txtconpass" SetFocusOnError="True"
                ToolTip="Enter username"><img src="image/username1.png" height="20px" width="20px" />  </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                ControlToValidate="txtconpass" Enabled="False"
                SetFocusOnError="True" ToolTip="please enter valid password"
                ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"
                ErrorMessage="Password must contain: Minimum 8 characters atleast 1 Alphabet and 1 Number" Display="Dynamic">

            </asp:RegularExpressionValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server"
                ErrorMessage="Password does not match"
                ValueToCompare="txtconpass" ControlToCompare="txtpass"
                Display="Dynamic" ControlToValidate="txtconpass"></asp:CompareValidator>


            <asp:Button ID="btnsubmit" runat="server" Text="submit" OnClick="btnsubmit_Click" />
            <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false" runat="server" />

        </form>
        <p>
            By Clicking  The Sign Up Button,You Agree To Your
        <a href="#">Term And Condition </a>and<a href="#">Policy Privecy</a>
        </p>
        <p class="para-2">Alredy Have an Account?<a href="Login.aspx">Login Here </a></p>
    </div>



    <script src="sweetalert/jquery/jqery.js"> </script>
    <script src="sweetalert/dist/sweetalert2.all.min.js"> </script>
    <script>
        $(document).ready(function () {

            $("#btnsubmit").click(function () {

                Swal.fire({
                    title: 'Do you want to save the changes?',
                    showDenyButton: true,
                    showCancelButton: true,
                    confirmButtonText: 'Save',
                    denyButtonText: `Don't save`,
                    timer: 3000
                }).then((result) => {
                    /* Read more about isConfirmed, isDenied below */
                    if (result.isConfirmed) {
                        Swal.fire('Saved!', '', 'success')
                    } else if (result.isDenied) {
                        Swal.fire('Changes are not saved', '', 'info')
                    }
                })
            });
        });

        ///////////////////////////////////////
        //$(document).ready(function () {

        //    $("#id").click(function () {

        //        Swal.fire({
        //            title: 'Error!',
        //            text: 'Do you want to continue',
        //            icon: 'error',
        //            timer: 3000,
        //            confirmButtonText: 'Cool'

        //        });
        //    });
        //});


    </script>

</body>
</html>
