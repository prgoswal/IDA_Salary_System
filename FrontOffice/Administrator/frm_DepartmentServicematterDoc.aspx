<%@ Page Title="" Language="C#" MasterPageFile="~/FrontOffice/MainMaster.master" AutoEventWireup="true" CodeFile="frm_DepartmentServicematterDoc.aspx.cs" Inherits="Administrator_frm_DepartmentServicematterDoc" %>

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
            control.makeTransliteratable(['<%=txt_DeptNameHindi.ClientID%>']);
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
                            <h3 class="panel-title">Department Service Matter Document</h3>
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
                                        <asp:DropDownList ID="ddl_DeptName" runat="server" OnSelectedIndexChanged="ddl_DeptName_SelectedIndexChanged" AutoPostBack="true"
                                             CssClass="form-control" >
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator  ID="rfv1" CssClass="errorMsg" runat="server" ErrorMessage="Please select Department" ControlToValidate="ddl_DeptName" ValidationGroup="a" ForeColor="Red"
                                            InitialValue="0" Display="Dynamic"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                            </div>

                            <div class="form-group">


                                <div class="col-xs-12 ">
                                    <label class="control-label col-xs-12 col-sm-4 required">
                                        Services Name
                                    </label>
                                    <div class="col-xs-12 col-sm-8">

                                        <asp:DropDownList ID="ddl_ServiceName" runat="server" OnSelectedIndexChanged="ddl_ServiceName_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">
                                            <asp:ListItem Value="0">--Select Service Name--</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator CssClass="errorMsg" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select Service Name" ControlToValidate="ddl_ServiceName" ValidationGroup="a" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>

                                    </div>



                                </div>
                            </div>



                            <div class="form-group">



                                <div class="col-xs-12 ">
                                    <label class="control-label col-xs-12 col-sm-4 required">
                                        Matter Name
                                    </label>
                                    <div class="col-xs-12 col-sm-8">

                                        <asp:DropDownList ID="ddl_matterName" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="0">--Select Matter Name--</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator CssClass="errorMsg" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select Matter Name" ControlToValidate="ddl_matterName" ValidationGroup="a" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>

                                    </div>

                                </div>

                            </div>


                            <div class="form-group">
                                <div class="col-xs-12 ">
                                    <label class="control-label col-xs-12 col-sm-4 required">
                                        Document Name English
                                    </label>
                                    <div class="col-xs-12 col-sm-8">
                                        <asp:TextBox ID="txt_DeptNameEnglish" runat="server" CssClass="form-control" MaxLength="50" placeholder="Enter Department name In English"></asp:TextBox>
                                        <asp:RequiredFieldValidator CssClass="errorMsg" ID="rfv2" runat="server" ControlToValidate="txt_DeptNameEnglish" ValidationGroup="a" ErrorMessage="Required Document Name English" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_DeptNameEnglish" FilterType="Custom,LowercaseLetters, UppercaseLetters" ValidChars=" " />

                                    </div>
                                </div>
                            </div>



                            <div class="form-group">
                                <div class="col-xs-12 ">
                                    <label class="control-label col-xs-12 col-sm-4 required">
                                        Document Name Hindi
                                    </label>
                                    <div class="col-xs-12 col-sm-8">
                                        <asp:TextBox ID="txt_DeptNameHindi" runat="server" CssClass="form-control" MaxLength="50" placeholder="Enter Department name in Hindi"></asp:TextBox>
                                        <asp:RequiredFieldValidator CssClass="errorMsg" ID="rfv3" runat="server" ControlToValidate="txt_DeptNameHindi" ValidationGroup="a" ErrorMessage="Required Document Name Hindi" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>


                            <div class="form-group">
                                <div class="col-xs-12 ">
                                    <label class="control-label col-xs-12 col-sm-4">
                                        Remark1
                                    </label>
                                    <div class="col-xs-12 col-sm-8">
                                        <asp:TextBox ID="txt_remark1" runat="server" CssClass="form-control" MaxLength="100" placeholder="Enter Remark1"></asp:TextBox>


                                    </div>
                                </div>
                            </div>


                            <div class="form-group">
                                <div class="col-xs-12 ">
                                    <label class="control-label col-xs-12 col-sm-4">
                                        Remark2
                                    </label>
                                    <div class="col-xs-12 col-sm-8">
                                        <asp:TextBox ID="txt_remark2" runat="server" CssClass="form-control" MaxLength="100" placeholder="Enter Remark2"></asp:TextBox>


                                    </div>
                                </div>
                            </div>


                        </div>
                        <div class="panel-footer">
                            <asp:Button ID="btnSave" Text="Save" runat="server" ValidationGroup="a" OnClick="btnSave_Click" CssClass="btn btn-success btnSave" />
                            <asp:Button ID="btnClear" Text="Clear" runat="server" OnClick="btnClear_Click" CssClass="btn btn-default btnClear" />
                            <asp:Button ID="btnExit" runat="server" CssClass="btn btn-danger" Text="Exit" PostBackUrl="~/FrontOffice/Dashboard.aspx" />
                            <div class="alertMsg success" runat="server" id="pnlSuccess"></div>
                            <div class="alertMsg failed" runat="server" id="pnlfailed"></div>
                        </div>
                    </div>


                </div>
            </div>
        </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>

