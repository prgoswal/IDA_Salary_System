<%@ Page Title="" Language="C#" MasterPageFile="~/FrontOffice/MainMaster.master" AutoEventWireup="true" CodeFile="frm_DepartmentServiceMatter.aspx.cs" Inherits="Administrator_frm_DepartmentServiceMatter" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">  
  
    <script>
        // put all your javascript functions here 
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
            control.makeTransliteratable(['<%=txt_MatterDescHindi.ClientID%>']);
        };
        google.setOnLoadCallback(onLoad);
        //

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(onLoad);
        

    </script>

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div>
                <div class="col-xs-12 col-sm-6 col-sm-offset-3">
                    <div class="panel panel-primary mt50">
                        <div class="panel-heading">
                            <h3 class="panel-title">Department Service Matter Master</h3>
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
                                        <asp:DropDownList ID="ddl_DeptName" runat="server" OnSelectedIndexChanged="ddl_DeptName_SelectedIndexChanged" AutoPostBack="true" class="service_txt browser-default select form-control inputs">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator CssClass="errorMsg" ID="rfv5" runat="server" ErrorMessage="Please select Department" ControlToValidate="ddl_DeptName" ValidationGroup="a" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-12 ">
                                    <label class="control-label col-xs-12 col-sm-4 required">
                                        Service Name
                                    </label>
                                    <div class="col-xs-12 col-sm-8">

                                        <asp:DropDownList ID="ddl_ServiceName" runat="server" class="service_txt browser-default select form-control inputs">
                                            <asp:ListItem Value="0">--Select Service Name--</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator CssClass="errorMsg" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select Service Name" ControlToValidate="ddl_ServiceName"
                                            ValidationGroup="a" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                            </div>


                            <div class="form-group">
                                <div class="col-xs-12 ">
                                    <label class="control-label col-xs-12 col-sm-4 required">
                                        Matter Desc English
                                    </label>
                                    <div class="col-xs-12 col-sm-8">
                                        <asp:TextBox ID="txt_MatterDescEnglish" runat="server" CssClass="form-control" MaxLength="50" placeholder="Enter matter Desc In English"></asp:TextBox>
                                        <asp:RequiredFieldValidator CssClass="errorMsg" ID="rfv1" runat="server" ControlToValidate="txt_MatterDescEnglish" ValidationGroup="a" ErrorMessage="Required Matter Desc English" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                            </div>



                            <div class="form-group">
                                <div class="col-xs-12 ">
                                    <label class="control-label col-xs-12 col-sm-4 required">
                                        Matter Desc Hindi
                                    </label>
                                    <div class="col-xs-12 col-sm-8">
                                        <asp:TextBox ID="txt_MatterDescHindi" runat="server" CssClass="form-control" MaxLength="50"
                                            placeholder="Enter Matter Desc in Hindi" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txt_MatterDescHindi" ValidationGroup="a" ErrorMessage="Required Matter Desc Hindi" Display="Dynamic" ForeColor="Red" CssClass="errorMsg"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                            </div>


                            <div class="form-group">
                                <div class="col-xs-12 ">
                                    <label class="control-label col-xs-12 col-sm-4">
                                        Matter Remark1
                                    </label>
                                    <div class="col-xs-12 col-sm-8">
                                        <asp:TextBox ID="txt_matterremark1" runat="server" CssClass="form-control" MaxLength="50" placeholder="Enter matter Remark1"></asp:TextBox>


                                    </div>
                                </div>
                            </div>


                            <div class="form-group">
                                <div class="col-xs-12 ">
                                    <label class="control-label col-xs-12 col-sm-4">
                                        Matter Remark2
                                    </label>
                                    <div class="col-xs-12 col-sm-8">
                                        <asp:TextBox ID="txt_Matterremark2" runat="server" CssClass="form-control" MaxLength="100" placeholder="Enter matter Remark2"></asp:TextBox>


                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="panel-footer">
                            <asp:Button ID="btnSave" Text="Save" runat="server" ValidationGroup="a" OnClick="btnSave_Click" CssClass="btn btn-success btnSave" />
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

