<%@ Page Title="" Language="C#" MasterPageFile="~/FrontOffice/MainMaster.master" AutoEventWireup="true" CodeFile="frm_Designation.aspx.cs" Inherits="Administrator_frm_Designation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
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
            control.makeTransliteratable(['<%=txt_DesignationNameHindi.ClientID%>']);
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
                    <h3 class="panel-title">Designation Master</h3>
                    <!-- /.box-tools -->
                </div>
                <!-- /.box-header -->
                <div class="panel-body form-horizontal">
                    <div class="form-group">

                       
                        <div class="col-xs-12">
                            <label class="control-label col-xs-12 col-sm-4 required">
                                Designation Name English
                            </label>
                            <div class="col-xs-12 col-sm-8">
                                <asp:TextBox ID="txt_DesignationNameEng" runat="server" CssClass="form-control" MaxLength="20" placeholder="Enter Designation Name In English"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txt_DesignationNameEng" Display="Dynamic" CssClass="errorMsg"
                                    ValidationGroup="a" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Requried Designation Name English"></asp:RequiredFieldValidator>                                
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_DesignationNameEng" FilterType="Custom,LowercaseLetters, UppercaseLetters" ValidChars=" " />
                              
                            </div>
                              
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-xs-12 ">
                            <label class="control-label col-xs-12 col-sm-4 required">
                                Designation Name Hindi
                            </label>
                            <div class="col-xs-12 col-sm-8">

       <asp:TextBox ID="txt_DesignationNameHindi" runat="server" CssClass="form-control" MaxLength="20" placeholder="Enter Designation Name In Hindi"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txt_DesignationNameHindi" ValidationGroup="a" CssClass="errorMsg"
                                    ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Required Designation Name Hindi"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                    </div>
                </div>

                <div class="panel-footer">
                            <asp:Button ID="btnSave" Text="Save" runat="server" ValidationGroup="a" OnClick="btnSave_Click"  CssClass="btn btn-success btnSave" />
                            <asp:Button ID="btnClear" Text="Clear" runat="server"  CssClass="btn btn-default btnClear" OnClick="btnClear_Click" />
                            <asp:Button ID="btnExit" runat="server"  CssClass="btn btn-danger" Text="Exit"  />
                            <div class="alertMsg success" runat="server"  id="pnlSuccess"></div>
                            <div class="alertMsg failed" runat="server" id="pnlfailed"></div>
                </div>
            </div>


        </div>
    </div>
        </ContentTemplate>
        </asp:UpdatePanel>

</asp:Content>

