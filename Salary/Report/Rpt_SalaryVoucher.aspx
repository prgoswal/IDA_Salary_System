<%@ Page Title="" Language="C#" MasterPageFile="~/Salary/SalaryMaster.master" AutoEventWireup="true" CodeFile="Rpt_SalaryVoucher.aspx.cs" Inherits="Report_Rpt_SalaryVoucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function LoadAllScript() {
            LoadBasic();
        }
    </script>
    <style>
        .mt10 {
            margin-top: 10px;
        }

        .table-header-fixer table {
            word-break: break-all;
            margin-bottom: 0;
            font-size: 12px;
        }

        .headerf-ix-table {
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

        .rdo label {
            margin-left: 3px;
        }

        .rdo table {
            max-width: 500px;
            margin: 0 auto;
        }

            .rdo table tr td {
                width: 33%;
            }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="updatepnl" runat="server">
        <ContentTemplate>
            <script>
                Sys.Application.add_load(LoadAllScript);
            </script>
            <div class="col-xs-12 col-sm-6 col-sm-offset-3 mrgntp10 mt10">
                <div class="panel panel-primary ">
                    <div class="panel-heading" style="text-align: center">Salary Voucher</div>
                    <div class="panel-body form-horizontal">
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="brdr_box">

                                        <div class="row">
                                            <div class="col-sm-12 col-xs-12">
                                                <div class="form-group">
                                                    <label class="col-xs-3">Employee&nbsp;Type<i class="text-danger">&nbsp;*</i></label><div class="col-sm-9">
                                                        <asp:DropDownList runat="server" CssClass="form-control form-control-xs col-sm-9" ID="ddlEmpType"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-footer">
                        <div class="row">
                            <div class="col-xs-12 col-sm-12 text-left">
                                <asp:LinkButton CssClass="btn btn-info" ID="btnpreview" OnClick="btnpreview_Click" runat="server"><i class="fa r  fa-eye"></i> Preview</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-danger" ID="btnExit" PostBackUrl="~/Salary/Dashboard.aspx" runat="server"><i class="fa r fa-close"></i> Exit</asp:LinkButton>
                                <asp:Label ID="lblMsg" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

