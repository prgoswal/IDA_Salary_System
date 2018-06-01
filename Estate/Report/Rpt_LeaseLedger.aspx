<%@ Page Title="" Language="C#" MasterPageFile="~/Estate/MainMaster.master" AutoEventWireup="true" CodeFile="Rpt_LeaseLedger.aspx.cs" Inherits="Estate_Report_Rpt_LeaseLedger" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
  <asp:UpdatePanel ID="updatepnl" runat="server">
        <ContentTemplate>
            <script>
                Sys.Application.add_load(LoadAllScript);
            </script>
            <div class="mrgntp10 mt10 mlr-auto" style="max-width: 770px">
                <div class="panel panel-primary ">
                    <div class="panel-heading" style="text-align: center">Lease Ledger</div>
                    <div class="panel-body form-horizontal">
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="brdr_box">
                                        
                                         <div class="row">
                                                <div class="col-sm-12 col-xs-12">
                                                    <div class="form-group">
                                                        <label class="col-xs-3">Scheme Name<i class="text-danger"> </i></label>
                                                        <div class="col-sm-9">
                                                            <asp:DropDownList runat="server" CssClass="form-control form-control-xs col-sm-9" ID="ddlSchName"></asp:DropDownList>
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
                            <div class="col-xs-12 col-sm-12 text-left">
                                <asp:LinkButton CssClass="btn btn-warning" ID="btnShow"  OnClick="btnShow_Click" runat="server"> Show</asp:LinkButton>
                                <asp:LinkButton CssClass="btn btn-primary" PostBackUrl="~/Estate/Dashboard.aspx"  ID="btnExit" runat="server"></i>Exit</asp:LinkButton>
                                <asp:Label ID="lblMsg" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

