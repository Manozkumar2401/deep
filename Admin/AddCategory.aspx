<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admins.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="deep.Admin.Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <div class ="container ">
    <br />
    <br />

            <div class ="form-horizontal ">
                <h2> Category</h2>
                <hr />
                 <div class ="form-group">
                    <asp:Label ID="Label2" CssClass ="col-md-2 control-label " runat="server" Text="BrandId"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:DropDownList ID="ddlBrand" CssClass ="form-control" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorMainCatID" runat="server" CssClass ="text-danger " InitialValue=""   ErrorMessage="*plz Enter Main CategoryID" ControlToValidate="ddlBrand" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class ="form-group">
                    <asp:Label ID="Label1" CssClass ="col-md-2 control-label " runat="server" Text="CategoryName"></asp:Label>
                    <div class ="col-md-3 ">
                        <asp:TextBox ID="txtcategory" runat="server" CssClass="form-control"  placeholder="enter category"></asp:TextBox>
<%--                       <asp:TextBox ID="txtcategory1" CssClass="form-control" runat="server"></asp:TextBox>--%>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorBrandName" runat="server" CssClass ="text-danger " ErrorMessage="*plz Enter Brandname" ControlToValidate="txtcategory" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                

                <div class ="form-group">
                    <div class ="col-md-2 "> </div>
                    <div class ="col-md-4 ">

                        <asp:Button ID="addcategorybtn" CssClass ="btn btn-success " runat="server" Text="Add" onclick="addcategorybtn_Click"  />
                        
                    </div>

                   
                </div>
                
              


                 <div class="panel panel-default">

               <div class="panel-heading"> All Brands</div>


     <asp:repeater ID="rptrBrands" runat="server" >

         <HeaderTemplate>
             <table class="table">
                  <thead>
                    <tr>
                        <th>#</th>
                  
                        <th>Category</th>
                              <th>Brand</th>
                        <th>UPDATE</th>

                    </tr>

                </thead>



            <tbody>
         </HeaderTemplate>


         <ItemTemplate>
             <tr>
                  <td>  <%# Eval("cid") %> </td>
                    <td><%# Eval("cname") %>  </td>
                    <td><%# Eval("name") %>  </td>

                   <td>Edit</td>


                  <td>  <a href="Addbrand.aspx?UpdateCategory=<%#Eval("cid")%>">Updatecategory </a></td>


                        </tr>
                </ItemTemplate>
              

         <FooterTemplate>
             </tbody>

              </table>
         </FooterTemplate>

     </asp:repeater>
                 



                

                </div>





                </div>





            </div>


</asp:Content>
