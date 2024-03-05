<%@ Page Title="" Language="C#" MasterPageFile="~/Users.Master" AutoEventWireup="true" CodeBehind="Loginpage.aspx.cs" Inherits="deep.Loginpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container ">
        <asp:Label ID="txtlabel" runat="server" Text=""></asp:Label>

        <div class="center-page ">
             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <h1>Sign In</h1>
            <div class="row">
                <label class="col-xs-11">Username</label>
                <div class="col-xs-11">
                    <asp:RequiredFieldValidator ID="requser" runat="server"
                        CssClass="danger"
                        Display="Dynamic" ErrorMessage="fill username" Font-Bold="True"
                        Font-Italic="False" ControlToValidate="txtuser" SetFocusOnError="True"
                        ToolTip="Enter username"><img src="images/username.png" height="20px"  width="20px" />  
                    </asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtuser" class="form-control" runat="server" placeholder="Enter username"></asp:TextBox>
                </div>
                <label class="col-xs-11">Password</label>
                <div class="col-xs-11">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        CssClass="danger"
                        Display="Dynamic" ErrorMessage="Please enter password" Font-Bold="True"
                        Font-Italic="False" ControlToValidate="txtpass" SetFocusOnError="True"
                        ToolTip="Enter username"><img src="images/ps.png" height="20px" width="20px" />  </asp:RequiredFieldValidator>
                    
                 
                    <asp:TextBox ID="txtpass" runat="server" placeholder="Enter Paasword" TextMode="Password" CssClass=" form-control"></asp:TextBox>


                </div>
               <label class="col-xs-11"></label>

                <div class="col-xs-11">
                    <asp:Button ID="btn_manage" Class="btn btn-success" runat="server" Text="Create User" OnClick="btn_manage_Click" />

                </div>
            </div>

            <p>
                <a href="#">
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                    Remember </a><a href="Forgetpassword.aspx">Forget password?</a>
            </p>
            <p class="para-2">Not a member?<a href="SignUppage.aspx">create a account?</a></p>
        </div>

        <label class="col-xs-11"></label>

        <div class="col-xs-11">
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

        </div>
    </div>









    <%-- <script>

        function validationform() {


            var user = document.getElementById("txtuser").Value;
            var pass = document.getElementById("txtpass").Value;

            if (user == "" & pass == "") {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Swal.fire({ icon: 'error',title: 'Oops...', text: 'Something went wrong!', footer: '<a href=>Why do I have this issue?</a>'})", true);
                return false;
            }
            else if (user == "" ) {
                return false;
            }
            else if ( pass == "") {
                return false;
            }
            else if (user == "" & pass == "") {
                return false;
            }

        }





    </script>--%>
</asp:Content>
