<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admins.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="deep.Admin.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

       <script src="https://kit.fontawesome.com/b99e675b6e.js"></script>

       <script defer>
           
            function ImagePreview1(input) {

                if (input.files && input.files[0]) {

                    var reader = new FileReader();
                    reader.onload = function (e) {

                             $('#<%=imageproduct1.ClientID%>').prop('src', e.target.result)

                            .width(200)
                            .height(200);
                    };

                    reader.readAsDataURL(input.files[0]);
                }
           }
           function ImagePreview2(input) {

               if (input.files && input.files[0]) {

                   var reader = new FileReader();
                   reader.onload = function (e) {

                       $('#<%=imageproduct2.ClientID%>').prop('src', e.target.result)

                             .width(200)
                             .height(200);
                     };

                     reader.readAsDataURL(input.files[0]);
                 }
           }
           function ImagePreview3(input) {

               if (input.files && input.files[0]) {

                   var reader = new FileReader();
                   reader.onload = function (e) {

                       $('#<%=imageproduct3.ClientID%>').prop('src', e.target.result)

                              .width(200)
                              .height(200);
                      };

                      reader.readAsDataURL(input.files[0]);
                  }
           }
           function ImagePreview4(input) {

               if (input.files && input.files[0]) {

                   var reader = new FileReader();
                   reader.onload = function (e) {

                       $('#<%=imageproduct4.ClientID%>').prop('src', e.target.result)

                               .width(200)
                               .height(200);
                       };

                       reader.readAsDataURL(input.files[0]);
                   }
           }
           function ImagePreview5(input) {

               if (input.files && input.files[0]) {

                   var reader = new FileReader();
                   reader.onload = function (e) {

                       $('#<%=imageproduct5.ClientID%>').prop('src', e.target.result)

                                .width(200)
                                .height(200);
                        };

                        reader.readAsDataURL(input.files[0]);
                    }
           }
       </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div class ="container">
       <div class ="form-horizontal">
           
           <br />
           <asp:Label ID="Label21" runat="server" ></asp:Label>
           <br />
           <h2>Add Product</h2>
           <hr />
           <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
           <div class ="form-group">
               <asp:Label ID="Label1" runat="server" CssClass ="col-md-2 control-label" Text="Proudct Name"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtProductName" CssClass ="form-control" runat="server"></asp:TextBox>


               </div>
           </div>

           <div class ="form-group">
               <asp:Label ID="Label2" runat="server" CssClass ="col-md-2 control-label" Text="Price"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtPrice" CssClass ="form-control" runat="server"></asp:TextBox>
                   <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" FilterType="Numbers" TargetControlID="txtPrice" runat="server" />
               </div>
           </div>


           <div class ="form-group">
               <asp:Label ID="Label3" runat="server" CssClass ="col-md-2 control-label" Text="SellingPrice"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtsellPrice" CssClass ="form-control" runat="server"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" FilterType="Numbers" TargetControlID="txtsellPrice" runat="server" />
               </div>
           </div>


           <div class ="form-group">
               <asp:Label ID="Label4" runat="server" CssClass ="col-md-2 control-label" Text="Brand"></asp:Label>
               <div class ="col-md-3">
                   <asp:DropDownList ID="ddlBrand" CssClass ="form-control" AutoPostBack="True" runat="server"  OnSelectedIndexChanged="ddlBrand_SelectedIndexChanged" ></asp:DropDownList>
               </div>
           </div>


           <div class ="form-group">
               <asp:Label ID="Label5" runat="server" CssClass ="col-md-2 control-label" Text="Category"></asp:Label>
               <div class ="col-md-3">
                   <asp:DropDownList ID="ddlCategory" CssClass ="form-control"  OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"  runat="server" AutoPostBack="True" ></asp:DropDownList>
               </div>
           </div>


           <div class ="form-group">
               <asp:Label ID="Label6" runat="server" CssClass ="col-md-2 control-label" Text="SubCategory"></asp:Label>
               <div class ="col-md-3">
                   <asp:DropDownList ID="ddlSubCategory" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubCategory_SelectedIndexChanged"></asp:DropDownList>
               </div>
           </div>


           <div class ="form-group">
               <asp:Label ID="Label19" runat="server" CssClass ="col-md-2 control-label" Text="Gender"></asp:Label>
               <div class ="col-md-3">
                   <asp:DropDownList ID="ddlGender" CssClass ="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGender_SelectedIndexChanged " ></asp:DropDownList>
               </div>
           </div>


            <div class ="form-group">
               <asp:Label ID="Label7" runat="server" CssClass ="col-md-2 control-label" Text="Size"></asp:Label>
               <div class ="col-md-3">
                   <asp:CheckBoxList ID="cblSize" CssClass ="form-control" RepeatDirection="Horizontal"  runat="server"></asp:CheckBoxList>

               </div>
           </div>

           <div class ="form-group">
               <asp:Label ID="Label20" runat="server" CssClass ="col-md-2 control-label" Text="Quantity"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtQuantity" CssClass ="form-control" runat="server"></asp:TextBox>
                   <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" FilterType="Numbers"
                                TargetControlID="txtQuantity" runat="server" />
               </div>
           </div>

            <div class ="form-group">
               <asp:Label ID="Label8" runat="server" CssClass ="col-md-2 control-label" Text="Description"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtDescription" TextMode ="MultiLine"  CssClass ="form-control" runat="server" Height="300px"></asp:TextBox>
              <ajaxToolkit:HtmlEditorExtender ID="HtmlEditorExtender1" EnableSanitization="false" TargetControlID="txtDescription" runat="server"></ajaxToolkit:HtmlEditorExtender>

               </div>
           </div>


            <div class ="form-group">
               <asp:Label ID="Label9" runat="server" CssClass ="col-md-2 control-label"  Height="300px" Text="Product Details"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtPDetail" TextMode ="MultiLine" CssClass ="form-control" runat="server"></asp:TextBox>
                <ajaxToolkit:HtmlEditorExtender ID="HtmlEditorExtender2" EnableSanitization="false" TargetControlID="txtPDetail" runat="server"></ajaxToolkit:HtmlEditorExtender>

               </div>
           </div>

           
            <div class ="form-group">
               <asp:Label ID="Label10" runat="server" CssClass ="col-md-2 control-label"   Height="300px" Text="Materials and Care"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtMatCare" TextMode ="MultiLine" CssClass ="form-control" runat="server"></asp:TextBox>
                 <ajaxToolkit:HtmlEditorExtender ID="HtmlEditorExtender3" EnableSanitization="false" TargetControlID="txtMatCare" runat="server"></ajaxToolkit:HtmlEditorExtender>

               </div>
           </div>

            <div class ="form-group">
               <asp:Label ID="Label11" runat="server" CssClass ="col-md-2 control-label" Text="Upload Image"></asp:Label>
               <div class ="col-md-3">
                   <asp:FileUpload ID="Fup1" CssClass ="form-control" runat="server" OnChange="ImagePreview1(this);" />
               </div>
           </div>

           <div class ="form-group">
               <asp:Label ID="Label12" runat="server" CssClass ="col-md-2 control-label" Text="Upload Image" ></asp:Label>
               <div class ="col-md-3">
                   <asp:FileUpload ID="Fup2" CssClass ="form-control" runat="server" OnChange="ImagePreview2(this);" />
               </div>
           </div>

           <div class ="form-group">
               <asp:Label ID="Label13" runat="server" CssClass ="col-md-2 control-label" Text="Upload Image" ></asp:Label>
               <div class ="col-md-3">
                   <asp:FileUpload ID="Fup3" CssClass ="form-control" runat="server"   OnChange="ImagePreview3(this);"/>
               </div>
           </div>

           <div class ="form-group">
               <asp:Label ID="Label14" runat="server" CssClass ="col-md-2 control-label" Text="Upload Image"></asp:Label>
               <div class ="col-md-3">
                   <asp:FileUpload ID="Fup4" CssClass ="form-control" runat="server"   OnChange="ImagePreview4(this);"/>
               </div>
           </div>



            <div class ="form-group">
               <asp:Label ID="Label15" runat="server" CssClass ="col-md-2 control-label" Text="Upload Image"></asp:Label>
               <div class ="col-md-3">
                   <asp:FileUpload ID="Fup5" CssClass ="form-control" runat="server"  OnChange="ImagePreview5(this);" />
               </div>
           </div>

            <div class ="form-group">
               <asp:Label ID="Label16" runat="server" CssClass ="col-md-2 control-label" Text="Free Delivery"></asp:Label>
               <div class ="col-md-3">
                   <asp:CheckBox ID="chFD" runat="server" />
               </div>
           </div>


            <div class ="form-group">
               <asp:Label ID="Label17" runat="server" CssClass ="col-md-2 control-label" Text="30 Days Return"></asp:Label>
               <div class ="col-md-3">
                   <asp:CheckBox ID="ch30Ret" runat="server" />
               </div>
           </div>


            <div class ="form-group">
               <asp:Label ID="Label18" runat="server" CssClass ="col-md-2 control-label" Text="COD"></asp:Label>
               <div class ="col-md-3">
                   <asp:CheckBox ID="cbCOD" runat="server" />
               </div>
           </div>


           <div class ="form-group">
                   
                    <div class ="col-md-6 ">

                        <asp:Button ID="btnAdd" CssClass="btn btn-success " runat="server" Text="ADD Product" OnClick="btnAdd_Click" />
                        
                    </div>


                </div>
         <%--   <div class ="form-group">
               
               <div class ="col-md-3">--%>

           <div>
               <asp:Image ID="imageproduct1" runat="server" CssClass="img-thumbnail" />
           </div>
           
           <div>
               <asp:Image ID="imageproduct2" runat="server" CssClass="img-thumbnail" />
           </div>
           <div>
               <asp:Image ID="imageproduct3" runat="server" CssClass="img-thumbnail" />
           </div>
           <div>
               <asp:Image ID="imageproduct4" runat="server" CssClass="img-thumbnail" />
           </div>
              <div>
               <asp:Image ID="imageproduct5" runat="server" CssClass="img-thumbnail" />
           </div>
           
         <%--      </div>
           </div>--%>

       </div>

    </div>
     <div class="container">
   
   <hr />
    <div class="panel panel-primary">
      <div class="panel-heading"><h2>Product Report</h2> </div>
      <div class="panel-body">
           <div class="col-md-12">
              <div class="form-group">
                <div class="table table-responsive">
                   <%--  <asp:GridView ID="GridView1" runat="server" CssClass="table" AutoGenerateColumns="false">
                    <Columns>  
                        <asp:BoundField DataField="PID" HeaderText="S.No." />  
                        <asp:BoundField DataField="PName" HeaderText="PName" />  
                        <asp:BoundField DataField="PPrice" HeaderText="Price" />  
                        <asp:BoundField DataField="PSelPrice" HeaderText="SellPrice" />  
                        <asp:BoundField DataField="Brand" HeaderText="Brand" />  
                        <asp:BoundField DataField="CatName" HeaderText="Category" />  
                        <asp:BoundField DataField="SubCatName" HeaderText="SubCategory" />

                        <asp:BoundField DataField="gender" HeaderText="gender" />  
                        <asp:BoundField DataField="SizeName" HeaderText="SizeName" />  
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                        
                        <asp:TemplateField HeaderText="Photo">  
                    <ItemTemplate>  
                        <%-- <img src="Images/ProductImages/<%# Eval("PID") %>/<%# Eval("ImageName") %><%# Eval("Extention") %>" alt="<%# Eval("ImageName") %>" style=" height:150px; width:150px;"/> --%>
                <%--    </ItemTemplate>  
                </asp:TemplateField>--%> 

                       <%-- <asp:CommandField ShowEditButton="true" />  
                        <asp:CommandField ShowDeleteButton="true" />--%>
                        
                    <%--     </Columns> 
                    </asp:GridView>--%>
                </div>
              
              </div>
           
           </div>
      
      
      </div>
      <div class="panel-footer">Panel Footer</div>
    </div>
    
</div>
     <%--<script type="text/javascript">
    function Search_Gridview(strKey) {
        var strData = strKey.value.toLowerCase().split(" ");
        var tblData = document.getElementById("<%=GridView1.ClientID %>");
        var rowData;
        for (var i = 1; i < tblData.rows.length; i++) {
            rowData = tblData.rows[i].innerHTML;
            var styleDisplay = 'none';
            for (var j = 0; j < strData.length; j++) {
                if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                    styleDisplay = '';
                else {
                    styleDisplay = 'none';
                    break;
                }
            }
            tblData.rows[i].style.display = styleDisplay;
        }
    }  
     </script>--%>


</asp:Content>
