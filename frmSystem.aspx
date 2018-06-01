<%@ Page Title="" Language="C#" MasterPageFile="~/CommonMasterPage.master" AutoEventWireup="true" CodeFile="frmSystem.aspx.cs" Inherits="frmSystem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function SalaryValid() {            
            var ddlmonth = document.getElementById("<%=ddlMonthSalary.ClientID %>");
            if (ddlmonth.value == "0") {
                alert("Please Select Month.");
                ddlmonth.focus();
                return false;
            }
        }

    </script>
     <script>
         $(document).ready(function () {
             var wh = parseInt($(window).height() - 172);
             $('.system-page').css('min-height', wh)
         });
         $(window).resize(function () {
             var wh = parseInt($(window).height() - 172);
             $('.system-page').css('min-height', wh)
         });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid form-horizontal system-page" style="padding-top: 35px">
        <div class="row">
            <div class="container">
                <div class="row">
                    <div class="col-xs-12 col-lg-3 col-sm-6" id="PnlSalarySystem" runat="server" visible="false">
                        <div class="panel panel-default change-part hover-shadow">
                            <div class="panel-body before-part">
                                <div class="inner-after">
                                    <div class="row">
                                        <div class="col-xs-12 text-center">
                                            <i class="fa fa-calculator"></i>
                                            <h4>Salary System</h4>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-body after-part">
                                <div class="inner-after">
                                    <div class="row">
                                        <div class="col-xs-12">
                                            <div class="form-group">
                                                <label class="col-xs-12">Select Month</label>
                                                <div class="col-xs-12">
                                                    <asp:DropDownList runat="server" ID="ddlMonthSalary" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-xs-12 text-center">
                                                <asp:Button ID="btnSalarySystem" CssClass="btn btn-success" Text="Continue" runat="Server" OnClientClick="return SalaryValid()" OnClick="btnSalarySystem_Click" />
                                                <button class="btn btn-danger part-close">Cancel</button>
                                            </div>
                                            
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12 col-lg-3 col-sm-6" id="PnlLegalSystem" runat="server" visible="false">
                        <div class="panel panel-default change-part hover-shadow pre" data-href="<%= ResolveUrl("~/Legal/dashboard.aspx")%>">
                            <div class="panel-body before-part">
                                <div class="inner-after">
                                    <div class="row">
                                        <div class="col-xs-12 text-center">
                                            <i class="fa fa-bar-chart"></i>
                                            <h4>Legal System</h4>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12 col-lg-3 col-sm-6" id="PnlEstateSystem" runat="server" visible="false">
                        <div class="panel panel-default change-part hover-shadow pre" data-href="<%= ResolveUrl("~/Estate/dashboard.aspx")%>">
                            <div class="panel-body before-part">
                                <div class="inner-after">
                                    <div class="row">
                                        <div class="col-xs-12 text-center">
                                            <i class="fa fa-calendar"></i>
                                            <h4>EState Managment System</h4>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="col-xs-12 col-lg-3 col-sm-6" id="PnlLeaseSystem" runat="server" visible="false">
                        <div class="panel panel-default change-part hover-shadow pre" data-href="<%= ResolveUrl("~/Lease/dashboard.aspx")%>">
                            <div class="panel-body before-part">
                                <div class="inner-after">
                                    <div class="row">
                                        <div class="col-xs-12 text-center">
                                            <i class="fa fa-gear"></i>
                                            <h4>Lease Managment System</h4>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="col-xs-12 col-lg-3 col-sm-6" id="PnlFrontOfficeSystem" runat="server" visible="false">
                        <div class="panel panel-default change-part hover-shadow pre" data-href="<%= ResolveUrl("~/FrontOffice/dashboard.aspx")%>">
                            <div class="panel-body before-part">
                                <div class="inner-after">
                                    <div class="row">
                                        <div class="col-xs-12 text-center">
                                            <i class="fa fa-calculator"></i>
                                            <h4>Front Office System</h4>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="col-xs-12 col-lg-3 col-sm-6" id="pnlDemandSystem" runat="server" visible="false">
                        <div class="panel panel-default change-part hover-shadow pre" data-href="<%= ResolveUrl("~/Demand/dashboard.aspx")%>">
                            <div class="panel-body before-part">
                                <div class="inner-after">
                                    <div class="row">
                                        <div class="col-xs-12 text-center">
                                            <i class="fa fa-bar-chart"></i>
                                            <h4>Demand-Cash Collection System</h4>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12 col-lg-3 col-sm-6" id="PnlDocumentScanning" runat="server" visible="false">
                        <div class="panel panel-default change-part hover-shadow">
                            <div class="panel-body before-part">
                                <div class="inner-after">
                                    <div class="row">
                                        <div class="col-xs-12 text-center">
                                            <i class="fa fa-bar-chart"></i>
                                            <h4>Document Scanning</h4>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                     <div class="col-xs-12 col-lg-3 col-sm-6" id="Div1" runat="server" visible="true">
                        <div class="panel panel-default change-part hover-shadow pre" data-href="<%= ResolveUrl("~/Admin_Module/Forms/dashboard.aspx")%>">
                            <div class="panel-body before-part">
                                <div class="inner-after">
                                    <div class="row">
                                        <div class="col-xs-12 text-center">
                                            <i class="fa fa-bar-chart"></i>
                                            <h4>Advance Admin Tool</h4>
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
</asp:Content>

