<%@ Page Title="" Language="C#" MasterPageFile="~/Legal/LegalMaster.master" AutoEventWireup="true" CodeFile="FrmReplyType.aspx.cs" Inherits="FrmReplyType" %>

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

            control.makeTransliteratable(['<%=txt_ReplyTypeH.ClientID%>']);
        }
        google.setOnLoadCallback(onLoad);

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scr1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <script type="text/javascript" lang="javascript">
                Sys.Application.add_load(onLoad);
            </script>
            <div>
                <div class="col-xs-12 col-sm-6 col-sm-offset-3">
                    <div class="panel panel-primary mt50">
                        <div class="panel-heading">
                            <h3 class="panel-title">Case Reply Master</h3>
                            <!-- /.box-tools -->
                        </div>
                        <!-- /.box-header -->
                        <div class="panel-body form-horizontal">
                            <div class="form-group">


                                <div class="col-xs-12">
                                    <label class="control-label col-xs-12 col-sm-4 required">
                                      case Reply Type English
                                    </label>
                                    <div class="col-xs-12 col-sm-8">
                                        <asp:TextBox ID="txt_ReplyTypeE" runat="server" CssClass="form-control" MaxLength="50" placeholder="Enter Reply Type In English"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txt_ReplyTypeE" CssClass="errorMsg" Display="Dynamic" ValidationGroup="a" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Enter Reply Type English"></asp:RequiredFieldValidator>

                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_ReplyTypeE" FilterType="Custom,LowercaseLetters, UppercaseLetters" ValidChars=" " />
                                    </div>

                                </div>

                            </div>
                            <div class="form-group">

                                <div class="col-xs-12 ">
                                    <label class="control-label col-xs-12 col-sm-4 required">
                                       case Reply Type Hindi
                                    </label>
                                    <div class="col-xs-12 col-sm-8">

                                        <asp:TextBox ID="txt_ReplyTypeH" runat="server" CssClass="form-control" placeholder="Enter Reply Type in Hindi" MaxLength="100"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txt_ReplyTypeH" CssClass="errorMsg" ValidationGroup="a" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Enter Reply Type Hindi"></asp:RequiredFieldValidator>

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


                        <div class="panel-body table table-responsive table-bordered" style="overflow-y: auto; height: 200px">
                            <asp:GridView ID="GridReplyType" runat="server" AutoGenerateColumns="False" DataKeyNames="ReplyTypeCode" OnRowCommand="GridReplyType_RowCommand" CssClass="table table-responsive table-bordered table-hover" HeaderStyle-BackColor="#006699" HeaderStyle-ForeColor="white">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sno.">
                                        <ItemTemplate>
                                            <%#(Container.DataItemIndex+1) %>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                 
                                    <asp:BoundField Visible="false" DataField="ReplyTypeCode" HeaderText="ReplyTypeCode" />
                                  
                                    <asp:TemplateField HeaderText="Case Reply Type English">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReplyTypeDescE" runat="server" Text=' <%# Eval("ReplyTypeDescE") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Case Reply Type Hindi">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReplyTypeDescH" runat="server" Text=' <%# Eval("ReplyTypeDescH") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField Visible="false" HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("ReplyTypeCode") %>' CommandName="DelRecord" runat="server">Delete</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkBtnEdit" CommandArgument='<%#(Container.DataItemIndex)%>' CommandName="EditRecord" runat="server">Edit</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>
                        </div>


                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>



