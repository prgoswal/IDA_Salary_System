<%@ Page Title="" Language="C#" MasterPageFile="~/FrontOffice/MainMaster.master" AutoEventWireup="true" CodeFile="frm_Department.aspx.cs" Inherits="Administrator_department" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 
    <link href="../css/Loader.css" rel="stylesheet" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
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

            // Create an instance on TransliterationControl with the required
            // options.
            var control =
            new google.elements.transliteration.TransliterationControl(options);

            // Enable transliteration in the textbox with id
            // 'transliterateTextarea'.
            control.makeTransliteratable(['<%=txt_DepartmentNameHindi.ClientID%>']);
            
        }
        google.setOnLoadCallback(onLoad);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(onLoad);

    </script>    
    
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div>
                <div class="col-xs-12 col-sm-6 col-sm-offset-3">
                    <div class="panel panel-primary mt50">
                        <div class="panel-heading">
                            <h3 class="panel-title">Department Master</h3>
                            <!-- /.box-tools -->
                        </div>
                        <!-- /.box-header -->
                        <div class="panel-body form-horizontal">
                            <div class="form-group">


                                <div class="col-xs-12">
                                    <label class="control-label col-xs-12 col-sm-4 required">
                                        Department Name English
                                    </label>
                                    <div class="col-xs-12 col-sm-8">
                                        <asp:TextBox ID="txt_DepartmentNameEnglish" runat="server" CssClass="form-control" MaxLength="30" 
                                            placeholder="Enter Department Name In English" TabIndex="1"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txt_DepartmentNameEnglish" Display="Dynamic" ValidationGroup="a"
                                            ForeColor="Red" SetFocusOnError="true" ErrorMessage="Requried Department Name English" CssClass="errorMsg"></asp:RequiredFieldValidator>
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_DepartmentNameEnglish" FilterType="Custom,LowercaseLetters, UppercaseLetters"
                                             ValidChars=" " />
                                    </div>

                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-12 ">
                                    <label class="control-label col-xs-12 col-sm-4 required">
                                        Department Name Hindi
                                    </label>
                                    <div class="col-xs-12 col-sm-8">

                                        <asp:TextBox ID="txt_DepartmentNameHindi" runat="server" CssClass="form-control" placeholder="Enter Department Name in Hindi" 
                                            MaxLength="50" TabIndex="2" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfv2" CssClass="errorMsg" runat="server" ControlToValidate="txt_DepartmentNameHindi" ValidationGroup="a" 
                                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Required Department Name Hindi"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                           <%-- OnClientClick="return ProgressBar();"--%>
                            <asp:Button ID="btnSave" Text="Save" runat="server"  ValidationGroup="a" OnClick="btnSave_Click" CssClass="btn btn-success btnSave" TabIndex="3"/>
                            <asp:Button ID="btnClear" Text="Clear" runat="server" OnClick="btnClear_Click" CssClass="btn btn-default btnClear" TabIndex="4" />
                            <asp:Button ID="btnExit" runat="server" PostBackUrl="~/FrontOffice/Dashboard.aspx" CssClass="btn btn-danger" Text="Exit" TabIndex="5" />
                            <div class="alertMsg success" runat="server" id="pnlSuccess"></div>
                            <div class="alertMsg failed" runat="server" id="pnlfailed"></div>
                        </div>
                    </div>


                </div>
            </div>         
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

