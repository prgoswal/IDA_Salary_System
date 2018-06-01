<%@ Page Title="" Language="C#" MasterPageFile="~/FrontOffice/MainMaster.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>
<%@ Register  Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Src="~/FrontOffice/UserControl/EntryLevel.ascx" TagName="UserControl" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   
    <title>Dashboard</title>
    <%--<script>
        function Getdate() {
            var today = new Date();
            var dd = today.getDate();
            var mm = today.getMonth() + 1;
            var yyyy = today.getFullYear();
            var date = dd +"-" +mm +"-"+ yyyy;
            alert(date);
        }
        
        $(document).ready(
            function myfunction() {

            });
       
        
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-12">
                <div class="panel panel-default">
                    <div class="panel-body">
                       <%-- <div class="row">
                            <div class="col-xs-12">                              
                                <asp:Label ID="lblka" runat="server" Text="Dashboard"></asp:Label>
                                <asp:Button ID="btndate" runat="server" OnClientClick="Getdate();" Text="date" />
                            </div>
                        </div>--%>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>

