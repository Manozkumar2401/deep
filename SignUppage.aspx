<%@ Page Title="" Language="C#" MasterPageFile="~/Users.Master" AutoEventWireup="true" CodeBehind="SignUppage.aspx.cs" Inherits="deep.SuinUppage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


   <style>

       .barborder{
           border:2px black ridge;
           width:120px
       }

       .poor{
           background-color:darkred;
       }
       .weak{
           background-color:red;
       }
       .average{
           background-color:blue;
       }
        .strong{
           background-color:green;
       }



   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container ">
        <asp:Label ID="txtlabel" runat="server" Text=""></asp:Label>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="center-page ">
            <div class="row">
                <label class="col-xs-11">Username</label>
                <div class="col-xs-11">
                    <asp:RequiredFieldValidator ID="requser" runat="server" 
                         CssClass="danger"
                        Display="Dynamic" ErrorMessage="fill username" Font-Bold="True"
                        Font-Italic="False" ControlToValidate="txtuser" SetFocusOnError="True"
                        ToolTip="Enter username"><img src="images/username.png" height="20px"  width="20px" />
                    </asp:RequiredFieldValidator>     <asp:TextBox ID="txtuser" runat="server" class="form-control" placeholder="Enter username"></asp:TextBox>
                </div>
                <label class="col-xs-11">Name</label>
                <div class="col-xs-11">
                    <div>
                    <asp:RequiredFieldValidator ID="reqname" runat="server" 
                        CssClass="danger"
                        Display="Dynamic" ErrorMessage="Please enter Name" Font-Bold="True"
                        Font-Italic="False" ControlToValidate="txtname" SetFocusOnError="True"
                        ToolTip="Enter username"><img src="images/user.png" height="20px" width="20px" />
                    </asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtname" runat="server" class="form-control" placeholder="Enter Name"></asp:TextBox>
                        </div>
                </div>
                <div class="row">
                </div>
                <label class="col-xs-11">Mobile</label>
                <div class="col-xs-11">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        CssClass="danger"
                        Display="Dynamic" ErrorMessage="Please enter mobileno" Font-Bold="True"
                        Font-Italic="False" ControlToValidate="txtmobile" SetFocusOnError="True"
                        ToolTip="Enter username"><img src="images/em.png" height="20px" width="20px" /> 

                    </asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtmobile" runat="server" class="form-control"  placeholder=" Monile no"></asp:TextBox>
                   <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" FilterType="Numbers"
                                TargetControlID="txtmobile" runat="server" />
                </div>
                <label class="col-xs-11">Email</label>
                <div class="col-xs-11">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        CssClass="danger"
                        Display="Dynamic" ErrorMessage="Please enter Email" Font-Bold="True"
                        Font-Italic="False" ControlToValidate="txtemail" SetFocusOnError="True"
                        ToolTip="Enter username"><img src="images/em.png" height="20px" width="20px" /> 

                    </asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtemail" runat="server" class="form-control" TextMode="Email" placeholder="Enter Email"></asp:TextBox>
                </div>
                <label class="col-xs-11">Address</label>
                <div class="col-xs-11">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        CssClass="danger"
                        Display="Dynamic" ErrorMessage="Please enter Email" Font-Bold="True"
                        Font-Italic="False" ControlToValidate="txtadd" SetFocusOnError="True"
                        ToolTip="Enter username"><img src="images/em.png" height="20px" width="20px" />
                    </asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtadd" runat="server" class="form-control" placeholder="Enter address"></asp:TextBox>
                </div>
                <label class="col-xs-11">Password</label>
                <div class="col-xs-11">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        CssClass="danger"
                        Display="Dynamic" ErrorMessage="Please enter password" Font-Bold="True"
                        Font-Italic="False" ControlToValidate="txtpass" SetFocusOnError="True"
                        ToolTip="Enter username"><img src="images/username1.png" height="20px" width="20px" /> 
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                        ControlToValidate="txtpass" Enabled="True"
                        SetFocusOnError="True" ToolTip="please enter valid password"
                        ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"
                        ErrorMessage="Password must contain: Minimum 8 characters atleast 1 Alphabet and 1 Number">
                    </asp:RegularExpressionValidator>
                    <asp:TextBox ID="txtpass" runat="server" class="form-control"  TextMode="Password" placeholder="Enter Paasword"></asp:TextBox>            
                    <ajaxToolkit:PasswordStrength ID="PasswordStrength1" runat="server" TargetControlID="txtpass" MinimumLowerCaseCharacters="5" MinimumNumericCharacters="5" MinimumSymbolCharacters="1" MinimumUpperCaseCharacters="5" PreferredPasswordLength="16" PrefixText="Your password is " StrengthIndicatorType="Text" HelpStatusLabelID="Label2" BarBorderCssClass=" barborder" HelpHandlePosition="LeftSide" />  
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>

                </div>
                <label class="col-xs-11">re-password</label>
                <div class="col-xs-11">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        CssClass="danger"
                        Display="Dynamic" ErrorMessage="Re-enter password" Font-Bold="True"
                        Font-Italic="False" ControlToValidate="txtconpass" SetFocusOnError="True"
                        ToolTip="Enter username"><img src="images/username1.png" height="20px" width="20px" />  </asp:RequiredFieldValidator>
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
                    <asp:TextBox ID="txtconpass" runat="server" class="form-control"  TextMode="Password" placeholder="confirm Paasword"></asp:TextBox>

                </div>
                <label class="col-xs-11"></label>

                <div class="col-xs-11">
                    <asp:Button ID="btn_manage" Class="btn btn-success" runat="server" Text="Create User" OnClick="btn_manage_Click" />
                </div>
            </div>
            <p>
                By Clicking  The Sign Up Button,You Agree To Your
        <a href="#">Term And Condition </a>and<a href="#">Policy Privecy</a>
            </p>
            <p class="para-2">Alredy Have an Account?<a href="Loginpage.aspx">Login Here </a></p>
        </div>
        <br />
        <hr />
        <label class="col-xs-11"></label>

        <div class="col-xs-11">
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

        </div>
    </div>
   
 
</asp:Content>
