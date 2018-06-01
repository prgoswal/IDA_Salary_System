<%@ Page Title="" Language="C#" MasterPageFile="~/Salary/SalaryMaster.master" AutoEventWireup="true" CodeFile="RptDesgWarkingvacant.aspx.cs" Inherits="Salary_Report_RptDesgWarkingvacant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <script>
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

    <script type="text/javascript">
        function Validation() {

            if ($('#ContentPlaceHolder1_ddlReportName').val() == '0') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').html(' Please Select Type ');
                $('#ContentPlaceHolder1_ddlReportName').css('border-color', 'red');
                $('#ContentPlaceHolder1_ddlReportName').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_ddlReportName').css('border-color', 'lightgray');
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:UpdatePanel ID="updatepnl" runat="server">
        <ContentTemplate>
            <div class="col-xs-12 col-sm-6 col-sm-offset-3 mrgntp10 mt10">
                <div class="panel panel-primary">
                    <div class="panel-heading"> Designation Wish Working Vacant Post</div>
                    <div class="panel-body form-horizontal">
                        <div class="row" style="text-align: center">
                            <div class="col-sm-12 mtb">
                                <div class="form-group">
                                    <label class="col-sm-3 col-xs-12">Class Name<i class="Star"> *</i></label>
                                    <div class="col-sm-9">
                                        <asp:DropDownList runat="server" ID="ddlClass" CssClass="form-control form-control-xs">
                                            <asp:ListItem Text="----Select---" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-footer">
                        <div class="row">
                            <div class="col-xs-12 col-sm-12 text-center">
                                <asp:LinkButton CssClass="btn btn-info" ID="btnShow"  OnClick="btnShow_Click" runat="server"><i class="fa r  fa-eye"></i> Preview</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-danger" PostBackUrl="~/Salary/Dashboard.aspx"  ID="btncancel"  runat="server"><i class="fa r fa-close"></i> Exit</asp:LinkButton>
                                <asp:Label ID="lblMsg" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

