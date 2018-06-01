<%@ Page Title="" Language="C#" MasterPageFile="~/Salary/SalaryMaster.master" AutoEventWireup="true" CodeFile="Frm_Bank.aspx.cs" Inherits="Transaction_Frm_Bank" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .radiobutton_list_inline_container {
            margin-bottom: 27px;
            position: relative;
            color: black;
        }

        .radiobutton_list_inline {
            left: 50%;
            position: absolute;
            transform: translateX(-50%);
        }

            .radiobutton_list_inline input[type="radio"], .radiobutton_list_inline label {
                cursor: pointer;
                user-select: none;
                display: block;
                float: left;
            }

            .radiobutton_list_inline input[type="radio"] {
                margin-top: 4px;
            }

            .radiobutton_list_inline label {
                margin-right: 10px;
            }

        .tblhd {
            background-color: #0a5486;
            color: #FFF;
        }

        .panel-heading {
            padding: 1px 15px;
        }
    </style>
    <script>
        function LoadAllScript() {
            LoadBasic();
        }
    </script>
    <script type="text/javascript">
        function SaveValidation() {
            if ($('input[id=ContentPlaceHolder1_rdbbank_0]:checked').val() == '0') {
                if ($('#ContentPlaceHolder1_txtBankName').val().trim() == '') {
                    $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed ');
                    $('#ContentPlaceHolder1_lblMsg').html('Enter Bank Name');
                    $('#ContentPlaceHolder1_txtBankName').css('border-color', 'red');
                    $('#ContentPlaceHolder1_txtBankName').focus();
                    return false;
                }
                else {
                    $('#ContentPlaceHolder1_txtBankName').css('border-color', 'lightgray');
                }
                if ($('#ContentPlaceHolder1_txtBranchName').val().trim() == '') {
                    $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed ');
                    $('#ContentPlaceHolder1_lblMsg').html('Enter Branch Name');
                    $('#ContentPlaceHolder1_txtBranchName').css('border-color', 'red');
                    $('#ContentPlaceHolder1_txtBranchName').focus();
                    return false;
                }
                else {
                    $('#ContentPlaceHolder1_txtBranchName').css('border-color', 'lightgray');
                }
                if ($('#ContentPlaceHolder1_txtIFSCCode').val().trim() == '') {
                    $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed ');
                    $('#ContentPlaceHolder1_lblMsg').html('Enter IFSC Code');
                    $('#ContentPlaceHolder1_txtIFSCCode').css('border-color', 'red');
                    $('#ContentPlaceHolder1_txtIFSCCode').focus();
                    return false;
                }
                else {
                    $('#ContentPlaceHolder1_txtIFSCCode').css('border-color', 'lightgray');
                }
            }
            else {
                if ($('#ContentPlaceHolder1_ddlBankName').val() == '0') {
                    $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                    $('#ContentPlaceHolder1_lblMsg').html('Select Bank Name');
                    $('#ContentPlaceHolder1_ddlBankName').css('border-color', 'red');
                    $('#ContentPlaceHolder1_ddlBankName').focus();
                    return false;
                }
                else {
                    $('#ContentPlaceHolder1_ddlBankName').css('border-color', 'lightgray');
                }
                if ($('#ContentPlaceHolder1_txtBranchName').val().trim() == '') {
                    $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed ');
                    $('#ContentPlaceHolder1_lblMsg').html('Enter Branch Name');
                    $('#ContentPlaceHolder1_txtBranchName').css('border-color', 'red');
                    $('#ContentPlaceHolder1_txtBranchName').focus();
                    return false;
                }
                else {
                    $('#ContentPlaceHolder1_txtBranchName').css('border-color', 'lightgray');
                }
                if ($('#ContentPlaceHolder1_txtIFSCCode').val().trim() == '') {
                    $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed ');
                    $('#ContentPlaceHolder1_lblMsg').html('Enter IFSC Code');
                    $('#ContentPlaceHolder1_txtIFSCCode').css('border-color', 'red');
                    $('#ContentPlaceHolder1_txtIFSCCode').focus();
                    return false;
                }
                else {
                    $('#ContentPlaceHolder1_txtIFSCCode').css('border-color', 'lightgray');
                }
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
                <div class="col-sm-8 col-sm-offset-2" style="margin-top: 20px;">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="text-center">Bank Master</h4>
                        </div>
                        <div class="panel-body form-horizontal">
                            <div class="col-sm-12 col-xs-12">
                                <div class="radiobutton_list_inline_container">
                                    <div class="radiobutton_list_inline">
                                        <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ForeColor="#0d4f86" ID="rdbbank" OnSelectedIndexChanged="rdbbank_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Text="Bank" Value="0" Selected="True">
                                            </asp:ListItem>
                                            <asp:ListItem Text="Branch" Value="1"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-12 col-xs-12">
                                    <div class="row">
                                        <label class="col-xs-3">Bank Name <i class="text-danger">*</i></label><div class="col-sm-9">
                                            <asp:TextBox runat="server" placeholder="Bank Name" ID="txtBankName" CssClass="form-control form-control-xs AlphaNum" MaxLength="100" />
                                            <asp:DropDownList runat="server" Visible="false" CssClass="form-control form-control-xs col-sm-9" ID="ddlBankName">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-xs-3">Branch Name <i class="text-danger">*</i></label><div class="col-sm-9">
                                            <asp:TextBox runat="server" placeholder="Branch Name" ID="txtBranchName" CssClass="form-control form-control-xs" MaxLength="100" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-xs-3">IFSC Code <i class="text-danger">*</i></label><div class="col-sm-9">
                                            <asp:TextBox runat="server" placeholder="IFSC Code" ID="txtIFSCCode" OnTextChanged="txtIFSCCode_TextChanged" AutoPostBack="true" CssClass="form-control form-control-xs AlphaNum" MaxLength="20" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 col-xs-12">
                                    <div class="form-group">
                                        <style>
                                            .tblhgt {
                                                max-height: 150px;
                                                min-height: 50px;
                                                overflow-y: scroll;
                                            }
                                        </style>
                                        <div class="col-sm-12 table-responsive">
                                            <div style="padding-right: 17px!important">
                                                <table class="table table-bordered" style="margin-bottom: 0px;">
                                                    <thead>
                                                        <tr class="tblhd">
                                                            <th style="width: 8%;">Edit</th>
                                                            <th style="width: 40%;">Bank Name</th>
                                                            <th style="width: 30%;">Branch Name</th>
                                                            <th style="width: 22%;">IFSC Code</th>
                                                        </tr>
                                                    </thead>
                                                </table>
                                            </div>
                                            <div class="tblhgt">
                                                <asp:GridView ID="GvBank" CssClass="table-bordered table-ims font12 table-responsive-ims-100" Style="width: 100%;" AutoGenerateColumns="false" ShowHeader="false" runat="server">
                                                    <HeaderStyle CssClass="ims_head" />
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-Width="8%">
                                                            <ItemTemplate>
                                                                <asp:LinkButton CommandName="select" Text="Edit" ID="btnEdit" Width="100%" CssClass="btn btn-xs  add_btn" runat="server" OnClick="btnEdit_Click"></asp:LinkButton>
                                                                <asp:Label ID="lblautono" Text='<%#Eval("Autono") %>' runat="server" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblBnkCd" Text='<%#Eval("BnkCd") %>' runat="server" Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="40%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBankName" Text='<%#Eval("BankName") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="30%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBranchName" Text='<%#Eval("BranchName") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField ItemStyle-Width="22%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIFSCCode" Text='<%#Eval("IFSCCode") %>' runat="server"></asp:Label>
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
                                    <asp:Label ID="lblMsg" CssClass="text-danger" runat="server" />
                                    <asp:LinkButton CssClass="btn btn-success" runat="server" Text="Save" OnClientClick="return SaveValidation()" ID="btnSave" OnClick="btnSave_Click"><i class="fa r fa-save"></i> Save</asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-warning" runat="server" ID="btnClear" OnClick="btnClear_Click"><i class="fa r fa-refresh"></i> Clear</asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-danger" runat="server" ID="btnExit"  PostBackUrl="~/Salary/Dashboard.aspx"><i class="fa r fa-close"></i> Exit</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

