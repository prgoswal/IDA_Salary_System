<%@ Page Title="" Language="C#" MasterPageFile="~/Estate/MainMaster.master" AutoEventWireup="true" CodeFile="frmPlotSituation.aspx.cs" Inherits="frmPlotSituation" %>

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

           control.makeTransliteratable(['<%=txtPlotSituaH.ClientID%>']);
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
   
        <div class="col-xs-12 col-sm-6 col-sm-offset-3">
            <div class="panel panel-primary mt10">
                <div class="panel-heading">
                    <h3 class="panel-title">Plot Situation Type Master</h3>
                    <!-- /.box-tools -->
                </div>
                <!-- /.box-header -->
                <div class="panel-body form-horizontal">
                    <div class="form-group">

                       
                        <div class="col-xs-12">
                            <label class="control-label col-xs-12 col-sm-4 required">
                                Plot Situation Type English
                            </label>
                            <div class="col-xs-12 col-sm-8">
                                <asp:TextBox ID="txtPlotSituaE" runat="server" CssClass="form-control" MaxLength="50" placeholder="Plot Situation Type English"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtPlotSituaE" Display="Dynamic" ValidationGroup="a" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Enter Plot Situation Type English"></asp:RequiredFieldValidator>
                             
                            </div>
                              
                        </div>

                    </div>
                    <div class="form-group">
                       
                        <div class="col-xs-12 ">
                            <label class="control-label col-xs-12 col-sm-4 required">
                               Plot Situation Type Hindi
                            </label>
                            <div class="col-xs-12 col-sm-8">

                                <asp:TextBox ID="txtPlotSituaH" runat="server" CssClass="form-control" placeholder="Plot Situation Type Hindi" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txtPlotSituaH" ValidationGroup="a" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Enter Plot Situation Type Hindi"></asp:RequiredFieldValidator>

                            </div>
                        </div
                        
                    </div>
                </div>
                <div class="panel-footer">
                            <asp:Button ID="btnSave" Text="Save" runat="server" ValidationGroup="a" OnClick="btnSave_Click"  CssClass="btn btn-success btnSave" />
                            <asp:Button ID="btnClear" Text="Clear" runat="server" OnClick="btnClear_Click" CssClass="btn btn-warning btnClear" />
                            <asp:Button ID="btnExit" runat="server" PostBackUrl="Dashboard.aspx" CssClass="btn btn-danger" Text="Exit" />
                            <div class="alertMsg success" runat="server"  id="pnlSuccess"></div>
                            <div class="alertMsg failed" runat="server" id="pnlfailed"></div>
                </div>
            </div>
        </div>
   
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>


