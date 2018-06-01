<%@ Page Title="" Language="C#" MasterPageFile="~/Estate/MainMaster.master" AutoEventWireup="true" CodeFile="FrmUseMaster.aspx.cs" Inherits="FrmMstUser" %>

<%--<%@ Register Src="~/UserControl/EntryLevel.ascx" TagName="UserControl" TagPrefix="cc1" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="https://www.google.com/jsapi">
    </script>
    <script>
        // Load the Google Transliterate API
        google.load("elements", "1", {
            packages: "transliteration"
        });

        function onLoad() {
            var options = {
                sourceLanguage:
                google.elements.transliteration.LanguageCode.ENGLISH,
                destinationLanguage:
                [google.elements.transliteration.LanguageCode.HINDI],
                shortcutKey: 'ctrl+g',
                transliterationEnabled: true
            };

            var control =
            new google.elements.transliteration.TransliterationControl(options);

            control.makeTransliteratable(['<%=txtSchemeUseH.ClientID%>']);
        }
        google.setOnLoadCallback(onLoad);

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scr" runat="server"></asp:ScriptManager>


     <asp:UpdatePanel ID="up1" runat="server">

        <ContentTemplate>
             <script type="text/javascript" lang="javascript">
                 Sys.Application.add_load(onLoad);
            </script>
    <div>
        <div class="col-xs-12 col-sm-8 col-sm-offset-2">
            <div class="panel panel-primary mt10">
                <div class="panel-heading">
                    <h3 class="panel-title">Add Use Type Master</h3>
                    <!-- /.box-tools -->
                </div>
                <!-- /.box-header -->
                <div class="panel-body form-horizontal">
                    <div class="form-group">


                        <div class="col-xs-12">
                            <label class="control-label col-xs-12 col-sm-4 required">
                                Scheme Use Type English.
                            </label>
                            <div class="col-xs-12 col-sm-8">
                                <asp:TextBox ID="txtSchemeUseE" runat="server" placeholder="Scheme Use Type English " CssClass=" form-control" MaxLength="30"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSchemeUseE" ErrorMessage="Enter Scheme Use English" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>

                                <%--  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_DevelopercatnameE" FilterType="Custom,LowercaseLetters, UppercaseLetters" ValidChars=" " />--%>
                            </div>

                        </div>

                    </div>
                    <div class="form-group">

                        <div class="col-xs-12 ">
                            <label class="control-label col-xs-12 col-sm-4 required">
                                Scheme Use Type Hindi
                            </label>
                            <div class="col-xs-12 col-sm-8">

                                <asp:TextBox ID="txtSchemeUseH" runat="server" placeholder="Scheme Use Type Hindi " CssClass=" form-control" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSchemeUseH" ErrorMessage="Enter Scheme Use Hindi" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>

                            </div>
                        </div>

                    </div>
                    <div class="form-group">

                        <div class="col-xs-12 ">
                            <label class="control-label col-xs-12 col-sm-4 required">
                                Scheme Use Type Short Name
                            </label>
                            <div class="col-xs-12 col-sm-8">

                                <asp:TextBox ID="txtSchemeUseSortName" runat="server" placeholder="Scheme Use Short Name " CssClass=" form-control" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="rq6" runat="server" ControlToValidate="txtSchemeUseSortName" ErrorMessage="Enter Scheme Use Short Name" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>

                            </div>
                        </div>

                    </div>
                </div>
                <div class="panel-footer">
                    <asp:Button ID="btnSave" Text="Save" runat="server" ValidationGroup="a" OnClick="btnSave_Click" CssClass="btn btn-success btnSave" />
                    <asp:Button ID="btnClear" Text="Clear" runat="server" OnClick="btnClear_Click" CssClass="btn btn-warning btnClear" />
                    <asp:Button ID="btnExit" runat="server" PostBackUrl="Dashboard.aspx" CssClass="btn btn-danger" Text="Exit" />
                    <div class="alertMsg success" runat="server" id="pnlSuccess"></div>
                    <div class="alertMsg failed" runat="server" id="pnlfailed"></div>
                </div>

                 <div class="panel-body">
                        <div class="col-xs-12">
                  <div style="max-height: 200px;overflow-y:scroll;">
                <%--<div class="panel-footer table table-responsive table-bordered" style="overflow-y: auto; height: 200px">--%>
                            <asp:GridView ID="grdUseType" CssClass="table table-responsive table-bordered table-hover" OnRowCommand="grdUseType_RowCommand" AutoGenerateColumns="false"  runat="server" HeaderStyle-BackColor="#006699" HeaderStyle-ForeColor="White">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. No.">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="UseCode" HeaderText="Use Code" />
                                    <asp:BoundField DataField="UseDescE" HeaderText="Use Desc Eng" />
                                    <asp:BoundField DataField="UseDescH" HeaderText="Use Desc Hindi" />
                                     <asp:BoundField DataField="UseShortName" HeaderText="Use Short Name" />
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="del" runat="server" CommandName="DelRecord" CommandArgument=' <%# Eval("UseCode") %>' Text="Delete"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>
                        </div></div>
                    </div>
            </div>
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

