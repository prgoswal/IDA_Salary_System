<%@ Page Title="" Language="C#" MasterPageFile="~/Estate/MainMaster.master" AutoEventWireup="true" CodeFile="frmSchPlotingDetail.aspx.cs" Inherits="frmSchPlotingDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <style>
        .sm_20 .sm_80 {
            float: left;
        }

        .sm_20 {
            width: 20%;
        }

        .sm_80 {
            width: 60%;
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
                <h3 class="panel-title">Scheme Wise Ploting Detail</h3>
            </div>
            <div class="panel-body form-horizontal scheme-form-group">
                <div class="form-group">
                    <div class="row">
                        <div class="col-xs-12 col-sm-12">
                            <label class="col-xs-12 col-sm-5 sm_20 required control-label">Scheme Name</label>
                            <div class="col-xs-12 col-sm-7 sm_80">
                                <asp:DropDownList runat="server" ID="ddlSchName" CssClass="form-control" OnSelectedIndexChanged="ddlSchName_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:CompareValidator CssClass="errorMsg" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Select Scheme Name" runat="server" ID="comparevalidator3" ValidationGroup="a" ControlToValidate="ddlSchName" ValueToCompare="0" Operator="NotEqual"></asp:CompareValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-xs-12 col-sm-12">
                            <label class="col-xs-12 col-sm-5 sm_20 required control-label" id="lblSectorName" runat="server">Sector Name</label>
                            <div class="col-xs-12 col-sm-7 sm_80">
                                <asp:DropDownList runat="server" ID="ddlSectorName" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 col-sm-6"></div>
                        <div class="col-xs-12 col-sm-6">
                            <div class="col-xs-12 col-sm-7">
                                <asp:Label runat="server" ID="lblSchMsg" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>



                <div class="col-xs-12">
                    <div style="padding-right: 17px">
                         <span class="pull-right"><b>Scheme Name : </b><asp:Label runat="server" ID="lblSchName"></asp:Label></span>
                        <table class="table table-bordered td-padding-0 brk-all" style="margin-bottom: 0px!important;">
                            <tr class="tbl_hd">
                                <th style="width: 20%;">Plot Type</th>
                                <th style="width: 15%;">Plot Use</th>
                                <th style="width: 10%;">Plot Width</th>
                                <th style="width: 10%;">Plot Length</th>
                                <th style="width: 10%">Plot Size</th>
                                <th style="width: 10%">Total Plots</th>
                                <th style="width: 10%;">Plot Area&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Sq.Yard</th>
                                <th style="width: 10%;">Plot Area&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Sq.Meter</th>
                                <th style="width: 05%">Add</th>
                            </tr>
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlPlotType" class="form-control">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlPlotUse" CssClass="form-control"></asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" MaxLength="10" CssClass="form-control" OnTextChanged="txtPlotWidth_TextChanged" AutoPostBack="true" ID="txtPlotWidth" />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txtPlotWidth" FilterMode="ValidChars" FilterType="Numbers" />
                                        <%--<asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPlotWidth" ErrorMessage="Enter Plot Width" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>--%>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtPlotLength" MaxLength="10" OnTextChanged="txtPlotLength_TextChanged" AutoPostBack="true" CssClass="form-control" />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPlotLength" FilterMode="ValidChars" FilterType="Numbers" />
                                        <%--<asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPlotLength" ErrorMessage="Enter Plot Length" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>--%>
                                    </td>
                                     <td>
                                        <asp:TextBox runat="server" ID="txtPlotSize" MaxLength="10" CssClass="form-control" />
                                        <%--<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtPlotSize" FilterMode="ValidChars" FilterType="Numbers" />--%>
                                        <%--<asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPlotLength" ErrorMessage="Enter Plot Length" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>--%>
                                    </td>
                                     <td>
                                        <asp:TextBox runat="server" ID="txtTotalPlots" MaxLength="10" CssClass="form-control" />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtTotalPlots" FilterMode="ValidChars" FilterType="Numbers" />
                                        <%--<asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPlotLength" ErrorMessage="Enter Plot Length" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>--%>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtPlotAreaSqYard" OnTextChanged="txtPlotAreaSqYard_TextChanged" AutoPostBack="true" MaxLength="10" CssClass="form-control" />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtPlotAreaSqYard" FilterMode="ValidChars" FilterType="Numbers" />
                                        <%--<asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPlotAreaSqYard" ErrorMessage="Enter Plot Area Sq.Yard" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>--%>
                                    </td>

                                    <td>
                                        <asp:TextBox runat="server" MaxLength="10" CssClass="form-control" ID="txtPlotAreaSqMeter" />
                                        <%--                                                  <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtPlotAreaSqMeter" FilterMode="ValidChars" FilterType="Numbers,Custom" />--%>
                                        <%--<asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPlotAreaSqMeter" ErrorMessage="Enter Plot Area Sq.Meter" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>--%>
                                    </td>
                                    <td>
                                        <asp:LinkButton Text="Add" CssClass="btn btn-sxs btn-info" ID="btnAdd" ValidationGroup="a" OnClick="btnAdd_Click" runat="server" /></td>
                                </tr>

                            </tbody>
                        </table>
                          
                    </div>
                     <div style="overflow-y: scroll; max-height: 149px; margin-bottom: 15px">
                        <asp:GridView ID="GvPlotDetail" CssClass="table table-bordered mb0 brk-all" AutoGenerateColumns="false" ShowHeader="false" runat="server">
                            <Columns>
                                <asp:TemplateField ItemStyle-CssClass="clsPlotName" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPlotTypeName" Text='<%#Eval("PlotTypeName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPlotUseName" Text='<%#Eval("PlotUseName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPlotWidth" Text='<%#Eval("PlotWidth") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPlotLength" Text='<%#Eval("PlotLength") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPlotLength" Text='<%#Eval("PlotSize") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPlotLength" Text='<%#Eval("TotalPlot") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPlotAreaSqyard" Text='<%#Eval("PlotAreaSqyard") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPlotAreaSqMeter" Text='<%#Eval("PlotAreaSqMeter") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="05%">
                                    <ItemTemplate>
                                       &nbsp;
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

            <div class="panel-footer">
                <asp:Button ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" ValidationGroup="save" CssClass="btn btn-success btnSave" />
                <asp:Button ID="btnClear" Text="Clear" OnClick="btnClear_Click" runat="server" CssClass="btn btn-default btnClear" />
                <asp:Button ID="btnExit" runat="server" PostBackUrl="Dashboard.aspx" CssClass="btn btn-danger" Text="Exit" />
                <div class="alertMsg success" runat="server" id="pnlSuccess"></div>
                <div class="alertMsg failed" runat="server" id="pnlfailed"></div>
            </div>

            <div class="panel-body">
                <div class="col-xs-12">
                    <div style="padding-right: 17px">
                        <table class="table table-bordered" style="margin-bottom: 0px!important;">
                            <tr class="tbl_hd">
                                <th style="width: 20px;">Scheme Name</th>
                                <th style="width: 10%;">Plot Type</th>
                                <th style="width: 10%;">Plot Use</th>
                                <th style="width: 10%;">Plot Width</th>
                                <th style="width: 10%;">Plot Length</th>
                                <th style="width: 10%">Plot Size</th>
                                <th style="width: 10%">Total Plots</th>
                                <th style="width: 10%;">Plot Area Sq.Yard</th>
                                <th style="width: 10%;">Plot Area Sq.Meter</th>
                            </tr>
                        </table>
                    </div>



             
                  <%--<div class="col-xs-12">--%>       
                     <div style="overflow-y: scroll; max-height: 145px; margin-bottom: 15px">   
                <%--<div style="max-height: 149px; margin-bottom: 15px;padding-right:15px;">--%>
                    <asp:GridView ID="GvPlotSaveDetail" CssClass="table table-bordered mb0" AutoGenerateColumns="false" ShowHeader="false" runat="server">
                        <Columns>
                            <asp:TemplateField ItemStyle-CssClass="clsPlotName" ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblSchNameE" Text='<%#Eval("SchNameE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-CssClass="clsPlotName" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblPlotTypeDesc" Text='<%#Eval("PlotTypeDesc") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblUseDescE" Text='<%#Eval("UseDescE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblPlotWidth" Text='<%#Eval("PlotWidth") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblPlotLength" Text='<%#Eval("PlotLength") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPlotLength" Text='<%#Eval("PlotSize") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPlotLength" Text='<%#Eval("TotalPlot") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblPlotAreaSqyard" Text='<%#Eval("PlotAreaSqyard") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-CssClass="clsSector" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblPlotAreaSqMeter" Text='<%#Eval("PlotAreaSqMeter") %>'></asp:Label>
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
              <%--  <div class="col-md-12">
                    <asp:GridView runat="server" ID="gvdemo" AutoGenerateColumns="true"></asp:GridView>
                </div>--%>

            </div>
        </div>

    </div>

</asp:Content>

