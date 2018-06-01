<%@ Page Title="" Language="C#" MasterPageFile="~/Salary/SalaryMaster.master" AutoEventWireup="true" CodeFile="Frm_LeaveMaster.aspx.cs" Inherits="MasterForm_Frm_LeaveMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function Validation() {
            if ($('#ContentPlaceHolder1_txtLoanDescription').val().trim() == '') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').html('  Please Enter Leave Description');
                $('#ContentPlaceHolder1_txtLoanDescription').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtLoanDescription').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_txtLoanDescription').css('border-color', 'lightgray');
            }
            if ($('#ContentPlaceHolder1_txtAbbreviated').val().trim() == '') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').html('  Please Enter Abbreviated');
                $('#ContentPlaceHolder1_txtAbbreviated').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtAbbreviated').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_txtAbbreviated').css('border-color', 'lightgray');
            }
            if ($('#ContentPlaceHolder1_txtMaximumLifeLimit').val().trim() == '') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').html('  Please Enter Maximum Life Limit');
                $('#ContentPlaceHolder1_txtMaximumLifeLimit').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtMaximumLifeLimit').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_txtMaximumLifeLimit').css('border-color', 'lightgray');
            }
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

        .Star {
            color: red;
        }

        .chk {
            color: #fff;
        }

            .chk input {
                margin-left: 10px;
            }

            .chk label {
                margin-left: 10px;
            }

        .blhed {
            margin-left: 0px !important;
            margin-right: 0px !important;
            background-color: #3c8dbc;
            color:#fff;
           
        }
        .blhed label{
            margin-top: 5px;
        }

        .grd {
            height: 100px;
            overflow-y: scroll;
        }
    </style>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="updatepnl" runat="server">
        <ContentTemplate>
            <div class="col-xs-12 mrgntp10 mt10">

                <div class="panel panel-primary ">
                    <div class="panel-heading">LEAVE MASTER</div>
                    <div class="panel-body form-horizontal">
                        <div class="">
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="brdr_box">
                                        <div class="row">
                                            <div class="col-sm-12 col-xs-12 mtb">
                                                <div class="form-group">
                                                    <label class="col-sm-4 col-xs-12">Leave Description <i class="Star">*</i></label>
                                                    <div class="col-sm-8">
                                                        <asp:TextBox runat="server" ID="txtLoanDescription" MaxLength="30" placeholder="Leave Desc" Style='text-transform: uppercase' CssClass="form-control form-control-xs Alphaonly" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12 col-xs-12 mtb">
                                                <div class="form-group">
                                                    <label class="col-sm-4 col-xs-12">Abbreviated Desc<i class="Star">*</i></label>
                                                    <div class="col-sm-8">
                                                        <asp:TextBox runat="server" ID="txtAbbreviated" placeholder="Abbreviated Desc" MaxLength="10" Style='text-transform: uppercase' CssClass="form-control form-control-xs Alphaonly" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group blhed">
                                            <div class="col-sm-12 col-xs-12 mtb ">
                                                <div class="row">
                                                    <div class="col-sm-12">
                                                        <label class="lblpdng col-sm-12 col-xs-12 ">Maximum Permitted Days :- </label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12 col-xs-12 mtb">
                                                <div class="form-group">
                                                    <label class="col-sm-4 col-xs-12">Maximum Life Limit<i class="Star"> *</i></label>
                                                    <div class="col-sm-8">
                                                        <asp:TextBox runat="server" ID="txtMaximumLifeLimit" MaxLength="9" OnTextChanged="txtMaximumLifeLimit_TextChanged" AutoPostBack="true" placeholder="Maximum Life Limit" Style='text-transform: uppercase' CssClass="form-control form-control-xs numberonly" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="table-header-fixer">
                                        <div class="header-fix-table">
                                            <table class="table table-bordered">
                                                <tr class="tbl_bg">
                                                    <th style="width: 15%">LEAVE DESCRIPTION</th>
                                                    <th style="width: 20%">ABBREVIATION DESCRIPTION</th>
                                                    <th style="width: 10%">MAX LIMIT</th>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="body-fix-table" style="max-height: 290px">
                                            <asp:GridView ID="GvLeaveMaster" ShowHeader="False" AutoGenerateColumns="false" EmptyDataText="No records Found" runat="server" CssClass="table table-bordered">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LBLLoanDesc" Text='<%#Eval("LvDesc") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LBLAvrdesc" Text='<%#Eval("LvAbrDesc") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LBLIntRate" Text='<%#Eval("MaxLimitLife") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
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
                                <asp:LinkButton CssClass="btn btn-success" ID="btnSave" runat="server" OnClientClick="return Validation()" OnClick="btnSave_Click"><i class="fa r fa-save"></i> Save</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-warning" ID="btnClear" runat="server" OnClick="btnClear_Click"><i class="fa r fa-refresh"></i> Clear</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-danger" PostBackUrl="~/Salary/Dashboard.aspx"  ID="btnExit" runat="server"><i class="fa r fa-close"></i> Exit</asp:LinkButton>
                                <asp:Label ID="lblMsg" CssClass="text-danger" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

