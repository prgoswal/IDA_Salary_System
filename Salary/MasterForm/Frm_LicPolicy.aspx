<%@ Page Title="" Language="C#" MasterPageFile="~/Salary/SalaryMaster.master" AutoEventWireup="true" CodeFile="Frm_LicPolicy.aspx.cs" Inherits="MasterForm_Frm_LicPolicy" %>

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

    <script type="text/javascript">
        function confirm(event) {
            var ind = (event.innerHTML);
            if (ind == "Stop") {
                $('#<%=lblpromsg.ClientID%>').html("Are You Sure (<span style='color:#1e983b'>  Live  </span>)  This Policy.");
            }
            else {
                $('#<%=lblpromsg.ClientID%>').html("Are You Sure (<span style='color:#f05050'>  Stop </span>)  This Policy.");
            }
            $('#myModal').modal("show");
            $('#btnsuccess').click(function () {
                window.location = event;
            });
            return false;
        }
    </script>

    <script type="text/javascript">
        function confirmDelete(event) {
            var ind = (event.innerHTML);
            if (ind == "Delete") {
                $('#<%=Label1.ClientID%>').html("Are You Sure (<span style='color:#f05050'>  Delete  </span>)  This Policy.");
            }
            $('#myModalDelete').modal("show");
            $('#btnDelete').click(function () {
                window.location = event;
            });
            return false;
        }
    </script>

    <script type="text/javascript">
        function SaveValidation() {
            if ($('#ContentPlaceHolder1_txtEmployeeNo').val().trim() == '') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed ');
                $('#ContentPlaceHolder1_lblMsg').html('Please Enter Employee No');
                $('#ContentPlaceHolder1_txtEmployeeNo').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtEmployeeNo').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_txtEmployeeNo').css('border-color', 'lightgray');
            }
            if ($('#ContentPlaceHolder1_DDLLICType').val() == '0') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').html('Please Select LIC Type ');
                $('#ContentPlaceHolder1_DDLLICType').css('border-color', 'red');
                $('#ContentPlaceHolder1_DDLLICType').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_DDLLICType').css('border-color', 'lightgray');
            }
            if ($('#ContentPlaceHolder1_DDLDivision').val() == '0') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').html('Please Select Division');
                $('#ContentPlaceHolder1_DDLDivision').css('border-color', 'red');
                $('#ContentPlaceHolder1_DDLDivision').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_DDLDivision').css('border-color', 'lightgray');
            }
            if ($('#ContentPlaceHolder1_DDLPolicyType').val() == '0') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').html('Please Select Policy Type');
                $('#ContentPlaceHolder1_DDLPolicyType').css('border-color', 'red');
                $('#ContentPlaceHolder1_DDLPolicyType').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_DDLPolicyType').css('border-color', 'lightgray');
            }
            if ($('#ContentPlaceHolder1_txtPolicyNo').val().trim() == '') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed ');
                $('#ContentPlaceHolder1_lblMsg').html('Please Enter Policy No');
                $('#ContentPlaceHolder1_txtPolicyNo').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtPolicyNo').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_txtPolicyNo').css('border-color', 'lightgray');
            }
        }
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="modal fade in" id="myModal" tabindex="-1" role="dialog" aria-labelledby="msgModalLabel">
        <div class="modal-dialog" role="document" style="position: absolute; top: 50%; left: 50%; transform: translate(-50%,-50%); margin: 0">
            <div class="modal-content">
                <div class="modal-header" style="background-color: steelblue; color: white;">
                    <button type="button" class="close" data-dismiss="modal" style="color: white">&times;</button>
                    <h4 class="modal-title">Policy Stop/Running Confirmation...<span>
                        <img style="width: 159px; position: absolute; top: 19px; display: none; left: 127px; z-index: 999; border-radius: 20px 20px"  alt="downloading..." />
                    </span></h4>
                </div>
                <div class="modal-body">
                    <label id="lblpromsg" runat="server"></label>
                </div>
                <div class="modal-footer">
                    <button type="button" id="btnsuccess" class="btn btn-success" data-dismiss="modal">Confirm</button>
                    <input type="button" id="btncancel" class="btn btn-info" value="Cancel" data-dismiss="modal" />
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade in" id="myModalDelete" tabindex="-1" role="dialog" aria-labelledby="msgModalLabel">
        <div class="modal-dialog" role="document" style="position: absolute; top: 50%; left: 50%; transform: translate(-50%,-50%); margin: 0">
            <div class="modal-content">
                <div class="modal-header" style="background-color: steelblue; color: white;">
                    <button type="button" class="close" data-dismiss="modal" style="color: white">&times;</button>
                    <h4 class="modal-title">Delete Confirmation...<span>
                        <img style="width: 159px; position: absolute; top: 19px; display: none; left: 127px; z-index: 999; border-radius: 20px 20px"  alt="downloading..." />
                    </span></h4>
                </div>
                <div class="modal-body">
                    <label id="Label1" runat="server"></label>
                </div>
                <div class="modal-footer">
                    <button type="button" id="btnDelete" class="btn btn-success" data-dismiss="modal">Yes</button>
                    <input type="button" id="btncancel1" class="btn btn-info" value="No" data-dismiss="modal" />
                </div>
            </div>
        </div>
    </div>
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
            <div class="mrgntp10 mt10 col-xs-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">INSURANCE POLICY DETAILS </div>
                    <div class="panel-body form-horizontal">

                        <div class="row">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <div class="col-sm-12 col-xs-12 mtb">
                                        <label class="col-sm-2 col-xs-12" style="padding-left: 15px">Employee No.<i class="Star">*</i></label>
                                        <div class="col-sm-10" style="padding-left: 10px">
                                            <div class="row">
                                                <div class="col-sm-3">
                                                    <asp:TextBox runat="server" ID="txtEmployeeNo" OnTextChanged="txtEmployeeNo_TextChanged" AutoPostBack="true" MaxLength="8" placeholder="Employee No." Style='text-transform: uppercase' CssClass="form-control form-control-xs numberonly" />
                                                </div>

                                                <div class="col-sm-5">
                                                    <asp:TextBox runat="server" ID="txtName" MaxLength="50" ReadOnly="true" placeholder="Name / Father Name" Style='text-transform: uppercase' CssClass="form-control form-control-xs Alphaonly" />
                                                </div>
                                                <div class="col-sm-4">
                                                    <asp:TextBox runat="server" ID="txtDesignation" MaxLength="50" ReadOnly="true" placeholder="Designation" Style='text-transform: uppercase' CssClass="form-control form-control-xs Alphaonly" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <div class="col-sm-12 col-xs-12 mtb">
                                        <label class="col-sm-4 col-xs-12">LIC Type <i class="Star">*</i></label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList runat="server" ID="DDLLICType" CssClass="form-control form-control-xs">
                                                <asp:ListItem Text="text1" />
                                                <asp:ListItem Text="text2" />
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <div class="col-sm-12 col-xs-12 mtb">
                                        <label class="col-sm-4 col-xs-12">Policy Type <i class="Star">*</i></label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList runat="server" ID="DDLPolicyType"  CssClass="form-control form-control-xs">
                                                <asp:ListItem Text="text1" />
                                                <asp:ListItem Text="text2" />
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <div class="col-sm-12 col-xs-12 mtb">
                                        <label class="col-sm-4 col-xs-12">Policy No.<i class="Star">*</i></label>
                                        <div class="col-sm-8">
                                            <asp:TextBox runat="server" ID="txtPolicyNo" MaxLength="9" placeholder="Policy No." Style='text-transform: uppercase' CssClass="form-control form-control-xs numberonly" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="col-sm-12 col-xs-12 mtb">
                                    <div class="form-group">
                                        <label class="col-sm-4 col-xs-12">Policy Amount.</label>
                                        <div class="col-sm-8">
                                            <asp:TextBox runat="server" ID="txtPolicyAmt" MaxLength="9" placeholder="Policy Amount" Style='text-transform: uppercase' CssClass="form-control form-control-xs Money" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <div class="col-sm-12 col-xs-12 mtb">
                                        <label class="col-sm-4 col-xs-12">Premium Amount. </label>
                                        <div class="col-sm-8">
                                            <asp:TextBox runat="server" ID="txtPremiumAmt" MaxLength="9" placeholder="Premium Amount " Style='text-transform: uppercase' CssClass="form-control form-control-xs Money" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div id="divstatus" runat="server">
                                    <div class="form-group">
                                        <div class="col-sm-12 col-xs-12 mtb">
                                            <label class="col-sm-4">Status</label>
                                            <style>
                                                .lic-radio-yn span input[type="checkbox"], .lic-radio-yn span label {
                                                    display: block;
                                                    float: left;
                                                    cursor: pointer;
                                                    user-select: none;
                                                }

                                                .lic-radio-yn span label {
                                                    margin-left: 4px;
                                                    margin-top: 2px;
                                                }
                                            </style>
                                            <div class="col-sm-8 lic-radio-yn">
                                                <asp:CheckBox ID="chkstatus" OnCheckedChanged="chkstatus_CheckedChanged" AutoPostBack="true" runat="server" Text="" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <div class="col-sm-12 col-xs-12 mtb">
                                        <label class="col-sm-4 col-xs-12">Start Date <i class="Star">*</i></label>
                                        <div class="col-sm-8 date-picker-icon">
                                            <asp:TextBox runat="server" ID="txtStartDate" MaxLength="10" OnTextChanged="txtStartDate_TextChanged" Style='text-transform: uppercase;' AutoPostBack="true" CssClass="datepicker form-control form-control-xs date-picker-icon" placeholder="DD/MM/YYYY" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <div class="col-sm-12 col-xs-12 mtb">
                                        <label class="col-sm-4 col-xs-12">Maturity Date <i class="Star">*</i></label>
                                        <div class="col-sm-8 date-picker-icon">
                                            <asp:TextBox runat="server" ID="txtMaturityDate" OnTextChanged="txtMaturityDate_TextChanged" MaxLength="10" Style='text-transform: uppercase;' AutoPostBack="true" CssClass="datepicker form-control form-control-xs date-picker-icon" placeholder="DD/MM/YYYY" />
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
                                <asp:LinkButton CssClass="btn btn-success" ID="btnSave" OnClientClick="return SaveValidation()" OnClick="btnSave_Click" runat="server"><i class="fa r fa-save"></i> Save</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-primary" ID="btnUpdate" runat="server" OnClick="btnUpdate_Click"><i class="fa r fa-close"></i> Update</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-warning" ID="btnReset" runat="server" OnClick="btnReset_Click"><i class="fa r fa-refresh"></i> Clear</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-danger"  PostBackUrl="~/Salary/Dashboard.aspx"  ID="btnExit" runat="server"><i class="fa r fa-close"></i> Exit</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body form-horizontal">
                        <div class="brd0r">
                            <div class="row">
                                <div class="col-sm-12 col-xs-12 mtb ">
                                    <div class=" form-group" style="margin-bottom: 0px!important">
                                        <label class="col-sm-12 col-xs-12 ">List of LIC Policy :</label>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="table-header-fixer" style="padding-right: 17px">
                                        <table class="table table-bordered f12 pd-sm br-wrd">
                                            <tr class="tbl_bg">
                                                <th style="width: 7%">Employee No.</th>
                                                <th style="width: 24%">Name / Father Name</th>
                                                <th style="width: 10%">LIC Type</th>
                                                <%--  <th style="width: 10%">Division</th>--%>
                                                <th style="width: 11%">Policy Type</th>
                                                <th style="width: 6%">Policy No.</th>
                                                <th style="width: 6%">Policy Amt.</th>
                                                <th style="width: 7%">Premium Amt.</th>
                                                <th style="width: 6%">Start Date</th>
                                                <th style="width: 7%">Maturity Date</th>
                                                <th style="width: 6%">Status</th>
                                                <th style="width: 5%">Edit</th>
                                                <th style="width: 5%">Delete</th>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="body-fix-table" style="max-height: 290px">
                                        <asp:GridView ID="gvLicpolicy" ShowHeader="False" AutoGenerateColumns="false" OnRowCommand="gvLicpolicy_RowCommand" OnRowDataBound="gvLicpolicy_RowDataBound" EmptyDataText="No records Found" runat="server" CssClass="table table-bordered pd-sm f12 br-wrd">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="7%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmpNo" Text='<%#Eval("EmpNo") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="24%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" Text='<%#Eval("name") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDesgDesc" Text='<%#Eval("DesgDesc") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEdcd" Text='<%#Eval("Edcd") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEDDesc" Text='<%#Eval("EDDesc") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDivCode" Visible="false" Text='<%#Eval("DivCode") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="10%" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDivCodeDese" Text='<%#Eval("DivCodeDese") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPolicyType" Visible="false" Text='<%#Eval("PolicyType") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="11%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPolicyTypeDese" Text='<%#Eval("PolicyTypeDese") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="6%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPolicyNo" Text='<%#Eval("PolicyNo") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="6%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPolicyAmt" Text='<%#Eval("PolicyAmt") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="7%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblInstallment" Text='<%#Eval("Installment") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="6%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStartDate" Text='<%#Eval("StartDate") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="7%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMaturityDate" Text='<%#Eval("MaturityDate") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="IsActive" Text='<%#Eval("Stop") %>' Width="100%" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="6%" ItemStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnActivenew" OnClientClick="return confirm(this)" CommandName="Actionnew" CommandArgument='<%#Container.DataItemIndex %>' ToolTip="Status" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="5%">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEdit" Text="Edit" Width="100%" OnClick="btnEdit_Click" CssClass="btn btn-xs btn-warning add_btn" runat="server"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="5%">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelete" Text="Delete" OnClientClick="return confirmDelete(this)" OnClick="btnDelete_Click" Width="100%" CssClass="btn btn-xs btn-danger add_btn btn-mi-ai" runat="server"></asp:LinkButton>
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
                </div>
           
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

