<%@ Page Title="" Language="C#" MasterPageFile="~/Salary/SalaryMaster.master" AutoEventWireup="true" CodeFile="FrmRetirmentBenfit.aspx.cs" Inherits="TransactionForm_FrmRetirmentBenfit" %>

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

        .header-fix-table {
            padding-right: 17px;
        }

        .pd-sm tr td {
            padding: 2px 4px !important;
        }

        .pd-sm tr th {
            padding: 2px 4px !important;
        }

        .f12 {
            font-size: 12px;
        }

        .br-wrd tr td, .br-wrd tr th {
            word-break: break-all;
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

            if ($('#ContentPlaceHolder1_txtEmployeeNo').val() == '') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed ');
                $('#ContentPlaceHolder1_lblMsg').html(' Please Enter Employee No');
                $('#ContentPlaceHolder1_txtEmployeeNo').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtEmployeeNo').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_txtEmployeeNo').css('border-color', 'lightgray');
            }
            if ($('#ContentPlaceHolder1_ddlSelectType').val() == '0') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').html(' Please Select Type ');
                $('#ContentPlaceHolder1_ddlSelectType').css('border-color', 'red');
                $('#ContentPlaceHolder1_ddlSelectType').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_ddlSelectType').css('border-color', 'lightgray');
            }
            if ($('#ContentPlaceHolder1_txtDOJ').val() == '') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').html(' Please Enter Date Of Joining ');
                $('#ContentPlaceHolder1_txtDOJ').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtDOJ').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_txtDOJ').css('border-color', 'lightgray');
            }

            if ($('#ContentPlaceHolder1_txtDOR').val() == '') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').html(' Please Enter Date Of Retirement ');
                $('#ContentPlaceHolder1_txtDOR').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtDOR').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_txtDOR').css('border-color', 'lightgray');
            }

            if ($('#ContentPlaceHolder1_txtDaPer').val() == '') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').html(' Please Enter DA ');
                $('#ContentPlaceHolder1_txtDaPer').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtDaPer').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_txtDaPer').css('border-color', 'lightgray');
            }

            if ($('#ContentPlaceHolder1_ddlSelectType').val() == '2') {

                if ($('#ContentPlaceHolder1_txtTotalLeave').val() == '') {
                    $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                    $('#ContentPlaceHolder1_lblMsg').html(' Please Enter Total No. Of Days ');
                    $('#ContentPlaceHolder1_txtTotalLeave').css('border-color', 'red');
                    $('#ContentPlaceHolder1_txtTotalLeave').focus();
                    return false;
                }
                else {
                    $('#ContentPlaceHolder1_txtTotalLeave').css('border-color', 'lightgray');
                }
            }

        }

        function CheckDays() {
            if ($('#ContentPlaceHolder1_txtTotalLeave').val() != '') {
                if ($('#ContentPlaceHolder1_txtTotalLeave').val() > 240) {
                    $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                    $('#ContentPlaceHolder1_lblMsg').html(' Total No. Of Days Not Greater-than 240 Days ');
                    $('#ContentPlaceHolder1_txtTotalLeave').css('border-color', 'red');
                    $('#ContentPlaceHolder1_txtTotalLeave').focus();
                    $('#ContentPlaceHolder1_txtTotalLeave').val('');
                    return false;
                } else {
                    $('#ContentPlaceHolder1_txtTotalLeave').css('border-color', 'lightgray');
                    $('#ContentPlaceHolder1_lblMsg').removeClass('alertMsg failed');
                    $('#ContentPlaceHolder1_lblMsg').html('');
                }
            }
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
                <div class="panel panel-primary ">
                    <div class="panel-heading" style="text-align: center">Retirement Benefit</div>
                    <div class="panel-body form-horizontal">
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="brdr_box">
                                        <div class="row">
                                            <div class="col-sm-12 col-xs-12 mtb">
                                                <div class="form-group">
                                                    <label class="col-sm-3 col-xs-12">Employee No.<i class="Star"> *</i></label>
                                                    <div class="col-sm-9">
                                                        <div class="row">
                                                            <div class="col-sm-4" style="text-align: left">
                                                                <asp:TextBox runat="server" ID="txtEmployeeNo" MaxLength="10" placeholder="Employee No." OnTextChanged="txtEmployeeNo_TextChanged" Style='text-transform: uppercase' AutoPostBack="true" CssClass="form-control form-control-xs numberonly" />
                                                            </div>
                                                            <div class="col-sm-8">
                                                                <asp:TextBox runat="server" ID="txtName" ReadOnly="true" MaxLength="50" placeholder="Name / Father Name" Style='text-transform: uppercase' CssClass="form-control form-control-xs" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12 col-xs-12 mtb">
                                                <div class="form-group">
                                                    <label class="col-sm-3 col-xs-12">Designation</label>
                                                    <div class="col-sm-9">
                                                        <asp:TextBox runat="server" ID="txtDesignation" ReadOnly="true" MaxLength="200" placeholder="Designation" Style='text-transform: uppercase' CssClass="form-control form-control-xs" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                      
                                        <div class="form-group">
                                            <div class="col-sm-12 col-xs-12 mtb">
                                                <div class="row">
                                                    <label class="col-sm-3 col-xs-12 ">
                                                        <asp:Label runat="server" Text="Basic / Grade Pay"></asp:Label>
                                                        <i class="Star"></i>
                                                    </label>
                                                    <div class="col-sm-9">
                                                        <div class="row">
                                                            <div class="col-sm-6">
                                                                <asp:TextBox runat="server" ID="lblBacic" ReadOnly="true" placeholder="Basic" CssClass="form-control form-control-xs" />
                                                            </div>
                                                            <div class="col-sm-6">
                                                                <asp:TextBox runat="server" ID="lblGradePay" ReadOnly="true" placeholder="Grade Pay" CssClass="form-control form-control-xs" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <style>
                                            .cstrw {
                                                width: 100%;
                                                background-color: #dcdcdc;
                                            }

                                                .cstrw label {
                                                    margin-top: 7px;
                                                }
                                        </style>

                                        <div class="row">
                                            <div class="col-sm-12 col-xs-12 mtb">
                                                <div class="form-group">
                                                    <label class="col-sm-3 col-xs-12">Select Type<i class="Star">*</i></label>
                                                    <div class="col-sm-9">
                                                        <asp:DropDownList runat="server" ID="ddlSelectType" CssClass="form-control form-control-xs" OnSelectedIndexChanged="ddlSelectType_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem Value="0" Text="-- Select type --" />
                                                            <asp:ListItem Value="1" Text="Gratuity" />
                                                            <asp:ListItem Value="2" Text="Leave Encashment" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <div class="col-sm-12 col-xs-12 mtb">
                                                <div class="row">
                                                    <label class="col-sm-3 col-xs-12 ">
                                                        <asp:Label runat="server" Text="DOJ. / DOR."></asp:Label>
                                                        <i class="Star">*</i></label>
                                                    <div class="col-sm-9">
                                                        <div class="row">
                                                            <div class="col-sm-6 date-picker-icon">
                                                                <asp:TextBox runat="server" ID="txtDOJ" Enabled="false" MaxLength="10" CssClass="form-control form-control-xs datepicker" placeholder="dd/mm/yyyy" />
                                                            </div>
                                                            <div class="col-sm-6 date-picker-icon">
                                                                <asp:TextBox runat="server" ID="txtDOR" MaxLength="10" OnTextChanged="txtDOR_TextChanged" AutoPostBack="true" CssClass="form-control form-control-xs datepicker" placeholder="dd/mm/yyyy" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <asp:HiddenField runat="server" ID="hfRrdInd" />
                                         <asp:HiddenField runat="server" ID="hfTotalMonth" />
                                        <%--<div class="form-group" id="divDMYDesc" runat="server" visible="false">--%>
                                        <div class="form-group" runat="server">
                                            <div class="col-sm-12 col-xs-12 mtb">
                                                <div class="row">
                                                    <label class="col-sm-3 col-xs-12 ">
                                                        <asp:Label runat="server" ID="Label1" Text=""></asp:Label>
                                                        <i class="Star"></i>
                                                    </label>
                                                    <div class="col-sm-9">
                                                        <div class="cstrw">
                                                            <div class="row">
                                                                <div class="col-sm-4">
                                                                    <label class="col-sm-3">Year</label>
                                                                    <div class="col-sm-9">
                                                                        <asp:Label runat="server" ID="lblYear" ReadOnly="true" CssClass="form-control " />
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <label class="col-sm-3">Month</label>
                                                                    <div class="col-sm-9">
                                                                        <asp:Label runat="server" ID="lblMonth" ReadOnly="true" CssClass="form-control " />
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <label class="col-sm-3">Days</label>
                                                                    <div class="col-sm-9">
                                                                        <asp:Label runat="server" ID="lblDays" ReadOnly="true" CssClass="form-control " />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <div class="col-sm-12 col-xs-12 mtb">
                                                <div class="row">
                                                    <label class="col-sm-3 col-xs-12 "><i class="Star"></i></label>
                                                    <div class="col-sm-9">
                                                        <div class="row">

                                                            <div class="col-sm-6">
                                                                <asp:TextBox runat="server" ID="txtDaPer" MaxLength="10" placeholder="Enter DA % " CssClass="form-control form-control-xs numberonly" />
                                                            </div>
                                                            <div class="col-sm-6" runat="server" id="DivTotalLeave" visible="false">
                                                                <asp:TextBox onchange="return CheckDays()" runat="server" ID="txtTotalLeave" MaxLength="10" placeholder="Enter Total Leave" CssClass="form-control form-control-xs numberonly" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group" id="divPayableAmount" runat="server" visible="false">
                                            <div class="col-sm-12 col-xs-12 mtb">
                                                <div class="row">
                                                    <label class="col-sm-3 col-xs-12 ">
                                                        Payable Amount

                                                        <i class="Star"></i>
                                                    </label>
                                                    <div class="col-sm-9">
                                                        <div class="row">
                                                            <div class="col-sm-6">
                                                                <asp:Label runat="server" ID="lblPayableAmount" CssClass="form-control form-control-xs" />
                                                            </div>
                                                            <div class="col-sm-6">
                                                            </div>
                                                        </div>
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
                            <div class="col-xs-12 col-sm-12 text-right">
                                <asp:Label ID="lblMsg" runat="server" />
                                <asp:LinkButton CssClass="btn btn-info" ID="lnkBtnCalculate" runat="server" OnClientClick="return Validation()" OnClick="lnkBtnCalculate_Click"><i class="fa r fa-calculator"></i> Calculate</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-success" ID="btnSave"  OnClientClick="return Validation()" runat="server" OnClick="btnSave_Click"><i class="fa r fa-save"></i> Save</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-warning" ID="btnclear" OnClick="btnclear_Click" runat="server"><i class="fa r fa-refresh"></i> Clear</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-danger" ID="btnExit" PostBackUrl="~/Salary/Dashboard.aspx" runat="server"><i class="fa r fa-close"></i> Exit</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

