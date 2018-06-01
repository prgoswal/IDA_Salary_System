<%@ Page Title="" Language="C#" MasterPageFile="~/Salary/SalaryMaster.master" AutoEventWireup="true" CodeFile="Trans_ManualPatrak.aspx.cs" Inherits="TransactionForm_Trans_ManualPatrak" %>

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

    <script type="text/Javascript">
        function Suspend(el) {
            var splt = el.split('.');
            if (splt[1]) {
                if (splt[1] != 5) {
                    $('#<%=txtSuspend.ClientID%>').val(splt[0]);
                    $('#<%=txtMedical.ClientID%>').val(splt[0]);
                }
            }
        }
        function Medical(el) {
            var splt = el.split('.');
            if (splt[1]) {
                if (splt[1] != 5) {
                    $('#<%=txtMedical.ClientID%>').val(splt[0]);
                }
            }
        }

        function HPL(el) {
            var splt = el.split('.');
            if (splt[1]) {
                if (splt[1] != 5) {
                    $('#<%=txtHPL.ClientID%>').val(splt[0]);
                }
            }
        }
        function CL(el) {
            var splt = el.split('.');
            if (splt[1]) {
                if (splt[1] != 5) {
                    $('#<%=txtCL.ClientID%>').val(splt[0]);
                }
            }
        }
        function EL(el) {
            var splt = el.split('.');
            if (splt[1]) {
                if (splt[1] != 5) {
                    $('#<%=txtEL.ClientID%>').val(splt[0]);
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
            <div class="col-xs-12 control-label-no-wrap form-group-manual-patrak">
                <div class="row">
                    <div class="col-xs-12 col-sm-12">
                        <div class="panel panel-primary mt10 mb0">
                            <div class="panel-heading">
                                <h3 class="panel-title">Supplementary Patrak</h3>
                            </div>
                            <div class="panel-body">
                                <div class="form-horizontal">
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-3">
                                            <div class="form-group">
                                                <label class="col-xs-12 col-sm-4 control-label">Employee No.</label>
                                                <div class="col-xs-12 col-sm-8">
                                                    <asp:TextBox runat="server" MaxLength="9" CssClass="form-control numberonly" placeholder="Employee No." ID="txtEmpNo" Style='text-transform: uppercase' OnTextChanged="txtEmpNo_TextChanged" AutoPostBack="true" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-xs-12 col-sm-4">
                                            <div class="form-group">
                                                <div class="col-xs-12 form-control" aria-readonly="true" style="width: calc(100% - 15px); margin: 0 auto">
                                                    <b>Name : </b>
                                                    <asp:Label runat="server" ID="lblEmpName" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-3">
                                            <div class="form-group">
                                                <div class="col-xs-12 form-control" aria-readonly="true" style="width: calc(100% - 15px); margin: 0 auto">
                                                    <b>Designation : </b>
                                                    <asp:Label runat="server" ID="lblDesignation" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-2">
                                            <div class="form-group">
                                                <div class="col-xs-12 form-control" aria-readonly="true" style="width: calc(100% - 15px); margin: 0 auto">
                                                    <b>Current Month : </b>
                                                    <asp:Label runat="server" ID="txtCurrentMonth" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-3">
                                            <div class="form-group">
                                                <label class="col-xs-12 col-sm-4 control-label">Effective Month</label>
                                                <div class="col-xs-8">
                                                    <asp:DropDownList runat="server" ID="ddlEffectiveMonth" OnSelectedIndexChanged="ddlEffectiveMonth_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-xs-12 col-sm-3">
                                            <div class="form-group">
                                                <label class="col-xs-12 col-sm-4 control-label">Voucher No.</label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox runat="server" MaxLength="9" CssClass="form-control" ID="txtVoucherNo" Style='text-transform: uppercase' placeholder="Voucher No." Enabled="false" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-3">
                                            <div class="form-group">
                                                <label class="col-xs-12 col-sm-4 control-label">Voucher Date</label>
                                                <div class="col-sm-8 date-picker-icon">
                                                    <asp:TextBox runat="server" MaxLength="10" ID="txtVoucherDate" CssClass="datepicker form-control form-control-xs date-picker-icon" Style='text-transform: uppercase' placeholder="dd/mm/yyyy" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-3">
                                            <div class="form-group">
                                                <label class="col-xs-12 col-sm-4 control-label">Suspend</label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox runat="server" MaxLength="2" OnTextChanged="txtSuspend_TextChanged" AutoPostBack="true" onkeyup="Suspend(this.value);" CssClass="form-control NoOfDays" Style='text-transform: uppercase' ID="txtSuspend" placeholder="Suspend" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="display: none">
                                        <div class="col-xs-12" style="margin-bottom: 5px;">
                                            <asp:CheckBox Text="Leave Type" ID="chkLeaveType" runat="server" />
                                        </div>
                                    </div>

                                    <div class="row" id="DivLeave" runat="server">
                                        <div class="col-xs-12 col-sm-3">
                                            <div class="form-group">
                                                <label class="col-xs-12 col-sm-4 control-label">Medical</label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox runat="server" MaxLength="4" OnTextChanged="txtMedical_TextChanged" onkeyup="Medical(this.value);" AutoPostBack="true" CssClass="form-control NoOfDays" Style='text-transform: uppercase' ID="txtMedical" placeholder="Medical" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-3">
                                            <div class="form-group">
                                                <label class="col-xs-12 col-sm-4 control-label">HPL</label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox runat="server" MaxLength="4" OnTextChanged="txtHPL_TextChanged" onkeyup="HPL(this.value);" AutoPostBack="true" CssClass="form-control NoOfDays" Style='text-transform: uppercase' ID="txtHPL" placeholder="HPL" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-3">
                                            <div class="form-group">
                                                <label class="col-xs-12 col-sm-4 control-label">CL</label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox runat="server" MaxLength="4" OnTextChanged="txtCL_TextChanged" onkeyup="CL(this.value);" AutoPostBack="true" CssClass="form-control NoOfDays" Style='text-transform: uppercase' ID="txtCL" placeholder=" CL" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-3">
                                            <div class="form-group">
                                                <label class="col-xs-12 col-sm-4 control-label">EL</label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox runat="server" MaxLength="4" OnTextChanged="txtEL_TextChanged" onkeyup="EL(this.value);" AutoPostBack="true" CssClass="form-control NoOfDays" Style='text-transform: uppercase' ID="txtEL" placeholder="EL" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-3">
                                            <div class="form-group">
                                                <label class="col-xs-12 col-sm-4 control-label">Entry Date</label>
                                                <div class="col-sm-8 date-picker-icon">
                                                    <asp:TextBox runat="server" MaxLength="10" ID="txtEnteryDate" CssClass="datepicker form-control form-control-xs date-picker-icon" Style='text-transform: uppercase' Enabled="false" placeholder="dd/mm/yyyy" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-3">
                                            <div class="form-group">
                                                <label class="col-xs-12 col-sm-4 control-label">Type</label>
                                                <div class="col-xs-8">
                                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlType" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                                        <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                                                        <asp:ListItem Value="1">Earning</asp:ListItem>
                                                        <asp:ListItem Value="2">Deduction</asp:ListItem>
                                                        <%--<asp:ListItem Value="3">Both</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-3">
                                            <div class="form-group">
                                                <label class="col-xs-12 col-sm-4 control-label">Ear./Ded. Head</label>
                                                <div class="col-xs-8">
                                                    <asp:DropDownList runat="server" ID="ddlEarDed" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-3">
                                            <div class="form-group">
                                                <label class="col-xs-12 col-sm-4 control-label">Amount</label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox runat="server" CssClass="form-control Money" MaxLength="9" ID="txtAmount" Style='text-transform: uppercase' placeholder="Amount" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-6">
                                            <div class="form-group">
                                                <label class="col-xs-12 col-sm-2 control-label">Narration</label>
                                                <div class="col-xs-10">
                                                    <asp:TextBox runat="server" CssClass="form-control" MaxLength="50" ID="txtNarration" Style='text-transform: uppercase' placeholder="Enter Narration" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-3">
                                            <div class="form-group">
                                                <label class="col-xs-12 col-sm-4 control-label">Total Days (P)</label>
                                                <div class="col-xs-8">
                                                    <asp:TextBox runat="server" MaxLength="9" Enabled="false" CssClass="form-control NoOfDays" ID="txtToatlDaysPrasent" Style='text-transform: uppercase' placeholder="Total Days (P)" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-3">
                                            <div class="form-group">
                                                <div class="col-xs-12 text-right">
                                                    <asp:Button Text="Add" CssClass="btn btn-primary"  runat="server" ID="btnAdd" OnClick="btnAdd_Click" />
                                                    <asp:LinkButton CssClass="btn btn-info" runat="server" ID="btnCalculate" OnClick="btnCalculate_Click"><i class="fa r fa-calculator"></i> Calculate</asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-2" runat="server">
                                            <div class="form-group">
                                                <label class="col-xs-12 col-sm-4 control-label">&nbsp;</label>
                                                <div class="col-xs-8">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-8 col-sm-offset-2 col-xs-12 table-responsive">
                                        <div style="padding-right: 17px;">
                                            <table class="table table-bordered table-sm table-br" style="margin-bottom: 0px;">
                                                <thead>
                                                    <tr class="tbl_bg">
                                                        <th style="width: 16%;">Employee No.</th>
                                                        <th style="width: 18%;">Type</th>
                                                        <th style="width: 28%;">Description</th>
                                                        <th style="width: 20%;">Amount</th>
                                                        <th class="text-center" style="width: 10%;"><i class="fa fa-pencil-square"></i>&nbsp;Edit</th>
                                                        <th class="text-center" style="width: 08%;"><i class="fa fa-trash-o"></i>&nbsp;Del</th>
                                                    </tr>
                                                </thead>
                                            </table>
                                        </div>
                                        <div style="max-height: 130px; overflow-y: scroll">
                                            <table class="table table-bordered table-sm table-br" style="margin-bottom: 0px;">
                                                <tbody>
                                                </tbody>
                                            </table>
                                            <asp:GridView ID="GvEdcd" CssClass="table-bordered table-ims font12 table-responsive-ims-100 pdl-sm tbl" OnRowCommand="GvEdcd_RowCommand" AutoGenerateColumns="false" ShowHeader="false" runat="server" Width="100%">
                                                <HeaderStyle CssClass="ims_head" />
                                                <Columns>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="gv_lblRefNo" runat="server" Text='<%#Eval("RefNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="gv_lblEdcd" runat="server" Text='<%#Eval("Edcd") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="gv_lblDrCr" runat="server" Text='<%#Eval("DrCr") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="gv_lblEffMonth" runat="server" Text='<%#Eval("EffMonth") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="gv_lblVno" runat="server" Text='<%#Eval("Vno") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="gv_lblVdate" runat="server" Text='<%#Eval("Vdate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="gv_lblmed" runat="server" Text='<%#Eval("med") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="gv_lblpl" runat="server" Text='<%#Eval("pl") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="gv_lblhpl" runat="server" Text='<%#Eval("hpl") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="gv_lbllwp" runat="server" Text='<%#Eval("lwp") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="gv_lblcl" runat="server" Text='<%#Eval("cl") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="gv_lblel" runat="server" Text='<%#Eval("el") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="gv_lblentdate" runat="server" Text='<%#Eval("entdate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="gv_lbltransno" runat="server" Text='<%#Eval("transno") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="gv_lblnarr" runat="server" Text='<%#Eval("narr") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="true">
                                                        <ItemTemplate>
                                                            <asp:Label ID="gv_lblType" runat="server" Text='<%#Eval("Type") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="gv_lblSelection" runat="server" Text='<%#Eval("Selection") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="16%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="gv_lblEmpNo" runat="server" Text='<%#Eval("EmpNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="18%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="gv_lblTypeDesc" runat="server" Text='<%#Eval("TypeDesc") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="28%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="gv_lblDesc" runat="server" Text='<%#Eval("AbrDesc") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="gv_lblAmount" runat="server" Text='<%#Eval("Amount") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="20%" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="gv_lblTotlalLeavet" runat="server" Text='<%#Eval("TotalDay") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="10%" ItemStyle-CssClass="text-center">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnEdit" Text="Edit" CommandName="Select1" Width="100%" CommandArgument='<%#Container.DataItemIndex %>' OnClick="btnEdit_Click" CssClass="btn btn-xs btn-info add_btn" runat="server"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="8%" ItemStyle-CssClass="text-center">
                                                        <ItemTemplate>
                                                            <asp:LinkButton runat="server" ID="btnDelete" CommandName="DeleteRow" Width="100%" CommandArgument='<%#Container.DataItemIndex %>' Text="Delete" CssClass="btn btn-xs btn-warning add_btn"></asp:LinkButton>
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
                            <div class="panel-footer text-right">
                                <asp:Label ID="lblMsg" runat="server" />
                                <asp:Button Text="Save" CssClass="btn btn-success" runat="server" ID="btnSave" OnClick="btnSave_Click" />
                                <asp:Button Text="Clear" CssClass="btn btn-warning" ID="btnClear" OnClick="btnClear_Click" runat="server" />
                                <asp:Button Text="Exit" PostBackUrl="~/Salary/Dashboard.aspx" CssClass="btn btn-danger" runat="server" />
                                <asp:HiddenField ID="hfNoOfDay" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

