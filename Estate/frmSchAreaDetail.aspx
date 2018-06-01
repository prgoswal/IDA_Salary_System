<%@ Page Title="" Language="C#" MasterPageFile="~/Estate/MainMaster.master" AutoEventWireup="true" CodeFile="frmSchAreaDetail.aspx.cs" Inherits="frmSchAreaDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:ScriptManager runat="server"></asp:ScriptManager>

       <style>
                                    .sm_20 .sm_80{
                                        float:left;
                                    }
                                    .sm_20{
                                       width:20%;
                                    }
                                    .sm_80{
                                        width:80%;
                                    }
           .tbl_hd {
               background-color: #3c8dbc;
               color: #fff;
           }
           .mb0 {
               margin-bottom:0
           }
                                </style>


    <div class="col-sm-8 col-sm-offset-2">
                        <div class="panel panel-primary mt10">
                            <div class="panel-heading">
                                <h3 class="panel-title">Scheme Wise Other Facility Area</h3>
                            </div>
                            <div class="panel-body form-horizontal scheme-form-group">                               
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-12">
                                            <label class="col-xs-12 col-sm-5 sm_20 required">Scheme Name</label>
                                           <div class="col-xs-12 col-sm-7 sm_80" >                                           
                                 <asp:DropDownList runat="server" CssClass="form-control" ID="ddlSchName" OnSelectedIndexChanged="ddlSchName_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    <asp:CompareValidator CssClass="errorMsg" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Select Scheme Name" runat="server" ID="comparevalidator1" ValidationGroup="add" ControlToValidate="ddlSchName" ValueToCompare="0" Operator="NotEqual"></asp:CompareValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-6">
                                            <label class="col-xs-12 col-sm-5">Total Scheme Area</label>
                                            <div class="col-xs-12 col-sm-7">                                               
                                          <asp:TextBox runat="server" ID="txtTotalSchArea" Enabled="false" placeholder="Total Scheme Area" MaxLength="10" CssClass="form-control"></asp:TextBox>                                         
                                               </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-6">
                                            <label class="control-label col-xs-12 col-sm-5">Total Ploting Area</label>
                                            <div class="col-xs-12 col-sm-7">
                                                <asp:TextBox ID="txtTotalPlotArea" runat="server" Enabled="false" CssClass="form-control" placeholder="Total Ploting Area" MaxLength="10"></asp:TextBox>                                                    
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                    <div class="form-group">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-6">
                                            <label class="col-xs-12 col-sm-5 required">Other Facility</label>
                                            <div class="col-xs-12 col-sm-7">                                      
                                                   <asp:DropDownList ID="ddlOtherFac" runat="server" CssClass="form-control">                                                   
                                                   </asp:DropDownList>   
                                               <asp:CompareValidator CssClass="errorMsg" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Select Other Facility" runat="server" ID="comparevalidator2" ValidationGroup="add" ControlToValidate="ddlOtherFac" ValueToCompare="0" Operator="NotEqual"></asp:CompareValidator>                                        
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-6">
                                            <label class="control-label col-xs-12 col-sm-5 required">Area</label>
                                            <div class="col-xs-12 col-sm-7">

                                                <div class="row">
                                                    <div class="col-xs-8">  <asp:TextBox runat="server" ID="txtArea" MaxLength="10" placeholder="Area" CssClass="form-control"></asp:TextBox> 
                                                         <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtArea" FilterMode="ValidChars" FilterType="Numbers" ValidChars=" " />
                                                  <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtArea" ErrorMessage="Enter Area" ForeColor="Red" ValidationGroup="add"></asp:RequiredFieldValidator>                                       </div>
                                                    <div class="col-xs-4">
                                                        <asp:Button runat="server" Text="Add" id="btnAdd" OnClick="btnAdd_Click"  ValidationGroup="add"  CssClass="btn btn-primary text-right" />
                                                    </div>
                                                </div>


                                          
                                            </div>                                          
                                        </div>
                                          
                                    </div>                                     
                                </div>
                                   
                            <div class="row">
                                
                                     <div class="col-xs-12">
                           

                        <div style="padding-right:17px">
                              <table  class="table table-bordered" style="margin-bottom:0px!important;">                              
                                   <tr class="tbl_hd">
                                       <th style="width:10%;">Sr. No.</th>
                                       <th style="width:40%;">Other Facility</th>   
                                       <th style="width:40%;">Area</th>  
                                       <th style="width:10%;"></th>                                                                                  
                                   </tr>                                                                                                                                                                                                                                                          
                               </table>
                            </div>
                                   <div class="">
                                        <div style="Overflow-y:scroll ;max-height: 149px;border-bottom:1px solid #ddd;margin-bottom:15px">
                              <asp:GridView ID="GVOtherFacility"  CssClass="table table-bordered mb0" OnRowCommand="GVOtherFacility_RowCommand" AutoGenerateColumns="false"  ShowHeader="false" runat="server">
                                    <HeaderStyle CssClass="ims_head" />
                                    <Columns>
                                          <asp:TemplateField  ItemStyle-CssClass="clsPlotName" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                         <%#Container.DataItemIndex+1 %>
                                                   </ItemTemplate> 
                                        </asp:TemplateField>  
                                        <asp:TemplateField   ItemStyle-CssClass="clsPlotName" ItemStyle-Width="40%">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblOtherfacCode" Visible="false"  Text='<%#Eval("FacilityCode") %>'></asp:Label>                                                                                                                                 
                                              <asp:Label runat="server" ID="lblOtherfacName"   Text='<%#Eval("FacilityName") %>'></asp:Label>
                                                   </ItemTemplate> 
                                        </asp:TemplateField>     
                                         <asp:TemplateField  ItemStyle-CssClass="clsSector" ItemStyle-Width="40%">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblAreaName"  Text='<%#Eval("FacilityAreaSqYard") %>'></asp:Label>                                                                                                                                        
                                            </ItemTemplate> 
                                        </asp:TemplateField>   
                                         <asp:TemplateField ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnDelete" Text="Del" CommandName="DeleteRow" CommandArgument='<%#Container.DataItemIndex %>' CssClass="btn btn-xs btn-danger add_btn" runat="server"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                                                         
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>  

                                        </div></div>
                           
                        </div>
                                </div>
                                      <div class="form-group">
                                    <div class="row">
                                     
                                        <div class="col-xs-12 col-sm-6 pull-right">
                                            <label class="control-label col-xs-12 col-sm-5">Total Other Facility Area</label>
                                            <div class="col-xs-12 col-sm-7">
                                                <asp:TextBox runat="server" CssClass="form-control" placeholder="Total Other Facility Area" ID="txtTotalfac"/>                                          
                                            </div>                                          
                                        </div>
                                          
                                    </div>                                     
                                </div>             
                                 </div> 
                            <div class="panel-footer">                                        
                                <asp:Button ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click"  CssClass="btn btn-success btnSave" />
                            <asp:Button ID="btnClear" Text="Clear" runat="server" OnClick="btnClear_Click"  CssClass="btn btn-default btnClear" />
                            <asp:Button ID="btnExit" runat="server" PostBackUrl="Dashboard.aspx" CssClass="btn btn-danger" Text="Exit" />
                            <div class="alertMsg success" runat="server"  id="pnlSuccess"></div>
                            <div class="alertMsg failed" runat="server" id="pnlfailed"></div>
                            </div>
                                </div>
                             </div>    



  
    <script>
        $(document).ready(function () {

            $('#thPlotType').width($('.clsPlotName').width() - 12);
            $('#thSector').width($('.clsSector').width() - 12);
        });
    </script> </asp:Content>