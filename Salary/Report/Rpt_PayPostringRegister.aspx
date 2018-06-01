<%@ Page Title="" Language="C#" MasterPageFile="~/Salary/SalaryMaster.master" AutoEventWireup="true" CodeFile="Rpt_PayPostringRegister.aspx.cs" Inherits="Report_Rpt_PayPostringRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        function LoadAllScript() {
            LoadBasic();
        }
    </script>
    <style>
        fieldset.scheduler-border {
            border: 1px solid #d4d4d4 !important;
            padding-left: 15px;
            padding-top: 5px;
            border-radius: 4px;
            margin-bottom: 0px;
        }

        fieldset .form-group {
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
    </style>
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

        .radio-5-grid .radio-col {
            width: 20%;
            float: left;
        }

            .radio-5-grid .radio-col input, .radio-5-grid .radio-col label {
                display: block;
                float: left;
                cursor: pointer;
                font-weight: normal;
            }

                .radio-5-grid .radio-col input:checked + label {
                    font-weight: bold;
                }

            .radio-5-grid .radio-col label {
                margin-top: 2px;
                margin-left: 3px;
            }

        .mlr-auto {
            margin-left: auto;
            margin-right: auto;
        }
    </style>

    <style>
        .pointer, .pointer label, .pointer input {
            cursor: pointer;
        }

        .no-selectable {
            user-select: none;
        }

        .internaldeduct-checklist {
            padding: 10px;
            border: 1px solid transparent;
            max-height: 220px;
            overflow-y: scroll;
            font-size: 13px;
            margin-left: -30px;
            margin-right: -15px;
            margin-top: -15px;
            padding-top: 16px;
        }

            .internaldeduct-checklist table tr td {
                width: 50%;
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

        .checkbox-aligner {
            position: absolute;
            z-index: 5;
            top: -25px;
            right: 20px;
            background: #fff;
            font-size: 13px;
        }

            .checkbox-aligner input, .checkbox-aligner label {
                display: block;
                float: left;
            }

            .checkbox-aligner label {
                margin-top: 2px;
                margin-left: 3px;
            }
    </style>

    <script type="text/javascript">
        function Validation() {
            if ($('#<%=ddlSelectType.ClientID%>').val() == '0') {
                $('#<%=lblMsg.ClientID%>').addClass('alertMsg failed');
                $('#<%=lblMsg.ClientID%>').html('Please Select Type');
                $('#<%=lblMsg.ClientID%>').show();
                $('#<%=ddlSelectType.ClientID%>').css('border-color', 'red');
                $('#<%=ddlSelectType.ClientID%>').focus();
                return false;
            }
            else {
                $('#<%=ddlSelectType.ClientID%>').css('border-color', 'lightgray');
            }
            if ($('#<%=ddlSelectType.ClientID%>').val() == '4') {
                if ($('#<%=txtFromLot.ClientID%>').val() == "" || $('#<%=txtToLot.ClientID%>').val() == "") {
                    $('#<%=lblMsg.ClientID%>').addClass('alertMsg failed');
                    $('#<%=lblMsg.ClientID%>').html('Please Enter Lot From and Lot To ');
                    $('#<%=lblMsg.ClientID%>').show();
                    $('#<%=txtFromLot.ClientID%>').css('border-color', 'red');
                    $('#<%=txtFromLot.ClientID%>').focus();
                    $('#<%=txtToLot.ClientID%>').css('border-color', 'red');
                    return false;
                }
                else {
                    $('#<%=txtFromLot.ClientID%>').css('border-color', 'lightgray');
                    $('#<%=txtToLot.ClientID%>').css('border-color', 'lightgray');
                }
            }
            else {
                $('#<%=ddlSelectType.ClientID%>').css('border-color', 'lightgray');
            }
            if ($('#<%=ddlSelectType.ClientID%>').val() == '5') {
                if ($('#<%=txtFromEmp.ClientID%>').val() == "" || $('#<%=txtToEmp.ClientID%>').val() == "") {
                    $('#<%=lblMsg.ClientID%>').addClass('alertMsg failed');
                    $('#<%=lblMsg.ClientID%>').html('Please Enter Emp From and Emp To ');
                    $('#<%=lblMsg.ClientID%>').show();
                    $('#<%=txtFromEmp.ClientID%>').css('border-color', 'red');
                    $('#<%=txtFromEmp.ClientID%>').focus();
                    $('#<%=txtToEmp.ClientID%>').css('border-color', 'red');
                    return false;
                }
                else {
                    $('#<%=txtFromLot.ClientID%>').css('border-color', 'lightgray');
                    $('#<%=txtToEmp.ClientID%>').css('border-color', 'lightgray');
                }
            }
            else {
                $('#<%=ddlSelectType.ClientID%>').css('border-color', 'lightgray');
            }
            if ($('#<%=ddlSelectType.ClientID%>').val() == '3') {
                if ($('#<%=ddlDepartment.ClientID%>').val() == '0') {
                    $('#<%=lblMsg.ClientID%>').addClass('alertMsg failed');
                    $('#<%=lblMsg.ClientID%>').html('Please Select Department');
                    $('#<%=lblMsg.ClientID%>').show();
                    $('#<%=ddlDepartment.ClientID%>').css('border-color', 'red');
                    $('#<%=ddlDepartment.ClientID%>').focus();
                    return false;
                }
                return true;
            }
            if ($('#<%=ddlSelectType.ClientID%>').val() == '6') {
                if ($('#<%=ddlClass.ClientID%>').val() == '0') {
                    $('#<%=lblMsg.ClientID%>').addClass('alertMsg failed');
                    $('#<%=lblMsg.ClientID%>').html('Please Select Class');
                    $('#<%=lblMsg.ClientID%>').show();
                    $('#<%=ddlClass.ClientID%>').css('border-color', 'red');
                    $('#<%=ddlClass.ClientID%>').focus();
                    return false;
                }
                return true;
            }
            if ($('#<%=ddlfinancialyear.ClientID%>').val() == '0') {
                $('#<%=lblMsg.ClientID%>').addClass('alertMsg failed');
                $('#<%=lblMsg.ClientID%>').html('Please Select Financial Year');
                $('#<%=lblMsg.ClientID%>').show();
                $('#<%=ddlfinancialyear.ClientID%>').css('border-color', 'red');
                $('#<%=ddlfinancialyear.ClientID%>').focus();
                return false;
            }
            else {
                $('#<%=ddlfinancialyear.ClientID%>').css('border-color', 'lightgray');
            }

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="updatepnl" runat="server">
        <ContentTemplate>
            <script>
                Sys.Application.add_load(LoadAllScript);
            </script>
            <div class="mrgntp10 mt10 mlr-auto" style="max-width: 800px">
                <div class="panel panel-primary ">
                    <div class="panel-heading" style="text-align: center">PAY POSTING REGISTER</div>
                    <div class="panel-body form-horizontal">
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="brdr_box">
                                        <div class="row">
                                            <div class="col-sm-12 col-xs-12 mtb" style="text-align: center">
                                                <div class="form-group">
                                                    <div class="col-sm-12">
                                                        <div class="row rdo">
                                                            <div class="radio-5-grid">
                                                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" BackColor="White" BorderStyle="None" CssClass="LBLPK" Font-Bold="True" Height="16px" RepeatDirection="Horizontal" Width="450px">
                                                                    <asp:ListItem Selected="True" Value="0">All
                                                                    </asp:ListItem>
                                                                    <asp:ListItem Value="1">Regular</asp:ListItem>
                                                                    <asp:ListItem Value="2">Deputation</asp:ListItem>
                                                                    <asp:ListItem Value="3">RRD</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12 col-xs-12">
                                                <div class="form-group">
                                                    <label class="col-xs-3">Employee Type<i class="text-danger"> </i></label>
                                                    <div class="col-sm-9">
                                                        <asp:DropDownList runat="server" CssClass="form-control form-control-xs col-sm-9" ID="ddlEmpType"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12 col-xs-12">
                                                <div class="form-group">
                                                    <label class="col-xs-3">Select Type<i class="text-danger"> *</i></label><div class="col-sm-9">
                                                        <asp:DropDownList runat="server" CssClass="form-control form-control-xs col-sm-9" ID="ddlSelectType" OnSelectedIndexChanged="ddlSelectType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <asp:Panel runat="server" ID="pnlDepartment" Visible="false">
                                            <div class="row">
                                                <div class="col-sm-12 col-xs-12">
                                                    <div class="form-group">
                                                        <label class="col-xs-3">Department<i class="text-danger"> *</i></label><div class="col-sm-9">
                                                            <asp:DropDownList runat="server" CssClass="form-control form-control-xs col-sm-9" ID="ddlDepartment"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel runat="server" ID="pnlClass" Visible="false">
                                            <div class="row">
                                                <div class="col-sm-12 col-xs-12">
                                                    <div class="form-group">
                                                        <label class="col-xs-3">Class<i class="text-danger"> *</i></label><div class="col-sm-9">
                                                            <asp:DropDownList runat="server" CssClass="form-control form-control-xs col-sm-9" ID="ddlClass"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel runat="server" ID="pnlLot" Visible="false">
                                            <div class="form-group">
                                                <div class="col-sm-12 col-xs-12 mtb">
                                                    <div class="row">
                                                        <label class="col-sm-3 col-xs-12 ">Lot From/To <i class="text-danger">*</i></label>
                                                        <div class="col-sm-9">
                                                            <div class="row">
                                                                <div class="col-sm-6">
                                                                    <asp:TextBox runat="server" ID="txtFromLot" onchange="return LotFun();" MaxLength="10" CssClass="form-control form-control-xs numberonly" placeholder="From" />
                                                                </div>
                                                                <div class="col-sm-6">
                                                                    <asp:TextBox runat="server" ID="txtToLot" MaxLength="10" CssClass="form-control form-control-xs numberonly" placeholder="To" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel runat="server" ID="pnlEmployee" Visible="false">
                                            <div class="form-group">
                                                <div class="col-sm-12 col-xs-12 mtb">
                                                    <div class="row">
                                                        <label class="col-sm-3 col-xs-12 ">Emp From/To <i class="text-danger">*</i></label>
                                                        <div class="col-sm-9">
                                                            <div class="row">
                                                                <div class="col-sm-6">
                                                                    <asp:TextBox runat="server" ID="txtFromEmp" MaxLength="10" onchange="return EmployeeFun();" CssClass="form-control form-control-xs numberonly" placeholder="From" />
                                                                </div>
                                                                <div class="col-sm-6">
                                                                    <asp:TextBox runat="server" ID="txtToEmp" MaxLength="10" CssClass="form-control form-control-xs numberonly" placeholder="To" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <div class="row" style="display: none">
                                            <div class="col-sm-12 col-xs-12  mtb">
                                                <div class="form-group">
                                                    <div class="col-sm-12">
                                                        <fieldset class="scheduler-border">
                                                            <legend class="scheduler-border">Yearly Option</legend>
                                                            <asp:RadioButtonList ID="rbYearlyOption" runat="server" BackColor="White" BorderStyle="None" CssClass="LBLPK radio-list-normal" Font-Bold="True" Height="16px" RepeatDirection="Horizontal">
                                                                <asp:ListItem Selected="True" Value="0">March-Feb</asp:ListItem>
                                                                <asp:ListItem Value="1">April-March</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                            <div class="check-list-normal">
                                                                <asp:CheckBox ID="CheckBox2" runat="server" Text="Income tax case" />
                                                            </div>
                                                        </fieldset>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12 col-xs-12 mtb">
                                                <div class="form-group">
                                                    <div class="col-xs-12">
                                                        <fieldset class="scheduler-border">
                                                            <legend class="scheduler-border">Earning</legend>
                                                            <asp:RadioButtonList runat="server" CssClass="LBLPK radio-list-normal" ID="rbEarnind" OnSelectedIndexChanged="rbEarnind_SelectedIndexChanged" AutoPostBack="true" RepeatDirection="Horizontal">
                                                                <asp:ListItem Selected="True" Value="0">All Earning to bre Printed on Report</asp:ListItem>
                                                                <asp:ListItem Value="1">Only Earning Summ.to be Printed on Report</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </fieldset>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12 col-xs-12 mtb">
                                                <div class="form-group">
                                                    <div class="col-sm-12">
                                                        <fieldset class="scheduler-border">
                                                            <legend class="scheduler-border">Deduction</legend>
                                                            <asp:RadioButtonList runat="server" CssClass="LBLPK radio-list-normal" ID="rbDeduction" OnSelectedIndexChanged="rbDeduction_SelectedIndexChanged" AutoPostBack="true" RepeatDirection="Horizontal">
                                                                <asp:ListItem Value="0" Selected="True">All Deduction to be Printed on Report</asp:ListItem>
                                                                <asp:ListItem Value="1">Only Deduction Summ.to be Printed on Report</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </fieldset>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-6 col-xs-12">
                                                <div class="form-group">
                                                    <div class="col-xs-12">
                                                        <fieldset class="scheduler-border">
                                                            <legend class="scheduler-border">Earning</legend>

                                                            <label class="col-xs-12">
                                                                <asp:CheckBox ID="chkall" runat="server" OnCheckedChanged="chkall_CheckedChanged" AutoPostBack="true" Text="Checked All " CssClass="pointer no-selectable checkbox-aligner" /></label>
                                                            <div class="col-sm-12">
                                                                <div class="internaldeduct-checklist">
                                                                    <asp:Panel runat="server" ID="EarningPanal">
                                                                        <asp:CheckBoxList ID="chklist" runat="server" RepeatColumns="1">
                                                                        </asp:CheckBoxList>
                                                                    </asp:Panel>
                                                                </div>
                                                            </div>
                                                        </fieldset>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6 col-xs-12">
                                                <div class="form-group">
                                                    <div class="col-xs-12">
                                                        <fieldset class="scheduler-border">
                                                            <legend class="scheduler-border">Deduction</legend>
                                                            <label class="col-xs-12">
                                                                <asp:CheckBox ID="ChkDeductionAll" runat="server" OnCheckedChanged="ChkDeductionAll_CheckedChanged" AutoPostBack="true" Text="Checked All " CssClass="pointer no-selectable checkbox-aligner" /></label>
                                                            <div class="col-sm-12">
                                                                <div class="internaldeduct-checklist">
                                                                    <asp:Panel runat="server" ID="DeductionPanal">
                                                                        <asp:CheckBoxList ID="ChkDeduction" runat="server" RepeatColumns="1">
                                                                        </asp:CheckBoxList>
                                                                    </asp:Panel>
                                                                </div>
                                                            </div>
                                                        </fieldset>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12 col-xs-12">
                                                <div class="form-group">
                                                    <label class="col-xs-3">Financial Year<i class="text-danger"> *</i></label><div class="col-sm-3">
                                                        <asp:DropDownList runat="server" CssClass="form-control form-control-xs" ID="ddlfinancialyear"></asp:DropDownList>
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
                                <asp:LinkButton CssClass="btn btn-info" ID="btnpreview" OnClientClick="return Validation()" OnClick="btnpreview_Click" runat="server"><i class="fa r  fa-eye"></i> Preview</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-danger" PostBackUrl="~/Salary/Dashboard.aspx" ID="btnExit" runat="server"><i class="fa r fa-close"></i> Exit</asp:LinkButton>
                                <asp:Label ID="lblMsg" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

