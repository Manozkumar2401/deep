<%@ Page Title="" Language="C#" MasterPageFile="~/Users.Master" AutoEventWireup="true" CodeBehind="Forgetpassword.aspx.cs" Inherits="deep.Forgetpassword1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container ">
        <asp:Label ID="txtlabel" runat="server" Text=""></asp:Label>
        <div class="center-page ">
            <h1>Forget Password</h1>
            <div class="row">
                <label class="col-xs-11">Username</label>
                <div class="col-xs-11">
                    <asp:TextBox ID="txtuser" class="form-control" runat="server" placeholder="Enter username"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="requser" runat="server"
                        BorderWidth="2px" CssClass="danger"
                        Display="Dynamic" ErrorMessage="fill username" Font-Bold="True"
                        Font-Italic="False" ControlToValidate="txtuser" SetFocusOnError="True"
                        ToolTip="Enter username"><img src="images/username.png" height="20px"  width="20px"  />  
                    </asp:RequiredFieldValidator>
                </div>
                <label class="col-xs-11">Password</label>
                <div class="col-xs-11">
                    <asp:TextBox ID="txtpass" ReadOnly="true" runat="server" class="form-control" placeholder="Get password"></asp:TextBox>
                </div>
                <label class="col-xs-11"></label>
                <div class="col-xs-11">
                    <asp:Button ID="btn_manage" Class="btn btn-success" runat="server" Text="Get password" />
                </div>
            </div>
            <p class="para-2">Not a member?<a href="SignUppage.aspx">create a account?</a></p>
        </div>
        <label class="col-xs-11"></label>
        <div class="col-xs-11">
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
