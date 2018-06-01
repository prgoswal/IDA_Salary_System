<%@ Page Title="" Language="C#" MasterPageFile="~/Estate/MainMaster.master" AutoEventWireup="true" CodeFile="frmSchSector.aspx.cs" Inherits="frmSchSector" %>

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
                                            <label class="col-xs-12 col-sm-5 sm_20 required  control-label">Scheme Name</label>
                                           <div class="col-xs-12 col-sm-7 sm_80" >                                           
                                <asp:DropDownList runat="server" ID="ddlSchName" CssClass="form-control" OnSelectedIndexChanged="ddlSchName_SelectedIndexChanged" AutoPostBack="true">                                   
                                </asp:DropDownList>
                                                  <asp:CompareValidator CssClass="errorMsg" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Select Scheme Name" runat="server" ID="comparevalidator3" ValidationGroup="a" ControlToValidate="ddlSchName" ValueToCompare="0" Operator="NotEqual"></asp:CompareValidator>
                                            </div>
                                        </div>                                        
                                    </div>
                                </div>
                              
                           
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-6">
                                            <label class="col-xs-12 col-sm-5 required control-label" id="lblSectorName" runat="server">Sector Name</label>
                                            <div class="col-xs-12 col-sm-7">                                           
                                                 <asp:TextBox runat="server"  ID="txtSector" CssClass="form-control" style="text-transform:uppercase;" placeholder="Sector Name" MaxLength="10"></asp:TextBox>                         
                                                <%--  <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSector" ErrorMessage="Enter Scheme No" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>                                                                                                                                                                         --%>
                                                 <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtSector" FilterMode="ValidChars" FilterType="Numbers,UppercaseLetters,LowercaseLetters,Custom" ValidChars=" " />
                                                  </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-6">                                            
                                            <div class="col-xs-12 col-sm-7">
                                            <asp:Label runat="server" ID="lblSchMsg" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                    </div>                          
                              
                                    </div>                                                                         
                            <div class="panel-footer">                                        
                                <asp:Button ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" ValidationGroup="a"  CssClass="btn btn-success btnSave" />
                            <asp:Button ID="btnClear" Text="Clear" runat="server" OnClick="btnClear_Click"  CssClass="btn btn-default btnClear"/>
                            <asp:Button ID="btnExit" runat="server" PostBackUrl="Dashboard.aspx" CssClass="btn btn-danger" Text="Exit" />
                            <div class="alertMsg success" runat="server"  id="pnlSuccess"></div>
                            <div class="alertMsg failed" runat="server" id="pnlfailed"></div>
                            </div>   
                            <div class="panel-body">
                             <div class="row">                                
                                     <div class="col-xs-12">                           
                        <div style="padding-right:17px">
                              <table  class="table table-bordered" style="margin-bottom:0px!important;">                              
                                   <tr class="tbl_hd">
                                       <th style="width:10%;">Sr. No.</th>
                                       <th style="width:45%;">Scheme Name</th>   
                                       <th style="width:45%;">Sector Name</th>                                                                                    
                                   </tr>                                                                                                                                                                                                                                                          
                               </table>
                            </div>                                 
                               
                           
                        </div>
                              
                              </div> 
                                     <div style="Overflow-y:scroll ;max-height: 149px;margin-bottom:15px">
                              <asp:GridView ID="GvSchSector"  CssClass="table table-bordered mb0" AutoGenerateColumns="false"  ShowHeader="false" runat="server">
                                   <Columns>
                                          <asp:TemplateField  ItemStyle-CssClass="clsPlotName" ItemStyle-Width="10%">
                                      <HeaderStyle CssClass="ims_head" />
                                           <ItemTemplate>
                                         <%#Container.DataItemIndex+1 %>
                                                   </ItemTemplate> 
                                        </asp:TemplateField>  
                                        <asp:TemplateField   ItemStyle-CssClass="clsPlotName" ItemStyle-Width="45%">
                                            <ItemTemplate>                                                                                                                                                                              
                                              <asp:Label runat="server" ID="lblSchNameE"   Text='<%#Eval("SchNameE") %>'></asp:Label>
                                                   </ItemTemplate> 
                                        </asp:TemplateField>     
                                         <asp:TemplateField  ItemStyle-CssClass="clsSector" ItemStyle-Width="45%">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblSectorDesc"  Text='<%#Eval("SectorDesc") %>'></asp:Label>                                                                                                                                        
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
                                        </div>                             
                             </div>    </div>  
                     </div>
    
    <script>
        $(document).ready(function () {

            $('#thPlotType').width($('.clsPlotName').width() - 12);
            $('#thSector').width($('.clsSector').width() - 12);
        });
    </script> 
</asp:Content>

