<%@ Page Title="" Language="C#" MasterPageFile="~/Salary/SalaryMaster.master" AutoEventWireup="true" CodeFile="Frm_Earning_DeductionDetails.aspx.cs" Inherits="Transaction_Frm_Earning_DeductionDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function LoadAllScript() {
            LoadBasic();
        }
    </script>
    <style>
        .tblhd {
            background-color: #0a5486;
            color: #FFF;
        }

        .tblhgt {
            max-height: 150px;
            min-height: 50px;
            overflow-y: scroll;
        }

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

        .tbl {
            width: 100%;
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

    <script type="text/javascript">
        function SaveValidation() {

            if ($('#ContentPlaceHolder1_ddlSelect').val() == '0') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').html(' Please Select Select Type');
                $('#ContentPlaceHolder1_ddlSelect').css('border-color', 'red');
                $('#ContentPlaceHolder1_ddlSelect').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_ddlSelect').css('border-color', 'lightgray');
            }
            if ($('#ContentPlaceHolder1_txtDesc').val().trim() == '') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed ');
                $('#ContentPlaceHolder1_lblMsg').html('Please Enter Description');
                $('#ContentPlaceHolder1_txtDesc').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtDesc').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_txtDesc').css('border-color', 'lightgray');
            }
            if ($('#ContentPlaceHolder1_txtAbrDesc').val().trim() == '') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed ');
                $('#ContentPlaceHolder1_lblMsg').html('Please Enter Abbreviated Description');
                $('#ContentPlaceHolder1_txtAbrDesc').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtAbrDesc').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_txtAbrDesc').css('border-color', 'lightgray');
            }
            if ($('#ContentPlaceHolder1_ddlGlCode').val() == '0') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').html('Please Select SGL Code ');
                $('#ContentPlaceHolder1_ddlGlCode').css('border-color', 'red');
                $('#ContentPlaceHolder1_ddlGlCode').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_ddlGlCode').css('border-color', 'lightgray');
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
            <div class="container">
                <div class="col-sm-12" style="margin-top: 20px;">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Earning / Deduction Master
                     <%--       <h4 class="text-center">Earning / Deduction Master</h4>--%>
                        </div>
                        <div class="panel-body form-horizontal">
                            <div class="form-group">
                                <div class="col-sm-6 col-xs-12">
                                    <div class="row">
                                        <label class="col-xs-3">Select Type</label>
                                        <div class="col-xs-7">
                                            <asp:DropDownList runat="server" CssClass="form-control form-control-xs" ID="ddlSelect" OnSelectedIndexChanged="ddlSelect_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                                                <asp:ListItem Text="EARNING" Value="1" />
                                                <asp:ListItem Text="DEDUCTION" Value="2" />
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-xs-12" id="divglcode" runat="server">
                                    <div class="row">
                                        <label class="col-xs-4">Deduction Type</label>
                                        <div class="col-xs-7">
                                            <asp:DropDownList runat="server" CssClass="form-control form-control-xs" ID="ddlDedType" OnSelectedIndexChanged="ddlDedType_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                                                <asp:ListItem Text="INTERNAL" Value="1" />
                                                <asp:ListItem Text="EXTERNAL" Value="2" />
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-6 col-xs-12">
                                    <div class="row">
                                        <label class="col-xs-3">Description</label>
                                        <div class="col-xs-7">
                                            <asp:TextBox runat="server" placeholder="Description" ID="txtDesc" Style='text-transform: uppercase' CssClass="form-control form-control-xs" MaxLength="100" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-xs-12">
                                    <div class="row">
                                        <label class="col-xs-4">Abbreviated Description </label>
                                        <div class="col-xs-7">
                                            <asp:TextBox runat="server" placeholder="Abbreviated Description" Style='text-transform: uppercase' ID="txtAbrDesc" CssClass="form-control form-control-xs" MaxLength="50" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-6 col-xs-12">
                                    <div class="row">
                                        <label class="col-xs-3">Payment Type</label>
                                        <div class="col-xs-7">
                                            <asp:RadioButtonList runat="server" RepeatDirection="horizontal" Width="100%" OnSelectedIndexChanged="RbpayAmount_SelectedIndexChanged" AutoPostBack="true" ForeColor="#0d4f86" ID="RbpayAmount">
                                                <asp:ListItem Text="Six Pay " Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Seventh Pay " Value="1"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-xs-12">
                                    <div class="form-group">
                                        <div class="col-sm-5">
                                            <asp:RadioButtonList runat="server" RepeatDirection="horizontal" OnSelectedIndexChanged="RdbAmt_SelectedIndexChanged" AutoPostBack="true" ForeColor="#0d4f86" ID="RdbAmt">
                                                <asp:ListItem Text="Fix Amt." Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Percent %" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Other" Value="2" Selected="True"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:TextBox runat="server" ID="txtAmt" Style='text-transform: uppercase' CssClass="form-control form-control-xs Money" MaxLength="8" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-xs-12">
                                    <div class="row">
                                        <label class="col-xs-3">GL Code</label><div class="col-xs-7">
                                            <asp:DropDownList runat="server" CssClass="form-control form-control-xs " ID="ddlGlCode">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-footer">
                                <div class="row">
                                    <div class="col-xs-12 col-sm-12 text-right">
                                        <asp:Label ID="lblMsg" runat="server" />
                                        <asp:LinkButton CssClass="btn btn-success" Text="Save" runat="server" ID="btnSave" OnClick="btnSave_Click"></asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-warning" runat="server" ID="btnClear" OnClick="btnClear_Click"><i class="fa r fa-refresh"></i> Clear</asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-danger" runat="server" ID="btnExit" PostBackUrl="~/Salary/Dashboard.aspx"><i class="fa r fa-close"></i> Exit</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 col-xs-12 table-responsive">
                                    <div style="padding-right: 17px;">
                                        <table class="table table-bordered" style="margin-bottom: 0px;">
                                            <thead>
                                                <tr class="tblhd">
                                                    <th style="width: 4%;">Edit</th>
                                                    <th style="width: 5%;">Edcd</th>
                                                    <th style="width: 20%;">Description</th>
                                                    <th style="width: 20%;">Abbreviated Description</th>
                                                    <th style="width: 7%;">Six Amt.</th>
                                                    <th style="width: 10%;">Six Persent %</th>
                                                    <th style="width: 10%;">Seventh Amt.</th>
                                                    <th style="width: 13%;">Seventh Persent %</th>
                                                    <th style="width: 10%;">GL Code</th>
                                                </tr>
                                            </thead>
                                        </table>
                                    </div>
                                    <div class="tblhgt">
                                        <asp:GridView ID="GvEdcd" CssClass="table-bordered table-ims font12 table-responsive-ims-100 pdl-sm tbl" AutoGenerateColumns="false" EmptyDataText="No records Found" ShowHeader="false" runat="server">
                                            <HeaderStyle CssClass="ims_head" />
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="4%">
                                                    <ItemTemplate>
                                                        <asp:LinkButton CommandName="select" Text="Edit" ID="btnEdit" Width="100%" CssClass="btn btn-xs  add_btn" runat="server" CausesValidation="false" OnClick="btnEdit_Click"></asp:LinkButton>
                                                        <asp:Label ID="lblautono" Text='<%#Eval("AutoNo") %>' runat="server" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblPayInd" Text='<%#Eval("PayInd") %>' runat="server" Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="5%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEdcd" Text='<%#Eval("Edcd") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="20%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldesc" Text='<%#Eval("[Desc]") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField ItemStyle-Width="20%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAbrDesc" Text='<%#Eval("AbrDesc") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="7%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFixamt" Text='<%#Eval("Fixamt") %>' runat="server" Style="float: right"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPerValue" Text='<%#Eval("PerValue") %>' runat="server" Style="float: right"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFixamt7" Text='<%#Eval("Fixamt7") %>' runat="server" Style="float: right"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="13%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPerValue7" Text='<%#Eval("PerValue7") %>' runat="server" Style="float: right"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGlCode" Text='<%#Eval("GlCode") %>' runat="server" Style="float: right"></asp:Label>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

