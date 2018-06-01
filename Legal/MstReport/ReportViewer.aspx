<%@ Page Title="" Language="C#" MasterPageFile="~/Legal/LegalMaster.master" AutoEventWireup="true" CodeFile="ReportViewer.aspx.cs" Inherits="Legal_MstReport_ReportViewer" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">   
    <script type="text/javascript">
        function PrintApplicationSuccess() {
            var panel = document.getElementById("Object1");
            var printWindow = window.open('', '', 'height=700,width=800');
            printWindow.document.write('</head><body>');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
        function printDocument() {
            $("#<%=frmPrint.ClientID%>").get(0).contentWindow.print();
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

        .cls {
            background-color: #3c8dbc;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="mrgntp10 mt10" style="width: 100%; margin-left: auto; margin-right: auto; max-width: 1060px">
        <div class="panel panel-primary">
            <div class="panel-heading" id="lblHeading" style='text-transform: uppercase' runat="server"></div>
            <div class="panel-body form-horizontal" style="padding: 0">
                <div class="row">
                    <div class="col-xs-12 report_page">
                        <div class="panel panel-default" style="margin-bottom: -2px; border: 0; padding: 2px">
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:HiddenField ID="hfprev" runat="server" />
                            <div class="panel-table table-black " >
                                <asp:Panel runat="server" ID="pnlPrintDraftPatta" Visible="false" >
                                    <rsweb:ReportViewer Height="430px" ShowParameterPrompts="false"  Width="100%" ID="ReportViewer1" runat="server"></rsweb:ReportViewer>
                                </asp:Panel>
                            </div>
                            <iframe id="frmPrint" name="IframeName" runat="server" style="display: none"></iframe>
                            <div id="divrpt" runat="server"></div>
                            <div class="panel-footer text-center">
                                <asp:Button Text="&#xf02f; Print" ID="print" runat="server" CssClass="font-awesome-font btn btn-info fa fa-print" aria-hidden="true" OnClick="print_Click" />
                                <asp:Button Text="&#xf0a8; Back" ID="btnBack" runat="server" OnClick="btnBack_Click" OnClientClick="JavaScript:window.history.back(1); return false;" CssClass="font-awesome-font btn btn-danger fa fa-arrow-left" aria-hidden="true" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

