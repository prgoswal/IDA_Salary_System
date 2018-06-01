<%@ Page Title="" Language="C#" MasterPageFile="~/Lease/MainMaster.master" AutoEventWireup="true" CodeFile="FrmMstOrgProfile.aspx.cs" Inherits="FrmMstOrgProfile" %>

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

        .plot-middle.one {
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

        .lg-529 {
            width: 450px;
        }

        .sidebar-collapsed .lg-529 {
            width: 529px;
        }

        @media (max-width:768px) {
            .lg-529 {
                width: 100%;
            }

            .sidebar-collapsed .lg-529 {
                width: 100%;
            }
        }

        .mop-radio input[type="radio"], .mop-radio label {
            float: left;
            display: block;
            cursor: pointer;
        }

            .mop-radio input[type="radio"] + label {
                font-weight: normal;
                padding-top: 2px;
                padding-left: 1px;
                margin-right: 6px;
            }

            .mop-radio input[type="radio"]:checked + label {
                font-weight: bold;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scr" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="row">
                    <h3 class="heading">
                        <asp:Label ID="Label77" runat="server" Text=""></asp:Label>
                    </h3>
                    <div class="col-sm-8 col-xs-12 col-sm-offset-2">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title">Profile Creation</h3>
                            </div>
                            <div class="panel-body form-horizontal scheme-form-group">
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-6">
                                            <label class="control-label col-xs-12 col-sm-7 required">Organization Name</label>
                                            <div class="col-xs-12 col-sm-5">
                                                <asp:DropDownList ID="ddlOrgName" runat="server" SkinID="ddl" CssClass="form-control lg-529">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator CssClass="errorMsg" ID="ReqddlOrgNamee" runat="server" ControlToValidate="ddlOrgName" ErrorMessage="Select Organization" ForeColor="Red" InitialValue="0" SkinID="ReqFieldValid" ValidationGroup="a"></asp:RequiredFieldValidator>
                                                <%--<asp:CompareValidator CssClass="errorMsg" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Select Organization" runat="server" ID="comparevalidator1" ValidationGroup="a" ControlToValidate="ddlOrgName" ValueToCompare="--SELECT--" Operator="NotEqual"></asp:CompareValidator>--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-6">
                                            <label class="control-label col-xs-12 col-sm-7 required">Zone Applicable</label>
                                            <div class="col-xs-12 col-sm-5">
                                                <div class="mop-radio">
                                                    <asp:RadioButton ID="rbtZoneYes" runat="server" GroupName="z1" Text="Yes" />
                                                    <asp:RadioButton ID="rbtZoneNo" Checked="true" runat="server" GroupName="z1" Text="No" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-xs-12 col-sm-6">
                                            <label class="control-label col-xs-12 col-sm-7 required">Ward Applicable</label>
                                            <div class="col-xs-12 col-sm-5">
                                                <div class="mop-radio">
                                                    <asp:RadioButton ID="rbtWardYes" runat="server" GroupName="w1" Text="Yes" />
                                                    <asp:RadioButton ID="rbtWardNo" Checked="true" runat="server" GroupName="w1" Text="No" />
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-6">
                                            <label class="control-label col-xs-12 col-sm-7 required">Developer Category Applicable</label>
                                            <div class="col-xs-12 col-sm-5">
                                                <div class="mop-radio">
                                                    <asp:RadioButton ID="rbtDevCateYes" runat="server" GroupName="d1" Text="Yes" />
                                                    <asp:RadioButton ID="rbtDevCateNo" Checked="true" runat="server" GroupName="d1" Text="No" />
                                                </div>

                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-6">
                                            <label class="control-label col-xs-12 col-sm-7 required">Developer Name Applicable</label>
                                            <div class="col-xs-12 col-sm-5">
                                                <div class="mop-radio">
                                                    <asp:RadioButton ID="rbtDevNameYes" runat="server" GroupName="n1" Text="Yes" />
                                                    <asp:RadioButton ID="rbtDevNameNo" Checked="true" runat="server" GroupName="n1" Text="No" />
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
                                <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Text="Save" ValidationGroup="a" CssClass="btn btn-success" />
                                <asp:Button ID="btnclear" runat="server" Text="Clear" OnClick="btnclear_Click" CssClass="btn btn-warning" />
                                <asp:Button ID="btnExit0" runat="server" Text="Exit" OnClick="btnExit0_Click" CssClass="btn btn-danger" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

