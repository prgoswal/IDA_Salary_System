<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Module/AdminMaster.master" AutoEventWireup="true" CodeFile="frmMenuTesting.aspx.cs" Inherits="Admin_Module_Forms_frmMenuTesting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-xs-12">

        <div class="panel panel-primary" style="max-width: 1217px; margin: 0 auto; margin-bottom: 15px">
            <div class="panel-heading">
                <div class="pannel-title text-center"><b>Profile / System Selection</b></div>
            </div>
            <div class="panel-body">
                <div class="form-horizontal">

                    <div class="row">
                        <div class="col-xs-12 col-sm-6">
                            <div class="form-group">
                                <label class="control-label col-xs-12 col-sm-4">Profile Name </label>
                                <div class="col-xs-12 col-sm-8">
                                    <asp:DropDownList ID="ddlProfileName" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-6">
                            <div class="form-group">
                                <label class="control-label col-xs-12 col-sm-4">System Name </label>
                                <div class="col-xs-12 col-sm-8">
                                    <div class="input-group">
                                        <asp:DropDownList ID="ddlSystemName" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                                        </asp:DropDownList>
                                        <span class="input-group-btn">
                                            <asp:Button ID="btnGo" Text="Go" CssClass="btn btn-success" runat="server" OnClick="btnGo_Click" />
                                        </span>
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

