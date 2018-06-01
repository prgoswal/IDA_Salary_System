<%@ Page Title="" Language="C#" MasterPageFile="~/Lease/MainMaster.master" AutoEventWireup="true" CodeFile="FrmGenerateServiceNo.aspx.cs" Inherits="FrmGenerateServiceNo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .radio_btn_grp {
            width: 100%;
            max-width: 700px;
            margin: 0 auto;
        }

        .radio_btn_col {
            width: 33%;
            float: left;
        }

            .radio_btn_col input[type="radio"], .radio_btn_col label {
                display: block;
                float: left;
                cursor: pointer;
                margin-right: 3px;
                font-weight: normal;
                user-select: none;
            }

                .radio_btn_col input[type="radio"]:checked + label {
                    font-weight: bold;
                }

            .radio_btn_col label {
                margin-top: 1px;
            }

            .radio_btn_col span {
                display: inline-block;
                margin-top: 3px;
                font-size: 11px;
                font-style: italic;
            }

        @media (max-width:500px) {
            .radio_btn_grp {
                width: 100%;
                padding: 15px;
            }

            .radio_btn_col input[type="radio"], .radio_btn_col label {
                display: inline;
            }

            .radio_btn_col {
                width: 100%;
                float: none;
                clear: both;
            }
        }

        .plot-no-label {
            float: left;
            width: 10.8%;
            padding-top: 8px;
            text-align: right;
            padding-right: 10px;
        }

        .plot-no-btn {
            float: left;
            width: 10%;
            text-align: right;
        }

        .sidebar-collapsed .plot-middle.one {
            float: left;
            width: 24%;
        }

        .plot-middle.two {
            float: left;
            width: 48%;
        }

        .plot-no-format {
            width: 300px;
            float: left;
        }

            .plot-no-format .form-control:nth-child(1) {
                float: left;
                width: 24%;
                border-right: 0;
                border-bottom-right-radius: 0;
                border-top-right-radius: 0;
            }

            .plot-no-format .form-control:nth-child(2) {
                float: left;
                width: 52%;
                border-right: 0;
                border-radius: 0;
            }

            .plot-no-format .form-control:nth-child(3) {
                float: left;
                width: 24%;
                border-bottom-left-radius: 0;
                border-top-left-radius: 0;
            }

        .plot-two-divider {
            width: calc(100% - 604px);
            float: left;
            padding-top: 10px;
            font-size: 12px;
            padding-left: 4px;
        }

        @media (max-width:600px) {
            .plot-no-label {
                float: left;
                width: 100%;
                padding-top: 0px;
                text-align: left;
                padding-right: 0px;
            }

            .plot-no-btn {
                float: none;
                width: 100%;
            }

            .plot-middle.one {
                float: none;
                width: 100%;
            }

            .plot-middle.two {
                float: none;
                width: 100%;
            }

            .plot-no-format {
                float: none;
                width: 100%;
            }

                .plot-no-format:not(:first-child) {
                    margin-left: 0px;
                }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scr" runat="server"></asp:ScriptManager>

    <div class="container-fluid">
        <div class="row">
            <h3 class="heading">
                <asp:Label ID="Label77" runat="server" Text="Generate ServiceNo"></asp:Label>
            </h3>
            <div class="col-xs-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Generate Service No.</h3>
                    </div>
                    <div class="panel-body form-horizontal scheme-form-group">
                        <div class="form-group">
                            <div class="row">
                                <div class="col-xs-12 col-sm-4">
                                    <label class="control-label col-xs-12 col-sm-4 required">Zone</label>
                                    <div class="col-xs-12 col-sm-8">
                                        <asp:DropDownList ID="ddlZone" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlZone_SelectedIndexChanged" SkinID="ddl" CssClass="form-control">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator CssClass="errorMsg" ID="ReqFldZone" runat="server" ControlToValidate="ddlZone" ErrorMessage="Please Select Zone" ForeColor="Red" InitialValue="0" SkinID="ReqFieldValid" ValidationGroup="ddlgroup"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-xs-12 col-sm-4">
                                    <label class="control-label col-xs-12 col-sm-4 required">Scheme Type</label>
                                    <div class="col-xs-12 col-sm-8">
                                        <asp:DropDownList ID="ddlSchemeType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSchemeType_SelectedIndexChanged" SkinID="ddl" TabIndex="1" CssClass="form-control">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator CssClass="errorMsg" ID="ReqFldSchemeType" runat="server" ControlToValidate="ddlSchemeType" ErrorMessage="Please Select Scheme Type" ForeColor="Red" InitialValue="0" SkinID="ReqFieldValid" ValidationGroup="ddlgroup"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-xs-12 col-sm-4">
                                    <label class="control-label col-xs-12 col-sm-4 required">Scheme Name</label>
                                    <div class="col-xs-12 col-sm-8">
                                        <asp:DropDownList ID="ddlSchemeName" runat="server" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="ddlSchemeName_SelectedIndexChanged" SkinID="ddl" TabIndex="2" CssClass="form-control">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator CssClass="errorMsg" ID="ReqFldScheneName" runat="server" ControlToValidate="ddlSchemeName" ErrorMessage="Please Select Scheme Name" ForeColor="Red" InitialValue="0" SkinID="ReqFieldValid" ValidationGroup="ddlgroup"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-xs-12 col-sm-4">
                                    <label class="control-label col-xs-12 col-sm-4 required">Sector</label>
                                    <div class="col-xs-12 col-sm-8">
                                        <asp:DropDownList ID="ddlSector" runat="server" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="ddlSector_SelectedIndexChanged" SkinID="ddl" TabIndex="3" CssClass="form-control">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator CssClass="errorMsg" ID="ReqFldSector" runat="server" ControlToValidate="ddlSector" ForeColor="Red" ErrorMessage="Please Select Sector" InitialValue="0" SkinID="ReqFieldValid" ValidationGroup="ddlgroup"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-xs-12 col-sm-4">
                                    <label class="control-label col-xs-12 col-sm-4 required">Plot Use</label>
                                    <div class="col-xs-12 col-sm-8">
                                        <asp:DropDownList ID="ddlPlotUse" runat="server" AutoPostBack="True" SkinID="ddl" TabIndex="5" CssClass="form-control">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator CssClass="errorMsg" ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlPlotUse" ForeColor="Red" ErrorMessage="Select Plot Use" InitialValue="0" SkinID="ReqFieldValid" ValidationGroup="ddlgroup"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-xs-12 col-sm-4">
                                    <label class="control-label col-xs-12 col-sm-4 required">Fix</label>
                                    <div class="col-xs-12 col-sm-8">
                                        <asp:CheckBox ID="cBoxFix" runat="server" AutoPostBack="True" Font-Bold="True" OnCheckedChanged="cBoxFix_CheckedChanged" TabIndex="4" Text="Fix" CssClass="form-control" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-xs-12 col-sm-12">
                                    <div class="radio_btn_grp">
                                        <div class="radio_btn_col">
                                            <asp:RadioButton ID="rbttSingle" runat="server" AutoPostBack="True" Checked="True" GroupName="g1" OnCheckedChanged="rbttSingle_CheckedChanged" TabIndex="6" Text="Single Entry" />
                                            <span>(Eg. 1 - A to 100 - A)</span>
                                        </div>
                                        <div class="radio_btn_col">
                                            <asp:RadioButton ID="rbttMorethenon" runat="server" AutoPostBack="True" GroupName="g1" OnCheckedChanged="rbttMorethenon_CheckedChanged" TabIndex="7" Text="Multiple Entry" />
                                            <span>(Eg. 1 - A to 1 - Z )</span>
                                        </div>
                                        <div class="radio_btn_col">
                                            <asp:RadioButton ID="rbttMultipal" runat="server" AutoPostBack="True" GroupName="g1" OnCheckedChanged="rbttMultipal_CheckedChanged" TabIndex="8" Text="Multiple Entry" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="col-xs-12">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>

                                                <asp:Panel ID="PanelSingle" runat="server" CssClass="mr0auto">
                                                    <label class="plot-no-label">Enter Plot No.</label>
                                                    <div class="plot-middle one">
                                                        <div class="plot-no-format">
                                                            <asp:TextBox ID="txtSPre" runat="server" CssClass="form-control" MaxLength="3" TabIndex="9"></asp:TextBox>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender32" runat="server" FilterMode="validChars"
                                                                ValidChars="abcdefghijklmnopqrstuvwxyz/-ABCDEFGHIJKLMNOPQRSTUVWXYZ" TargetControlID="txtSPre"></cc1:FilteredTextBoxExtender>
                                                            <asp:TextBox ID="txtPlotNo" runat="server" AutoPostBack="True" CssClass="form-control" MaxLength="7" OnTextChanged="txtPlotNo_TextChanged" TabIndex="10"></asp:TextBox>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender33" runat="server" FilterMode="validChars"
                                                                TargetControlID="txtPlotNo" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                                                            <asp:TextBox ID="txtSpost" runat="server" CssClass="form-control" MaxLength="3" TabIndex="11"></asp:TextBox>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterMode="validChars"
                                                                ValidChars="abcdefghijklmnopqrstuvwxyz/-ABCDEFGHIJKLMNOPQRSTUVWXYZ" TargetControlID="txtSpost"></cc1:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator CssClass="errorMsg" ID="ReqFldPlotNo" runat="server" ForeColor="Red" ControlToValidate="txtPlotNo" ErrorMessage="Plot No. Required " SkinID="ReqFieldValid" ValidationGroup="ddlgroup"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="plot-no-btn">
                                                        <asp:Button ID="bttSServiceno" runat="server" OnClick="bttSServiceno_Click" SkinID="btt" TabIndex="12" Text="Get Service No." ValidationGroup="ddlgroup" CssClass="btn btn-primary" />
                                                    </div>
                                                </asp:Panel>



                                                <asp:Panel ID="PanelMultipal" runat="server" CssClass="mr0auto">
                                                    <label class="plot-no-label">Enter Plot No.</label>
                                                    <div class="plot-middle two">
                                                        <div class="plot-no-format">
                                                            <asp:TextBox ID="txtFpre" runat="server" AutoPostBack="True" MaxLength="5" OnTextChanged="txtFpre_TextChanged" SkinID="txtboxAlphaNumb" TabIndex="13" CssClass="form-control"></asp:TextBox>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterMode="validChars"
                                                                ValidChars="abcdefghijklmnopqrstuvwxyz/-ABCDEFGHIJKLMNOPQRSTUVWXYZ" TargetControlID="txtFpre"></cc1:FilteredTextBoxExtender>
                                                            <asp:TextBox ID="txtPlotNoFrom" runat="server" AutoPostBack="True" CssClass="form-control" MaxLength="5" OnTextChanged="txtPlotNoFrom_TextChanged" TabIndex="14"></asp:TextBox>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterMode="validChars"
                                                                TargetControlID="txtPlotNoFrom" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                                                            <asp:TextBox ID="txtFpost" runat="server" AutoPostBack="True" MaxLength="5" OnTextChanged="TextBox4_TextChanged" SkinID="txtboxAlphaNumb" TabIndex="15" CssClass="form-control"></asp:TextBox>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterMode="validChars"
                                                                ValidChars="abcdefghijklmnopqrstuvwxyz/-ABCDEFGHIJKLMNOPQRSTUVWXYZ" TargetControlID="txtFpost"></cc1:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator CssClass="errorMsg" ID="ReqFldPlotNo0" runat="server" ControlToValidate="txtPlotNoFrom" ErrorMessage="Plot No. Required " SkinID="ReqFieldValid" ValidationGroup="ddlgroup"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="plot-two-divider">To </div>
                                                        <div class="plot-no-format">
                                                            <asp:TextBox ID="txtTpre" runat="server" Enabled="False" MaxLength="5" SkinID="txtboxAlphaNumb" TabIndex="16" CssClass="form-control"></asp:TextBox>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" FilterMode="validChars"
                                                                ValidChars="abcdefghijklmnopqrstuvwxyz/-ABCDEFGHIJKLMNOPQRSTUVWXYZ" TargetControlID="txtTpre"></cc1:FilteredTextBoxExtender>
                                                            <asp:TextBox ID="txtPlotNoTo" runat="server" CssClass="form-control" MaxLength="5" TabIndex="17"></asp:TextBox>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterMode="validChars"
                                                                TargetControlID="txtPlotNoTo" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                                                            <asp:TextBox ID="txtTpost" runat="server" AutoPostBack="True" Enabled="False" MaxLength="2" OnTextChanged="txtTpost_TextChanged" TabIndex="18" CssClass="form-control"></asp:TextBox>
                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" FilterMode="validChars"
                                                                ValidChars="abcdefghijklmnopqrstuvwxyz/-ABCDEFGHIJKLMNOPQRSTUVWXYZ" TargetControlID="txtTpost"></cc1:FilteredTextBoxExtender>
                                                            <asp:RequiredFieldValidator CssClass="errorMsg" ID="ReqFldPlotNo1" runat="server" ControlToValidate="txtPlotNoTo" ErrorMessage="Plot No. Required " SkinID="ReqFieldValid" ValidationGroup="ddlgroup"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="plot-no-btn">
                                                        <asp:Button ID="bttserviceNo" runat="server" OnClick="bttserviceNo_Click" SkinID="btt" TabIndex="19" Text="Get Service No." ValidationGroup="ddlgroup" CssClass="btn btn-primary" />
                                                    </div>
                                                </asp:Panel>

                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlSector" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-xs-12">
                                    <asp:Label ID="lblMsgplot" runat="server" SkinID="Msg" ForeColor="Red"></asp:Label>

                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" style="width: 100%; padding-left: 15px; padding-right: 30px;">
                                        <ContentTemplate>

                                            <asp:Panel ID="PanelgetSno" runat="server" Visible="False">
                                                <asp:Label ID="lblServiceNo" runat="server" SkinID="Msglable" Visible="False" CssClass="alertMsg success" Style="width: 100%"></asp:Label>
                                            </asp:Panel>

                                            <asp:Label ID="lblMesg" runat="server" SkinID="Msglable" Visible="False" ForeColor="Red"></asp:Label>
                                            <asp:Label ID="lblmess" runat="server" Visible="False" ForeColor="Red"></asp:Label>

                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="bttSServiceno" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="bttserviceNo" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>

                    </div>

                    <div class="panel-footer text-right">

                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save"
                            ValidationGroup="ddlgroup" CssClass="btn btn-success" />
                        <asp:Button ID="btnclear" runat="server" OnClick="btnclear_Click" Text="Clear" CssClass="btn btn-warning" />
                        <asp:Button ID="btnExit0" runat="server" OnClick="btnExit_Click" Text="Exit" CssClass="btn btn-danger" />
                    </div>

                </div>


            </div>





        </div>
    </div>







</asp:Content>

