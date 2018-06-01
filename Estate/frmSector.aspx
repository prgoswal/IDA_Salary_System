<%@ Page Title="" Language="C#" MasterPageFile="~/Estate/MainMaster.master" AutoEventWireup="true" CodeFile="frmSector.aspx.cs" Inherits="frmSector" %>

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
                                        width:60%;
                                    }                                  
                            .tbl_hd{
                                background-color:#3c8dbc;
                                color:#fff;
                            }                            
                    </style>                              
    <div class="col-sm-8 col-sm-offset-2">
                        <div class="panel panel-primary mt10">
                            <div class="panel-heading">
                                <h3 class="panel-title">Sector Master</h3>
                            </div>
                            <div class="panel-body form-horizontal scheme-form-group">
                                <div class="form-group">
                                    <div class="row">
                                         <div class="col-xs-12 col-sm-12">
                                            <label class="col-xs-12 col-sm-5 sm_20 required">Scheme Name</label>
                                           <div class="col-xs-12 col-sm-7 sm_80" >                                           
                                <asp:DropDownList runat="server" ID="ddlSchName" CssClass="form-control">                                   
                                </asp:DropDownList>
                                                  <asp:CompareValidator CssClass="errorMsg" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Select Scheme Name" runat="server" ID="comparevalidator3" ValidationGroup="a" ControlToValidate="ddlSchName" ValueToCompare="0" Operator="NotEqual"></asp:CompareValidator>
                                            </div>
                                        </div>                                        
                                    </div>
                                </div>
                              
                                <div class="form-group">
                                    <div class="row">
                                          <div class="col-xs-12 col-sm-12">
                                            <label class="col-xs-12 col-sm-5 sm_20 required">Plot Type</label>
                                           <div class="col-xs-12 col-sm-7 sm_80" >                                           
                                <asp:DropDownList runat="server" ID="ddlPlotType" CssClass="form-control">                                    
                                </asp:DropDownList>
                                                 <asp:CompareValidator CssClass="errorMsg" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Select Plot Type" runat="server" ID="comparevalidator1" ValidationGroup="a" ControlToValidate="ddlPlotType" ValueToCompare="0" Operator="NotEqual"></asp:CompareValidator>
                                            </div>
                                        </div>                                   
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-6">
                                            <label class="col-xs-12 col-sm-5 required">Sector</label>
                                            <div class="col-xs-12 col-sm-7">                                           
                                                 <asp:TextBox runat="server" ID="txtSector" CssClass="form-control" placeholder="Sector"></asp:TextBox>   
                                                 <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSector" ErrorMessage="Enter Scheme No" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>                                                                                                                                                                         
                                                 </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-6">                                            
                                            <div class="col-xs-12 col-sm-7">
                                             <asp:Button runat="server" Text="Add" id="btnAdd" OnClick="btnAdd_Click"  ValidationGroup="a"  CssClass="btn btn-primary" />
                                        </div>
                                    </div>
                                </div>
                                    </div>                          
                                       <div class="col-xs-12 col-sm-8 col-sm-offset-2">
                           
                              <table  class="table table-bordered" style="margin-bottom:0px!important;">                              
                                   <tr class="tbl_hd">
                                       <th id="thPlotType" >Plot Type</th>   
                                       <th id="thSector" >Sector</th>                                                                                    
                                   </tr>                                                                                                                                                                                                                                                          
                               </table>
                            
                                  <div class="">
                                        <div style="Overflow-y:scroll ;max-height: 149px;">
                              <asp:GridView ID="GVSector"  CssClass="table table-bordered" AutoGenerateColumns="false"  ShowHeader="false" runat="server">
                                    <HeaderStyle CssClass="ims_head" />
                                    <Columns>
                                        <asp:TemplateField   ItemStyle-CssClass="clsPlotName">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblPlotType" Visible="false"  Text='<%#Eval("PlotTypeCode") %>'></asp:Label>                                                                                                                                 
                                              <asp:Label runat="server" ID="lblPlotTypeName"   Text='<%#Eval("PlotTypeName") %>'></asp:Label>
                                                   </ItemTemplate> 
                                        </asp:TemplateField>     
                                         <asp:TemplateField  ItemStyle-CssClass="clsSector">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblSector"  Text='<%#Eval("Sector") %>'></asp:Label>                                                                                                                                        
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
                                                                                                      
                            <div class="panel-footer">                                        
                                <asp:Button ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click"  CssClass="btn btn-success btnSave" />
                            <asp:Button ID="btnCleae" Text="Clear" runat="server"  CssClass="btn btn-default btnClear" OnClick="btnCleae_Click" />
                            <asp:Button ID="btnExit" runat="server" PostBackUrl="Dashboard.aspx" CssClass="btn btn-danger" Text="Exit" />
                            <div class="alertMsg success" runat="server"  id="pnlSuccess"></div>
                            <div class="alertMsg failed" runat="server" id="pnlfailed"></div>
                            </div>                                
                             </div>    
                        </div>
    
    <script>
        $(document).ready(function () {
          
            $('#thPlotType').width($('.clsPlotName').width()-12 );
            $('#thSector').width($('.clsSector').width() - 12);
        });
    </script> 
</asp:Content>

