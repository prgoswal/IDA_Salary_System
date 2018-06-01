<%@ Page Title="" Language="C#" MasterPageFile="~/Demand/DemandMaster.master" AutoEventWireup="true" CodeFile="FrmGenerateDemandOld.aspx.cs" Inherits="Demand_FrmGenerateDemandOld" %>

<%@ Register Src="~/Demand/UserControl/DemandSearch.ascx" TagName="DemandSearch" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .mt10 {
            margin-top: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div>
                <div class="col-sm-12 col-sm-offset-0">
                    <div class="panel panel-primary mt10">
                        <div class="panel-heading">
                            <h3 class="panel-title">Demand Generation</h3>
                            <!-- /.box-tools -->
                        </div>
                        <!-- /.box-header -->
                        <div class="panel-body form-horizontal">
                            <div class="form-group" style="margin-bottom:0px;">
                                <div class="col-sm-6">
                                    <label class="col-xs-4 col-sm-3 required control-label">
                                        Demand Category
                                    </label>
                                    <div class="col-xs-8 col-sm-8">

                                        <asp:DropDownList ID="ddlDemandCategory" runat="server" class="service_txt browser-default select form-control inputs" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlDemandCategory_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator CssClass="errorMsg" ID="rfv1" runat="server" ErrorMessage="Please select Demand Category" ControlToValidate="ddlDemandCategory"
                                            ValidationGroup="a" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <label class="col-xs-4 col-sm-3 required control-label">
                                        Account Name
                                    </label>
                                    <div class="col-xs-8 col-sm-8">
                                        <asp:DropDownList ID="ddlAccountName" runat="server" class="service_txt browser-default select form-control inputs" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlAccountName_SelectedIndexChanged">
                                            <asp:ListItem Value="0">--Select Account Name--</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator CssClass="errorMsg" ID="rfv5" runat="server" ErrorMessage="Please select Account Name" ControlToValidate="ddlAccountName"
                                            ValidationGroup="a" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                    <style>
                                        .acntname{
                                            margin-top:6px;
                                        }
                                        .acntname .acntname_lbl{
                                            margin-left:10px;
                                        }
                                        .acntname_lbl1{
                                            margin-left:160px;
                                        }
                                    </style>
                                    <div class="col-sm-12 pull right acntname">
                                        <asp:Label ID="txtAccNameHindi" runat="server"  CssClass="acntname_lbl1 control-label"/>
                                        <asp:Label ID="txtRefPartycode" runat="server" CssClass="acntname_lbl control-label"/>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-6">
                                    <label class="col-xs-4 col-sm-3 control-label required ">
                                        Demand For
                                    </label>
                                    <div class="col-xs-8 col-sm-8">

                                        <asp:DropDownList ID="ddldemandfor" runat="server" class="service_txt browser-default select form-control inputs">
                                            <asp:ListItem Value="0">--Select Demand For--</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator CssClass="errorMsg" ID="ref12" runat="server" ErrorMessage="Please select Demand For" ControlToValidate="ddldemandfor"
                                            ValidationGroup="a" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>


                            <cc2:DemandSearch runat="server" ID="DemardSearch"></cc2:DemandSearch>
                        </div>


                        <div class="panel-footer">
                            <%-- OnClientClick="return ProgressBar();"--%>
                            <asp:Button ID="btnSave" Text="Save" runat="server" ValidationGroup="a" OnClick="btnSave_Click" CssClass="btn btn-success btnSave" TabIndex="3" />
                            <asp:Button ID="btnClear" Text="Clear" runat="server" OnClick="btnClear_Click" CssClass="btn btn-default btnClear" />
                            <asp:Button ID="btnExit" runat="server" PostBackUrl="~/Demand/Dashboard.aspx" CssClass="btn btn-danger" Text="Exit" TabIndex="5" />
                            <div class="alertMsg success" runat="server" id="pnlSuccess"></div>
                            <div class="alertMsg failed" runat="server" id="pnlfailed"></div>
                        </div>
                    </div>


                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

