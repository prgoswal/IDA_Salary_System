<%@ Page Title="" Language="C#" MasterPageFile="~/Estate/MainMaster.master" AutoEventWireup="true" CodeFile="FrmDeveloper.aspx.cs" Inherits="FrmDeveloper" %>

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

            control.makeTransliteratable(['<%=txtDevDescH.ClientID%>']);
        }
        google.setOnLoadCallback(onLoad);

    </script>

    <script type="text/javascript">
               function userValid() {
            debugger
            var DevCate = document.getElementById("<%=ddlDevCate.ClientID %>");
            if (DevCate.value == 'Select Developer Category' || DevCate.value == '') {               
                alert("Please Select Developer Category!");
                return false;
            }           
        }

   </script>     

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scr" runat="server"></asp:ScriptManager>

    <div>
        <div class="col-xs-12 col-sm-8 col-sm-offset-2">
            <div class="panel panel-primary mt10">
                <div class="panel-heading">
                    <h3 class="panel-title">Developer Master</h3>
                    <!-- /.box-tools -->
                </div>
                <!-- /.box-header -->
                <div class="panel-body form-horizontal">

                    <div class="form-group">
                        <div class="col-xs-12">
                            <label class="control-label col-xs-12 col-sm-4 required">
                                Select Developer Category
                            </label>
                            <div class="col-xs-12 col-sm-8">
                                <asp:DropDownList ID="ddlDevCate" runat="server" CssClass="form-control"></asp:DropDownList>
                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_DevelopercatnameE" Display="Dynamic" ValidationGroup="a" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Requried Developer Category Name English"></asp:RequiredFieldValidator>

                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt_DevelopercatnameE" FilterType="Custom,LowercaseLetters, UppercaseLetters" ValidChars=" " />--%>
                                  <asp:CompareValidator CssClass="errorMsg" ForeColor="Red" SetFocusOnError="true" ErrorMessage=" Select Developer Category" runat="server" ID="comparevalidator1" ValidationGroup="a" ControlToValidate="ddlDevCate" ValueToCompare="Select Developer Category" Operator="NotEqual"></asp:CompareValidator>
                            </div>

                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-xs-12">
                            <label class="control-label col-xs-12 col-sm-4 required">
                                Developer Description English.
                            </label>
                            <div class="col-xs-12 col-sm-8">
                                <asp:TextBox ID="txtDevDescE" runat="server" placeholder="Developer Description English " CssClass=" form-control" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDevDescE" ErrorMessage="Enter Developer Description English" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>

                                <%--  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_DevelopercatnameE" FilterType="Custom,LowercaseLetters, UppercaseLetters" ValidChars=" " />--%>
                            </div>

                        </div>
                    </div>
                    <div class="form-group">

                        <div class="col-xs-12 ">
                            <label class="control-label col-xs-12 col-sm-4 required">
                                Developer Description Hindi
                            </label>
                            <div class="col-xs-12 col-sm-8">
                                <asp:TextBox ID="txtDevDescH" runat="server" onblur="onLoad()" placeholder="Developer Description Hindi " CssClass="form-control" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator SetFocusOnError="true" CssClass="errorMsg" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDevDescH" ErrorMessage="Enter Developer Description Hindi" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="panel-footer">
                    <asp:Button ID="btnSave" Text="Save" runat="server"  ValidationGroup="a" OnClick="btnSave_Click" CssClass="btn btn-success btnSave" />
                    <asp:Button ID="btnClear" Text="Clear" runat="server" OnClick="btnClear_Click" CssClass="btn btn-warning btnClear" />
                    <asp:Button ID="btnExit" runat="server" PostBackUrl="Dashboard.aspx" CssClass="btn btn-danger" Text="Exit" />
                    <div class="alertMsg success" runat="server" id="pnlSuccess"></div>
                    <div class="alertMsg failed" runat="server" id="pnlfailed"></div>
                </div>

                   <div class="panel-body">
                        <div class="col-xs-12">
                  <div style="max-height: 200px;overflow-y:scroll;">
                   <%--<div class="panel-footer table table-responsive table-bordered" style="overflow-y: auto; height: 200px">--%>
                            <asp:GridView ID="grdDeveloper" CssClass="table table-responsive table-bordered table-hover" AutoGenerateColumns="false" OnRowCommand="grdDeveloper_RowCommand" runat="server" HeaderStyle-BackColor="#006699" HeaderStyle-ForeColor="White">
                                <Columns>
                                    <asp:TemplateField HeaderText="SNo.">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="DeveloperCode" HeaderText="Dev Code" />
                                    <asp:BoundField DataField="DeveloperDescE" HeaderText="Developer Desc Eng" />
                                    <asp:BoundField DataField="DeveloperDescH" HeaderText="Developer Desc Hindi" />
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="del" runat="server" CommandName="DelRecord" CommandArgument=' <%# Eval("DeveloperCode") %>' Text="Delete"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>
                        </div>
                     </div></div>
            </div>
        </div>
    </div>

</asp:Content>


