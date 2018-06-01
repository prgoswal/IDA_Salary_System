<%@ Page Title="" Language="C#" MasterPageFile="~/Estate/MainMaster.master" AutoEventWireup="true" CodeFile="FrmSchOtherFacility.aspx.cs" Inherits="FrmSchOtherFacility" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<%@ Register Src="~/UserControl/EntryLevel.ascx" TagName="UserControl" TagPrefix="cc1" %>--%>
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

            control.makeTransliteratable(['<%=txtSchOthFacHindi.ClientID%>']);
        }
        google.setOnLoadCallback(onLoad);

    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scr" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
             <script type="text/javascript" lang="javascript">
                 Sys.Application.add_load(onLoad);
            </script>
            <div>
                <div class="col-xs-12 col-sm-8 col-sm-offset-2">
                    <div class="panel panel-primary mt10">
                        <div class="panel-heading">
                            <h3 class="panel-title">Scheme Other Facility Area Master</h3>
                            <!-- /.box-tools -->
                        </div>
                        <!-- /.box-header -->
                        <div class="panel-body form-horizontal">

                            <div class="form-group">
                                <div class="col-xs-12">
                                    <label class="control-label col-xs-12 col-sm-4 required">
                                        Scheme Other Facility Area English
                                    </label>
                                    <div class="col-xs-12 col-sm-8">
                                        <asp:TextBox ID="txtSchOthFacEnglish" runat="server" placeholder="Scheme Other Facility Area English " CssClass=" form-control" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSchOthFacEnglish" ErrorMessage="Enter Scheme Other Facility Area English" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                    </div>

                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-xs-12">
                                    <label class="control-label col-xs-12 col-sm-4 required">
                                        Scheme Other Facility Area Hindi
                                    </label>
                                    <div class="col-xs-12 col-sm-8">
                                        <asp:TextBox ID="txtSchOthFacHindi" runat="server" placeholder=" Scheme Other Facility Area Hindi" CssClass=" form-control" MaxLength="100"></asp:TextBox>
                                        <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSchOthFacHindi" ErrorMessage="Enter Scheme Other Facility Area Hindi" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>

                                        <%--  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_DevelopercatnameE" FilterType="Custom,LowercaseLetters, UppercaseLetters" ValidChars=" " />--%>
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
                       <%-- <div class="panel-footer table table-responsive table-bordered" style="overflow-y: auto; height: 200px">--%>                                                    
                            <asp:GridView ID="grdSchOtherFacility" CssClass="table table-responsive table-bordered table-hover" AutoGenerateColumns="false" OnRowCommand="grdSchOtherFacility_RowCommand" runat="server" HeaderStyle-BackColor="#006699" HeaderStyle-ForeColor="White">
                                <Columns>
                                    <asp:TemplateField HeaderText="SNo.">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="OtherfacilityInd" HeaderText="ID" />
                                    <asp:BoundField DataField="OtherfacilityDescE" HeaderText="Scheme Other Facility Eng" />
                                    <asp:BoundField DataField="OtherfacilityDescH" HeaderText="Scheme Other Facility Hindi" />
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="del" runat="server" CommandName="DelRecord" CommandArgument=' <%# Eval("OtherfacilityInd") %>' Text="Delete"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>
                        </div><
                            </div></div>

                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>


