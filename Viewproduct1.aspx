<%@ Page Title="" Language="C#" MasterPageFile="~/Users.Master" AutoEventWireup="true" CodeBehind="Viewproduct.aspx.cs" Inherits="deep.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row " style="padding-top:20px">
     
               
           
    </div>




    <div class="row" style="padding-top:20px" >

        <asp:Repeater ID="RepterProduct" runat="server">

      <ItemTemplate>
              <div class="col-sm-3 col-md-3">
           
          <div class=" thumbnail">              
                    <img src="images/ProductImage/<%# Eval("pid")%>/<%# Eval("ImageName") %><%#Eval("extension") %> "  alt="<%#Eval("ImageName") %>"/>
<%--              <img src="images/ProductImage/70/Majestic Man Slim Fit Cotton Blend Formal Shirts for Men298d9cba-4b10-4913-a13b-d0250000af5804.jpg"  alt="IMAGE"/>--%>
              <div class="caption"> 
                   <div class="probrand"><%# Eval("BrandName") %> </div>
                   <div class="proName"> <%# Eval("ProductName") %></div>
                   <div class="proPrice"> <span class="proOgPrice" > <%# Eval("pprice") %> </span> <%# Eval("pselprice") %> <span class="proPriceDiscount"> (<%# Eval("DISCOUNTAMOUNT") %> off) </span></div> 
                   
              </div>
          </div>
          
        </div>
               
      </ItemTemplate>
           
            </asp:Repeater>
    </div>
</asp:Content>
