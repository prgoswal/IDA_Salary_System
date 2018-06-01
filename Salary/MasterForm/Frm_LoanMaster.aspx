<%@ Page Title="" Language="C#" MasterPageFile="~/Salary/SalaryMaster.master" AutoEventWireup="true" CodeFile="Frm_LoanMaster.aspx.cs" Inherits="MasterForm_Frm_LoanMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">

        function LoadDesc()
        {
           
            if ($('#ContentPlaceHolder1_ddlLoanDescription').val() != '0') {
                $('#ContentPlaceHolder1_lblMsg').removeClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').html('');
                $('#ContentPlaceHolder1_ddlLoanDescription').css('border-color', 'lightgray');
            }
        }
        function Validation() {
            if ($('#ContentPlaceHolder1_ddlLoanDescription').val() == '0') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').html(' Please Select Loan Description');
                $('#ContentPlaceHolder1_ddlLoanDescription').css('border-color', 'red');
                $('#ContentPlaceHolder1_ddlLoanDescription').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_ddlLoanDescription').css('border-color', 'lightgray');
            }
            if ($('#ContentPlaceHolder1_txtAbbreviatedDescription').val().trim() == '') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').html('  Please Enter Abbreviated Description');
                $('#ContentPlaceHolder1_txtAbbreviatedDescription').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtAbbreviatedDescription').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_txtAbbreviatedDescription').css('border-color', 'lightgray');
            }
            if ($('#ContentPlaceHolder1_txtInterestRate').val().trim() == '') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').html('  Please Enter Interest Rate');
                $('#ContentPlaceHolder1_txtInterestRate').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtInterestRate').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_txtInterestRate').css('border-color', 'lightgray');
            }
            if ($('#ContentPlaceHolder1_txtInstallments').val().trim() == '') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').html('  Please Enter No. of Installments');
                $('#ContentPlaceHolder1_txtInstallments').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtInstallments').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_txtInstallments').css('border-color', 'lightgray');
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="updatepnl" runat="server">
        <ContentTemplate>
            <div class="col-xs-12 mrgntp10 mt10">
                <div class="panel panel-primary">
                    <div class="panel-heading">LOAN MASTER</div>
                    <div class="panel-body form-horizontal">
                        <div class="">
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="brdr_box">
                                        <div class="row">
                                            <div class="col-sm-12 col-xs-12 mtb">
                                                <div class="form-group">
                                                    <label class="col-sm-4 col-xs-12">Loan Description <i class="Star">*</i></label>
                                                    <div class="col-sm-8">
                                                         <asp:DropDownList runat="server" ID="ddlLoanDescription"  CssClass="form-control form-control-xs" onchange="return LoadDesc()">
                                                            <asp:ListItem Text="text1" />
                                                            <asp:ListItem Text="text2" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12 col-xs-12 mtb">
                                                <div class="form-group">
                                                    <label class="col-sm-4 col-xs-12">Abbreviated Description <i class="Star">*</i></label>
                                                    <div class="col-sm-8">
                                                        <asp:TextBox runat="server" ID="txtAbbreviatedDescription" MaxLength="20" placeholder="Abbreviated Description" Style='text-transform: uppercase' CssClass="form-control form-control-xs Alphaonly" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12 col-xs-12 mtb">
                                                <div class="form-group">
                                                    <label class="col-sm-4 col-xs-12">Interest Rate <i class="Star">*</i></label>
                                                    <div class="col-sm-8">
                                                        <asp:TextBox runat="server" ID="txtInterestRate" MaxLength="9" placeholder="Interest Rate" Style='text-transform: uppercase' CssClass="form-control form-control-xs numberonly" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12 col-xs-12 mtb">
                                                <div class="form-group">
                                                    <label class="col-sm-4 col-xs-12">No. of Installments <i class="Star">*</i></label>
                                                    <div class="col-sm-8">
                                                        <asp:TextBox runat="server" ID="txtInstallments" MaxLength="9" placeholder="No. of Installments" Style='text-transform: uppercase' CssClass="form-control form-control-xs numberonly" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12 col-xs-12 mtb">
                                                <div class="form-group">
                                                    <label class="col-sm-4 col-xs-12">Installment Amount:</label>
                                                    <div class="col-sm-8">
                                                        <asp:TextBox runat="server" ID="txtInstallmentAmount1" MaxLength="9" placeholder="Installment Amount " Style='text-transform: uppercase' CssClass="form-control form-control-xs Decimal4" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="display:none">
                                            <div class="col-sm-12 col-xs-12 mtb">
                                                <div class="form-group">
                                                    <label class="col-sm-4 col-xs-12">Installment Amount2:</label>
                                                    <div class="col-sm-8">
                                                        <asp:TextBox runat="server" ID="txtInstallmentAmount2" MaxLength="9" placeholder="Installment Amount2" Style='text-transform: uppercase' CssClass="form-control form-control-xs numberonly" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
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
                                    </style>
                                    <div class="table-header-fixer">
                                        <div class="header-fix-table">
                                            <table class="table table-bordered">
                                                <tr class="tbl_bg">
                                                    <th style="width: 23%">LOAN DESC</th>
                                                    <th style="width: 25%">ABBREVIATION DESC</th>
                                                    <th style="width: 10%">RATE</th>
                                                    <th style="width: 25%">NO. OF INSTALLMENT</th>
                                                    <th style="width: 18%">INSTALLMENT AMOUNT </th>
                                                  <%--  <th style="width: 18%">INSTALLMENT AMOUNT2 </th>--%>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="body-fix-table" style="max-height: 290px">
                                            <asp:GridView ID="GvLoanMaster" ShowHeader="False" AutoGenerateColumns="false" EmptyDataText="No records Found" runat="server" CssClass="table table-bordered">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-Width="23%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LBLLoanDesc" Text='<%#Eval("LoanDesc") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="25%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LBLAvrdesc" Text='<%#Eval("Avrdesc") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LBLIntRate" Text='<%#Eval("IntRate") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="25%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LBLAvrdesc" Text='<%#Eval("NoOfInst") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="18%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LBLLoanAmtRange1" Text='<%#Eval("LoanAmtRange1") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField ItemStyle-Width="18%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LBLLoanAmtRange2" Text='<%#Eval("LoanAmtRange2") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
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
                                <asp:LinkButton CssClass="btn btn-warning" ID="btnclear" runat="server" OnClick="btnclear_Click"><i class="fa r fa-refresh"></i> Clear</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-danger" ID="btnExit" runat="server"  PostBackUrl="~/Salary/Dashboard.aspx"><i class="fa r fa-close"></i> Exit</asp:LinkButton>
                                <asp:Label ID="lblMsg" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

