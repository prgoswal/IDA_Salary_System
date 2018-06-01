<%@ Page Title="" Language="C#" MasterPageFile="~/Salary/SalaryMaster.master" AutoEventWireup="true" CodeFile="Frm_QryEmp.aspx.cs" Inherits="MasterForm_Frm_QryEmp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        function LoadAllScript() {
            LoadBasic();
            //$('.datepicker').focus
            $('.datepicker').datepicker({ dateFormat: 'dd/mm/yy', maxDate: '0', changeYear: true, changeMonth: true });
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

        .blhed {
            margin-left: 0px !important;
            margin-right: 0px !important;
            background-color: #3c8dbc;
            color: #fff;
        }

            .blhed label {
                margin-top: 5px;
            }

        .brdr {
            border: 1px solid #000;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="updatepnl" runat="server">
        <ContentTemplate>
            <script>
                Sys.Application.add_load(LoadAllScript);
            </script>
            <div class="col-xs-12 col-sm-8 col-sm-offset-2 mrgntp10 mt10">
                <div class="panel panel-primary ">
                    <div class="panel-heading" style="text-align: center">QUERY EMPLOYEE </div>
                    <div class="panel-body form-horizontal">
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-sm-2">
                                        <asp:CheckBox ID="Chkname" runat="server" OnCheckedChanged="Chkname_CheckedChanged" AutoPostBack="true" Text="&nbsp;&nbsp;Name" />
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server" ID="txtname"  MaxLength="20" placeholder="Name" Style='text-transform: uppercase' CssClass="form-control form-control-xs" />
                                    </div>
                                    <div class="col-sm-2">
                                        <asp:CheckBox ID="chkFHname" runat="server" OnCheckedChanged="chkFHname_CheckedChanged" AutoPostBack="true" Text="&nbsp;&nbsp;F/H.Name " />
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server" ID="txtfhname"   MaxLength="20" placeholder="F/H.Name " Style='text-transform: uppercase' CssClass="form-control form-control-xs" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-sm-2">
                                        <asp:CheckBox ID="chkEmpNo" OnCheckedChanged="chkEmpNo_CheckedChanged" AutoPostBack="true" runat="server" Text="&nbsp;&nbsp;Emp. No " />
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server" ID="txtEmpNo"  MaxLength="9" placeholder="Emp. No " Style='text-transform: uppercase' CssClass="form-control form-control-xs numberonly" />
                                    </div>
                                    <div class="col-sm-2">
                                        <asp:CheckBox ID="chkSection" OnCheckedChanged="chkSection_CheckedChanged" AutoPostBack="true" runat="server" Text="&nbsp;&nbsp;Section " />
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:DropDownList runat="server" ID="ddlSection" CssClass="form-control form-control-xs">
                                            <asp:ListItem Text="----Select---" />
                                            <asp:ListItem Text="text2" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-sm-2">
                                        <asp:CheckBox ID="ChkSrLotNo" OnCheckedChanged="ChkSrLotNo_CheckedChanged" AutoPostBack="true" runat="server" Text="&nbsp;&nbsp;Sr/Lot No. " />
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server" ID="txtLotNo"  MaxLength="9" placeholder="Sr/Lot No. " Style='text-transform: uppercase' CssClass="form-control form-control-xs numberonly" />
                                    </div>
                                    <div class="col-sm-2">
                                        <asp:CheckBox ID="chkDOB" OnCheckedChanged="chkDOB_CheckedChanged" AutoPostBack="true" runat="server" Text="&nbsp;&nbsp;DOB " />
                                    </div>
                                    <div class="col-sm-4 date-picker-icon">
                                        <asp:TextBox runat="server" ID="txtDOB" MaxLength="10" Style='text-transform: uppercase;' CssClass="datepicker form-control form-control-xs date-picker-icon" placeholder="DD/MM/YYYY" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-sm-2">
                                        <asp:CheckBox ID="chkDesignation" runat="server" OnCheckedChanged="chkDesignation_CheckedChanged" AutoPostBack="true" Text="&nbsp;&nbsp;Designation" />
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:DropDownList runat="server" ID="ddlDesignation" CssClass="form-control form-control-xs">
                                            <asp:ListItem Text="----Select---" />
                                            <asp:ListItem Text="text2" />
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-2">
                                        <asp:CheckBox ID="chkRRD" OnCheckedChanged="chkRRD_CheckedChanged" AutoPostBack="true" runat="server" Text="&nbsp;&nbsp;RRD" />
                                    </div>
                                    <div class="col-sm-4">
                                        <%--  <asp:TextBox runat="server" ID="txtRRD" AutoPostBack="true" placeholder="RRD" Style='text-transform: uppercase' CssClass="form-control form-control-xs" />--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body form-horizontal" id="Divgrid" runat="server">
                            <div class="brd0r">
                                <div class="row">
                                    <div class="col-sm-12 col-xs-12 mtb ">
                                        <div class=" form-group" style="margin-bottom: 0px!important">
                                            <label class="col-sm-12 col-xs-12 ">Employee Details :-</label>
                                        </div>
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="table-header-fixer" style="padding-right: 17px">
                                            <table class="table table-bordered f12 pd-sm br-wrd">
                                                <tr class="tbl_bg">
                                                    <th style="width: 14%">Employee No.</th>
                                                    <th style="width: 14%">Name</th>
                                                    <th style="width: 14%">Father Name</th>
                                                    <th style="width: 28%">Address</th>
                                                    <th style="width: 14%">DOB</th>
                                                    <th style="width: 14%">Designation</th>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="body-fix-table" style="max-height: 290px">
                                            <asp:GridView ID="GvQtyEmp" ShowHeader="False" AutoGenerateColumns="false" EmptyDataText="No records Found" runat="server" CssClass="table table-bordered pd-sm f12 br-wrd">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-Width="14%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEmpNo" Text='<%#Eval("EmpNo") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="14%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblName" Text='<%#Eval("Name") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="14%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFHName" Text='<%#Eval("FHName") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="28%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAddress" Text='<%#Eval("Address") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="14%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDob" Text='<%#Eval("Dob") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="14%" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBasic" Text='<%#Eval("Basic") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="14%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDesignation" Text='<%#Eval("Designation") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
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
                            <div class="col-xs-12 col-sm-12 text-left">
                                <asp:LinkButton CssClass="btn btn-info" ID="btnShow" OnClick="btnShow_Click" runat="server"><i class="fa r fa-eye"></i> Search</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-warning" ID="btnclear" OnClick="btnclear_Click" runat="server"><i class="fa r fa-refresh"></i> Clear</asp:LinkButton>
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

