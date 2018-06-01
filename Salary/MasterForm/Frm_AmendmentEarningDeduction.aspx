<%@ Page Title="" Language="C#" MasterPageFile="~/Salary/SalaryMaster.master" AutoEventWireup="true" CodeFile="Frm_AmendmentEarningDeduction.aspx.cs" Inherits="MasterForm_Frm_AmendmentEarningDeduction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        function LoadAllScript() {
            LoadBasic();

            $(document).ready(function () {
                $(".fi-chkSelectAll input").click(function () {
                    if ($(this).is(":checked")) {
                        $(".fi-chkItem input").prop('checked', true);
                    } else {
                        $(".fi-chkItem input").prop('checked', false);
                    }
                });

                $(".fi-chkItem input").click(function () {
                    var cbcheked = $(".fi-chkItem input:checked").length;
                    var cbblank = $(".fi-chkItem input").length;

                    if (cbcheked < cbblank) {
                        if ($(".fi-chkSelectAll input").is(":checked")) {
                            $(".fi-chkSelectAll input").prop('checked', false);
                        }
                    }
                    if (cbcheked == cbblank) {
                        $(".fi-chkSelectAll input").prop('checked', true);
                    }
                });
            });
        }
    </script>

    <script>
        $(document).ready(function () {
            $(".fi-chkSelectAll input").click(function () {
                if ($(this).is(":checked")) {
                    $(".fi-chkItem input").prop('checked', true);
                } else {
                    $(".fi-chkItem input").prop('checked', false);
                }
            });

            $(".fi-chkItem input").click(function () {
                var cbcheked = $(".fi-chkItem input:checked").length;
                var cbblank = $(".fi-chkItem input").length;

                if (cbcheked < cbblank) {
                    if ($(".fi-chkSelectAll input").is(":checked")) {
                        $(".fi-chkSelectAll input").prop('checked', false);
                    }
                }
                if (cbcheked == cbblank) {
                    $(".fi-chkSelectAll input").prop('checked', true);
                }
            });
        });
    </script>


    <style>
        .fa.r {
            margin-right: 5px;
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

        .panel-heading {
            background: #3c8dbc !important;
            text-align: center;
            font-weight: bold;
            font-size: 17px;
            color: #fff !important;
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

        .th-sm tr th, .th-sm tr td {
            padding: 2px !important;
            vertical-align: middle !important;
        }

        .blhed {
            margin-left: 0px !important;
            margin-right: 0px !important;
            background-color: #3c8dbc;
        }

        .grd {
            height: 100px;
            overflow-y: scroll;
        }
    </style>
    <script type="text/javascript">
        function Validation() {
            if (jQuery("#ContentPlaceHolder1_chkemp").prop("checked")) {
                //if ($('#ContentPlaceHolder1_DDlDesignatio').val() == '0') {
                //    $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                //    $('#ContentPlaceHolder1_lblMsg').html(' Please Select Designation Name');
                //    $('#ContentPlaceHolder1_DDlDesignatio').css('border-color', 'red');
                //    $('#ContentPlaceHolder1_DDlDesignatio').focus();
                //    return false;
                //}
                //else {
                //    $('#ContentPlaceHolder1_DDlDesignatio').css('border-color', 'lightgray');
                //}
                //var boxes = $('.chkItem');
                //if (boxes.filter(':checked').length == 0) {
                //    $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                //    $('#ContentPlaceHolder1_lblMsg').html('You must select at least one !');
                //    return false;
                //}
                if ($('#ContentPlaceHolder1_DDlHead').val() == '0') {
                    $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                    $('#ContentPlaceHolder1_lblMsg').html(' Please Select Head ');
                    $('#ContentPlaceHolder1_DDlHead').css('border-color', 'red');
                    $('#ContentPlaceHolder1_DDlHead').focus();
                    return false;
                }
                else {
                    $('#ContentPlaceHolder1_DDlHead').css('border-color', 'lightgray');
                }
                if ($('#ContentPlaceHolder1_ddlDeductionHead').val() == '0') {
                    $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                    $('#ContentPlaceHolder1_lblMsg').html('Please Select Deduction Head ');
                    $('#ContentPlaceHolder1_ddlDeductionHead').css('border-color', 'red');
                    $('#ContentPlaceHolder1_ddlDeductionHead').focus();
                    return false;
                }
                else {
                    $('#ContentPlaceHolder1_ddlDeductionHead').css('border-color', 'lightgray');
                }
                if ($('#ContentPlaceHolder1_txtAmount').val().trim() == '') {
                    $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed ');
                    $('#ContentPlaceHolder1_lblMsg').html(' Please Enter Amount');
                    $('#ContentPlaceHolder1_txtAmount').css('border-color', 'red');
                    $('#ContentPlaceHolder1_txtAmount').focus();
                    return false;
                }
                else {
                    $('#ContentPlaceHolder1_txtAmount').css('border-color', 'lightgray');
                }
            }
            else {

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
                if ($('#ContentPlaceHolder1_DDlHead').val() == '0') {
                    $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                    $('#ContentPlaceHolder1_lblMsg').html(' Please Select Head ');
                    $('#ContentPlaceHolder1_DDlHead').css('border-color', 'red');
                    $('#ContentPlaceHolder1_DDlHead').focus();
                    return false;
                }
                else {
                    $('#ContentPlaceHolder1_DDlHead').css('border-color', 'lightgray');
                }
                if ($('#ContentPlaceHolder1_ddlDeductionHead').val() == '0') {
                    $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                    $('#ContentPlaceHolder1_lblMsg').html('Please Select Deduction Head ');
                    $('#ContentPlaceHolder1_ddlDeductionHead').css('border-color', 'red');
                    $('#ContentPlaceHolder1_ddlDeductionHead').focus();
                    return false;
                }
                else {
                    $('#ContentPlaceHolder1_ddlDeductionHead').css('border-color', 'lightgray');
                }
                if ($('#ContentPlaceHolder1_txtAmount').val().trim() == '') {
                    $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed ');
                    $('#ContentPlaceHolder1_lblMsg').html(' Please Enter Amount');
                    $('#ContentPlaceHolder1_txtAmount').css('border-color', 'red');
                    $('#ContentPlaceHolder1_txtAmount').focus();
                    return false;
                }
                else {
                    $('#ContentPlaceHolder1_txtAmount').css('border-color', 'lightgray');
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
            <div class="col-xs-10 col-sm-offset-1 mrgntp10 mt10">
                <div class="panel panel-primary">
                    <div class="panel-heading">AMENDMENT IN EARNING & DEDUCTION </div>
                    <div class="panel-body form-horizontal">
                        <div class="">
                            <div class="form-group blhed">
                                <div class="col-sm-12 col-xs-12 mtb">
                                    <div class="row chk">
                                        <asp:CheckBox ID="chkemp" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true" Text="BULK EMPLOYEE AMENDMENT " />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12" id="pnlDynClass" runat="server">
                                    <div class="row" id="divpanal" runat="server">
                                        <div class="col-sm-4">
                                            <div class="brdr_box">
                                                <div class="row">
                                                    <div class="col-sm-12 col-xs-12 mtb">
                                                        <div class="form-group">
                                                            <label class="col-sm-12 col-xs-12">Employee No <i class="Star">*</i></label>
                                                            <div class="col-sm-12">
                                                                <asp:TextBox runat="server" ID="txtEmployeeNo" OnTextChanged="txtEmployeeNo_TextChanged" AutoPostBack="true" MaxLength="8" placeholder="Employee No " Style='text-transform: uppercase' CssClass="form-control form-control-xs numberonly" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="row">
                                                <div class="col-sm-12 col-xs-12 mtb">
                                                    <div class="form-group">
                                                        <label class="col-sm-12 col-xs-12">Employee Name / Father Name</label>
                                                        <div class="col-sm-12">
                                                            <asp:TextBox runat="server" ID="txtName" ReadOnly="true" MaxLength="50" placeholder="Name / Father Name" Style='text-transform: uppercase' CssClass="form-control form-control-xs Alphaonly" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Designation</label>
                                                <div class="col-sm-12">
                                                    <asp:TextBox runat="server" ID="txtDesignation" ReadOnly="true" MaxLength="200" placeholder="Designation" Style='text-transform: uppercase' CssClass="form-control form-control-xs" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 col-xs-12 mtb">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Head <i class="Star">*</i></label>
                                                <div class="col-sm-12">
                                                    <asp:DropDownList runat="server" ID="DDlHead" OnSelectedIndexChanged="DDlHead_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control form-control-xs">
                                                        <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                                                        <asp:ListItem Value="1">EARNING</asp:ListItem>
                                                        <asp:ListItem Value="2">INTERNAL DEDUCTION</asp:ListItem>
                                                        <asp:ListItem Value="3">EXTERNAL DEDUCTION</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-4 col-xs-12 mtb">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Deduction Head <i class="Star">*</i></label>
                                                <div class="col-sm-12">
                                                    <asp:DropDownList runat="server" ID="ddlDeductionHead" CssClass="form-control form-control-xs">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-4 col-xs-12 mtb">
                                            <div class="form-group">
                                                <label class="col-sm-12 col-xs-12">Amount <i class="Star">*</i></label>
                                                <div class="col-sm-5">
                                                    <asp:TextBox runat="server" ID="txtAmount" MaxLength="9" placeholder="Amount" Style='text-transform: uppercase' CssClass="form-control form-control-xs Money" />
                                                </div>


                                                <div class="col-sm-7">
                                                    <asp:Button CssClass="btn btn-info btn" ID="LinkButton1" OnClientClick="return Validation()" OnClick="LinkButton1_Click" runat="server" Text="ADD"></asp:Button>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" id="DivmultipalEmp" runat="server">
                                        <div class="col-sm-4">
                                            <div class="brdr_box">
                                                <div class="row">
                                                    <div class="col-sm-12 col-xs-12 mtb">
                                                        <div class="form-group">
                                                            <label class="col-sm-12 col-xs-12">Select Filter Type<i class="Star"> *</i></label>
                                                            <div class="col-sm-12">
                                                                <asp:DropDownList runat="server" ID="ddlFilterType" AutoPostBack="true" OnSelectedIndexChanged="ddlFilterType_SelectedIndexChanged" CssClass="form-control form-control-xs">
                                                                    <%--<asp:ListItem Value="0" Text="-- Select --" />--%>
                                                                    <asp:ListItem Value="1" Text="Class Wise" />
                                                                    <asp:ListItem Value="2" Text="Designation Wise" />
                                                                    <asp:ListItem Value="3" Text="Department Wise" />
                                                                    <asp:ListItem Value="4" Text="Emp Type Wise" />
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row" id="Designation" runat="server" visible="false">
                                                    <div class="col-sm-12 col-xs-12 mtb">
                                                        <div class="form-group">
                                                            <label class="col-sm-12 col-xs-12">Designation <i class="Star">*</i></label>
                                                            <div class="col-sm-12">
                                                                <asp:DropDownList runat="server" ID="DDlDesignatio" CssClass="form-control form-control-xs">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row" id="pnlClass" runat="server" visible="true">
                                                    <div class="col-sm-12 col-xs-12 mtb">
                                                        <div class="form-group">
                                                            <label class="col-sm-12 col-xs-12">Class <i class="Star">*</i></label>
                                                            <div class="col-sm-12">
                                                                <asp:DropDownList runat="server" ID="ddlClass" CssClass="form-control form-control-xs">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row" id="pnlEmpType" runat="server" visible="false">
                                                    <div class="col-sm-12 col-xs-12 mtb">
                                                        <div class="form-group">
                                                            <label class="col-sm-12 col-xs-12">Employee&nbsp;Type <i class="Star">*</i></label>
                                                            <div class="col-sm-12">
                                                                <asp:DropDownList runat="server" CssClass="form-control form-control-xs col-sm-9" ID="ddlEmpType"></asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>


                                                <div class="row" id="pnlDepartment" runat="server" visible="false">
                                                    <div class="col-sm-12 col-xs-12 mtb">
                                                        <div class="form-group">
                                                            <label class="col-sm-12 col-xs-12">Department <i class="Star">*</i></label>
                                                            <div class="col-sm-12">
                                                                <asp:DropDownList runat="server" ID="ddlDepartment" CssClass="form-control form-control-xs">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-sm-12 col-xs-12 mtb">
                                                        <div class="form-group">
                                                            <label class="col-sm-4 col-xs-12">&nbsp <i class="Star"></i></label>
                                                            <div class="col-sm-8">
                                                                <asp:LinkButton CssClass="btn btn-info" ID="btnSearch" OnClick="btnSearch_Click" runat="server"><i class="fa r fa-search"></i> Search</asp:LinkButton>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-8">
                                            <div class="row">
                                                <div class="col-sm-12 col-xs-12 mtb">
                                                    <div class="form-group">
                                                        <div class="col-sm-12">
                                                            <div class="table-header-fixer">

                                                                <div class="header-fix-table">
                                                                    <table class="table table-bordered  th-sm">
                                                                        <tr class="tbl_bg">
                                                                            <th style="width: 15%">
                                                                                <asp:CheckBox Text="Select All " runat="server" ID="chkSelectAll" CssClass="fi-chkSelectAll" />
                                                                            </th>
                                                                            <th style="width: 20%">Employee No.</th>
                                                                            <th style="width: 65%">Employee Name</th>
                                                                        </tr>
                                                                    </table>
                                                                </div>

                                                                <div class="body-fix-table grd" style="border-bottom: 1px solid #ddd; border-left: 1px solid #ddd">
                                                                    <asp:GridView ID="GvBULKEMPLOYEE" CssClass="table table-bordered table-ims font12 table-responsive-ims-100 th-sm" AutoGenerateColumns="false" EmptyDataText="No records Found" ShowHeader="false" Width="100%" runat="server">
                                                                        <Columns>
                                                                            <asp:TemplateField ItemStyle-Width="15%" ItemStyle-CssClass="text-center">
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkItem" CssClass="fi-chkItem" runat="server" />
                                                                                    <%#Container.DataItemIndex+1 %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="20%" ItemStyle-CssClass="text-left">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblEmpNo" Style="float: left" ReadOnly="true" Text='<%#Eval("Empno") %>' runat="server"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="65%" ItemStyle-CssClass="text-left">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblEmpName" Style="float: left" ReadOnly="true" Text='<%#Eval("name") %>' runat="server"></asp:Label>
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
                                            <div class="row">
                                                <div class="form-group">
                                                    <label class="col-sm-2 col-xs-12 control-label">New&nbsp;Amount<i class="Star"></i></label>
                                                    <div class="col-sm-3">
                                                        <asp:TextBox runat="server" ID="txtReplaceAmt" MaxLength="9" placeholder="New Amt." CssClass="form-control form-control-xs Money" />
                                                    </div>
                                                    <div class="col-sm-3">
                                                        <asp:Button CssClass="btn btn-info btn" ID="btnBulkAdd" Visible="false" OnClientClick="return Validation()" OnClick="LinkButton1_Click" runat="server" Text="ADD"></asp:Button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-xs-12">

                                            <div class="table-header-fixer">
                                                <div class="header-fix-table">
                                                    <table class="table table-bordered th-sm">
                                                        <tr class="tbl_bg">

                                                            <th style="width: 09%">Emp. No.</th>
                                                            <th style="width: 38%">Name / Father Name</th>
                                                            <th style="width: 23%">Head Name</th>
                                                            <th style="width: 12%">Old Amount </th>
                                                            <th style="width: 12%">New Amount</th>
                                                            <th style="width: 6%">Edit</th>
                                                            <%-- <th style="width: 08%">Delete</th>--%>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <div class="body-fix-table" style="max-height: 186px">
                                                    <asp:GridView ID="GridDEDUCTION" CssClass="table table-bordered table-ims th-sm font12 table-responsive-ims-100" EmptyDataText="No records Found" AutoGenerateColumns="false" ShowHeader="false" Width="100%" runat="server">
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-Width="09%" ItemStyle-CssClass="text-left">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEmpNo" Style="float: left" Text='<%#Eval("EmpNo") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="38%" ItemStyle-CssClass="text-left">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblName" Style="float: left" ReadOnly="true" Text='<%#Eval("Name") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="23%" ItemStyle-CssClass="text-left">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDeductionHead" Style="float: left" ReadOnly="true" Text='<%#Eval("EdDes") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-CssClass="text-left" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDeductionHeadCD" Style="float: left" ReadOnly="true" Text='<%#Eval("EdCd") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-CssClass="text-left" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblselectType" Style="float: left" ReadOnly="true" Text='<%#Eval("selectType") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-CssClass="text-left" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDesignationNameID" Style="float: left" ReadOnly="true" Text='<%#Eval("DesignationNameID") %>' runat="server"></asp:Label>
                                                                    <asp:Label ID="lblDeptId" Style="float: left" ReadOnly="true" Text='<%#Eval("DeptId") %>' runat="server"></asp:Label>
                                                                    <asp:Label ID="lblClassId" Style="float: left" ReadOnly="true" Text='<%#Eval("ClassId") %>' runat="server"></asp:Label>
                                                                    <asp:Label ID="lblFilterType" Style="float: left" ReadOnly="true" Text='<%#Eval("FilterType") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField ItemStyle-Width="12%" ItemStyle-CssClass="text-left">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblOldAmtAMOUNT" Style="float: left" ReadOnly="true" Text='<%#Eval("OldAmt") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="12%" ItemStyle-CssClass="text-left">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblNewAmt" Style="float: left" ReadOnly="true" Text='<%#Eval("NewAmt") %>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField ItemStyle-Width="6%">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnEdit" Text="Edit" Width="100%" OnClick="btnEdit_Click" CommandArgument='<%#Container.DataItemIndex %>' CssClass="btn btn-xs btn-danger add_btn" runat="server"></asp:LinkButton>
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
                                <div class="col-sm-3" id="pnlErDedDesc" runat="server" visible="false">
                                    <div class="row">

                                        <div class="col-xs-12">

                                            <div class="table-header-fixer">
                                                <div class="header-fix-table">
                                                    <table class="table table-bordered  table-padding-sm">
                                                        <tr class="tbl_bg">

                                                            <th style="width: 70%">Prev. Month Salary</th>
                                                            <th style="width: 30%">Amount</th>

                                                        </tr>
                                                    </table>
                                                </div>
                                                <style>
                                                    .ss {
                                                        display: none;
                                                    }

                                                    .table-padding-sm {
                                                        margin-bottom: 10px;
                                                    }

                                                        .table-padding-sm tr td {
                                                            padding: 2px 7px !important;
                                                            font-size: 11px;
                                                        }
                                                </style>
                                                <div class="body-fix-table" style="max-height: 320px">
                                                    <asp:GridView ID="gvOldEarDed" OnRowDataBound="gvOldEarDed_RowDataBound" CssClass="table table-bordered table-ims font12 table-responsive-ims-100 table-padding-sm" AutoGenerateColumns="false" ShowHeader="false" runat="server">
                                                        <Columns>
                                                            <asp:BoundField DataField="Edcd" Visible="true" ItemStyle-CssClass="ss" />
                                                            <asp:BoundField DataField="EdcdDesc" ItemStyle-Width="70%" />
                                                            <asp:BoundField DataField="CalAmt" ItemStyle-Width="30%" />
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

                    </div>

                    <div class="panel-footer">
                        <div class="row">
                            <div class="col-xs-12 col-sm-12 text-left">
                                <asp:LinkButton CssClass="btn btn-success" ID="btnSave" OnClick="btnSave_Click" runat="server"><i class="fa r fa-save"></i>Save</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-warning" ID="btnClear" runat="server" OnClick="btnClear_Click"><i class="fa r fa-refresh"></i>Clear</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-danger" PostBackUrl="~/Salary/Dashboard.aspx" ID="btnExit" runat="server"><i class="fa r fa-close"></i>Exit</asp:LinkButton>
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

