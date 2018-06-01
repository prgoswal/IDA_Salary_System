<%@ Page Title="" Language="C#" MasterPageFile="~/Salary/SalaryMaster.master" AutoEventWireup="true" CodeFile="FrmPFCharge.aspx.cs" Inherits="Salary_TransactionForm_FrmPFCharge" %>

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
                    <div class="panel-heading" style="text-align: center">PF CHARGES</div>
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
                                        <div class="row">
                                            <div class="col-sm-12 col-xs-12 mtb">
                                                <div class="form-group">
                                                    <label class="col-sm-3 col-xs-12">
                                                        <asp:RadioButtonList runat="server" RepeatDirection="horizontal" Width="100%" OnSelectedIndexChanged="RbpayAmount_SelectedIndexChanged" AutoPostBack="true" ForeColor="Black" ID="RbpayAmount">
                                                            <asp:ListItem Text="Six Pay" Selected="True" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Seventh Pay" Value="1"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </label>
                                                    <div class="col-sm-9">
                                                        <div id="DivBasic" runat="server">
                                                            <label class="col-sm-1 col-xs-12">Basic</label>
                                                            <div class="col-sm-3">
                                                                <asp:TextBox runat="server" ID="txtBasic" MaxLength="10" OnTextChanged="txtBasic_TextChanged" onpaste="return false" oncut="return false" AutoPostBack="true" placeholder="Basic" Style='text-transform: uppercase' CssClass="form-control form-control-xs Decimal4" />
                                                            </div>
                                                        </div>
                                                        <div id="DivGrade" runat="server">
                                                            <label class="col-sm-1 col-xs-12">Grade</label>
                                                            <div class="col-sm-3">
                                                                <asp:TextBox runat="server" ID="txtGrade" MaxLength="10" placeholder="Grade" OnTextChanged="txtGrade_TextChanged" onpaste="return false" oncut="return false" AutoPostBack="true" Style='text-transform: uppercase' CssClass="form-control form-control-xs Decimal4" />
                                                            </div>
                                                        </div>
                                                        <div id="DivDA" runat="server">
                                                            <label class="col-sm-1 col-xs-12">DA</label>
                                                            <div class="col-sm-3">
                                                                <asp:TextBox runat="server" ID="txtDA" MaxLength="10" placeholder="DA" Style='text-transform: uppercase' onpaste="return false" oncut="return false" OnTextChanged="txtDA_TextChanged" AutoPostBack="true" CssClass="form-control form-control-xs Decimal4" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12 col-xs-12 mtb">
                                                <div class="form-group">
                                                    <label class="col-sm-3 col-xs-12">
                                                        Total Charges
                                                    </label>
                                                    <div class="col-sm-9">
                                                        <label class="col-sm-2 col-xs-12">PF 12%</label>
                                                        <div class="col-sm-3">
                                                            <asp:TextBox runat="server" ID="txtPF" MaxLength="15" ReadOnly="true" placeholder="PF" onpaste="return false" oncut="return false" Style='text-transform: uppercase' CssClass="form-control form-control-xs Decimal4" />
                                                        </div>
                                                        <label class="col-sm-4 col-xs-12">Admin Charge 1.16%</label>
                                                        <div class="col-sm-3">
                                                            <asp:TextBox runat="server" ID="txtAdminCharge" MaxLength="15" ReadOnly="true" onpaste="return false" oncut="return false" placeholder="Admin Charge" Style='text-transform: uppercase' CssClass="form-control form-control-xs Decimal4" />
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

