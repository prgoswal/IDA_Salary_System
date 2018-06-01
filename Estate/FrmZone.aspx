<%@ Page Title="" Language="C#" MasterPageFile="~/Estate/MainMaster.master" AutoEventWireup="true" CodeFile="FrmZone.aspx.cs" Inherits="frm_Zone" %>

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

            control.makeTransliteratable(['<%=txt_ZonenameH.ClientID%>']);
       }
       google.setOnLoadCallback(onLoad);

    </script>
    <script type="text/javascript">
        function ConfirmOnDelete(item) {
            if (confirm("Are you sure to delete: " + item + "?") == true)
                return true;
            else
                return false;
        }
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
        <div class="col-xs-12 col-sm-8 col-sm-offset-2">
            <div class="panel panel-primary mt10">
                <div class="panel-heading">
                    <h3 class="panel-title">Zone Master</h3>
                    <!-- /.box-tools -->
                </div>
                <!-- /.box-header -->
                <div class="panel-body form-horizontal">
                    <div class="form-group">

                        <div class="col-xs-12">
                            <label class="control-label col-xs-12 col-sm-4 required">
                                Zone Name English
                            </label>
                            <div class="col-xs-12 col-sm-8">
                                <asp:TextBox ID="txt_ZonenameE" runat="server" CssClass="form-control" MaxLength="50" placeholder="Enter Zone Name In English"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txt_ZonenameE" CssClass="errorMsg" Display="Dynamic" ValidationGroup="a" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Enter Zone Name English"></asp:RequiredFieldValidator>

                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_ZonenameE" FilterType="Custom,LowercaseLetters, UppercaseLetters" ValidChars=" " />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12 ">
                            <label class="control-label col-xs-12 col-sm-4 required">
                                Zone Name Hindi
                            </label>
                            <div class="col-xs-12 col-sm-8">
                                <asp:TextBox ID="txt_ZonenameH" runat="server" CssClass="form-control" placeholder="Enter Zone Name In Hindi" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txt_ZonenameH" CssClass="errorMsg" ValidationGroup="a" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Enter Zone Name Hindi"></asp:RequiredFieldValidator>
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
                <%--<div class="panel-footer table table-responsive table-bordered" style="overflow-y:auto;height:200px" >--%>
              <asp:GridView ID="gv_Zone" runat="server" AutoGenerateColumns="False" DataKeyNames="ZoneCode" CssClass="table table-responsive table-bordered table-hover" OnRowCommand="gv_Zone_RowCommand" HeaderStyle-BackColor="#006699" HeaderStyle-ForeColor="white">
                <Columns>
                    <asp:BoundField DataField="ZoneCode" HeaderText="Zone Code" />
                    <asp:BoundField DataField="CityCode" HeaderText="City Code" />
                    <asp:BoundField DataField="ZoneNameE" HeaderText="Zone Name English" />
                    <asp:BoundField DataField="ZoneNameH" HeaderText="Zone Name Hindi" />
                     <asp:TemplateField HeaderText="Action">
                      <ItemTemplate>
                       <asp:LinkButton ID="LinkButton1"  CommandArgument='<%# Eval("ZoneCode") %>' CommandName="DelRecord" runat="server">Delete</asp:LinkButton>
                     </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                   
            </asp:GridView>

                </div>
                    </div>
                   </div>
            </div>
        </div>
    </div>

      </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

