<%@ Page Title="" Language="C#" MasterPageFile="~/Salary/SalaryMaster.master" AutoEventWireup="true" CodeFile="Rpt_TaxFileCreation.aspx.cs" Inherits="Report_Rpt_TaxFileCreation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   <%-- <script>
        function LoadAllScript() {
            LoadBasic();
        }
    </script>--%>
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
    <script type="text/javascript">
        function EmployeeFun() {
            if ($('#<%=ddlSelectType.ClientID%>').val() == '5') {
                if ($('#<%=txtFromEmp.ClientID%>').val() != "") {
                    var From = $('#<%=txtFromEmp.ClientID%>').val();
                    $('#<%=txtToEmp.ClientID%>').val(From);

                    $('#<%=lblMsg.ClientID%>').html('');
                    $('#<%=lblMsg.ClientID%>').removeClass('alertMsg failed');
                }
                else {
                    $('#<%=txtToEmp.ClientID%>').val('');
                }
            }
        }

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
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <%-- <asp:UpdatePanel ID="updatepnl" runat="server">
        <ContentTemplate>
            <script>
                Sys.Application.add_load(LoadAllScript);
            </script>--%>
            <div class="mrgntp10 mt10 mlr-auto" style="max-width: 770px">
                <div class="panel panel-primary ">
                    <div class="panel-heading" style="text-align: center">BANK BRANCH WISE TEXT FILE </div>
                    <div class="panel-body form-horizontal">
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="brdr_box">

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
                                        <asp:Panel runat="server" ID="pnlEmpType" Visible="false">
                                            <div class="row">
                                                <div class="col-sm-12 col-xs-12">
                                                    <div class="form-group">
                                                        <label class="col-xs-3">Employee Type<i class="text-danger"> *</i></label><div class="col-sm-9">
                                                            <asp:DropDownList runat="server" CssClass="form-control form-control-xs col-sm-9" ID="ddlEmpType"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <div class="row">
                                            <div class="col-sm-12 col-xs-12">
                                                <div class="form-group">
                                                    <label class="col-xs-3">Create Text File For<i class="text-danger"> *</i></label><div class="col-sm-9">
                                                        <asp:DropDownList runat="server" CssClass="form-control form-control-xs col-sm-9" AutoPostBack="true" OnSelectedIndexChanged="ddlTxtFileCreation_SelectedIndexChanged" ID="ddlTxtFileCreation"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                         <asp:Panel runat="server" ID="PanelLoanType" Visible="false">
                                            <div class="row">
                                                <div class="col-sm-12 col-xs-12">
                                                    <div class="form-group">
                                                        <label class="col-xs-3">Loan Type<i class="text-danger"> *</i></label><div class="col-sm-9">
                                                            <asp:DropDownList runat="server" CssClass="form-control form-control-xs col-sm-9" ID="ddlLoantype"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>

                                        <div class="row">
                                            <div class="col-sm-12 col-xs-12">
                                                <div class="form-group">
                                                    <label class="col-xs-3">Bank Name<i class="text-danger"> *</i></label><div class="col-sm-9">
                                                        <asp:DropDownList runat="server" CssClass="form-control form-control-xs col-sm-9"  OnSelectedIndexChanged="ddlBank_SelectedIndexChanged" AutoPostBack="true" ID="ddlBank"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12 col-xs-12">
                                                <div class="form-group">
                                                    <label class="col-xs-3">Branch Name<i class="text-danger"> *</i></label><div class="col-sm-9">
                                                        <asp:DropDownList runat="server" CssClass="form-control form-control-xs col-sm-9" ID="ddlBranch"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                          <div class="row">
                                            <div class="col-sm-12 col-xs-12">
                                                <div class="form-group">
                                                    <label class="col-xs-3">Narration<i class="text-danger"> </i></label><div class="col-sm-9">
                                                         <asp:TextBox runat="server" ID="txtNarration" MaxLength="855" TextMode="MultiLine" CssClass="form-control form-control-xs" placeholder="Enter Narration" />
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
                                <asp:Label ID="lblMsg" runat="server" ForeColor="red" />
                                <asp:Label ID="lblMsg1" runat="server" ForeColor="Green" />
                                <asp:Label ID="lblMsg2" runat="server" ForeColor="Green" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 col-sm-12 text-left">
                                <asp:LinkButton CssClass="btn btn-success" ID="btnCREATION" runat="server" OnClick="btnCREATION_Click"><i class="fa r fa-save"></i>CREATION</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-info" ID="btnDOWNLOAD" OnClick="btnDOWNLOAD_Click" runat="server"><i class="fa r fa-download"></i>DOWNLOAD</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-warning" ID="btnClear" OnClick="btnClear_Click" runat="server">CLEAR</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-danger" PostBackUrl="~/Salary/Dashboard.aspx" ID="btnEXIT" runat="server"> EXIT</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
     <%--   </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

