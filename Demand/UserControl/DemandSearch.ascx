<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DemandSearch.ascx.cs" Inherits="Demand_UserControl_DemandSearch" %>
<script>
    function Validate() {
        if ($('#<%=txtSearchRefNo.ClientID%>').val() == "" && ($('#<%=ddlSearchScheme.ClientID%>').val() == "0" || $('#<%=txtSearchPlotNo.ClientID%>').val() == "")) {
            $('#<%=lblmsg.ClientID%>').html("Please Select Reference No. OR Scheme AND PlotNo. ");
            return false;
        }
    }
</script>
<asp:UpdatePanel ID="upd1" runat="server">
    <ContentTemplate>
        <hr />
        <div class="row innr_pnl one">
            <div class="col-sm-4">
                <div class="form-group">
                    <label class="col-xs-12 col-sm-12">
                        Reference&nbsp;No.
                    </label>
                    <div class="col-xs-12 col-sm-12">
                        <asp:TextBox ID="txtSearchRefNo" runat="server" class="form-control" MaxLength="10"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="fte1" runat="server" ValidChars="0123456789" TargetControlID="txtSearchRefNo" />
                        <span class="or-label">OR</span>
                    </div>
                </div>
            </div>

            <div class="col-sm-4">
                <div class="form-group">
                    <label class=" col-xs-12 col-sm-12">
                        Scheme
                    </label>
                    <div class="col-xs-12 col-sm-12">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlSearchScheme">
                            <asp:ListItem>--Select Scheme--</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="form-group">
                    <label class=" col-xs-12 col-sm-12">
                        Plot No.
                    </label>
                    <div class="col-xs-12 col-sm-12 ">
                        <asp:TextBox ID="txtSearchPlotNo" runat="server" class="form-control" MaxLength="30"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="col-sm-12 text-right">

                <div class="col-xs-6 col-sm-6 ">
                    <asp:Label ID="lblmsg" CssClass="errorMsg" ForeColor="Red" runat="server"></asp:Label>
                </div>
                <div class="col-xs-6 col-sm-6  ">
                    <asp:Button ID="btnSearch" Text="Search" runat="server" CssClass="btn btn-success btn-xs btnSave" OnClientClick="return Validate();" OnClick="btnSearch_Click" />
                    <asp:Button ID="Button4" Text="Advance Search" runat="server" ValidationGroup="a" CssClass="btn btn-primary btn-xs btnSave" />
                    <asp:Button ID="btnSearchClear" Text="Clear" runat="server" CssClass="btn btn-default btn-xs btnClear" OnClick="btnSearchClear_Click" />
                </div>
            </div>




        </div>

        <hr />


        <div class="row Search_pnl two">
            <div class="col-sm-4">
                <div class="form-group">
                    <label class="col-xs-12 col-sm-12">
                        Reference&nbsp;No.
                    </label>
                    <div class="col-xs-12 col-sm-12 ">
                        <asp:TextBox ID="txtRefNo" runat="server" MaxLength="10" CssClass="form-control" Enabled="false"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" ValidChars="0123456789" TargetControlID="txtRefNo" />

                    </div>
                </div>
            </div>

            <div class="col-sm-4">
                <div class="form-group">
                    <label class=" col-xs-12 col-sm-12">
                        Service No
                    </label>
                    <div class="col-xs-12 col-sm-12">
                        <asp:TextBox ID="txtServiceNo" runat="server" CssClass="form-control" MaxLength="10" Enabled="false"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="form-group">
                    <label class=" col-xs-12 col-sm-12">
                        Plot No.
                    </label>
                    <div class="col-xs-12 col-sm-12 ">
                        <asp:TextBox ID="txtPlotNo" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="form-group">
                    <label class=" col-xs-12 col-sm-12">
                        Property&nbsp;Holder Name
                    </label>
                    <div class="col-xs-12 col-sm-12 ">
                        <asp:TextBox ID="txtPropPlaceHolder" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="form-group">
                    <label class=" col-xs-12 col-sm-12">
                        Address
                    </label>
                    <div class="col-xs-12 col-sm-12">
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="form-group">
                    <label class=" col-xs-12 col-sm-12">
                        Scheme
                    </label>
                    <div class="col-xs-12 col-sm-12">
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlScheme" Enabled="false">
                            <asp:ListItem>--Select Scheme--</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>

        <hr />



    </ContentTemplate>
</asp:UpdatePanel>
