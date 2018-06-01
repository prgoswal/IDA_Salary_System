<%@ Page Title="" Language="C#" MasterPageFile="~/Salary/SalaryMaster.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="FrmFilterInformation.aspx.cs" Inherits="Salary_TransactionForm_FrmFilterInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- <script type="text/javascript">
        function LoadAllScript() {
            LoadBasic();
        }
    </script>--%>
    <script>
        $(document).ready(function () {
            $(".fi-chkAllDesgination input").click(function () {
                if ($(this).is(":checked")) {
                    $(".fi-ChkDesignation input").prop('checked', true);
                } else {
                    $(".fi-ChkDesignation input").prop('checked', false);
                }
            });
            $(".fi-ChkDesignation input").click(function () {
                var cbcheked = $(".fi-ChkDesignation input:checked").length;
                var cbblank = $(".fi-ChkDesignation input").length;

                if (cbcheked < cbblank) {
                    if ($(".fi-chkAllDesgination input").is(":checked")) {
                        $(".fi-chkAllDesgination input").prop('checked', false);
                    }
                }
                if (cbcheked == cbblank) {
                    $(".fi-chkAllDesgination input").prop('checked', true);
                }
            });
        });

        function Order_By() {
            $('#ContentPlaceHolder1_lblMsg').html('');
            $('#ContentPlaceHolder1_lblMsg').hide();
            $('#ContentPlaceHolder1_chkOrderBy').css('background-color', 'white');

        }
    </script>


    <style>
        .pointer, .pointer label, .pointer input {
            cursor: pointer;
        }

        .no-selectable {
            user-select: none;
        }

        .internaldeduct-checklist {
            padding: 10px;
            border: 0;
            border-radius: 0px;
            min-height: 170px;
            max-height: 120px;
            overflow-y: scroll;
            font-size: 12px;
            margin-left: -15px;
            margin-top: -10px;
        }

            .internaldeduct-checklist table {
                width: 100%;
            }

                .internaldeduct-checklist table tr td {
                    /*width: 100%;*/
                }

                    .internaldeduct-checklist table tr td input, .internaldeduct-checklist table tr td label {
                        font-weight: normal;
                        display: block;
                        float: left;
                        cursor: pointer;
                    }

                    .internaldeduct-checklist table tr td label {
                        margin-top: 2px;
                        margin-left: 2px;
                    }

                    .internaldeduct-checklist table tr td input:checked + label {
                        font-weight: bold;
                    }

        fieldset.scheduler-border {
            border: 1px solid #d4d4d4 !important;
            padding-left: 15px;
            padding-top: 5px;
            border-radius: 4px;
            margin-bottom: 15px;
        }


        legend.scheduler-border {
            width: inherit; /* Or auto */
            padding: 0 10px; /* To give a bit of padding on the left and right */
            border-bottom: none;
            font-size: 12px;
            font-weight: bold;
            margin-bottom: 0px;
        }

        .radio-list-normal, .check-list-normal {
            float: left;
            padding-bottom: 5px;
        }

            .radio-list-normal input, .radio-list-normal label, .check-list-normal input, .check-list-normal label {
                display: block;
                float: left;
                cursor: pointer;
                user-select: none;
                font-weight: normal;
            }

            .radio-list-normal label, .check-list-normal label {
                margin-top: 2px;
                margin-left: 3px;
                margin-right: 15px;
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

        table.gender-chklist {
            width: 100%;
            margin: 0;
        }

        .gender-chklist tr td {
            width: 33%;
            padding-left: 5px;
        }

        .table-select-query-filter {
            margin-bottom: 0;
        }

            .table-select-query-filter tr th {
                background: #3c8dbc;
                color: #fff;
            }

        .table-select-query-filter-sm {
            width: 100%;
            white-space: nowrap;
        }

            .table-select-query-filter-sm tr td, .table-select-query-filter-sm tr th {
                padding: 4px 4px !important;
                font-size: 12px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updatepnl">
        <ProgressTemplate>
            <div class="loading active"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="updatepnl" runat="server">
        <ContentTemplate>
            <script>
                Sys.Application.add_load(LoadAllScript);
            </script>--%>
    <div class="container-fluid" style="max-width: 1100px">
        <div class="row">
            <div class="col-xs-12">
                <div class="panel panel-primary mt10 mb0">
                    <div class="panel-heading">
                        <h3 class="panel-title">Filter Information</h3>
                    </div>
                    <div class="panel-body form-horizontal" style="padding-bottom: 5px">
                        <div class="row">
                            <div class="col-xs-12 col-sm-6">
                                <fieldset class="scheduler-border">
                                    <legend class="scheduler-border">Select Fields</legend>
                                    <div class="internaldeduct-checklist ">
                                        <script>
                                            $(document).ready(function () {
                                                $(".fi-chkSelectAll input").click(function () {
                                                    if ($(this).is(":checked")) {
                                                        $(".fi-ChkSelectField input").prop('checked', true);
                                                    } else {
                                                        $(".fi-ChkSelectField input").prop('checked', false);
                                                    }
                                                });

                                                $(".fi-ChkSelectField input").click(function () {
                                                    var cbcheked = $(".fi-ChkSelectField input:checked").length;
                                                    var cbblank = $(".fi-ChkSelectField input").length;

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
                                        <asp:CheckBox Text="Select All" runat="server" ID="chkSelectAll" CssClass="fi-chkSelectAll" />
                                        <asp:CheckBoxList runat="server" ID="ChkSelectField" onclick="return Select_Fields();" RepeatColumns="3" CssClass="fi-ChkSelectField">
                                        </asp:CheckBoxList>
                                    </div>
                                </fieldset>
                            </div>

                            <div class="col-xs-12 col-sm-2">
                                <fieldset class="scheduler-border">
                                    <legend class="scheduler-border">Order By</legend>
                                    <div class="internaldeduct-checklist ">
                                        <asp:CheckBoxList runat="server" ID="chkOrderBy" onclick="return Order_By();" RepeatColumns="1">
                                        </asp:CheckBoxList>
                                    </div>
                                </fieldset>
                            </div>

                            <div class="col-xs-12 col-sm-4">
                                <fieldset class="scheduler-border">
                                    <legend class="scheduler-border">Filter Field</legend>
                                    <div class="internaldeduct-checklist ">
                                        <asp:CheckBoxList runat="server" OnSelectedIndexChanged="chkFilterField_SelectedIndexChanged" AutoPostBack="true" RepeatColumns="2" ID="chkFilterField">
                                        </asp:CheckBoxList>
                                    </div>
                                </fieldset>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-xs-12 col-sm-12">
                                <fieldset class="scheduler-border" style="padding-top: 15px">
                                    <legend class="scheduler-border hidden">&nbsp;</legend>
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-6">

                                            <div class="form-group" id="divDoj" runat="server" visible="false">
                                                <label runat="server" class="col-xs-12 col-sm-4 control-label">Date Of Join</label>
                                                <div class="col-xs-12 col-sm-4 date-picker-icon">
                                                    <asp:TextBox runat="server" CssClass="datepicker form-control form-control-xs date-picker-icon" ID="txtDateOfJoin" placeholder="DD/MM/YYYY" />
                                                </div>
                                                <div class="col-xs-12 col-sm-4">
                                                    <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rbDateOfJoin" CssClass="check-list-normal" Style="margin-top: 8px">
                                                        <asp:ListItem Value="0" Text="Before" Selected="True" />
                                                        <asp:ListItem Value="1" Text="After" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>

                                            <div class="form-group" id="divDor" runat="server" visible="false">
                                                <label runat="server" class="col-xs-12 col-sm-4 control-label">Retirement Date</label>
                                                <div class="col-xs-12 col-sm-4 date-picker-icon">
                                                    <asp:TextBox runat="server" CssClass="datepicker form-control form-control-xs date-picker-icon" ID="txtDateOfRetir" placeholder="DD/MM/YYYY" />
                                                </div>
                                                <div class="col-xs-12 col-sm-4">
                                                    <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rbDateOfRetir" CssClass="check-list-normal" Style="margin-top: 8px">
                                                        <asp:ListItem Value="0" Text="Before" Selected="True" />
                                                        <asp:ListItem Value="1" Text="After" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>

                                            <div class="form-group" runat="server" visible="false">
                                                <label id="Label1" runat="server" class="col-xs-12 col-sm-3 control-label">Suspend Date From</label>
                                                <div class="col-xs-12 col-sm-4 date-picker-icon">
                                                    <asp:TextBox runat="server" CssClass="datepicker form-control form-control-xs date-picker-icon" ID="txtSuspendDateFrom" placeholder="DD/MM/YYYY" />
                                                </div>
                                                <div class="col-xs-12 col-sm-1">
                                                    <label id="Label2" runat="server" class="col-xs-12 col-sm-3 control-label">To</label>
                                                </div>
                                                <div class="col-xs-12 col-sm-4">
                                                    <asp:TextBox runat="server" CssClass="datepicker form-control form-control-xs date-picker-icon" ID="txttxtSuspendDateTo" placeholder="DD/MM/YYYY" />
                                                </div>
                                            </div>

                                            <div class="form-group" id="divEmpNo" runat="server" visible="false">
                                                <label id="Label3" runat="server" class="col-xs-12 col-sm-3 control-label">Emp. No. From</label>
                                                <div class="col-xs-12 col-sm-3">
                                                    <asp:TextBox runat="server" CssClass="form-control form-control-xs" ID="txtEmpNoFrom" placeholder="Emp. From" OnTextChanged="txtEmpNoFrom_TextChanged" AutoPostBack="true" />
                                                </div>

                                                <label id="Label4" runat="server" class="col-xs-12 col-sm-3 control-label">Emp. No. To</label>
                                                <div class="col-xs-12 col-sm-3">
                                                    <asp:TextBox runat="server" CssClass="form-control form-control-xs" ID="txtEmpNoTo" placeholder="Emp. To" />
                                                </div>

                                            </div>


                                            <div class="form-group" id="divGender" runat="server" visible="false">
                                                <asp:CheckBoxList ID="chkGender" runat="server" CssClass="check-list-normal gender-chklist" DataTextField="language" OnSelectedIndexChanged="chkGender_SelectedIndexChanged" AutoPostBack="true" DataValueField="language" RepeatColumns="1">
                                                    <asp:ListItem Value="0" Selected="True">Both</asp:ListItem>
                                                    <asp:ListItem Value="1">Male</asp:ListItem>
                                                    <asp:ListItem Value="2">Female</asp:ListItem>
                                                </asp:CheckBoxList>
                                            </div>


                                        </div>

                                    </div>
                                </fieldset>
                            </div>
                        </div>
                        <div class="row">

                            <script>
                                $(document).ready(function () {
                                    $(".fi-chkAllClass input").click(function () {
                                        if ($(this).is(":checked")) {
                                            $(".fi-ChkClass input").prop('checked', true);
                                        } else {
                                            $(".fi-ChkClass input").prop('checked', false);
                                        }
                                    });

                                    $(".fi-ChkClass input").click(function () {
                                        var cbcheked = $(".fi-ChkClass input:checked").length;
                                        var cbblank = $(".fi-ChkClass input").length;

                                        if (cbcheked < cbblank) {
                                            if ($(".fi-chkAllClass input").is(":checked")) {
                                                $(".fi-chkAllClass input").prop('checked', false);
                                            }
                                        }
                                        if (cbcheked == cbblank) {
                                            $(".fi-chkAllClass input").prop('checked', true);
                                        }
                                    });
                                });
                            </script>
                            <div class="col-xs-12 col-sm-3" id="divClass" runat="server" visible="false">
                                <fieldset class="scheduler-border">
                                    <legend class="scheduler-border">Class</legend>
                                    <div class="internaldeduct-checklist ">
                                        <asp:CheckBox ID="chkAllClass" Text="Select All" runat="server" CssClass="fi-chkAllClass" />
                                        <asp:CheckBoxList runat="server" RepeatColumns="1" ID="ChkClass" CssClass="fi-ChkClass">
                                        </asp:CheckBoxList>
                                    </div>
                                </fieldset>
                            </div>

                            <div class="col-xs-12 col-sm-3" id="divDesignation" runat="server" visible="false">
                                <fieldset class="scheduler-border">
                                    <legend class="scheduler-border">Designation</legend>
                                    <div class="internaldeduct-checklist ">
                                        <asp:CheckBox ID="chkAllDesgination" Text="Select All" runat="server" CssClass="fi-chkAllDesgination" />
                                        <asp:CheckBoxList runat="server" ID="ChkDesignation" RepeatColumns="1" CssClass="fi-ChkDesignation">
                                        </asp:CheckBoxList>
                                    </div>
                                </fieldset>
                            </div>


                            <script>
                                $(document).ready(function () {
                                    $(".fi-chkAllGrade input").click(function () {
                                        if ($(this).is(":checked")) {
                                            $(".fi-ChkGrad input").prop('checked', true);
                                        } else {
                                            $(".fi-ChkGrad input").prop('checked', false);
                                        }
                                    });

                                    $(".fi-ChkGrad input").click(function () {
                                        var cbcheked = $(".fi-ChkGrad input:checked").length;
                                        var cbblank = $(".fi-ChkGrad input").length;

                                        if (cbcheked < cbblank) {
                                            if ($(".fi-chkAllGrade input").is(":checked")) {
                                                $(".fi-chkAllGrade input").prop('checked', false);
                                            }
                                        }
                                        if (cbcheked == cbblank) {
                                            $(".fi-chkAllGrade input").prop('checked', true);
                                        }
                                    });
                                });
                            </script>
                            <div class="col-xs-12 col-sm-3" id="divGrade" runat="server" visible="false">
                                <fieldset class="scheduler-border">
                                    <legend class="scheduler-border">Grade</legend>
                                    <div class="internaldeduct-checklist ">
                                        <asp:CheckBox Text="Select All" runat="server" ID="chkAllGrade" CssClass="fi-chkAllGrade" />
                                        <asp:CheckBoxList runat="server" RepeatColumns="1" ID="ChkGrad" CssClass="fi-ChkGrad">
                                        </asp:CheckBoxList>
                                    </div>
                                </fieldset>
                            </div>
                            <script>
                                $(document).ready(function () {
                                    $(".fi-ChkAllDepartment input").click(function () {
                                        if ($(this).is(":checked")) {
                                            $(".fi-ChkDepartment input").prop('checked', true);
                                        } else {
                                            $(".fi-ChkDepartment input").prop('checked', false);
                                        }
                                    });

                                    $(".fi-ChkDepartment input").click(function () {
                                        var cbcheked = $(".fi-ChkDepartment input:checked").length;
                                        var cbblank = $(".fi-ChkDepartment input").length;

                                        if (cbcheked < cbblank) {
                                            if ($(".fi-ChkAllDepartment input").is(":checked")) {
                                                $(".fi-ChkAllDepartment input").prop('checked', false);
                                            }
                                        }
                                        if (cbcheked == cbblank) {
                                            $(".fi-ChkAllDepartment input").prop('checked', true);
                                        }
                                    });
                                });
                            </script>
                            <div class="col-xs-12 col-sm-3" id="divDepartment" runat="server" visible="false">
                                <fieldset class="scheduler-border">
                                    <legend class="scheduler-border">Department</legend>
                                    <div class="internaldeduct-checklist ">
                                        <asp:CheckBox Text="Select All" runat="server" ID="ChkAllDepartment" CssClass="fi-ChkAllDepartment" />
                                        <asp:CheckBoxList runat="server" ID="ChkDepartment" RepeatColumns="1" CssClass="fi-ChkDepartment" />
                                    </div>
                                </fieldset>
                            </div>

                            <script>
                                $(document).ready(function () {
                                    $(".fi-ChkAllEmpType input").click(function () {
                                        if ($(this).is(":checked")) {
                                            $(".fi-chkEmpType input").prop('checked', true);
                                        } else {
                                            $(".fi-chkEmpType input").prop('checked', false);
                                        }
                                    });

                                    $(".fi-chkEmpType input").click(function () {
                                        var cbcheked = $(".fi-chkEmpType input:checked").length;
                                        var cbblank = $(".fi-chkEmpType input").length;

                                        if (cbcheked < cbblank) {
                                            if ($(".fi-ChkAllEmpType input").is(":checked")) {
                                                $(".fi-ChkAllEmpType input").prop('checked', false);
                                            }
                                        }
                                        if (cbcheked == cbblank) {
                                            $(".fi-ChkAllEmpType input").prop('checked', true);
                                        }
                                    });
                                });
                            </script>
                            <div class="col-xs-12 col-sm-3" id="divEmpType" runat="server" visible="false">
                                <fieldset class="scheduler-border">
                                    <legend class="scheduler-border">Emp Type</legend>
                                    <div class="internaldeduct-checklist ">
                                        <asp:CheckBox Text="Select All" runat="server" ID="ChkAllEmpType" CssClass="fi-ChkAllEmpType" />
                                        <asp:CheckBoxList runat="server" ID="chkEmpType" CssClass="fi-chkEmpType">
                                        </asp:CheckBoxList>
                                    </div>
                                </fieldset>
                            </div>
                        </div>

                    </div>
                    <div class="panel-footer text-right">
                        <asp:Label ID="lblMsg" runat="server" />
                        <asp:LinkButton CssClass="btn btn-success" ID="btnSearch" OnClick="btnSearch_Click" runat="server"><i class="fa r fa-search"></i> Search</asp:LinkButton>
                        <asp:LinkButton CssClass="btn btn-warning" runat="server" ID="btnClear" OnClick="btnClear_Click"><i class="fa r fa-refresh"></i> Clear</asp:LinkButton>
                        <asp:LinkButton CssClass="btn btn-danger" ID="btnExit" PostBackUrl="~/Salary/Dashboard.aspx" runat="server"><i class="fa r fa-close"></i> Exit</asp:LinkButton>
                    </div>

                    <script>
                        function Close() {
                            $('#processed-modal').modal('hide');
                            $('.modal-backdrop').removeClass('modal-backdrop');
                        }
                    </script>
                    <%--processed Popup click on Confirom Button Yes  *Start*--%>
                    <div id="processed-modal" class="modal pos-rel" role="dialog" aria-labelledby="msgModalLabel" data-keyboard="false" data-backdrop="static">
                        >
                        <div class="modal-dialog modal-dialog-lg" style="width: 100%; margin: 27px auto; max-width: 1211px;">
                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header" style="background: #3c8dbc; color: #fff;">
                                    <b>Employee Information  </b>
                                    <button type="button" class="close red" data-dismiss="modal">&times;</button>
                                </div>
                                <div class="modal-body" style="padding: 0; padding-top: 5px">
                                    <div class="row">
                                        <div class="col-sm-12 col-xs-12">
                                            <div style="max-height: 476px; overflow: scroll">
                                                <asp:GridView ID="GvFilterInformation" ShowHeader="True" AutoGenerateColumns="true" EmptyDataText="No records Found" runat="server" CssClass="table table-bordered table-select-query-filter table-select-query-filter-sm">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sr. No.">
                                                            <ItemTemplate>
                                                                <%#Container.DataItemIndex+1%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer text-center" style="padding: 7px; text-align: center">
                                    <asp:LinkButton CssClass="btn btn-info" Visible="false" ID="btndownload" OnClientClick="return  Close();" OnClick="btndownload_Click" runat="server"><i class="fa r fa-download"></i> Download</asp:LinkButton>
                                    <input type="button" class="btn btn-danger" value="Close" data-dismiss="modal" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--processed Popup click on Confirom Button Yes  *End*--%>
                </div>
            </div>
        </div>
    </div>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

