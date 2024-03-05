<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admins.Master" AutoEventWireup="true" CodeBehind="Addbrand.aspx.cs" Inherits="deep.Admin.Addbrand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    
    <div class ="container ">
    <br />
    <br />

            <div class ="form-horizontal ">
                <h2>Add Brand</h2>
                <hr />
                <div class ="form-group">
                    <asp:Label ID="Label1" CssClass ="col-md-2 control-label " runat="server" Text="BrandName"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:TextBox ID="txtBrand" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorBrandName" runat="server" CssClass ="text-danger " ErrorMessage="*plz Enter Brandname" ControlToValidate="txtBrand" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                

                <div class ="form-group">
                    <div class ="col-md-2 "> </div>
                    <div class ="col-md-4 ">

                        <asp:Button ID="btnAddbrand" CssClass ="btn btn-success " runat="server" Text="Add" OnClick="btnAddbrand_Click"  />
                        
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
                        <th>Brand</th>
                        <th>Edit</th>
                        <th>UPDATE</th>

                    </tr>

                </thead>



            <tbody>
         </HeaderTemplate>


         <ItemTemplate>
             <tr>
                  <td>  <%# Eval("id") %> </td>
                    <td><%# Eval("Name") %>   </td>

                   <td>Edit</td>


                  <td>  <a href="Addbrand.aspx?Updatebrand=<%#Eval("id")%>">UpdateBrandName </a></td>


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
