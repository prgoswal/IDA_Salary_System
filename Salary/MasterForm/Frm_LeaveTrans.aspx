<%@ Page Title="" Language="C#" MasterPageFile="~/Salary/SalaryMaster.master" AutoEventWireup="true" CodeFile="Frm_LeaveTrans.aspx.cs" Inherits="MasterForm_Frm_LeaveTrans" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function LoadAllScript() {
            LoadBasic();
        }
    </script>

    <%--    <script type="text/javascript">
        function confirm() {
            $('#myModal').modal("show");
            //$('#btnsuccess').click(function () {
            //    window.location = event;
            //});
            return false;
        }
    </script>--%>


    <script type="text/javascript">
        function Validation() {
            if ($('#ContentPlaceHolder1_txtEmployeeNo').val().Trim() == '') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed ');
                $('#ContentPlaceHolder1_lblMsg').html(' Please Enter Employee No');
                $('#ContentPlaceHolder1_txtEmployeeNo').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtEmployeeNo').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_txtEmployeeNo').css('border-color', 'lightgray');
            }
            if ($('#ContentPlaceHolder1_ddlTypeofLeave').val() == '0') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed');
                $('#ContentPlaceHolder1_lblMsg').html(' Please Select Type of Leave');
                $('#ContentPlaceHolder1_ddlTypeofLeave').css('border-color', 'red');
                $('#ContentPlaceHolder1_ddlTypeofLeave').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_ddlTypeofLeave').css('border-color', 'lightgray');
            }
        }

        function UpdateValidation() {
            if ($('#ContentPlaceHolder1_txtEmployeeNo').val().Trim() == '') {
                $('#ContentPlaceHolder1_lblMsg').addClass('alertMsg failed ');
                $('#ContentPlaceHolder1_lblMsg').html(' Please Enter Employee No');
                $('#ContentPlaceHolder1_txtEmployeeNo').css('border-color', 'red');
                $('#ContentPlaceHolder1_txtEmployeeNo').focus();
                return false;
            }
            else {
                $('#ContentPlaceHolder1_txtEmployeeNo').css('border-color', 'lightgray');
            }
        }
    </script>
    <script type="text/Javascript">
        function checkDec(el) {
            var splt = el.split('.');
            if (splt[1]) {
                if (splt[1] != 5) {
                    $('#<%=txtNoOfDays.ClientID%>').val(splt[0]);
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
            <div class="col-xs-12 col-sm-8 col-sm-offset-2 mrgntp10 mt10">
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
                        font-size: 11px;
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
                <div class="panel panel-primary ">
                    <div class="panel-heading" style="text-align: center">LEAVE TRANSACTION </div>
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
                                                    <label class="col-sm-3 col-xs-12">Type of Leave <i class="Star">*</i></label>
                                                    <div class="col-sm-9">
                                                        <asp:DropDownList runat="server" ID="ddlTypeofLeave" OnSelectedIndexChanged="ddlTypeofLeave_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control form-control-xs">
                                                            <asp:ListItem Text="text1" />
                                                            <asp:ListItem Text="text2" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" id="DivDate" runat="server">
                                            <div class="col-sm-12 col-xs-12 mtb">
                                                <div class="form-group">
                                                    <label class="col-sm-3 col-xs-12">Date</label>
                                                    <div class="col-sm-9">
                                                        <div class="row">
                                                            <div class="col-sm-6 date-picker-icon">
                                                                <asp:TextBox runat="server" ID="txtFromDate" MaxLength="10" Style='text-transform: uppercase;' CssClass="datepicker form-control form-control-xs date-picker-icon" placeholder="From Date" />
                                                            </div>

                                                            <div class="col-sm-6 date-picker-icon">
                                                                <asp:TextBox runat="server" ID="txtToDate" MaxLength="10" Style='text-transform: uppercase;' CssClass="datepickerForExpiryDate form-control form-control-xs date-picker-icon" placeholder="To Date" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12 col-xs-12 mtb">
                                                <div class="form-group">
                                                    <label class="col-sm-3 col-xs-12">No. Of Days </label>
                                                    <div class="col-sm-9">
                                                        <asp:TextBox runat="server" ID="txtNoOfDays" MaxLength="5" placeholder="No. Of Days" Style='text-transform: uppercase' onkeyup="checkDec(this.value);" CssClass="form-control form-control-xs NoOfDays" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12 col-xs-12 mtb">
                                                <div class="form-group">
                                                    <label class="col-sm-3 col-xs-12">Narration</label>
                                                    <div class="col-sm-9">
                                                        <asp:TextBox ID="txtNarration" runat="server" MaxLength="70" class="msgbox form-control" TextMode="MultiLine" placeholder="Enter Narration"></asp:TextBox>
                                                        <span style="float: right; font-size: 18px; display: none" id="textarea_feedback"></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-sm-12 col-xs-12 mtb">
                                                <div class="form-group">
                                                    <label class="col-sm-3 col-xs-12">&nbsp;</label>
                                                    <div class="col-sm-9">
                                                        <asp:CheckBox Text="Show Suspend Case" runat="server" ID="chkSuspendCase" OnCheckedChanged="chkSuspendCase_CheckedChanged" AutoPostBack="true" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <script>
                                            function Close() {
                                                $('#<%=chkSuspendCase.ClientID%>').prop('checked', false);
                                                $('#myModal').modal('hide');
                                                $('.modal-backdrop').removeClass('modal-backdrop');
                                            }


                                        </script>
                                        <%-- <script type="text/javascript">
                                             function validate(ctrl) {
                                                 debugger;
                                                 var grdRow = ctrl.parentNode.parentNode;
                                                 var grdControl = grdRow.getElementsByTagName("input");

                                                 // LOOP THROUGH EACH INPUT CONTROL IN THE GRIDVIEW.
                                                 for (var i = 0; i < grdControl.length; i++) {
                                                     if (grdControl[i].type = 'text') {
                                                         if (grdControl[i].value === "") {
                                                             alert(grdControl[i].title + ' is required.');
                                                             return false;
                                                         }
                                                     }
                                                 }
                                             }

                                        </script>--%>
                                      
                                        <div class="modal fade in" id="myModal" tabindex="-1" role="dialog" aria-labelledby="msgModalLabel" data-keyboard="false" data-backdrop="static">
                                            <div class="modal-dialog" role="document" style="position: absolute; top: 50%; left: 50%; transform: translate(-50%,-50%); margin: 0; width: 790px">
                                                <div class="modal-content">
                                                    <div class="modal-header" style="background-color: steelblue; color: white; padding: 10px">
                                                        <%--<button type="button" class="close" data-dismiss="modal" style="color: #fff; background: red; border-radius: 100%; height: 20px; font-size: 14px; width: 20px; margin-top: 2px;">
                                                            &times;</button>--%>
                                                        <asp:LinkButton ID="lnkBtnclose" OnClientClick="return Close();" class="close" Style="color: #fff; background: red; border-radius: 100%; height: 20px; font-size: 14px; padding: 4px; width: 20px; margin-top: 2px;" runat="server">&times;</asp:LinkButton>
                                                        <h4 class="modal-title">All Suspend Case<span>
                                                            <img style="width: 159px; position: absolute; top: 19px; display: none; left: 127px; z-index: 999; border-radius: 20px 20px" alt="downloading..." />
                                                        </span></h4>
                                                    </div>
                                                    <div class="modal-body">
                                                        <div class="panel-body form-horizontal" id="divSusCase" runat="server">
                                                            <div class="brd0r">
                                                                <div class="row">
                                                                    <div class="col-sm-12">
                                                                        <div class="table-header-fixer" style="padding-right: 17px">
                                                                            <table class="table table-bordered f12 pd-sm br-wrd">
                                                                                <tr class="tbl_bg">
                                                                                    <%--  <th style="width: 3%">.</th>--%>
                                                                                    <th style="width: 10%">Emp. No.</th>
                                                                                    <th style="width: 40%">Name</th>
                                                                                    <th style="width: 7%">NoOfLv</th>
                                                                                    <th style="width: 33%">Narration</th>
                                                                                    <th style="width: 10%">Delete</th>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                        <div class="body-fix-table" style="max-height: 400px;">
                                                                            <asp:GridView ID="gvPopupSuspendCase" ShowHeader="False" AutoGenerateColumns="false" EmptyDataText="No records Found" runat="server" CssClass="table table-bordered f12 pd-sm br-wrd">
                                                                                <Columns>
                                                                                    <%-- <asp:TemplateField ItemStyle-Width="3%">
                                                                                        <ItemTemplate>
                                                                                            <asp:CheckBox Text="" runat="server" onclick="CheckOne(this)" ID="chkGridCheckbox" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>--%>

                                                                                    <asp:TemplateField ItemStyle-Width="10%">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblEmpNo1" Text='<%#Eval("Empno") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="40%">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblName" Text='<%#Eval("name") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>

                                                                                    <asp:TemplateField ItemStyle-Width="7%">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblNoOfLv" Text='<%#Eval("NoOfLv") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>


                                                                                    <asp:TemplateField ItemStyle-Width="33%">
                                                                                        <ItemTemplate>
                                                                                            <%--<asp:Label ID="lblNarr" Text='<%#Eval("Narr") %>' Style='text-transform: uppercase' runat="server"></asp:Label>--%>
                                                                                            <asp:TextBox ID="txtNarrationPopup" placeholder="Enter Narration" Style="width: 202px; height: 23px;" runat="server"></asp:TextBox>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>

                                                                                    <asp:TemplateField ItemStyle-Width="10%">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton  ID="BtnSusDelete" OnClick="BtnSusDelete_Click" Text="Delete" Width="100%" CssClass="btn btn-xs btn-danger add_btn" runat="server"></asp:LinkButton>
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
                                                                            <asp:Label Text="" ID="lblPopErrorMsg" runat="server" ForeColor="Red" />
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
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-footer">
                        <div class="row">
                            <div class="col-xs-12 col-sm-12 text-right">
                                <asp:Label ID="lblMsg" runat="server" />
                                <asp:LinkButton CssClass="btn btn-success" ID="btnSave" OnClientClick="return Validation()" OnClick="btnSave_Click" runat="server"><i class="fa r fa-save"></i> Save</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-info" ID="btnUpdate" runat="server" OnClientClick="return UpdateValidation()" OnClick="btnUpdate_Click"><i class="fa r fa-save"></i> Update</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-danger" ID="btnDelete" runat="server" OnClientClick="return UpdateValidation()" OnClick="btnDelete_Click"><i class="fa r fa-close"></i> Delete</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-warning" ID="btnclear" OnClick="btnclear_Click" runat="server"><i class="fa r fa-refresh"></i> Clear</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-danger" ID="btnExit" PostBackUrl="~/Salary/Dashboard.aspx" runat="server"><i class="fa r fa-close"></i> Exit</asp:LinkButton>

                            </div>
                        </div>
                    </div>

                    <div class="panel-body form-horizontal" id="DivTrans" runat="server">
                        <div class="brd0r">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="table-header-fixer" style="padding-right: 17px">
                                        <table class="table table-bordered f12 pd-sm br-wrd">
                                            <tr class="tbl_bg">
                                                <th style="width: 7.5%">Emp. No.</th>
                                                <th style="width: 19%">Name / Father Name</th>
                                                <th style="width: 12%">DesgDesc</th>
                                                <th style="width: 14%">LvDesc</th>
                                                <th style="width: 6%">NoOfLv</th>
                                                <th style="width: 8.5%">FormDate</th>
                                                <th style="width: 6%">ToDate</th>
                                                <th style="width: 13%">Narr</th>
                                                <th style="width: 06%">Edit</th>
                                                <th style="width: 07%">Delete</th>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="body-fix-table" style="max-height: 290px;">
                                        <asp:GridView ID="GvTransaction" ShowHeader="False" AutoGenerateColumns="false" EmptyDataText="No records Found" runat="server" CssClass="table table-bordered f12 pd-sm br-wrd">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="7.5%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmpNo" Text='<%#Eval("Empno") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="19%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" Text='<%#Eval("name") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="12%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDesgDesc" Text='<%#Eval("DesgDesc") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="10%" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLvCd" Text='<%#Eval("LvCd") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField ItemStyle-Width="14%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLvDesc" Text='<%#Eval("LvDesc") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField ItemStyle-Width="6%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNoOfLv" Text='<%#Eval("NoOfLv") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="8.5%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFormDate" Text='<%#Eval("FormDate") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="6%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblToDate" Text='<%#Eval("ToDate") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="13%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNarr" Text='<%#Eval("Narr") %>' Style='text-transform: uppercase' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="06%">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEdit" Text="Edit" Width="100%" OnClick="btnEdit_Click" CssClass="btn btn-xs btn-warning add_btn" runat="server"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField ItemStyle-Width="07%">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btndelete" Text="Delete" Width="100%" OnClick="btndelete_Click" CssClass="btn btn-xs btn-warning add_btn" runat="server"></asp:LinkButton>
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

