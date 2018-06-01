<%@ Page Title="" Language="C#" MasterPageFile="~/Salary/SalaryMaster.master" AutoEventWireup="true" CodeFile="FrmMonthImport.aspx.cs" Inherits="MasterForm_FrmMonthImport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function LoadAllScript() {
            LoadBasic();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updatepnl">
        <ProgressTemplate>
            <div class="loading active"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="updatepnl" runat="server">
        <ContentTemplate>
            <script>
                Sys.Application.add_load(LoadAllScript);
            </script>
            <div class="col-xs-12 col-sm-8 col-sm-offset-2 mrgntp10 mt10">
                <style>
                    .mt10 {
                        margin-top: 10px;
                    }

                    .table-header-fixer table {
                        word-break: break-all;
                        margin-bottom: 0;
                        font-size: 12px;
                    }

                    .header-fix-table {
                        padding-right: 17px;
                    }

                    .body-fix-table {
                        overflow-y: scroll;
                        overflow-x: visible;
                    }

                    .tbl_bg {
                        background: #3c8dbc;
                        color: #fff;
                    }

                    .chk_inpt input {
                        margin-right: 5px;
                    }

                    .chk_inpt label {
                        margin-left: 5px;
                    }

                    hr {
                        margin: 10px 0px 10px 0px;
                    }

                    .second_heading {
                        font-size: 30px;
                        font-weight: normal !important;
                    }

                    .Star {
                        color: red;
                    }

                    .mrgntp10 {
                        margin-top: 20px;
                    }

                    .panel-heading {
                        background: #3c8dbc !important;
                        text-align: center;
                        font-weight: bold;
                        font-size: 17px;
                        color: #fff !important;
                    }

                    .date-picker-icon:after {
                        font-family: FontAwesome;
                        content: '\f073';
                        display: block;
                        position: absolute;
                        right: 30px;
                        top: 7px;
                        color: #9999b2;
                        cursor: pointer;
                        pointer-events: none;
                    }
                </style>
                <div class="panel panel-primary ">
                    <div class="panel-heading" style="text-align: center">IMPORT MONTH </div>
                    <div class="panel-body form-horizontal">
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="brdr_box" style="text-align: center">
                                        <asp:LinkButton CssClass="btn btn-success" ID="btnImport" OnClick="btnImport_Click" runat="server"><i class="fa r fa-refresh"></i> IMPORT</asp:LinkButton>
                                        <%--<asp:LinkButton CssClass="btn btn-warning" ID="btnclear" OnClick="btnclear_Click" runat="server"><i class="fa r fa-close"></i>CLEAR</asp:LinkButton>--%>
                                        <asp:LinkButton CssClass="btn btn-danger" PostBackUrl="~/Salary/Dashboard.aspx" ID="btnExit" runat="server"><i class="fa r fa-close"></i> EXIT</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-footer">
                        <div class="row" style="text-align: center">
                            <div class="col-xs-12 col-sm-12 text-Center">
                                <asp:Label ID="lblMsg" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

