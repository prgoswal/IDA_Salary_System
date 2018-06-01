<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Module/AdminMaster.master" AutoEventWireup="true" CodeFile="frmMenuAssignment.aspx.cs" Inherits="Admin_Module_Forms_frmMenuAssignment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(function () {
            $('td input').change(function () {
                if ($(this).is(':checked')) {
                    $(this).parent('td').css('background', '#ffffee')
                }
                else {
                    $(this).parent('td').css('background', '#fff')
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-xs-12">

        <div class="panel panel-primary" style="max-width: 1217px; margin: 0 auto; margin-bottom: 15px">
            <div class="panel-heading">
                <div class="pannel-title text-center"><b>Profile wise Menu Assignment</b></div>
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
                                            <asp:Button ID="btnSearch" Text="Search" CssClass="btn btn-success" runat="server" OnClick="btnSearch_Click" />
                                        </span>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>



                </div>
            </div>

        </div>
        <div class="panel panel-primary" runat="server" visible="false" id="pnlDetailSection" style="max-width: 1217px; margin: 0 auto">
            <div class="panel-body" style="padding: 0;">
                <div class="row">
                    <style type="text/css">
                        .gv-table {
                            margin-bottom: 0px;
                        }

                            .gv-table th {
                                background: #eee;
                                color: #000;
                            }

                            .gv-table tr th, .gv-table tr td {
                                padding: 2px 4px !important;
                            }

                            .gv-table input, .gv-table label {
                                display: block;
                                float: left;
                                cursor: pointer;
                                font-weight: normal;
                                user-select: none;
                                -webkit-user-select: none;
                                -moz-user-select: none;
                                margin: 0;
                            }

                                .gv-table input:checked + label {
                                    font-weight: bold;
                                }

                            .gv-table input {
                                margin-right: 5px;
                                margin-top: 2px;
                            }

                        .gv-table-main {
                            width: 1200px;
                            margin: 0 auto;
                        }

                            .gv-table-main tr td:nth-child(1) {
                                width: 400px;
                                //background:rgba(255,0,0,0.1);
                            }

                            .gv-table-main tr td:nth-child(2) {
                                width: 800px;
                                padding: 0 !important;
                            }

                        .gv-table-sub-l1 tr td:nth-child(1) {
                            width: 400px;
                            
                        }

                        .gv-table-sub-l1 tr td:nth-child(2) {
                            width: 400px;
                        }

                        .gv-table-sub-l2 tr td:nth-child(1) {
                            width: 400px;
                        }

                        .gv-table-th {
                            width: 1200px;
                            margin: 0 auto;
                        }

                            .gv-table-th th {
                                width: 400px;
                            }
                    </style>
                    <div class="col-xs-12 col-sm-12">
                        <div style="padding-right: 17px;">
                            <table class="table table-bordered gv-table gv-table-th">
                                <tr>
                                    <th>Main Menu</th>
                                    <th>Sub Menu L1</th>
                                    <th>Sub Menu L2</th>
                                </tr>
                            </table>
                        </div>
                        <div style="max-height: 320px; overflow-y: scroll">
                            <asp:Panel ID="PanelMainMenus" runat="server" ScrollBars="Auto">
                                <asp:GridView ID="gvMainMenu" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered gv-table gv-table-main" OnRowDataBound="gvMainMenu_RowDataBound" DataKeyNames="MenuCode,LinkUrl" ShowHeader="false">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Main Menu" ItemStyle-CssClass="check-test">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkMainMenu" runat="server" Text='<%#Eval("MenuName") %>' />
                                                <asp:HiddenField ID="hfMenuCode" runat="server" Value='<%#Eval("MenuCode") %>' />
                                                <asp:HiddenField ID="hfLinkUrl" runat="server" Value='<%#Eval("LinkUrl") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Panel ID="pnlSubMenuL1" runat="server">
                                                    <asp:GridView ID="gvSubMenuL1" runat="server" AutoGenerateColumns="false" CssClass="table  table-bordered gv-table  gv-table-sub-l1" OnRowDataBound="gvSubMenuL1_RowDataBound" DataKeyNames="SubMenuL1Code,LinkUrl" ShowHeader="false">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sub Menu L1">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkSubMenuL1" runat="server" Text='<%#Eval("SubMenuL1Name") %>' />
                                                                    <asp:HiddenField ID="hfSubMenuL1Code" runat="server" Value='<%#Eval("SubMenuL1Code") %>' />
                                                                    <asp:HiddenField ID="hfSubMenuL1LinkUrl" runat="server" Value='<%#Eval("LinkUrl") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="hfLinkUrl" Value='<%#Eval("LinkUrl") %>' runat="server" />
                                                                    <asp:Panel ID="pnlSubMenuL2" runat="server">
                                                                        <asp:GridView ID="gvSubMenuL2" runat="server" AutoGenerateColumns="false" CssClass="table  table-bordered gv-table gv-table-sub-l2" DataKeyNames="SubMenuL2Code,LinkUrl" ShowHeader="false">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Sub Menu L2">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chkSubMenuL2" runat="server" Text='<%#Eval("SubMenuL2Name") %>' />
                                                                                        <asp:HiddenField ID="hfSubMenuL2Code" runat="server" Value='<%#Eval("SubMenuL2Code") %>' />
                                                                                        <asp:HiddenField ID="hfSubMenuL2LinkUrl" runat="server" Value='<%#Eval("LinkUrl") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </asp:Panel>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField ItemStyle-Width="150px" Visible="false" DataField="LinkUrl" HeaderText="Link Url" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </asp:Panel>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-footer text-right">
                <span class="alertMsg" runat="server" visible="false" id="ErrorMsg"></span>
                <asp:Button ID="btnSave" Text="Save" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                <asp:Button ID="btnClear" Text="Clear" CssClass="btn btn-warning" runat="server" OnClick="btnClear_Click" />
                <asp:Button ID="btnExit" Text="Exit" CssClass="btn btn-danger" runat="server" OnClick="btnExit_Click" />
            </div>
        </div>
    </div>
</asp:Content>

