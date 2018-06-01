<%@ Page Title="" Language="C#" MasterPageFile="~/Salary/SalaryMaster.master" AutoEventWireup="true" CodeFile="FrmLoanOpening.aspx.cs" Inherits="TransactionForm_FrmLoanOpening" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function LoadAllScript() {
            LoadBasic();

            $(document).ready(function () {
                $(".fi-chkAllDesgination input").click(function () {
                    if ($(this).is(":checked")) {
                        $(".fi-ChkDesignation input").prop('checked', true);
                    } else {
                        $(".fi-ChkDesignation input").prop('checked', false);
                    }
                });
                $(".fi-ChkDesignation input").click(function () {
                    var cbcheked = $(".fi-ChkDesignation input:checked").length;
                    var cbblank = $(".fi-ChkDesignation input").length;

                    if (cbcheked < cbblank) {
                        if ($(".fi-chkAllDesgination input").is(":checked")) {
                            $(".fi-chkAllDesgination input").prop('checked', false);
                        }
                    }
                    if (cbcheked == cbblank) {
                        $(".fi-chkAllDesgination input").prop('checked', true);
                    }
                });
            });


            $(document).ready(function () {
                $(".fi-ChkAllEmpType input").click(function () {
                    if ($(this).is(":checked")) {
                        $(".fi-chkEmpType input").prop('checked', true);
                    } else {
                        $(".fi-chkEmpType input").prop('checked', false);
                    }
                });

                $(".fi-chkEmpType input").click(function () {
                    var cbcheked = $(".fi-chkEmpType input:checked").length;
                    var cbblank = $(".fi-chkEmpType input").length;

                    if (cbcheked < cbblank) {
                        if ($(".fi-ChkAllEmpType input").is(":checked")) {
                            $(".fi-ChkAllEmpType input").prop('checked', false);
                        }
                    }
                    if (cbcheked == cbblank) {
                        $(".fi-ChkAllEmpType input").prop('checked', true);
                    }
                });
            });

            $(document).ready(function () {
                $(".fi-ChkAllDepartment input").click(function () {
                    if ($(this).is(":checked")) {
                        $(".fi-ChkDepartment input").prop('checked', true);
                    } else {
                        $(".fi-ChkDepartment input").prop('checked', false);
                    }
                });

                $(".fi-ChkDepartment input").click(function () {
                    var cbcheked = $(".fi-ChkDepartment input:checked").length;
                    var cbblank = $(".fi-ChkDepartment input").length;

                    if (cbcheked < cbblank) {
                        if ($(".fi-ChkAllDepartment input").is(":checked")) {
                            $(".fi-ChkAllDepartment input").prop('checked', false);
                        }
                    }
                    if (cbcheked == cbblank) {
                        $(".fi-ChkAllDepartment input").prop('checked', true);
                    }
                });
            });

            $(document).ready(function () {
                $(".fi-chkAllClass input").click(function () {
                    if ($(this).is(":checked")) {
                        $(".fi-ChkClass input").prop('checked', true);
                    } else {
                        $(".fi-ChkClass input").prop('checked', false);
                    }
                });

                $(".fi-ChkClass input").click(function () {
                    var cbcheked = $(".fi-ChkClass input:checked").length;
                    var cbblank = $(".fi-ChkClass input").length;

                    if (cbcheked < cbblank) {
                        if ($(".fi-chkAllClass input").is(":checked")) {
                            $(".fi-chkAllClass input").prop('checked', false);
                        }
                    }
                    if (cbcheked == cbblank) {
                        $(".fi-chkAllClass input").prop('checked', true);
                    }
                });
            });

            $(document).ready(function () {
                $(".fi-chkAllGrade input").click(function () {
                    if ($(this).is(":checked")) {
                        $(".fi-ChkGrad input").prop('checked', true);
                    } else {
                        $(".fi-ChkGrad input").prop('checked', false);
                    }
                });

                $(".fi-ChkGrad input").click(function () {
                    var cbcheked = $(".fi-ChkGrad input:checked").length;
                    var cbblank = $(".fi-ChkGrad input").length;

                    if (cbcheked < cbblank) {
                        if ($(".fi-chkAllGrade input").is(":checked")) {
                            $(".fi-chkAllGrade input").prop('checked', false);
                        }
                    }
                    if (cbcheked == cbblank) {
                        $(".fi-chkAllGrade input").prop('checked', true);
                    }
                });
            });


        }
    </script>

    <style>
        .td-pd-sm tr th, .td-pd-sm tr td {
            padding: 2px 6px !important;
        }

        .pointer, .pointer label, .pointer input {
            cursor: pointer;
        }

        .no-selectable {
            user-select: none;
        }

        .internaldeduct-checklist {
            padding: 10px;
            border: 0;
            border-radius: 0px;
            min-height: 125px;
            max-height: 120px;
            overflow-y: scroll;
            font-size: 12px;
            margin-left: -15px;
            margin-top: -10px;
        }

            .internaldeduct-checklist table {
                width: 100%;
            }

                .internaldeduct-checklist table tr td {
                    /*width: 100%;*/
                }

                    .internaldeduct-checklist table tr td input, .internaldeduct-checklist table tr td label {
                        font-weight: normal;
                        display: block;
                        float: left;
                        cursor: pointer;
                    }

                    .internaldeduct-checklist table tr td label {
                        margin-top: 2px;
                        margin-left: 2px;
                    }

                    .internaldeduct-checklist table tr td input:checked + label {
                        font-weight: bold;
                    }

        fieldset.scheduler-border {
            border: 1px solid #d4d4d4 !important;
            padding-left: 15px;
            padding-top: 5px;
            border-radius: 4px;
            margin-bottom: 15px;
        }


        legend.scheduler-border {
            width: inherit; /* Or auto */
            padding: 0 10px; /* To give a bit of padding on the left and right */
            border-bottom: none;
            font-size: 12px;
            font-weight: bold;
            margin-bottom: 0px;
        }

        .radio-list-normal, .check-list-normal {
            float: left;
            padding-bottom: 5px;
        }

            .radio-list-normal input, .radio-list-normal label, .check-list-normal input, .check-list-normal label {
                display: block;
                float: left;
                cursor: pointer;
                user-select: none;
                font-weight: normal;
            }

            .radio-list-normal label, .check-list-normal label {
                margin-top: 2px;
                margin-left: 3px;
                margin-right: 15px;
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

        table.gender-chklist {
            width: 100%;
            margin: 0;
        }

        .gender-chklist tr td {
            width: 33%;
            padding-left: 5px;
        }

        .table-select-query-filter {
            margin-bottom: 0;
        }

            .table-select-query-filter tr th {
                background: #3c8dbc;
                color: #fff;
            }
    </style>
    <script type="text/javascript">
        function Validation() {
            if ($('#ContentPlaceHolder1_txtEmployeeNo').val().Trim() == '') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed ');
                $('#ContentPlaceHolder1_lblMsg').html(' Please Enter Employee No');
                $('#ContentPlaceHolder1_txtEmployeeNo').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtEmployeeNo').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_txtEmployeeNo').css('border-color', 'lightgray');
            }
            if ($('#ContentPlaceHolder1_ddlTypeofLeave').val() == '0') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').html(' Please Select Type of Leave');
                $('#ContentPlaceHolder1_ddlTypeofLeave').css('border-color', 'red');
                $('#ContentPlaceHolder1_ddlTypeofLeave').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_ddlTypeofLeave').css('border-color', 'lightgray');
            }
        }
    </script>

    <style>
        .mt10 {
            margin-top: 10px;
        }

        .blhed {
            background-color: #3c8dbc;
        }

        .chk {
            color: #fff;
        }

            .chk input {
                display: block;
                float: left;
                margin-right: 4px;
                cursor: pointer;
            }

            .chk label {
                display: block;
                float: left;
                margin-top: 2px;
                margin-bottom: 0 !important;
                cursor: pointer;
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
            margin-bottom: 0;
            margin-top: 0;
            cursor: pointer;
        }

        .chk_inpt label {
            margin-left: 5px;
            margin-bottom: 0 !important;
            cursor: pointer;
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

        .form-group {
            margin-bottom: 10px;
        }

        .th-middle tr th {
            vertical-align: middle;
        }

        .form-control {
            height: 30px !important;
            line-height: 30px !important;
            padding: 5px 5px !important;
        }

        .mb0 {
            margin-bottom: 0;
        }
    </style>
    <script>
        function Close() {
            $('#<%=chkBulk.ClientID%>').prop('checked', true);
            $('#myModal').modal('hide');
            $('.modal-backdrop').removeClass('modal-backdrop');

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

            <div class="col-xs-12 col-sm-10 col-sm-offset-1 mrgntp10 mt10">
                <div class="panel panel-primary mb0">
                    <div class="panel-heading" style="text-align: center; padding: 3px 3px; margin-top: -27px;">NEW LOAN OPENING</div>
                    <div class="panel-body form-horizontal">
                        <asp:Panel ID="pnlSingleEmployee" runat="server">

                            <div class="col-sm-12">
                                <div class="brdr_box row">
                                    <div class="blhed row" style="margin-bottom: 10px; margin-top: -10px">

                                        <div class="col-sm-12 col-xs-12 mtb">
                                            <div class="chk">
                                                <asp:CheckBox ID="chkBulk" runat="server" Text="BULK EMPLOYEE" OnCheckedChanged="chkBulk_CheckedChanged" AutoPostBack="true" />

                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" id="divEmployeeDetails" runat="server">
                                        <div class="col-sm-12 col-xs-12 mtb">
                                            <div class="form-group">
                                                <label class="col-sm-2 col-xs-12">Employee No.<i class="Star"> *</i></label>
                                                <div class="col-sm-10">
                                                    <div class="row">
                                                        <div class="col-sm-3" style="text-align: left">
                                                            <asp:TextBox runat="server" ID="txtEmployeeNo" MaxLength="8" placeholder="Employee No." OnTextChanged="txtEmployeeNo_TextChanged" Style='text-transform: uppercase' AutoPostBack="true" CssClass="form-control form-control-xs numberonly" />
                                                        </div>
                                                        <div class="col-sm-6">
                                                            <asp:TextBox runat="server" ID="txtName" ReadOnly="true" placeholder="Name / Father Name" Style='text-transform: uppercase' CssClass="form-control form-control-xs" />
                                                        </div>
                                                        <div class="col-sm-3">
                                                            <asp:TextBox runat="server" ID="txtDesignation" ReadOnly="true" placeholder="Designation" Style='text-transform: uppercase' CssClass="form-control form-control-xs" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 col-xs-12 mtb">
                                            <div class="form-group">
                                                <label class="col-sm-2 col-xs-12">Loan Type <i class="Star">*</i></label>
                                                <div class="col-sm-4 col-xs-12">
                                                    <asp:DropDownList runat="server" ID="ddlTypeofLoan" OnSelectedIndexChanged="ddlTypeofLoan_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control form-control-xs">
                                                        <asp:ListItem Text="text1" />
                                                    </asp:DropDownList>
                                                </div>
                                                <label class="col-sm-2 col-xs-12">Interest Rate<i class="Star">*</i></label>
                                                <div class="col-sm-4 col-xs-12">
                                                    <asp:TextBox runat="server" ID="txtInterestRate" MaxLength="10" Enabled="false" placeholder="Interest Rate" Style='text-transform: uppercase' CssClass="form-control form-control-xs Amount" />
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 col-xs-12 mtb">
                                            <div class="form-group">
                                                <label class="col-sm-2 col-xs-12">Actual Loan Amount<i class="Star">*</i></label>
                                                <div class="col-sm-4 col-xs-12">
                                                    <asp:TextBox runat="server" ID="txtActualLoanAmount" MaxLength="10" OnTextChanged="txtActualLoanAmount_TextChanged" AutoPostBack="true" placeholder="Actual Loan Amount" Style='text-transform: uppercase' CssClass="form-control form-control-xs Amount" />
                                                </div>
                                                <label class="col-sm-2 col-xs-12">Interest Amount<i class="Star">*</i></label>
                                                <div class="col-sm-4 col-xs-12">
                                                    <asp:TextBox runat="server" ID="txtInterestAmount"  MaxLength="10" placeholder="Interest Amount" Enabled="false" Style='text-transform: uppercase' CssClass="form-control form-control-xs Amount" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 col-xs-12 mtb">
                                            <div class="form-group">
                                                <label class="col-sm-2 col-xs-12">Loan Senction Date<i class="Star">*</i></label>
                                                <div class="col-sm-4 col-xs-12 date-picker-icon">
                                                    <asp:TextBox runat="server" ID="txtLoanSectionDate" MaxLength="10" Style='text-transform: uppercase;' CssClass="datepicker form-control form-control-xs date-picker-icon" placeholder="DD/MM/YYYY" />
                                                </div>
                                                <label class="col-sm-2 col-xs-12">Deduction Month <i class="Star">*</i></label>
                                                <div class="col-sm-4 col-xs-12">
                                                    <asp:DropDownList runat="server" ID="ddlDeductionMonth" CssClass="form-control form-control-xs">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 col-xs-12 mtb">
                                            <div class="form-group">
                                                <label class="col-sm-2 col-xs-12">Monthly Instalments<i class="Star">*</i></label>
                                                <div class="col-sm-4 col-xs-12">
                                                    <asp:TextBox runat="server" ID="txtMonthlyIncome" MaxLength="10" OnTextChanged="txtMonthlyIncome_TextChanged" Enabled="false" AutoPostBack="true" placeholder="Monthly Instalments" Style='text-transform: uppercase' CssClass="form-control form-control-xs Decimal4" />
                                                </div>
                                                <label class="col-sm-2 col-xs-12">No Of Instalments<i class="Star">*</i></label>
                                                <div class="col-sm-4 col-xs-12">
                                                    <asp:TextBox runat="server" ID="txtNoOfInstalments" MaxLength="10" placeholder="No Of Instalments" Enabled="false" Style='text-transform: uppercase' CssClass="form-control form-control-xs Decimal4" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 col-xs-12 mtb">
                                            <div class="form-group">
                                                <label class="col-sm-2 col-xs-12">Voucher No.<i class="Star">*</i></label>
                                                <div class="col-sm-4 col-xs-12">
                                                    <asp:TextBox runat="server" ID="txtVNo" MaxLength="8" placeholder="Voucher No." Style='text-transform: uppercase' CssClass="form-control form-control-xs numberonly" />
                                                </div>
                                                <label class="col-sm-2 col-xs-12">Ref. No.<i class="Star"></i></label>
                                                <div class="col-sm-4 col-xs-12">
                                                    <asp:TextBox runat="server" ID="txtRefNo" MaxLength="10" placeholder="Ref. No." Style='text-transform: uppercase' CssClass="form-control form-control-xs numberonly" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 col-xs-12 mtb">
                                            <div class="form-group">
                                                <label class="col-sm-2 col-xs-12">Narration</label>
                                                <div class="col-sm-10">
                                                    <asp:TextBox ID="txtNarration" runat="server" MaxLength="50" class="msgbox form-control" placeholder="Enter Narration"></asp:TextBox>
                                                    <span style="float: right; font-size: 18px;" id="textarea_feedback"></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </asp:Panel>
                        <asp:Panel ID="pnlBulkEmployee" runat="server">
                            <div class="modal   in" id="myModal" tabindex="-1" role="dialog" aria-labelledby="msgModalLabel" data-keyboard="false" data-backdrop="static">
                                <div class="modal-dialog" role="document" style="margin: 0 auto; width: 100%; max-width: 990px; margin-top: 50px">
                                    <div class="modal-content">
                                        <div class="modal-header" style="background-color: steelblue; color: white; padding: 10px">
                                            <%--<button type="button" class="close" data-dismiss="modal" style="color: #fff; background: red; border-radius: 100%; height: 20px; font-size: 14px; width: 20px; margin-top: 2px;">
                                                            &times;</button>--%>
                                            <asp:LinkButton ID="lnkBtnclose" OnClientClick="return Close();" class="close" Style="color: #fff; background: red; border-radius: 100%; height: 20px; font-size: 14px; padding: 4px; width: 20px; margin-top: 2px;" runat="server">&times;</asp:LinkButton>
                                            <h4 class="modal-title">Filter Information<span>
                                                <img style="width: 159px; position: absolute; top: 19px; display: none; left: 127px; z-index: 999; border-radius: 20px 20px" alt="downloading..." />
                                            </span></h4>
                                        </div>
                                        <div class="modal-body">
                                            <%------------------------------------START---------------------------------------------------------------%>

                                            <div class="container-fluid" style="max-width: 1100px">
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <div class="panel panel-primary mt10">

                                                            <div class="panel-body form-horizontal">
                                                                <div class="row">
                                                                    <div class="col-xs-12 col-sm-6">
                                                                        <fieldset class="scheduler-border">
                                                                            <legend class="scheduler-border">Filter Field</legend>
                                                                            <div class="internaldeduct-checklist " style="font-size: 14px">
                                                                                <asp:CheckBoxList runat="server" OnSelectedIndexChanged="chkFilterField_SelectedIndexChanged" AutoPostBack="true" RepeatColumns="3" ID="chkFilterField">
                                                                                </asp:CheckBoxList>
                                                                            </div>
                                                                        </fieldset>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-xs-12 col-sm-12">
                                                                        <fieldset class="scheduler-border" style="padding-top: 15px">
                                                                            <legend class="scheduler-border hidden">&nbsp;</legend>
                                                                            <div class="row">
                                                                                <div class="col-xs-12 col-sm-8">

                                                                                    <div class="form-group" id="divDoj" runat="server" visible="false">
                                                                                        <label runat="server" class="col-xs-12 col-sm-4 control-label">Date Of Join</label>
                                                                                        <div class="col-xs-12 col-sm-4 date-picker-icon">
                                                                                            <asp:TextBox runat="server" CssClass="datepicker form-control form-control-xs date-picker-icon" ID="txtDateOfJoin" placeholder="DD/MM/YYYY" />
                                                                                        </div>
                                                                                        <div class="col-xs-12 col-sm-4">
                                                                                            <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rbDateOfJoin" CssClass="check-list-normal" Style="margin-top: 8px">
                                                                                                <asp:ListItem Value="0" Text="Before" Selected="True" />
                                                                                                <asp:ListItem Value="1" Text="After" />
                                                                                            </asp:RadioButtonList>
                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="form-group" id="divDor" runat="server" visible="false">
                                                                                        <label runat="server" class="col-xs-12 col-sm-4 control-label">Retirement Date</label>
                                                                                        <div class="col-xs-12 col-sm-4 date-picker-icon">
                                                                                            <asp:TextBox runat="server" CssClass="datepicker form-control form-control-xs date-picker-icon" ID="txtDateOfRetir" placeholder="DD/MM/YYYY" />
                                                                                        </div>
                                                                                        <div class="col-xs-12 col-sm-4">
                                                                                            <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rbDateOfRetir" CssClass="check-list-normal" Style="margin-top: 8px">
                                                                                                <asp:ListItem Value="0" Text="Before" Selected="True" />
                                                                                                <asp:ListItem Value="1" Text="After" />
                                                                                            </asp:RadioButtonList>
                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="form-group" runat="server" visible="false">
                                                                                        <label id="Label1" runat="server" class="col-xs-12 col-sm-3 control-label">Suspend Date From</label>
                                                                                        <div class="col-xs-12 col-sm-4 date-picker-icon">
                                                                                            <asp:TextBox runat="server" CssClass="datepicker form-control form-control-xs date-picker-icon" ID="txtSuspendDateFrom" placeholder="DD/MM/YYYY" />
                                                                                        </div>
                                                                                        <div class="col-xs-12 col-sm-1">
                                                                                            <label id="Label2" runat="server" class="col-xs-12 col-sm-3 control-label">To</label>
                                                                                        </div>
                                                                                        <div class="col-xs-12 col-sm-4">
                                                                                            <asp:TextBox runat="server" CssClass="datepicker form-control form-control-xs date-picker-icon" ID="txttxtSuspendDateTo" placeholder="DD/MM/YYYY" />
                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="form-group" id="divEmpNo" runat="server" visible="false">
                                                                                        <label id="Label3" runat="server" class="col-xs-12 col-sm-3 control-label">Emp. No. From</label>
                                                                                        <div class="col-xs-12 col-sm-3">
                                                                                            <asp:TextBox runat="server" CssClass="form-control form-control-xs" ID="txtEmpNoFrom" placeholder="Emp. From" OnTextChanged="txtEmpNoFrom_TextChanged" AutoPostBack="true" />
                                                                                        </div>

                                                                                        <label id="Label4" runat="server" class="col-xs-12 col-sm-3 control-label">Emp. No. To</label>
                                                                                        <div class="col-xs-12 col-sm-3">
                                                                                            <asp:TextBox runat="server" CssClass="form-control form-control-xs" ID="txtEmpNoTo" placeholder="Emp. To" />
                                                                                        </div>

                                                                                    </div>


                                                                                    <div class="form-group" id="divGender" runat="server" visible="false">
                                                                                        <asp:CheckBoxList ID="chkGender" runat="server" CssClass="check-list-normal gender-chklist" DataTextField="language" DataValueField="language" RepeatColumns="1">
                                                                                            <asp:ListItem Value="0" Selected="True">Both</asp:ListItem>
                                                                                            <asp:ListItem Value="1">Male</asp:ListItem>
                                                                                            <asp:ListItem Value="2">Female</asp:ListItem>
                                                                                        </asp:CheckBoxList>
                                                                                    </div>


                                                                                </div>

                                                                            </div>
                                                                        </fieldset>
                                                                    </div>
                                                                </div>
                                                                <div class="row">


                                                                    <div class="col-xs-12 col-sm-3" id="divClass" runat="server" visible="false">
                                                                        <fieldset class="scheduler-border">
                                                                            <legend class="scheduler-border">Class</legend>
                                                                            <div class="internaldeduct-checklist ">
                                                                                <asp:CheckBox ID="chkAllClass" Text="Select All" runat="server" CssClass="fi-chkAllClass" />
                                                                                <asp:CheckBoxList runat="server" RepeatColumns="1" ID="ChkClass" CssClass="fi-ChkClass">
                                                                                </asp:CheckBoxList>
                                                                            </div>
                                                                        </fieldset>
                                                                    </div>

                                                                    <div class="col-xs-12 col-sm-3" id="divDesignation" runat="server" visible="false">
                                                                        <fieldset class="scheduler-border">
                                                                            <legend class="scheduler-border">Designation</legend>
                                                                            <div class="internaldeduct-checklist ">
                                                                                <asp:CheckBox ID="chkAllDesgination" Text="Select All" runat="server" CssClass="fi-chkAllDesgination" />
                                                                                <asp:CheckBoxList runat="server" ID="ChkDesignation" RepeatColumns="1" CssClass="fi-ChkDesignation">
                                                                                </asp:CheckBoxList>
                                                                            </div>
                                                                        </fieldset>
                                                                    </div>

                                                                    <div class="col-xs-12 col-sm-3" id="divGrade" runat="server" visible="false">
                                                                        <fieldset class="scheduler-border">
                                                                            <legend class="scheduler-border">Grade</legend>
                                                                            <div class="internaldeduct-checklist ">
                                                                                <asp:CheckBox Text="Select All" runat="server" ID="chkAllGrade" CssClass="fi-chkAllGrade" />
                                                                                <asp:CheckBoxList runat="server" RepeatColumns="1" ID="ChkGrad" CssClass="fi-ChkGrad">
                                                                                </asp:CheckBoxList>
                                                                            </div>
                                                                        </fieldset>
                                                                    </div>

                                                                    <div class="col-xs-12 col-sm-3" id="divDepartment" runat="server" visible="false">
                                                                        <fieldset class="scheduler-border">
                                                                            <legend class="scheduler-border">Department</legend>
                                                                            <div class="internaldeduct-checklist ">
                                                                                <asp:CheckBox Text="Select All" runat="server" ID="ChkAllDepartment" CssClass="fi-ChkAllDepartment" />
                                                                                <asp:CheckBoxList runat="server" ID="ChkDepartment" RepeatColumns="1" CssClass="fi-ChkDepartment" />
                                                                            </div>
                                                                        </fieldset>
                                                                    </div>


                                                                    <div class="col-xs-12 col-sm-3" id="divEmpType" runat="server" visible="false">
                                                                        <fieldset class="scheduler-border">
                                                                            <legend class="scheduler-border">Emp Type</legend>
                                                                            <div class="internaldeduct-checklist ">
                                                                                <asp:CheckBox Text="Select All" runat="server" ID="ChkAllEmpType" CssClass="fi-ChkAllEmpType" />
                                                                                <asp:CheckBoxList runat="server" ID="chkEmpType" CssClass="fi-chkEmpType">
                                                                                </asp:CheckBoxList>
                                                                            </div>
                                                                        </fieldset>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="panel-footer text-left">
                                                                <asp:LinkButton CssClass="btn btn-info" ID="bntAddGrid" OnClientClick="return Close();" runat="server" OnClick="bntAddGrid_Click"><i class="fa r fa-save"></i> Add In Grid </asp:LinkButton>
                                                                <input type="button" class="btn btn-danger" onclick="return Close();" value="Close" data-dismiss="modal" />
                                                                <asp:Label ID="lblPopUpErrorMsg" runat="server" ForeColor="Red" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <%--------------------------------------END-------------------------------------------------------------%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <div class="row" id="divGrid" runat="server" visible="false">
                            <%-- <div class="col-xs-12">
                                <div class="col-sm-10 col-xs-12 pull-right">
                                    <div class="table-responsive">
                                        <asp:GridView ID="GvFilterInformation" ShowHeader="True" AutoGenerateColumns="true" EmptyDataText="No records Found" runat="server" CssClass="table table-bordered table-select-query-filter td-pd-sm">
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>--%>
                            <div class="col-sm-10 col-xs-12 pull-right">
                                <div class="table-responsive">
                                    <div class="col-sm-12">
                                        <div class="table-header-fixer" style="padding-right: 17px">
                                            <table class="table table-bordered f12 pd-sm br-wrd">
                                                <tr class="tbl_bg th-middle">
                                                    <th style="width: 5%" class="chk">
                                                        <asp:CheckBox Text="All" ID="chkAll" OnCheckedChanged="chkAll_CheckedChanged" AutoPostBack="true" runat="server" />

                                                    </th>
                                                    <th style="width: 6%">Sr. No.
                                                    </th>
                                                    <th style="width: 10%">Emp. No.</th>
                                                    <th style="width: 35%">Name / Father Name</th>
                                                    <th style="width: 22%">Desigantion</th>
                                                    <th style="width: 22%">Department</th>

                                                </tr>
                                            </table>
                                        </div>

                                        <div class="body-fix-table" style="max-height: 160px">
                                            <asp:GridView ID="GvFilterInformation" ShowHeader="False" AutoGenerateColumns="false" EmptyDataText="No records Found" runat="server" CssClass="table table-bordered table-select-query-filter td-pd-sm f12 table-hover">
                                                <Columns>

                                                    <asp:TemplateField ItemStyle-Width="5%" ItemStyle-CssClass="chk">
                                                        <ItemTemplate>
                                                            <asp:CheckBox Text="" runat="server" ID="chk_Grid" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="6%" >
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField ItemStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEmpNo" Text='<%#Eval("EmpNo") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField ItemStyle-Width="35%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblName" Text='<%#Eval("FirstName") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField ItemStyle-Width="22%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDesgDesc" Text='<%#Eval("DesgDesc") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField ItemStyle-Width="22%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEdcd" Text='<%#Eval("DeptName") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                <RowStyle ForeColor="#000066" />
                                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                                            </asp:GridView>
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
                                <asp:LinkButton CssClass="btn btn-success" ID="btnSave" OnClick="btnSave_Click" runat="server"><i class="fa r fa-save"></i> Save</asp:LinkButton>
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

