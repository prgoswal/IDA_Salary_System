<%@ Page Title="" Language="C#" MasterPageFile="~/Estate/MainMaster.master" AutoEventWireup="true" CodeFile="FrmWard.aspx.cs" Inherits="frm_Ward" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
         
           control.makeTransliteratable(['<%=txt_WardNameH.ClientID%>']);
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
        <div class="col-xs-12 col-sm-8 col-sm-offset-2">
            <div class="panel panel-primary mt10">
                <div class="panel-heading">
                    <h3 class="panel-title">Ward Master</h3>
                    <!-- /.box-tools -->
                </div>
                <!-- /.box-header -->
                <div class="panel-body form-horizontal">
                    <div class="form-group">

                       
                        <div class="col-xs-12">
                            <label class="control-label col-xs-12 col-sm-4 required">
                                Ward Name English
                            </label>
                            <div class="col-xs-12 col-sm-8">
                                <asp:TextBox ID="txt_WardnameE" runat="server" CssClass="form-control" MaxLength="50" placeholder="Enter Ward Name In English"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txt_WardnameE" CssClass="errorMsg" Display="Dynamic" ValidationGroup="a" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Enter ward Name English"></asp:RequiredFieldValidator>

                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_WardnameE" FilterType="Custom,LowercaseLetters, UppercaseLetters" ValidChars=" " />
                            </div>
                              
                        </div>

                    </div>
                    <div class="form-group">

                       
                        <div class="col-xs-12 ">
                            <label class="control-label col-xs-12 col-sm-4 required">
                                Ward Name Hindi
                            </label>
                            <div class="col-xs-12 col-sm-8">

                                <asp:TextBox ID="txt_WardNameH" runat="server" CssClass="form-control" placeholder="Enter Ward Name In Hindi" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv2" runat="server" CssClass="errorMsg" ControlToValidate="txt_WardNameH" ValidationGroup="a" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Enter ward Name Hindi"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                               
                        
                    </div>
                </div>
                <div class="panel-footer">
                            <asp:Button ID="btnSave" Text="Save" runat="server" ValidationGroup="a" OnClick="btnSave_Click"  CssClass="btn btn-success btnSave" />
                            <asp:Button ID="btnClear" Text="Clear" runat="server" OnClick="btnClear_Click" CssClass="btn btn-warning btnClear" />
                            <asp:Button ID="btnExit" runat="server" PostBackUrl="Dashboard.aspx" CssClass="btn btn-danger" Text="Exit" />
                            <div class="alertMsg success" runat="server"  id="pnlSuccess"></div>
                            <div class="alertMsg failed" runat="server" id="pnlfailed"></div>
                </div>

                
                   <div class="panel-body">
                        <div class="col-xs-12">
                  <div style="max-height: 200px;overflow-y:scroll;">
                  <%--<div class="panel-footer table table-responsive table-bordered" style="overflow-y:auto;height:200px" >--%>
              <asp:GridView ID="dgv_Ward" runat="server" AutoGenerateColumns="False" DataKeyNames="WardCode" CssClass="table table-responsive table-bordered table-hover" OnRowCommand="dgv_Ward_RowCommand" HeaderStyle-BackColor="#006699" HeaderStyle-ForeColor="white">
                <Columns>
                    <asp:BoundField DataField="WardCode" HeaderText="Ward Code" />
                    <asp:BoundField DataField="WardNameE" HeaderText="Ward Name English" />
                    <asp:BoundField DataField="WardNameH" HeaderText="Ward Name Hindi" />
                    <asp:BoundField DataField="CityCode" HeaderText="City Code" />
                     <asp:TemplateField HeaderText="Action">
                      <ItemTemplate>
                       <asp:LinkButton ID="LinkButton1"  CommandArgument='<%# Eval("WardCode") %>' CommandName="DelRecord" runat="server">Delete</asp:LinkButton>
                     </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                   
            </asp:GridView>
</div>
                </div>


            </div>
        </div>
    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

