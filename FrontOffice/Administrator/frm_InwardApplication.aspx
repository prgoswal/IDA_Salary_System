<%@ Page Title="" Language="C#" MasterPageFile="~/FrontOffice/MainMaster.master" AutoEventWireup="true" CodeFile="frm_InwardApplication.aspx.cs" Inherits="Administrator_frm_InwardApplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            var checkboxes = $('#<%=chkInward.ClientID %>').find('input:checkbox');
            checkboxes.click(function () {
                var selectedIndex = checkboxes.index($(this));
                var items = $('#<% = chkInward.ClientID %> input:checkbox');
               for (i = 0; i < items.length; i++) {
                   if (i == selectedIndex)
                       items[i].checked = true;
                   else
                       items[i].checked = false;
               }
           });
        });
    </script>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div>
                <div class="col-xs-12 col-sm-6 col-sm-offset-3">
                    <div class="panel panel-primary mt50">
                        <div class="panel-heading">
                            <h3 class="panel-title">Inward / Application</h3>
                        </div>

                        <div class="panel-body form-horizontal scheme-form-group">
                            <div class="form-group">
                                <div class="col-xs-12">
                                    <div class="col-xs-12 col-sm-8">
                                        <%-- <asp:RadioButtonList ID="rblInward" runat="server" CssClass="radio"></asp:RadioButtonList>--%>
                                        <asp:CheckBoxList ID="chkInward" runat="server" CssClass="check"></asp:CheckBoxList>
                                    </div>
                                </div>
                            </div>


                        </div>
                        <div class="panel-footer">
                            <asp:Button ID="btnGO" Text="GO" runat="server" ValidationGroup="a" CssClass="btn btn-success btnSave" OnClick="btnGO_Click" />
                        </div>
                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

