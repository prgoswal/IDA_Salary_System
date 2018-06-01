<%@ Page Title="" Language="C#" MasterPageFile="~/Legal/LegalMaster.master" AutoEventWireup="true" CodeFile="RptMstCaseStage.aspx.cs" Inherits="MstReport_RptMstCaseStage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:ScriptManager ID="scr" runat="server"></asp:ScriptManager>
    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-12">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="row">
                            <div style="text-align:center" class="col-xs-12">
                                <%--<rsweb:ReportViewer Height="550px" ShowParameterPrompts="false" Width="70%" ID="ReportViewer1" runat="server"></rsweb:ReportViewer>--%>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

