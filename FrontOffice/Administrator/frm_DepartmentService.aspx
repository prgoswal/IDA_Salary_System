<%@ Page Title="" Language="C#" MasterPageFile="~/FrontOffice/MainMaster.master" AutoEventWireup="true" CodeFile="frm_DepartmentService.aspx.cs" Inherits="Administrator_frm_DepartmentService" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   
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
            control.makeTransliteratable(['<%=txt_ServiceDescHindi.ClientID%>']);
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
                            <h3 class="panel-title">Department Service Master</h3>
                            <!-- /.box-tools -->
                        </div>
                        <!-- /.box-header -->
                        <div class="panel-body form-horizontal scheme-form-group">
                            <div class="form-group">
                                <div class="col-xs-12">
                                    <label class="control-label col-xs-12 col-sm-4 required">
                                        Department Name
                                    </label>
                                    <div class="col-xs-12 col-sm-8">

                                        <asp:DropDownList ID="ddl_DeptName" runat="server" class="service_txt browser-default select form-control inputs">
                                            <asp:ListItem Value="0">--Select Department--</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator CssClass="errorMsg" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select Department" ControlToValidate="ddl_DeptName" ValidationGroup="a" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-12 ">
                                    <label class="control-label col-xs-12 col-sm-4 required">
                                        Services Desc English
                                    </label>
                                    <div class="col-xs-12 col-sm-8">

                                        <asp:TextBox ID="txt_ServiceDescEnglish" runat="server" MaxLength="50" placeholder="Enter Service Description in English" 
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator CssClass="errorMsg" ID="rfv1" runat="server" ControlToValidate="txt_ServiceDescEnglish" ValidationGroup="a" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" 
                                            ErrorMessage="Requried Service Description English"></asp:RequiredFieldValidator>
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_ServiceDescEnglish" FilterType="Custom,LowercaseLetters, UppercaseLetters" ValidChars=" " />


                                    </div>
                                </div>
                            </div>


                            <div class="form-group">
                                <div class="col-xs-12 ">
                                    <label class="control-label col-xs-12 col-sm-4 required">
                                        Services Desc Hindi
                                    </label>
                                    <div class="col-xs-12 col-sm-8">

                                        <asp:TextBox ID="txt_ServiceDescHindi" runat="server" CssClass="form-control" MaxLength="50" placeholder="Enter Service Description in Hindi"></asp:TextBox>

                                        <asp:RequiredFieldValidator CssClass="errorMsg" ID="rfv2" runat="server" ControlToValidate="txt_ServiceDescHindi" ValidationGroup="a" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Requried Service Description Hindi"></asp:RequiredFieldValidator>



                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-xs-12 ">
                                    <label class="control-label col-xs-12 col-sm-4">
                                        Services Remark1
                                    </label>
                                    <div class="col-xs-12 col-sm-8">

                                        <asp:TextBox ID="txt_ServiceRemark1" runat="server" CssClass="form-control" MaxLength="50" placeholder="Enter Service Remark1"></asp:TextBox>



                                    </div>
                                </div>
                            </div>


                            <div class="form-group">
                                <div class="col-xs-12 ">
                                    <label class="control-label col-xs-12 col-sm-4">
                                        Services Remark2
                                    </label>
                                    <div class="col-xs-12 col-sm-8">

                                        <asp:TextBox ID="txt_ServiceRemark2" runat="server" CssClass="form-control" MaxLength="50" placeholder="Enter Service Remark2"></asp:TextBox>



                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="panel-footer">
                            <asp:Button ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" ValidationGroup="a" CssClass="btn btn-success btnSave" />
                            <asp:Button ID="btnClear" Text="Clear" runat="server" OnClick="btnClear_Click" CssClass="btn btn-default btnClear" />
                            <asp:Button ID="btnExit" runat="server" PostBackUrl="~/FrontOffice/Dashboard.aspx" CssClass="btn btn-danger" Text="Exit" />
                            <div class="alertMsg success" runat="server" id="pnlSuccess"></div>
                            <div class="alertMsg failed" runat="server" id="pnlfailed"></div>




                        </div>
                    </div>


                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

