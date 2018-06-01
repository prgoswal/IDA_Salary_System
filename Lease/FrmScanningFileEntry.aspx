<%@ Page Title="" Language="C#" MasterPageFile="~/Lease/MainMaster.master" AutoEventWireup="true" CodeFile="FrmScanningFileEntry.aspx.cs" Inherits="FrmScanningFileEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scr" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="row">
                    <h3 class="heading">
                        <asp:Label ID="Label77" runat="server" Text="Scanning File Entry"></asp:Label>
                    </h3>
                    <div style="max-width:1250px;margin:auto">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">Scanning File Entry</h3>
                            </div>
                            <div class="panel-body form-horizontal scheme-form-group">




                                <div class="">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-3">
                                            <div class="form-group">
                                                <label class="col-xs-12 col-sm-12">Reference&nbsp;No.</label>
                                                <div class="col-xs-12 col-sm-12">
                                                    <asp:TextBox ID="txtRefNo" runat="server" class="form-control" MaxLength="10"></asp:TextBox>
                                                    <cc1:FilteredTextBoxExtender ID="fte1" runat="server" ValidChars="0123456789" TargetControlID="txtRefNo" />
                                                    <span class="or-label">OR</span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-3">
                                            <div class="form-group">
                                                <label class="col-xs-12 col-sm-12 ">Scheme No.</label>
                                                <div class="col-xs-12 col-sm-12">
                                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlScheme">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-3">
                                            <div class="form-group">
                                                <label class="col-xs-12 col-sm-12 ">Plot No.</label>
                                                <div class="col-xs-12 col-sm-12">
                                                    <asp:TextBox ID="txtPlotNo" runat="server" class="form-control" MaxLength="30"></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator CssClass="errorMsg" ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtIDARefNo" ErrorMessage="Enter IDA Ref No." ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>--%>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-xs-12 col-sm-3">
                                            <div class="form-group">
                                                 <label class="control-label col-xs-12 col-sm-12 ">&nbsp;</label>
                                                <div class="col-xs-12 col-sm-12">
                                                    <asp:Button ID="btnSearch" Text="Search" runat="server" ValidationGroup="s" CssClass="btn btn-success" OnClientClick="return Validate();" OnClick="btnSearch_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>





                                <div class="row innr_pnl two" runat="server" id="pnlSearchedItem" visible="false">
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class=" col-xs-12 col-sm-12">
                                                Plot No.
                                            </label>
                                            <div class="col-xs-12 col-sm-12 ">
                                                <asp:TextBox ID="txtSPlotNo" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class=" col-xs-12 col-sm-12">
                                                Property&nbsp;Holder Name
                                            </label>
                                            <div class="col-xs-12 col-sm-12 ">
                                                <asp:TextBox ID="txtPropPlaceHolder" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class=" col-xs-12 col-sm-12">
                                                Address
                                            </label>
                                            <div class="col-xs-12 col-sm-12">
                                                <asp:TextBox ID="txtAddress" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class=" col-xs-12 col-sm-12">
                                                Scheme
                                            </label>
                                            <div class="col-xs-12 col-sm-12">
                                                <asp:TextBox ID="txtSchemeName" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>





                                <div class="">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-3">
                                            <div class="form-group">
                                            <label class="col-xs-12 col-sm-12">IDA Reference No.</label>
                                            <div class="col-xs-12 col-sm-12">
                                                <asp:TextBox ID="txtIDARefNo" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator CssClass="errorMsg" ID="ReqddlOrgNamee" runat="server" ControlToValidate="txtIDARefNo" ErrorMessage="Enter IDA Ref No." ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                                <%--<asp:CompareValidator CssClass="errorMsg" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Select Organization" runat="server" ID="comparevalidator1" ValidationGroup="a" ControlToValidate="ddlOrgName" ValueToCompare="--SELECT--" Operator="NotEqual"></asp:CompareValidator>--%>
                                            </div>
                                                </div>
                                        </div>
                                         <div class="col-xs-12 col-sm-3">
                                             <div class="form-group">
                                            <label class="col-xs-12 col-sm-12">New Service No</label>
                                            <div class="col-xs-12 col-sm-12">
                                                <asp:TextBox ID="txtNewServiceNo" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator CssClass="errorMsg" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtIDARefNo" ErrorMessage="Enter New Service No." ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                                <%--<asp:CompareValidator CssClass="errorMsg" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Select Organization" runat="server" ID="comparevalidator1" ValidationGroup="a" ControlToValidate="ddlOrgName" ValueToCompare="--SELECT--" Operator="NotEqual"></asp:CompareValidator>--%>
                                            </div>
                                                 </div>
                                        </div>
                                         <div class="col-xs-12 col-sm-3">
                                             <div class="form-group">
                                            <label class="col-xs-12 col-sm-12">Approval </label>
                                            <div class="col-xs-12 col-sm-12">
                                                <div class="form-control">
                                                    <asp:CheckBox ID="CheckYes" OnCheckedChanged="CheckYes_CheckedChanged" runat="server" Text="Verify Above Data" />
                                                </div>
                                            </div>
                                                </div>
                                        </div>
                                    </div>
                                </div>

                               

                            </div>
                            <div class="panel-footer text-right">
                                <asp:Label ID="Lblmsg" runat="server" ForeColor="Red" Text=""></asp:Label>
                                <div class="alertMsg success" runat="server" id="pnlSuccess"></div>
                                <div class="alertMsg failed" runat="server" id="pnlfailed"></div>

                                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" ValidationGroup="a" CssClass="btn btn-success" />
                                <asp:Button ID="btnclear" runat="server" Text="Clear" OnClick="btnclear_Click" CssClass="btn btn-warning" />
                                <asp:Button ID="btnExit0" runat="server" Text="Exit" CssClass="btn btn-danger" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>


