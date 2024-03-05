<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admins.Master" AutoEventWireup="true" CodeBehind="AddSubCategory.aspx.cs" Inherits="deep.Admin.SubCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <div class ="container ">
            <div class ="form-horizontal ">
                <br />
                <br />

                <h2>Add SubCategory</h2>
                <hr />
                  <div class ="form-group">
                    <asp:Label ID="Label3" CssClass ="col-md-2 control-label " runat="server"  Text="CompanyName"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:DropDownList ID="ddlBrand" CssClass="form-control" runat="server" AutoPostBack="true"   OnSelectedIndexChanged="ddlBrand_SelectedIndexChanged1"  ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass ="text-danger "    ErrorMessage="*plz Enter Main CategoryID" ControlToValidate="ddlBrand" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                 <div class ="form-group">
                    <asp:Label ID="Label2" CssClass ="col-md-2 control-label " runat="server" Text=" CategoryName"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:DropDownList ID="ddlcategory" CssClass="form-control" runat="server"   ></asp:DropDownList>

                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorMainCatID" runat="server" CssClass="text-danger " ErrorMessage="* Enter  Categoryid" ControlToValidate="ddlcategory" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>


                <div class ="form-group">
                    <asp:Label ID="Label1" CssClass ="col-md-2 control-label " runat="server" Text="SubCategory Name"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:TextBox ID="txtSubCategory" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtSubCategoryName" runat="server" CssClass ="text-danger " ErrorMessage="* Enter SubCategory" ControlToValidate="txtSubCategory" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class ="form-group">
                    <div class ="col-md-2 "> </div>
                    <div class ="col-md-6 ">

                        <asp:Button ID="btnAddSubCategory" CssClass ="btn btn-success " runat="server" Text="Add SubCategory"  OnClick="btnAddSubCategory_Click"  />
                        
                    </div>
                </div>
                

            </div>

         <h1>Sub Categories</h1>
        <hr />

 <div class="panel panel-default">

               <div class="panel-heading"> All Sub Categories</div>


     <asp:repeater ID="rptrSubCat" runat="server">

         <HeaderTemplate>
             <table class="table">
                  <thead>
                    <tr>
                        <th>#</th>
                        <th>SubCategory</th>
                        <th>Category</th>
                        <th>Edit</th>

                    </tr>

                </thead>



            <tbody>
         </HeaderTemplate>


         <ItemTemplate>
             <tr>
                    <th> <%# Eval("Sid") %> </th>
                    <td><%# Eval("SName") %>   </td>
                    <td><%# Eval("cname") %>   </td>

                    <td>Edit</td>
                </tr>
         </ItemTemplate>


         <FooterTemplate>
             </tbody>

              </table>
         </FooterTemplate>

     </asp:repeater>

              
                
            

   
</div>



        </div>





</asp:Content>
