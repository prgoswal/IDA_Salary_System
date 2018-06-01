<%@ Page Title="" Language="C#" MasterPageFile="~/Demand/DemandMaster.master" AutoEventWireup="true" CodeFile="FrmGenerateDemand.aspx.cs" Inherits="FrmGenerateDemand" %>

<%@ Register Src="~/Demand/UserControl/DemandSearch.ascx" TagName="DemandSearch" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .panel-heading {
            padding: 2px 15px;
        }

        .form-control {
            height: 30px;
            margin-top: 5px;
        }

        .acntname {
            margin-top: 2px;
        }

            .acntname .acntname_lbl {
                margin-left: 10px;
            }

        .acntname_lbl1 {
            margin-left: 224px;
        }

        .innr_pnl.one {
            padding-top: 5px;
        }

        hr {
            margin-top: 8px;
            margin-bottom: 8px;
        }

        label {
            margin-bottom: 0px;
        }

        .Search_pnl .col-sm-4 {
            margin-bottom: -10px !important;
        }

        .mb0 {
            margin-bottom: 0px;
        }

        .table > thead > tr > th {
            padding: 3px;
        }

        .table > tbody > tr > td {
            padding: 3px;
        }

        .tblscrl {
            height: 135px;
            overflow-y: scroll;
        }

        .mt0 {
            margin-top: 0px;
        }

        .mb-8 {
            margin-top: -8px;
        }
    </style>
    <script>
        function CalValidate() {
            var txtRefNo = document.getElementById('<%=UCDemardSearch.FindControl("txtRefNo").ClientID %>')
            var txtServiceNo = document.getElementById('<%=UCDemardSearch.FindControl("txtServiceNo").ClientID %>')
            if ($('#<%=ddlDemandCategory.ClientID%>').val() == "0") {
                $('#<%=lblCalMsg.ClientID%>').html("Please Select Demand Category. ");
                return false;
            }
            else if ($('#<%=ddlAccountName.ClientID%>').val() == "0") {
                $('#<%=lblCalMsg.ClientID%>').html("Please Select Account Name. ");
                return false;
            }
            else if ($('#<%=ddldemandfor.ClientID%>').val() == "0") {
                $('#<%=lblCalMsg.ClientID%>').html("Please Select Demand For. ");
                 return false;
            }            
            else if (txtRefNo.value == "") {
                $('#<%=lblCalMsg.ClientID%>').html("Please Enter Reference No. ");
                return false;
            }
            else if (txtServiceNo.value == "") {
                $('#<%=lblCalMsg.ClientID%>').html("Please Enter Service No. ");
                 return false;
             }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div class="col-sm-6 mb-8">

                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Demand Generation</h3>
                        <!-- /.box-tools -->
                    </div>
                    <!-- /.box-header -->
                    <div class="panel-body form-horizontal">
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-xs-4 col-sm-4 required control-label">
                                    Demand Category
                                </label>
                                <div class="col-xs-8 col-sm-8">
                                    <asp:DropDownList ID="ddlDemandCategory" runat="server" class="service_txt browser-default select form-control inputs" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlDemandCategory_SelectedIndexChanged">
                                        <asp:ListItem Value="0">--Select Demand Category--</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator CssClass="errorMsg" ID="rfv1" runat="server" ErrorMessage="Please select Demand Category" ControlToValidate="ddlDemandCategory"
                                        ValidationGroup="a" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-sm-12">
                                <label class="col-xs-4 col-sm-4 required control-label">
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
                            </div>
                            <div class="col-sm-12 pull right acntname" runat="server" id="pnltext" visible="false">
                                <asp:Label ID="txtAccNameHindi" runat="server" CssClass="acntname_lbl1 control-label" />
                                <asp:Label ID="txtRefPartycode" runat="server" CssClass="acntname_lbl control-label" />

                            </div>
                            <div class="col-sm-12">
                                <label class="col-xs-4 col-sm-4 required control-label">
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
                        <cc2:DemandSearch runat="server" ID="UCDemardSearch"></cc2:DemandSearch>
                        <div class="row Search_pnl two">
                            <div class="col-sm-12 text-right">
                               
                                    <div class="col-xs-8 col-sm-8 ">
                                        <asp:Label ID="lblCalMsg" runat="server" forecolor="red" CssClass="errorMsg"></asp:Label>
                                    </div>
                                    <div class="col-xs-4 col-sm-4 ">
                                        <asp:Button ID="btnCalculate" Text="Calculate" runat="server" CssClass="btn btn-primary btn-xs btnSave" OnClientClick="return CalValidate()" OnClick="btnCalculate_Click" />
                                    </div>
                               
                            </div>


                        </div>
                    </div>
                </div>
            </div>



            <div class="col-sm-6 mb-8">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">&nbsp;</h3>
                        <!-- /.box-tools -->
                    </div>
                    <div class="panel-body form-horizontal">
                        <div class="tblscrl">
                            <asp:GridView ID="grdCal" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered mb0">
                                <Columns>
                                    <asp:TemplateField HeaderText="SrNo.">
                                        <ItemTemplate>
                                            <%#(Container.DataItemIndex+1) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Demand For">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnacccode" runat="server" Value='<%#Eval("Acccode") %>' />
                                            <asp:Label ID="lblDemandFor" runat="server" Text='<%#Eval("DemandFor") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle BackColor="#337ab7" ForeColor="White" />
                            </asp:GridView>
                        </div>

                        <div class="row Search_pnl two">
                            <div class="col-sm-12">
                                <div class="pull-right">
                                    <div class="col-xs-12 col-sm-12 ">
                                        <asp:Button ID="btnadd" Text="Add" runat="server" CssClass="btn btn-primary btn-xs btnSave"
                                            Style="margin-bottom: 8px;" OnClick="btnadd_Click" />
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="tblscrl" style="height: 230px">
                            <asp:GridView ID="grdTotalCal" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered mb0" OnRowDataBound="grdTotalCal_RowDataBound" ShowFooter="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="SrNo.">
                                        <ItemTemplate>
                                            <%#(Container.DataItemIndex+1) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Demand For">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnacccode" runat="server" Value='<%#Eval("Acccode") %>' />
                                            <asp:Label ID="lblDemandFor" runat="server" Text='<%#Eval("DemandFor") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            Total
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lbltotalAmount" runat="server" Text="0.00"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                </Columns>
                                <HeaderStyle BackColor="#337ab7" ForeColor="White" />
                                <FooterStyle BackColor="#337ab7" ForeColor="White" HorizontalAlign="right"/>
                            </asp:GridView>
                        </div>

                    </div>
                    <%--<div class="panel-body form-horizontal">
                        <table class="table table-bordered mb0">
                            <thead>
                                <tr style="background-color: #337ab7; color: #fff;">
                                    <th style="width: 10%">S. No.</th>
                                    <th style="width: 60%">Account Name</th>
                                    <th style="width: 30%">Amount</th>
                                </tr>
                            </thead>
                        </table>
                        <div class="tblscrl">
                            <table class="table table-bordered mb0">
                                <tbody>
                                    <tr>
                                        <td style="width: 10%">1</td>
                                        <td style="width: 60%">Neha</td>
                                        <td style="width: 27%">2000000</td>
                                    </tr>
                                    <tr>
                                        <td>1</td>
                                        <td>Neha</td>
                                        <td>2000000</td>
                                    </tr>
                                    <tr>
                                        <td>1</td>
                                        <td>Neha</td>
                                        <td>2000000</td>
                                    </tr>
                                    <tr>
                                        <td>1</td>
                                        <td>Neha</td>
                                        <td>2000000</td>
                                    </tr>
                                    <tr>
                                        <td>1</td>
                                        <td>Neha</td>
                                        <td>2000000</td>
                                    </tr>
                                    <tr>
                                        <td>1</td>
                                        <td>Neha</td>
                                        <td>2000000</td>
                                    </tr>
                                    <tr>
                                        <td>1</td>
                                        <td>Neha</td>
                                        <td>2000000</td>
                                    </tr>
                                    <tr>
                                        <td>1</td>
                                        <td>Neha</td>
                                        <td>2000000</td>
                                    </tr>

                                </tbody>
                            </table>
                        </div>
                        <table class="table table-bordered mt0">
                            <tr>
                                <td style="width: 70%;">
                                    <asp:Button ID="Button5" Text="Total" runat="server" CssClass="btn btn-primary btn-xs btnSave pull-right" /></td>
                                <td>2000000</td>

                            </tr>
                        </table>
                        <div class="row Search_pnl two">
                            <div class="col-sm-12">
                                <div class="pull-right">
                                    <div class="col-xs-12 col-sm-12 ">
                                        <asp:Button ID="Button2" Text="Add" runat="server" CssClass="btn btn-primary btn-xs btnSave" Style="margin-bottom: 8px;" />
                                    </div>
                                </div>
                            </div>


                        </div>


                        <table class="table table-bordered mb0">
                            <thead>
                                <tr style="background-color: #337ab7; color: #fff;">
                                    <th style="width: 10%">S. No.</th>
                                    <th style="width: 60%">Account Name</th>
                                    <th style="width: 30%">Amount</th>
                                </tr>
                            </thead>
                        </table>
                        <div class="tblscrl">
                            <table class="table table-bordered mt0">
                                <tbody>
                                    <tr>
                                        <td style="width: 10%">1</td>
                                        <td style="width: 60%">Neha</td>
                                        <td style="width: 27%">2000000</td>
                                    </tr>
                                    <tr>
                                        <td>1</td>
                                        <td>Neha</td>
                                        <td>2000000</td>
                                    </tr>
                                    <tr>
                                        <td>1</td>
                                        <td>Neha</td>
                                        <td>2000000</td>
                                    </tr>
                                    <tr>
                                        <td>1</td>
                                        <td>Neha</td>
                                        <td>2000000</td>
                                    </tr>
                                    <tr>
                                        <td>1</td>
                                        <td>Neha</td>
                                        <td>2000000</td>
                                    </tr>
                                    <tr>
                                        <td>1</td>
                                        <td>Neha</td>
                                        <td>2000000</td>
                                    </tr>
                                    <tr>
                                        <td>1</td>
                                        <td>Neha</td>
                                        <td>2000000</td>
                                    </tr>


                                </tbody>
                            </table>
                        </div>

                    </div>--%>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

