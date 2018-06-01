<%@ Page Title="" Language="C#" MasterPageFile="~/FrontOffice/MainMaster.master" AutoEventWireup="true" CodeFile="frm_DepartmentEmployee.aspx.cs" Inherits="Administrator_frm_DepartmentEmployee" %>

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
            control.makeTransliteratable(['<%=txt_EmployeenameHindi.ClientID%>']);
        }
        google.setOnLoadCallback(onLoad);

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(onLoad);
    </script>

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div>
                <div class="col-xs-12 col-sm-6 col-sm-offset-3">
                    <div class="panel panel-primary ">
                        <div class="panel-heading">
                            <h3 class="panel-title">Department Employee Master</h3>
                            <!-- /.box-tools -->
                        </div>
                        <!-- /.box-header -->
                        <div class="panel-body form-horizontal scheme-form-group">
                            <div class="form-group">
                                <div class="col-xs-12">
                                    <label class="control-label col-xs-12 col-sm-5 required">
                                        Employee Name English
                                    </label>
                                    <div class="col-xs-12 col-sm-7">
                                        <asp:TextBox ID="txt_EmployeeNameEng" runat="server" CssClass="form-control" MaxLength="40" placeholder="Enter Employee Name In English"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txt_EmployeeNameEng" Display="Dynamic" ValidationGroup="a"
                                            ForeColor="Red" SetFocusOnError="true" ErrorMessage="Requried Employee Name English" CssClass="errorMsg"></asp:RequiredFieldValidator>

                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_EmployeeNameEng" FilterType="Custom,LowercaseLetters, UppercaseLetters" ValidChars=" " />

                                    </div>

                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-xs-12 ">
                                    <label class="control-label col-xs-12 col-sm-5 required">
                                        Employee Name Hindi
                                    </label>
                                    <div class="col-xs-12 col-sm-7">

                                        <asp:TextBox ID="txt_EmployeenameHindi" runat="server" CssClass="form-control" MaxLength="50" placeholder="Enter Employee Name In Hindi"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txt_EmployeenameHindi" ValidationGroup="a" ForeColor="Red"
                                            Display="Dynamic" SetFocusOnError="true" ErrorMessage="Required Employee Name Hindi" CssClass="errorMsg"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                            </div>


                            <div class="form-group">
                                <div class="col-xs-12 ">
                                    <label class="control-label col-xs-12 col-sm-5 required">
                                        Department Name 
                                    </label>
                                    <div class="col-xs-12 col-sm-7">

                                        <asp:DropDownList ID="ddl_DepartmentName" runat="server" CssClass="form-control"></asp:DropDownList>
                                        <asp:RequiredFieldValidator CssClass="errorMsg" ID="rfv5" runat="server" ErrorMessage="Please select Department" ControlToValidate="ddl_DepartmentName" ValidationGroup="a" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                            </div>


                            <div class="form-group">
                                <div class="col-xs-12 ">
                                    <label class="control-label col-xs-12 col-sm-5">
                                        Is Employee Is Department Head
                                    </label>
                                    <div class="col-xs-12 col-sm-7">
                                        <div class="radio-button-container">
                                            <asp:RadioButtonList ID="Rdb_EmpDepHaed" RepeatDirection="Horizontal" runat="server">
                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>


                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-xs-12 ">
                                    <label class="control-label col-xs-12 col-sm-5 required">
                                        Employee Level
                                    </label>
                                    <div class="col-xs-12 col-sm-7">

                                        <asp:DropDownList ID="ddl_EmpLevel" runat="server" CssClass="form-control"></asp:DropDownList>
                                        <asp:RequiredFieldValidator CssClass="errorMsg" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select Employee Level" ControlToValidate="ddl_EmpLevel" ValidationGroup="a" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                            </div>


                            <div class="form-group">
                                <div class="col-xs-12 ">
                                    <label class="control-label col-xs-12 col-sm-5 required">
                                        Employee MobileNo
                                    </label>
                                    <div class="col-xs-12 col-sm-7">

                                        <asp:TextBox ID="txt_EmpMobNo" runat="server" CssClass="form-control" MaxLength="10" MinLength="10" placeholder="Enter Employee MobileNo"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_EmpMobNo" ValidationGroup="a" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Required Employee MobileNo" CssClass="errorMsg"></asp:RequiredFieldValidator>

                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt_EmpMobNo" FilterType="Numbers" ValidChars=" " />

                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-xs-12 ">
                                    <label class="control-label col-xs-12 col-sm-5 required">
                                        Employee Email
                                    </label>
                                    <div class="col-xs-12 col-sm-7">

                                        <asp:TextBox ID="txt_EmpEmail" runat="server" CssClass="form-control" MaxLength="35" placeholder="Enter Employee Email"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_EmpEmail" ValidationGroup="a" ForeColor="Red"
                                            Display="Dynamic" SetFocusOnError="true" ErrorMessage="Required Employee Email" CssClass="errorMsg"></asp:RequiredFieldValidator>

                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Valid Employee Email" ControlToValidate="txt_EmpEmail"
                                            Display="Dynamic" ForeColor="red" SetFocusOnError="True" CssClass="errorMsg" ValidationGroup="a"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                                    </div>
                                </div>
                            </div>


                            <div class="form-group">
                                <div class="col-xs-12 ">
                                    <label class="control-label col-xs-12 col-sm-5 required">
                                        Employee Designation
                                    </label>
                                    <div class="col-xs-12 col-sm-7">

                                        <asp:DropDownList ID="ddl_EmpDesignation" runat="server" CssClass="form-control"></asp:DropDownList>
                                        <asp:RequiredFieldValidator CssClass="errorMsg" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please select Employee Designation" ControlToValidate="ddl_EmpDesignation" ValidationGroup="a" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>

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

