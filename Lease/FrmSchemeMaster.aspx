<%@ Page Title="" Language="C#" MasterPageFile="~/Lease/MainMaster.master" AutoEventWireup="true" CodeFile="FrmSchemeMaster.aspx.cs" Inherits="FrmSchemeMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="js/Validation.js"></script>
    <asp:ScriptManager ID="scr" runat="server"></asp:ScriptManager>

    <div class="container-fluid">
        <asp:UpdatePanel ID="upd" runat="server">
            <ContentTemplate>                

                <div class="row">
                    <h3 class="heading">
                        <asp:Label ID="Label78" runat="server" Text="Scheme Master"></asp:Label>
                    </h3>
                    <div class="col-xs-12">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">Insert Scheme</h3>
                            </div>
                            <div class="panel-body form-horizontal scheme-form-group">
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-4">
                                            <label class="control-label col-xs-12 col-sm-5 required">Scheme Name</label>
                                            <div class="col-xs-12 col-sm-7 width-660-sm">
                                                <asp:TextBox ID="txt_scheme_name" runat="server" CssClass="form-control" MaxLength="100" placeholder="Scheme Name"></asp:TextBox>
                                                <asp:RequiredFieldValidator  SetFocusOnError="true" CssClass="errorMsg" ID="rq6" runat="server" ControlToValidate="txt_scheme_name" ErrorMessage="Enter Scheme Name" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-4">
                                            <label class="control-label col-xs-12 col-sm-5 required">Scheme Short Name</label>
                                            <div class="col-xs-12 col-sm-7">
                                                <asp:TextBox ID="Txtscheme_short_name" runat="server" CssClass="form-control" MaxLength="50" placeholder="Scheme Short Name"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="TxtagentName_FilteredTextBoxExtender3"
                                                    runat="server" FilterMode="ValidChars" TargetControlID="Txtscheme_short_name"
                                                    ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ. "></cc1:FilteredTextBoxExtender>
                                                <cc1:FilteredTextBoxExtender ID="TxtagentName_FilteredTextBoxExtender4"
                                                    runat="server" FilterMode="InvalidChars" InvalidChars="0123456789"
                                                    TargetControlID="Txtscheme_short_name"></cc1:FilteredTextBoxExtender>
                                                <asp:RequiredFieldValidator  SetFocusOnError="true" CssClass="errorMsg" ID="rq4" runat="server" ControlToValidate="Txtscheme_short_name" ErrorMessage="Enter Short Scheme Name" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-4">
                                            <label class="control-label col-xs-12 col-sm-5 required">Zone</label>
                                            <div class="col-xs-12 col-sm-7">
                                                <asp:DropDownList ID="ddl_zone" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-4">
                                            <label class="control-label col-xs-12 col-sm-5 required">Ward No.</label>
                                            <div class="col-xs-12 col-sm-7">
                                                <asp:DropDownList ID="ddl_Ward" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-4">
                                            <label class="control-label col-xs-12 col-sm-5">Developer Type</label>
                                            <div class="col-xs-12 col-sm-7">
                                                <asp:DropDownList ID="ddl_developer_type" runat="server" AutoPostBack="True"
                                                    CssClass="form-control"
                                                    OnSelectedIndexChanged="ddl_developer_type_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-4">
                                            <label class="control-label col-xs-12 col-sm-5">Developer Name</label>
                                            <div class="col-xs-12 col-sm-7">
                                                <asp:DropDownList ID="ddl_developer_name" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-4">
                                            <label class="control-label col-xs-12 col-sm-5">Scheme Use</label>
                                            <div class="col-xs-12 col-sm-7">
                                                <asp:DropDownList ID="ddl_scheme_use1" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-4">
                                            <label class="control-label col-xs-12 col-sm-5 required">Scheme Location</label>
                                            <div class="col-xs-12 col-sm-7">
                                                <asp:TextBox ID="txt_secemelocation" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator  SetFocusOnError="true" CssClass="errorMsg" ID="rq3" runat="server" ControlToValidate="txt_secemelocation" ErrorMessage="Enter Scheme Location " ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-4">
                                            <label class="control-label col-xs-12 col-sm-5 required">Approval No.</label>
                                            <div class="col-xs-12 col-sm-7">
                                                <asp:TextBox ID="txtapprovalno1" runat="server" MaxLength="8" CssClass="form-control"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="txtmobileNo_FilteredTextBoxExtender0"
                                                    runat="server" TargetControlID="txtapprovalno1" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                                                <asp:RequiredFieldValidator  SetFocusOnError="true" CssClass="errorMsg" ID="rq2" runat="server" ControlToValidate="txtapprovalno1" ForeColor="Red" ErrorMessage="Enter Approval No." ValidationGroup="a"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-4">
                                            <label class="control-label col-xs-12 col-sm-5 required">Approved Date</label>
                                            <div class="col-xs-12 col-sm-7">
                                                <asp:TextBox ID="txtappdate" runat="server" MaxLength="12"
                                                    CssClass="form-control"></asp:TextBox>
                                                <cc1:MaskedEditExtender ID="MaskedEditExtendermn" runat="server"
                                                    AutoComplete="False" AutoCompleteValue="h " CultureName="en-US"
                                                    Mask="99/99/9999" MaskType="Date" TargetControlID="txtappdate"
                                                    UserDateFormat="None"></cc1:MaskedEditExtender>
                                                <asp:CustomValidator ID="CUSVAL1" runat="server"
                                                    ClientValidationFunction="cstm_DateValidation" ControlToValidate="txtappdate"
                                                    Display="Dynamic" EnableClientScript="true"
                                                    OnServerValidate="cstmDate_ServerValidate" ValidateEmptyText="true"
                                                    ValidationGroup="A" />
                                                <asp:RequiredFieldValidator CssClass="errorMsg" ID="rq1" runat="server" ControlToValidate="txtappdate" ForeColor="Red" ErrorMessage="Enter Approval Date" ValidationGroup="a"></asp:RequiredFieldValidator>

                                                <asp:RegularExpressionValidator  SetFocusOnError="true" runat="server" ControlToValidate="txtappdate" ForeColor="Red" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                                   CssClass="errorMsg" ErrorMessage="Invalid date format." ValidationGroup="a" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-4">
                                            <label class="control-label col-xs-12 col-sm-5 required">Total Area</label>
                                            <div class="col-xs-12 col-sm-7 two-form-control">
                                                <asp:TextBox ID="txt_total_area" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_total_area" ForeColor="Red" ErrorMessage="Enter Total Area" ValidationGroup="a" CssClass="errorMsg"></asp:RequiredFieldValidator>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                    TargetControlID="txt_total_area" ValidChars="0123456789."></cc1:FilteredTextBoxExtender>
                                                <asp:DropDownList ID="ddl_unit" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-4">
                                            <label class="control-label col-xs-12 col-sm-5 required">Residental Area</label>
                                            <div class="col-xs-12 col-sm-7 two-form-control">
                                                <asp:TextBox ID="txt_Residental_Area" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator CssClass="errorMsg" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_Residental_Area" ForeColor="Red" ErrorMessage="Enter Residental Area" ValidationGroup="a"></asp:RequiredFieldValidator>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                    TargetControlID="txt_Residental_Area" ValidChars="0123456789."></cc1:FilteredTextBoxExtender>
                                                <asp:DropDownList ID="ddl_unit2" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-4">
                                            <label class="control-label col-xs-12 col-sm-5 required">Commersial Area</label>
                                            <div class="col-xs-12 col-sm-7 two-form-control">
                                                <asp:TextBox ID="txt_commersial_area" runat="server" CssClass="form-control"
                                                    MaxLength="10"></asp:TextBox>
                                                <asp:RequiredFieldValidator  SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_commersial_area" ForeColor="Red" ErrorMessage="Enter Commersial Area" ValidationGroup="a"></asp:RequiredFieldValidator>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                    TargetControlID="txt_commersial_area" ValidChars="0123456789."></cc1:FilteredTextBoxExtender>
                                                <asp:DropDownList ID="ddl_unit3" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                                
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-4">
                                            <label class="control-label col-xs-12 col-sm-5 required">Cost Center Code</label>
                                            <div class="col-xs-12 col-sm-7">
                                                <asp:TextBox ID="TxtCCCode" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox>
                                                <asp:RequiredFieldValidator  SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtCCCode" ForeColor="Red" ErrorMessage="Enter Cost Center Code" ValidationGroup="a"></asp:RequiredFieldValidator>
                                                <cc1:FilteredTextBoxExtender ID="TxtCCCode_FilteredTextBoxExtender" runat="server" TargetControlID="TxtCCCode" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-4">
                                            <label class="control-label col-xs-12 col-sm-5 required">Industrial Area</label>
                                            <div class="col-xs-12 col-sm-7 two-form-control">
                                                <asp:TextBox ID="txt_internal_area" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_internal_area" ForeColor="Red" ErrorMessage="Enter Industrial Area" ValidationGroup="a"></asp:RequiredFieldValidator>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt_internal_area" ValidChars="0123456789."></cc1:FilteredTextBoxExtender>
                                                <asp:DropDownList ID="ddl_unit4" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="panel-footer">
                                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" ValidationGroup="a" CssClass="btn btn-success" />
                                <asp:Button ID="btnclear" runat="server" OnClick="btnclear_Click" Text="Clear" CssClass="btn btn-default" />
                                <asp:Button ID="btnExit" runat="server"  OnClick="btnExit_Click" Text="Exit" CssClass="btn btn-danger" />
                                <asp:Label ID="LblMsg" runat="server" Visible="false"></asp:Label>

                            </div>
                        </div>
                    </div>

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

