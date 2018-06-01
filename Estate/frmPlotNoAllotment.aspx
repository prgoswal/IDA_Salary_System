<%@ Page Title="" Language="C#" MasterPageFile="~/Estate/MainMaster.master" AutoEventWireup="true" CodeFile="frmPlotNoAllotment.aspx.cs" Inherits="frmPlotNoAllotment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager runat="server"></asp:ScriptManager>
     <style>
                    .sm_20 .sm_80 {
                        float: left;
                    }

                    .sm_20 {
                        width: 20%;
                    }

                    .sm_80 {
                        width: 80%;
                    }                

        .tbl_hd {
            background-color: #3c8dbc;
            color: #fff;
        }

        .td-padding-0 tr th {
            padding: 5px !important;
        }

        .td-padding-0 tr td {
            padding: 0px !important;
        }

            .td-padding-0 tr td .btn {
                padding: 1px 4px !important;
            }

            .td-padding-0 tr td input, .td-padding-0 tr td select {
                border: 0 !important;
                border-radius: 0;
                padding: 3px 2px;
                height: 30px;
            }

                .td-padding-0 tr td input:focus, .td-padding-0 tr td select:focus {
                    outline: 1px solid #ddd !important;
                    box-shadow: none;
                }
                .brk-all {
                    word-break:break-all
                }
    </style>
        <div class="col-sm-10 col-sm-offset-1">
        <div class="panel panel-primary mt10">
            <div class="panel-heading">
                <h3 class="panel-title">Plot Number Allotment</h3>
            </div>
            <div class="panel-body form-horizontal scheme-form-group">
                  <div class="form-group">
                    <div class="row">
                        <div class="col-xs-12 col-sm-12">
                            <label class="col-xs-12 col-sm-5 sm_20 required">Scheme Name</label>
                            <div class="col-xs-12 col-sm-7 sm_80">
                            <asp:DropDownList runat="server" ID="ddlSchName" OnSelectedIndexChanged="ddlSchName_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                           <asp:CompareValidator CssClass="errorMsg" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Select Scheme Name" runat="server" ID="comparevalidator3" ValidationGroup="save" ControlToValidate="ddlSchName" ValueToCompare="0" Operator="NotEqual"></asp:CompareValidator>
                                  </div>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-xs-12 col-sm-12">
                            <label class="col-xs-12 col-sm-5 sm_20" id="lblSectorName" runat="server">Sector Name</label>
                            <div class="col-xs-12 col-sm-7 sm_80">
                            <asp:DropDownList runat="server" ID="ddlSecName" OnSelectedIndexChanged="ddlSecName_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                <asp:Label runat="server" ID="lblSchMsg" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-xs-12 col-sm-6">
                            <label class="col-xs-12 col-sm-5">Plot Type</label>
                            <div class="col-xs-12 col-sm-7">
                              <asp:DropDownList runat="server" ID="ddlPlotType" OnSelectedIndexChanged="ddlPlotType_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-6">
                            <label class="col-xs-12 col-sm-5 control-label">Plot size</label>
                            <div class="col-xs-12 col-sm-7">                               
                             <asp:DropDownList runat="server" ID="ddlPlotSize" OnSelectedIndexChanged="ddlPlotSize_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>  
                            </div>
                        </div>
                    </div>
                </div>
                 <div class="form-group">
                    <div class="row">
                        <div class="col-xs-12 col-sm-6">
                            <label class="col-xs-12 col-sm-5">Total Plot</label>
                            <div class="col-xs-12 col-sm-7">
                                <asp:TextBox runat="server" placeholder="Total Plot" ID="txtTotalPlot" MaxLength="10"  CssClass="form-control"></asp:TextBox>
                                  <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtTotalPlot" FilterMode="ValidChars" FilterType="Numbers" />
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-6">
                            <label class="control-label col-xs-12 col-sm-5">Total Assigned Plot</label>
                            <div class="col-xs-12 col-sm-7">
                               <asp:TextBox runat="server" placeholder="Total Assigned Plot" ID="txtTotalAssplot" MaxLength="10" CssClass="form-control"></asp:TextBox>
                                 <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtTotalAssplot" FilterMode="ValidChars" FilterType="Numbers" />
                            </div>
                        </div>
                    </div>
                </div>
               <div class="form-group">
                    <div class="row">
                        <div class="col-xs-12 col-sm-6">
                            <label class="col-xs-12 col-sm-5 required">Plot No. From</label>
                            <div class="col-xs-12 col-sm-7">
                               <asp:TextBox runat="server" placeholder="Plot No. From" MaxLength="10" ID="txtPlotNoFrom" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPlotNoFrom" ErrorMessage="Enter Plot No. Form" ForeColor="Red" ValidationGroup="assign"></asp:RequiredFieldValidator>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txtPlotNoFrom" FilterMode="ValidChars" FilterType="Numbers" />
                                  </div>
                        </div>
                        <div class="col-xs-12 col-sm-6">
                            <label class="control-label col-xs-12 col-sm-5 required">Plot No.To</label>
                            <div class="col-xs-12 col-sm-7">
                                <asp:TextBox runat="server" placeholder="Plot No.To" MaxLength="10" ID="txtPlotNoTo" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPlotNoTo" ErrorMessage="Enter Plot No. To" ForeColor="Red" ValidationGroup="assign"></asp:RequiredFieldValidator>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPlotNoTo" FilterMode="ValidChars" FilterType="Numbers" />
                                  </div>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">                       
                        <div class="col-xs-12 col-sm-6">
                            <label class="col-xs-12 col-sm-5">Separator</label>
                            <div class="col-xs-12 col-sm-7">
                               <asp:DropDownList runat="server" ID="ddlSeprator" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                         <div class="col-xs-12 col-sm-6">
                               <div class="col-xs-12 col-sm-7">
                            <asp:Button runat="server" Text="Assign plot No." ValidationGroup="assign" id="btnAsgPlotNo" OnClick="btnAsgPlotNo_Click"   CssClass="btn btn-primary text-right" />
                                   </div>
                        </div>
                    </div>
                </div>

                     <div class="col-xs-12">
                    <div style="padding-right: 17px">                       
                        <table class="table table-bordered td-padding-0 brk-all" style="margin-bottom: 0px!important;">
                            <tr class="tbl_hd">
                                <th style="width:  5%;">Sr No.</th>
                                <th style="width:  10%;">Plot No</th>
                                <th style="width: 10%">Plot Type</th>
                                <th style="width: 10%">Plot Size</th>
                               <th style="width: 15%">Plot Area Sq.Yard </th>
                               <th style="width: 15%">Plot Area Sq.Meter</th>                              
                               <th style="width: 35%;">Plot Features</th>                                
                            </tr>                           
                        </table>
                          
                    </div>
                     
                </div>

                   <div class="col-xs-12">
                  <div style="max-height: 149px;overflow-y:scroll;">
                        <asp:GridView ID="GvPlotAllot" CssClass="table table-bordered mb0 brk-all" OnRowDataBound="GvPlotAllot_RowDataBound" AutoGenerateColumns="false" ShowHeader="false" runat="server">
                            <Columns>
                                <asp:TemplateField ItemStyle-CssClass="clsPlotName" ItemStyle-Width="5%">
                                    <ItemTemplate>
                                      <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                  <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPlotNo" Text='<%#Eval("PlotNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>                               
                                 <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPlotTypeName" Text='<%#Eval("PlotTypeName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPlotSizeName" Text='<%#Eval("PlotSize") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField> 
                                 <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPlotAreaSqyard" Text='<%#Eval("PlotAreaSqyard") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField> 
                                 <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPlotAreaSqMeter" Text='<%#Eval("PlotAreaSqMeter") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>                                      
                                 <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="35%">                                                                                                                                                   
                                    <ItemTemplate>   
                                               <asp:CheckBoxList runat="server" RepeatColumns="3" ID="chkplot"></asp:CheckBoxList>                                                                                                           
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
                    </div>



                <style>
                    .rdo label{
                        margin-right:10px;
                    }
                </style>

                
            </div>
            <div class="panel-footer">
                <asp:Button ID="btnSave" Text="Save" OnClick="btnSave_Click" runat="server" ValidationGroup="save" CssClass="btn btn-success btnSave" />
                <asp:Button ID="btnClear" Text="Clear" OnClick="btnClear_Click" runat="server" CssClass="btn btn-default btnClear" />
                <asp:Button ID="btnExit" runat="server" PostBackUrl="Dashboard.aspx" CssClass="btn btn-danger" Text="Exit" />
                <div class="alertMsg success" runat="server" id="pnlSuccess"></div>
                <div class="alertMsg failed" runat="server" id="pnlfailed"></div>
            </div>



                 <div class="panel-body">

                <div class="col-xs-12">
                    <div style="padding-right: 17px">
                         <table class="table table-bordered td-padding-0 brk-all" style="margin-bottom: 0px!important;">
                            <tr class="tbl_hd">
                                <th style="width:  10%;">Sr No.</th>
                                <th style="width:  15%;">Plot No</th>
                                <th style="width: 15%">Plot Type</th>
                                <th style="width: 15%">Plot Size</th>
                               <th style="width: 15%">Plot Area Sq.Yard </th>
                               <th style="width: 15%">Plot Area Sq.Meter</th>                                                                                          
                            </tr>                           
                        </table>
                    </div>
                </div>    

                
                   <div class="col-xs-12">
                  <div style="max-height: 149px;overflow-y:scroll;">
                        <asp:GridView ID="GvBind" CssClass="table table-bordered mb0 brk-all"  AutoGenerateColumns="false" ShowHeader="false" runat="server">
                            <Columns>
                                <asp:TemplateField ItemStyle-CssClass="clsPlotName" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                      <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                  <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPlotNo" Text='<%#Eval("PlotNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>                               
                                 <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPlotTypeName" Text='<%#Eval("PlotTypeDesc") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPlotSizeName" Text='<%#Eval("PlotSize") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField> 
                                 <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPlotAreaSqyard" Text='<%#Eval("PlotSizeSqYard") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField> 
                                 <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPlotAreaSqMeter" Text='<%#Eval("PlotSizeSqMeter") %>'></asp:Label>
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
                    </div>          
            </div>


        </div>
    </div>


</asp:Content>

