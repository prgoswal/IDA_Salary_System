<%@ Page Title="" Language="C#" MasterPageFile="~/Salary/SalaryMaster.master" AutoEventWireup="true" CodeFile="Proc_FrmSalaryProcessing.aspx.cs" Inherits="TransactionForm_Proc_FrmSalaryProcessing" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        function LoadAllScript() {
            LoadBasic();
        }

    </script>

    <script>
        function hideConfirm() {
            $('#confirm-modal').modal('hide');
            return
        } function hideProcess() {
            $('#processed-modal').modal('hide');
            return
        }
        function LotFun() {
            if ($('#<%=ddlSelectType.ClientID%>').val() == '4') {
                if ($('#<%=txtFromLot.ClientID%>').val() != "") {
                    var From = $('#<%=txtFromLot.ClientID%>').val();
                    $('#<%=txtToLot.ClientID%>').val(From);
                    $('#<%=btnSave.ClientID%>').focus();

                    $('#<%=lblMsg.ClientID%>').html('');
                    $('#<%=lblMsg.ClientID%>').removeClass('alertMsg failed');
                }
                else {
                    $('#<%=txtToLot.ClientID%>').val('');
                }
            }
        }

        function EmployeeFun() {
            if ($('#<%=ddlSelectType.ClientID%>').val() == '5') {
                if ($('#<%=txtFromEmp.ClientID%>').val() != "") {
                    var From = $('#<%=txtFromEmp.ClientID%>').val();
                    $('#<%=txtToEmp.ClientID%>').val(From);
                    $('#<%=btnSave.ClientID%>').focus();
                    $('#<%=lblMsg.ClientID%>').html('');
                    $('#<%=lblMsg.ClientID%>').removeClass('alertMsg failed');
                }
                else {
                    $('#<%=txtToEmp.ClientID%>').val('');
                }
            }
        }


        function clear() {
            $('#<%=ddlSelectType.ClientID%>').css('border-color', 'lightgray');
            $('#<%=ddlDepartment.ClientID%>').css('border-color', 'lightgray');
            $('#<%=txtFromLot.ClientID%>').css('border-color', 'lightgray');
            $('#<%=txtToLot.ClientID%>').css('border-color', 'lightgray');
            $('#<%=txtFromEmp.ClientID%>').css('border-color', 'lightgray');
            $('#<%=txtToEmp.ClientID%>').css('border-color', 'lightgray');
            $('#<%=ddlClass.ClientID%>').css('border-color', 'lightgray');
            $('#<%=ddlEmpType.ClientID%>').css('border-color', 'lightgray');
            $('#<%=lblMsg.ClientID%>').html('');
            $('#<%=lblMsg.ClientID%>').removeClass('alertMsg failed');

        }
    </script>

    <script type="text/javascript">

        function confirmYesNo1() {
            clear();
            if ($('#<%=ddlSelectType.ClientID%>').val() == '0') {
                $('#<%=lblMsg.ClientID%>').addClass('alertMsg failed');
                $('#<%=lblMsg.ClientID%>').html('Please Select Type');
                $('#<%=lblMsg.ClientID%>').show();
                $('#<%=ddlSelectType.ClientID%>').css('border-color', 'red');
                $('#<%=ddlSelectType.ClientID%>').focus();
                return false;
            }
            else if ($('#<%=ddlSelectType.ClientID%>').val() == '1') {
                $('#confirm-modal').modal('show');
                return false;
            }

            else if ($('#<%=ddlSelectType.ClientID%>').val() == '3') {
                if ($('#<%=ddlDepartment.ClientID%>').val() == '0') {
                    $('#<%=lblMsg.ClientID%>').addClass('alertMsg failed');
                    $('#<%=lblMsg.ClientID%>').html('Please Select Department');
                    $('#<%=lblMsg.ClientID%>').show();
                    $('#<%=ddlDepartment.ClientID%>').css('border-color', 'red');
                    $('#<%=ddlDepartment.ClientID%>').focus();
                    return false;
                }
                else {
                    $('#confirm-modal').modal('show');
                    return false;
                }
            }

            else if ($('#<%=ddlSelectType.ClientID%>').val() == '4') {
                if ($('#<%=txtFromLot.ClientID%>').val() == "" || $('#<%=txtToLot.ClientID%>').val() == "") {

                    $('#<%=lblMsg.ClientID%>').addClass('alertMsg failed');
                    $('#<%=lblMsg.ClientID%>').html('Please Enter Lot From and Lot To ');
                    $('#<%=lblMsg.ClientID%>').show();
                    $('#<%=txtFromLot.ClientID%>').css('border-color', 'red');
                    $('#<%=txtFromLot.ClientID%>').focus();
                    $('#<%=txtToLot.ClientID%>').css('border-color', 'red');

                    return false;
                }
                else {
                    $('#<%=txtFromLot.ClientID%>').css('border-color', 'lightgray');
                    $('#<%=txtToLot.ClientID%>').css('border-color', 'lightgray');
                    $('#confirm-modal').modal('show');
                    return false;
                }
            }

            else if ($('#<%=ddlSelectType.ClientID%>').val() == '5') {
                if ($('#<%=txtFromEmp.ClientID%>').val() == "" || $('#<%=txtFromLot.ClientID%>').val() == "") {

                    $('#<%=lblMsg.ClientID%>').addClass('alertMsg failed');
                    $('#<%=lblMsg.ClientID%>').html('Please Enter Emp From and Emp To ');
                    $('#<%=lblMsg.ClientID%>').show();
                    $('#<%=txtFromEmp.ClientID%>').css('border-color', 'red');
                    $('#<%=txtFromEmp.ClientID%>').focus();
                    $('#<%=txtFromLot.ClientID%>').css('border-color', 'red');

                    return false;
                }
                else {
                    $('#<%=txtFromEmp.ClientID%>').css('border-color', 'lightgray');
                    $('#<%=txtFromLot.ClientID%>').css('border-color', 'lightgray');
                    $('#confirm-modal').modal('show');
                    return false;
                }
            }
            else if ($('#<%=ddlSelectType.ClientID%>').val() == '6') {
                if ($('#<%=ddlClass.ClientID%>').val() == '0') {
                    $('#<%=lblMsg.ClientID%>').addClass('alertMsg failed');
                    $('#<%=lblMsg.ClientID%>').html('Please Select Class');
                    $('#<%=lblMsg.ClientID%>').show();
                    $('#<%=ddlClass.ClientID%>').css('border-color', 'red');
                    $('#<%=ddlClass.ClientID%>').focus();
                    return false;
                }
                else {

                    $('#confirm-modal').modal('show');
                    return false;
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
            <div class="container">
                <%--Confirom Popup click on processing Button *Start*--%>
                <div id="confirm-modal" class="modal pos-rel" role="dialog">
                    <div class="modal-dialog modal-dialog-lg " style="margin-top: 100px">
                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header" style="background: #3c8dbc; color: #fff;">
                                <b>Confirmation</b>
                                <button type="button" class="close red" data-dismiss="modal">&times;</button>
                            </div>
                            <div class="modal-body">
                                Do You Wants To Processed Salary ?                   
                            </div>
                            <div class="modal-footer">
                                <asp:Button Text="Yes" runat="server" ID="btnPopYes" CssClass="btn btn-success modal-del-opener" OnClick="btnPopYes_Click" OnClientClick="return hideConfirm()" />
                                <input type="button" class="btn btn-danger" value="No" data-dismiss="modal" />
                            </div>
                        </div>
                    </div>
                </div>
                <%--Confirom Popup click on processing Button *End*--%>

                <%--processed Popup click on Confirom Button Yes  *Start*--%>
                <div id="processed-modal" class="modal pos-rel" role="dialog">
                    <div class="modal-dialog modal-dialog-lg" style="margin-top: 100px">
                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header" style="background: #3c8dbc; color: #fff;">
                                <b>Confirmation</b>
                                <button type="button" class="close red" data-dismiss="modal">&times;</button>
                            </div>
                            <div class="modal-body">
                                Accounts Control Already Imported ( <span style="color: red; font-weight: bold">Do You Wants To Processed Salary</span> )          
                            </div>
                            <div class="modal-footer">
                                <asp:Button Text="Yes" runat="server" ID="Button1" CssClass="btn btn-success modal-del-opener" OnClick="btnSalProcYes_Click" OnClientClick="return hideProcess()" />
                                <input type="button" class="btn btn-danger" value="No" data-dismiss="modal" />
                            </div>
                        </div>
                    </div>
                </div>
                <%--processed Popup click on Confirom Button Yes  *End*--%>

                <div class="col-sm-6 col-sm-offset-3" style="margin-top: 20px;">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="text-center">SALARY PROCESSING</h4>
                        </div>
                        <div class="panel-body form-horizontal">

                            <div class="row">
                                <div class="col-sm-12 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-xs-3">Emp Type<i class="text-danger"> *</i></label><div class="col-sm-9">
                                            <asp:DropDownList runat="server" CssClass="form-control form-control-xs col-sm-9" ID="ddlEmpType"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-sm-12 col-xs-12">
                                    <div class="form-group">
                                        <label class="col-xs-3">Select Type<i class="text-danger"> *</i></label><div class="col-sm-9">
                                            <asp:DropDownList runat="server" CssClass="form-control form-control-xs col-sm-9" ID="ddlSelectType" OnSelectedIndexChanged="ddlSelectType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>



                            <asp:Panel runat="server" ID="pnlDepartment" Visible="false">
                                <div class="row">
                                    <div class="col-sm-12 col-xs-12">
                                        <div class="form-group">
                                            <label class="col-xs-3">Department<i class="text-danger"> *</i></label><div class="col-sm-9">
                                                <asp:DropDownList runat="server" CssClass="form-control form-control-xs col-sm-9" ID="ddlDepartment"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>

                            <asp:Panel runat="server" ID="pnlClass" Visible="false">
                                <div class="row">
                                    <div class="col-sm-12 col-xs-12">
                                        <div class="form-group">
                                            <label class="col-xs-3">Class<i class="text-danger"> *</i></label><div class="col-sm-9">
                                                <asp:DropDownList runat="server" CssClass="form-control form-control-xs col-sm-9" ID="ddlClass"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>

                            <asp:Panel runat="server" ID="pnlLot" Visible="false">
                                <div class="form-group">
                                    <div class="col-sm-12 col-xs-12 mtb">
                                        <div class="row">
                                            <label class="col-sm-3 col-xs-12 ">Lot From/To <i class="text-danger">*</i></label>
                                            <div class="col-sm-9">
                                                <div class="row">
                                                    <div class="col-sm-6">
                                                        <asp:TextBox runat="server" ID="txtFromLot" onchange="return LotFun();" MaxLength="10" CssClass="form-control form-control-xs numberonly" placeholder="From" />
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <asp:TextBox runat="server" ID="txtToLot" MaxLength="10" CssClass="form-control form-control-xs numberonly" placeholder="To" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>

                            <asp:Panel runat="server" ID="pnlEmployee" Visible="false">
                                <div class="form-group">
                                    <div class="col-sm-12 col-xs-12 mtb">
                                        <div class="row">
                                            <label class="col-sm-3 col-xs-12 ">Emp From/To <i class="text-danger">*</i></label>
                                            <div class="col-sm-9">
                                                <div class="row">
                                                    <div class="col-sm-6">
                                                        <asp:TextBox runat="server" ID="txtFromEmp" MaxLength="10" onchange="return EmployeeFun();" CssClass="form-control form-control-xs numberonly" placeholder="From" />
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <asp:TextBox runat="server" ID="txtToEmp" MaxLength="10" CssClass="form-control form-control-xs numberonly" placeholder="To" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>

                        </div>
                        <div class="panel-footer">
                            <div class="row">
                                <div class="col-xs-12 col-sm-12 text-right">
                                    <asp:Label ID="lblMsg" CssClass="text-danger" runat="server" />
                                    <asp:LinkButton CssClass="btn btn-success modal-open-confrm" runat="server" Text="Processing" ID="btnSave" OnClientClick="return confirmYesNo1()"><i class="fa r fa-refresh"></i> Processing</asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-danger" PostBackUrl="~/Salary/Dashboard.aspx" runat="server" ID="btnExit"><i class="fa r fa-close"></i> Exit</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

