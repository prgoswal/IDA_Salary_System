<%@ Page Title="" Language="C#" MasterPageFile="~/Salary/SalaryMaster.master" AutoEventWireup="true" CodeFile="Frm_Trasstopay.aspx.cs" Inherits="MasterForm_Frm_Trasstopay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
            if ($('#ContentPlaceHolder1_txtEmployeeNo').val().trim() == '') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed ');
                $('#ContentPlaceHolder1_lblMsg').html(' Please Enter Employee No');
                $('#ContentPlaceHolder1_txtEmployeeNo').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtEmployeeNo').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_txtEmployeeNo').css('border-color', 'lightgray');
            }
            if ($('#ContentPlaceHolder1_txtDate').val().trim() == '') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed ');
                $('#ContentPlaceHolder1_lblMsg').html(' Please Select Date');
                $('#ContentPlaceHolder1_txtDate').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtDate').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_txtDate').css('border-color', 'lightgray');
            }


            if ($('#ContentPlaceHolder1_txtStopReason').val().trim() == '') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed ');
                $('#ContentPlaceHolder1_lblMsg').html(' Please Enter Stop Reason');
                $('#ContentPlaceHolder1_txtStopReason').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtStopReason').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_txtStopReason').css('border-color', 'lightgray');
            }
        }

        function UPDelValidation() {
            if ($('#ContentPlaceHolder1_txtEmployeeNo').val().trim() == '') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed ');
                $('#ContentPlaceHolder1_lblMsg').html(' Please Enter Employee No');
                $('#ContentPlaceHolder1_txtEmployeeNo').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtEmployeeNo').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_txtEmployeeNo').css('border-color', 'lightgray');
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
                    <div class="panel-heading" style="text-align: center">STOP PAYMENT </div>
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
                                                        <asp:TextBox runat="server" ID="txtDesignation" ReadOnly="true" MaxLength="50" placeholder="Designation" Style='text-transform: uppercase' CssClass="form-control form-control-xs" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-sm-12 col-xs-12 mtb">
                                                <div class="row">
                                                    <label class="col-sm-3 col-xs-12 ">Date <i class="Star">*</i></label>
                                                    <div class="col-sm-9">
                                                        <div class="row">
                                                            <div class="col-sm-6 date-picker-icon">
                                                                <asp:TextBox runat="server" ID="txtDate" MaxLength="10" OnTextChanged="txtDate_TextChanged" Style='text-transform: uppercase;' AutoPostBack="true" CssClass="datepicker form-control form-control-xs date-picker-icon" placeholder="DD/MM/YYYY" />
                                                            </div>
                                                            <div class="col-sm-6">
                                                                <asp:TextBox runat="server" ID="txtMonth" ReadOnly="true" MaxLength="20" placeholder="Current Month / Year" Style='text-transform: uppercase' CssClass="form-control form-control-xs" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12 col-xs-12 mtb">
                                                <div class="form-group">
                                                    <label class="col-sm-3 col-xs-12">Stop Reason <i class="Star">*</i></label>
                                                    <div class="col-sm-9">
                                                        <asp:TextBox ID="txtStopReason" runat="server" MaxLength="50" class="msgbox form-control" TextMode="MultiLine"></asp:TextBox>
                                                        <span style="float: right; font-size: 18px;display:none" id="textarea_feedback"></span>
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
                                <asp:LinkButton CssClass="btn btn-success" ID="btnSave" OnClientClick="return Validation()" OnClick="btnSave_Click" runat="server"><i class="fa r fa-save"></i> Save</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-info" ID="btnUpdate" Visible="false" OnClientClick="return UPDelValidation()" OnClick="btnUpdate_Click" runat="server"> Update</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-danger" ID="btnDelete" Visible="false" OnClientClick="return UPDelValidation()" OnClick="btnDelete_Click" runat="server"> Delete</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-warning" ID="btnclear" OnClick="btnclear_Click" runat="server"> Clear</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-danger" ID="btnExit"  PostBackUrl="~/Salary/Dashboard.aspx" runat="server">Exit</asp:LinkButton>
                                <asp:Label ID="lblMsg" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

