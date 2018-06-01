<%@ Page Title="" Language="C#" MasterPageFile="~/Legal/LegalMaster.master" AutoEventWireup="true" CodeFile="frmCaseMaster.aspx.cs" Inherits="frmCaseMaster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript" src="https://www.google.com/jsapi">
    </script>
    <script>
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

            control.makeTransliteratable(['<%=txt_caseTypeNmH.ClientID%>']);
        }
        google.setOnLoadCallback(onLoad);

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                    <h3 class="panel-title">Case Master</h3><asp:Label ID="lblcaseTypecode" runat="server"></asp:Label>
                    <!-- /.box-tools -->
                </div>
                <!-- /.box-header -->
                <div class="panel-body form-horizontal">
                    <div class="form-group">

                        <div class="col-xs-12">
                            <label class="control-label col-xs-12 col-sm-4 required">
                                Case Type Name English
                            </label>
                            <div class="col-xs-12 col-sm-8">
                                <asp:TextBox ID="txt_caseTypeNmE" runat="server" CssClass="form-control" MaxLength="60" placeholder="Case Type Name In English"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txt_caseTypeNmE" CssClass="errorMsg" Display="Dynamic" ValidationGroup="a" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Enter Name In English"></asp:RequiredFieldValidator>

                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_caseTypeNmE" FilterType="Custom,LowercaseLetters, UppercaseLetters" ValidChars=" " />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12 ">
                            <label class="control-label col-xs-12 col-sm-4 required">
                                Case Type Name Hindi
                            </label>
                            <div class="col-xs-12 col-sm-8">
                                <asp:TextBox ID="txt_caseTypeNmH" runat="server" CssClass="form-control" placeholder="Case Type Name In Hindi" MaxLength="120"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txt_caseTypeNmH" CssClass="errorMsg" ValidationGroup="a" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Enter Name In Hindi"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-footer">
                     <asp:Button ID="btnupdate" Text="Update" runat="server" ValidationGroup="a" OnClick="btnupdate_Click" CssClass="btn btn-success btnSave" />
                    <asp:Button ID="btnSave" Text="Save" runat="server" ValidationGroup="a" OnClick="btnSave_Click" CssClass="btn btn-success btnSave" />
                    <asp:Button ID="btnClear" Text="Clear" runat="server" OnClick="btnClear_Click" CssClass="btn btn-warning btnClear" />
                    <asp:Button ID="btnExit" runat="server" PostBackUrl="Dashboard.aspx" CssClass="btn btn-danger" Text="Exit" />
                    <div class="alertMsg success" runat="server" id="pnlSuccess"></div>
                    <div class="alertMsg failed" runat="server" id="pnlfailed"></div>
                </div>


                <div class="panel-body table table-responsive table-bordered" style="overflow-y:auto;height:200px" >
              <asp:GridView ID="gv_casemaster" runat="server" AutoGenerateColumns="False" OnRowCommand="gv_casemaster_RowCommand" DataKeyNames="CaseTypeCode" CssClass="table table-responsive table-bordered table-hover"  HeaderStyle-BackColor="#006699" HeaderStyle-ForeColor="white">
                <Columns>
                     <asp:TemplateField HeaderText="Sno.">
                                        <ItemTemplate>
                                            <%#(Container.DataItemIndex+1) %>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>

                    <asp:BoundField DataField="CaseTypeCode" Visible="false" HeaderText="CaseTypeCode" />
                     <asp:TemplateField HeaderText="Case Type Name English">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcaseTypeNmE" runat="server" Text=' <%# Eval("CaseTypeNmE") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Case Type Name Hindi">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcaseTypeNmH" runat="server" Text=' <%# Eval("CaseTypeNmH") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                    
                    
                                 
                     <asp:TemplateField HeaderText="Select">
                      <ItemTemplate>
                          <asp:LinkButton ID="lnk1" runat="server"  CommandArgument='<%#(Container.DataItemIndex)%>' CommandName="Select">Edit</asp:LinkButton>
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

