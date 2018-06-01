<%@ Page Title="" Language="C#" MasterPageFile="~/Estate/MainMaster.master" AutoEventWireup="true" CodeFile="frmPlotTypeMaster.aspx.cs" Inherits="frmPlotTypeMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:ScriptManager ID="scr" runat="server"></asp:ScriptManager>


     <div class="col-xs-12 col-sm-8 col-sm-offset-2">
            <div class="panel panel-primary mt10">
                <div class="panel-heading">
                    <h3 class="panel-title">Plot Type Master</h3>
                    <!-- /.box-tools -->
                </div>
                <!-- /.box-header -->
                <div class="panel-body form-horizontal">
                    <style>
                        .tbl_hd{
                            background-color:#3c8dbc;
                            color:#fff;
                        }
                    </style>
                    <div class="row">
                        <div class="col-xs-12 col-sm-6">
                            
                          <div class="form-group">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-12">
                                            <label class="col-xs-12 col-sm-5 required">Plot Type</label>
                                            <div class="col-xs-12 col-sm-7">
                                             <asp:TextBox runat="server" ID="txtPlotType" MaxLength="70" placeholder="Plot Type" CssClass="form-control"></asp:TextBox>  
                                          <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPlotType" ErrorMessage="Enter Plot Type" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                                   </div>
                                        </div>
                                            </div>
                                  </div>
                              <div class="form-group"> 
                                  <div class="row">                                       
                                   <div class="col-xs-12 col-sm-12">
                                            <label class="col-xs-12 col-sm-5 required">Plot Type Short Name</label>
                                            <div class="col-xs-12 col-sm-7">
                                             <asp:TextBox runat="server" ID="txtPlotTypeShort" MaxLength="70" placeholder="Plot Type Short Name" CssClass="form-control"></asp:TextBox>   
                                                   <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPlotTypeShort" ErrorMessage="Enter Plot Type Short Name" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>                          
                                            </div>
                                        </div>
                                    </div>                            
                                             </div>
                        </div>
                        <div class="col-xs-12 col-sm-6">
                           
                          <table  class="table table-bordered" style="margin-bottom:0px!important;">                              
                               <tr class="tbl_hd">
                                   <th>Plot Type</th>                                                                                       
                               </tr>                                                                                                                                                                                                                           
                           </table>
                            
                                  <div class="table-responsive">
                                        <div style="Overflow-y:scroll;max-height: 149px;">
                              <asp:GridView ID="GvPlot"  CssClass="table table-bordered" AutoGenerateColumns="false"  ShowHeader="false" runat="server">
                                    <HeaderStyle CssClass="ims_head" />
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblPlotType"  Text='<%#Eval("PlotTypeDesc") %>'></asp:Label>                                                                                                                                        
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
                                </asp:GridView>   </div></div>
                           
                        </div>
                    </div>
          </div>
                <div class="panel-footer">
                            <asp:Button ID="btnSave" Text="Save" runat="server" ValidationGroup="a" OnClick="btnSave_Click"  CssClass="btn btn-success btnSave" />
                            <asp:Button ID="btnClear" Text="Clear" runat="server" OnClick="btnClear_Click"  CssClass="btn btn-default btnClear" />
                            <asp:Button ID="btnExit" runat="server" PostBackUrl="Dashboard.aspx" CssClass="btn btn-danger" Text="Exit" />
                            <div class="alertMsg success" runat="server"  id="pnlSuccess"></div>
                            <div class="alertMsg failed" runat="server" id="pnlfailed"></div>
                </div>
            </div>

</div>        
</asp:Content>

